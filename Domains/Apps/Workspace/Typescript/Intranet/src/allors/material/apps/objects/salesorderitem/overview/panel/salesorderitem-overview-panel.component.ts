import { Component, Self, HostBinding } from '@angular/core';
import { PanelService, NavigationService, RefreshService, ErrorService, Action, MetaService, ContextService } from '../../../../../../angular';
import { SalesOrderItem, SalesOrder } from '../../../../../../domain';
import { Meta } from '../../../../../../meta';
import { DeleteService, TableRow, Table, EditService, MethodService } from '../../../../..';
import * as moment from 'moment';

import { MatSnackBar } from '@angular/material';

import { CreateData, ObjectService } from '../../../../../../material/base/services/object';

interface Row extends TableRow {
  object: SalesOrderItem;
  item: string;
  type: string;
  status: string;
  ordered: number;
  shipped: number;
  picked: number;
  reserved: number;
  short: number;
  returned: number;
  lastModifiedDate: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'salesorderitem-overview-panel',
  templateUrl: './salesorderitem-overview-panel.component.html',
  providers: [ContextService, PanelService]
})
export class SalesOrderItemOverviewPanelComponent {

  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: Meta;

  order: SalesOrder;
  salesOrderItems: SalesOrderItem[];
  table: Table<Row>;

  delete: Action;
  edit: Action;
  cancel: Action;
  reject: Action;
  confirm: Action;
  approve: Action;
  continue: Action;

  get createData(): CreateData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
      associationRoleType: this.metaService.m.SalesOrder.SalesOrderItems,
    };
  }

  constructor(
    @Self() public allors: ContextService,
    @Self() public panel: PanelService,
    public objectService: ObjectService,
    public metaService: MetaService,
    public refreshService: RefreshService,
    public navigation: NavigationService,
    public errorService: ErrorService,
    public methodService: MethodService,
    public deleteService: DeleteService,
    public editService: EditService,
    public snackBar: MatSnackBar
  ) {

    this.m = this.metaService.m;

    panel.name = 'salesordertitem';
    panel.title = 'Sales Order Items';
    panel.icon = 'contacts';
    panel.expandable = true;

    this.delete = deleteService.delete(panel.manager.context);
    this.edit = editService.edit();
    this.cancel = methodService.create(allors.context, this.m.SalesOrderItem.Cancel, { name: 'Cancel' });
    this.reject = methodService.create(allors.context, this.m.SalesOrderItem.Reject, { name: 'Reject' });
    this.confirm = methodService.create(allors.context, this.m.SalesOrderItem.Confirm, { name: 'Confirm' });
    this.approve = methodService.create(allors.context, this.m.SalesOrderItem.Approve, { name: 'Approve' });
    this.continue = methodService.create(allors.context, this.m.SalesOrderItem.Continue, { name: 'Continue' });

    const sort = true;
    this.table = new Table({
      selection: true,
      columns: [
        { name: 'item', sort },
        { name: 'type', sort },
        { name: 'state', sort },
        { name: 'ordered', sort },
        { name: 'shipped', sort },
        { name: 'picked', sort },
        { name: 'reserved', sort },
        { name: 'short', sort },
        { name: 'returned', sort },
        { name: 'lastModifiedDate', sort },
      ],
      actions: [
        this.edit,
        this.delete,
        this.cancel,
        this.reject,
        this.confirm,
        this.approve,
        this.continue,
      ],
      defaultAction: this.edit,
      autoSort: true,
      autoFilter: true,
    });

    const pullName = `${panel.name}_${this.m.SalesOrderItem.name}`;
    const orderPullName = `${panel.name}_${this.m.SalesOrder.name}`;

    panel.onPull = (pulls) => {
      const { pull, x } = this.metaService;

      const id = this.panel.manager.id;

      pulls.push(
        pull.SalesOrder({
          name: pullName,
          object: id,
          fetch: {
            SalesOrderItems: {
              include: {
                InvoiceItemType: x,
                SalesOrderItemState: x,
                Product: x,
                SerialisedItem: x,
              }
            }
          }
        }),
        pull.SalesOrder({
          name: orderPullName,
          object: id
        }),
      );
    };

    panel.onPulled = (loaded) => {

      this.salesOrderItems = loaded.collections[pullName] as SalesOrderItem[];
      this.order = loaded.objects[orderPullName] as SalesOrder;
      this.table.total = loaded.values[`${pullName}_total`] || this.salesOrderItems.length;
      this.table.data = this.salesOrderItems.map((v) => {
        return {
          object: v,
          item: (v.Product && v.Product.Name) || (v.SerialisedItem && v.SerialisedItem.Name) || '',
          type: `${v.InvoiceItemType && v.InvoiceItemType.Name}`,
          status: `${v.SalesOrderItemState && v.SalesOrderItemState.Name}`,
          ordered: v.QuantityOrdered,
          shipped: v.QuantityShipped,
          picked: v.QuantityPicked,
          reserved: v.QuantityReserved,
          short: v.QuantityShortFalled,
          returned: v.QuantityReturned,
          lastModifiedDate: moment(v.LastModifiedDate).fromNow()
        } as Row;
      });
    };
  }
}
