import { Observable, Subject, Subscription } from 'rxjs/Rx';
import { Component, OnInit, AfterViewInit, OnDestroy, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { MdSnackBar } from '@angular/material';
import { TdLoadingService, TdDialogService, TdMediaService } from '@covalent/core';

import { Scope } from '../../../allors/angular/base/Scope';
import { AllorsService } from '../../allors.service';
import { PullRequest, Query, Equals, Like, TreeNode, Sort, Page } from '../../../allors/domain';
import { MetaDomain } from '../../../allors/meta/index';

import { ProductType } from '../../../allors/domain';

@Component({
  templateUrl: './productTypes.component.html',
})
export class ProductTypesComponent implements AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  data: ProductType[];
  filtered: ProductType[];

  constructor(private titleService: Title,
    private router: Router,
    private loadingService: TdLoadingService,
    private dialogService: TdDialogService,
    private snackBarService: MdSnackBar,
    public media: TdMediaService,
    private allors: AllorsService) {
    this.scope = new Scope(allors.database, allors.workspace);
  }

  goBack(): void {
    this.router.navigate(['/']);
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
    this.titleService.setTitle('Product Types');
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  search(criteria: string): void {

    if (this.subscription) {
      this.subscription.unsubscribe();
    }

    const m: MetaDomain = this.allors.meta;

    const query: Query[] = [new Query(
      {
        name: 'productTypes',
        objectType: m.ProductType,
        include: [
          new TreeNode({ roleType: m.ProductType.ProductCharacteristics }),
        ],
      })];

    this.scope.session.reset();

    this.subscription = this.scope
      .load('Pull', new PullRequest({ query: query }))
      .subscribe(() => {
        this.data = this.scope.collections.productTypes as ProductType[];
      },
      (error: any) => {
        alert(error);
        this.goBack();
      });
  }

  delete(productType: ProductType): void {
    this.dialogService
      .openConfirm({ message: 'Are you sure you want to delete this product type?' })
      .afterClosed().subscribe((confirm: boolean) => {
        if (confirm) {
          // TODO: Logical, physical or workflow delete
        }
      });
  }

  onView(productType: ProductType): void {
    this.router.navigate(['/catalogues/productTypes/' + productType.id + '/edit']);
  }
}