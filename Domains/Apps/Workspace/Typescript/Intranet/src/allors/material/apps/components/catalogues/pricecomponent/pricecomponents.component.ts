import { Component, Input, Output, EventEmitter } from '@angular/core';

import { NavigationService, Allors } from '../../../../../angular';
import { PriceComponent } from '../../../../../domain';
import { ObjectType } from '../../../../../framework';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'price-component',
  templateUrl: './pricecomponents.component.html',
})
export class PriceComponentsComponent {

  @Input() currentPricecomponents: PriceComponent[];

  @Input() inactivePricecomponents: PriceComponent[];

  @Input() allPricecomponents: PriceComponent[];

  @Output() add: EventEmitter<ObjectType> = new EventEmitter<ObjectType>();

  @Output() edit: EventEmitter<ObjectType> = new EventEmitter<ObjectType>();

  @Output() delete: EventEmitter<PriceComponent> = new EventEmitter<PriceComponent>();

  pricecomponentsCollection = 'Current';

  constructor(
    public allors: Allors,
    public navigationService: NavigationService) { }

  get prices(): any {

    switch (this.pricecomponentsCollection) {
      case 'Current':
        return this.currentPricecomponents;
      case 'Inactive':
        return this.inactivePricecomponents;
      case 'All':
      default:
        return this.allPricecomponents;
    }
  }
}