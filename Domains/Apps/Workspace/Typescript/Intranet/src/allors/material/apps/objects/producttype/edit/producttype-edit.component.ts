import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { Subscription, combineLatest } from 'rxjs';

import { ErrorService, Saved, ContextService, MetaService, RefreshService } from '../../../../../angular';
import { ProductType, SerialisedItemCharacteristicType } from '../../../../../domain';
import { PullRequest, Sort } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { switchMap, map } from 'rxjs/operators';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { CreateData, EditData, ObjectData } from 'src/allors/material/base/services/object';
import { StateService } from '../../../services/state';

@Component({
  templateUrl: './producttype-edit.component.html',
  providers: [ContextService]
})
export class ProductTypeEditComponent implements OnInit, OnDestroy {

  public title: string;
  public subTitle: string;

  public m: Meta;

  public productType: ProductType;

  public characteristics: SerialisedItemCharacteristicType[];

  private subscription: Subscription;

  constructor(
    @Self() private allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: CreateData & EditData,
    public dialogRef: MatDialogRef<ProductTypeEditComponent>,
    public metaService: MetaService,
    public refreshService: RefreshService,
    private errorService: ErrorService,
    private stateService: StateService) {

    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    const { m, pull, x } = this.metaService;

    this.subscription = combineLatest(this.refreshService.refresh$)
      .pipe(
        switchMap(([]) => {

          const isCreate = (this.data as EditData).id === undefined;

          const pulls = [
            pull.ProductType({
              object: this.data.id,
              include: {
                SerialisedItemCharacteristicTypes: x,
              }
            }),
            pull.SerialisedItemCharacteristicType({
              sort: new Sort(m.SerialisedItemCharacteristicType.Name),
            })
          ];

          return this.allors.context
            .load('Pull', new PullRequest({ pulls }))
            .pipe(
              map((loaded) => ({ loaded, isCreate }))
            );
        })
      )
      .subscribe(({ loaded, isCreate }) => {

        this.allors.context.reset();

        this.characteristics = loaded.collections.SerialisedItemCharacteristicTypes as SerialisedItemCharacteristicType[];

        if (isCreate) {
          this.title = 'Add Product Type';
          this.productType = this.allors.context.create('ProductType') as ProductType;
        } else {
          this.productType = loaded.objects.ProductType as ProductType;

          if (this.productType.CanWriteName) {
            this.title = 'Edit Product Type';
          } else {
            this.title = 'View Product Type';
          }
        }
      }, this.errorService.handler);
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {

    this.allors.context
      .save()
      .subscribe((saved: Saved) => {
        const data: ObjectData = {
          id: this.productType.id,
          objectType: this.productType.objectType,
        };

        this.dialogRef.close(data);
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }
}
