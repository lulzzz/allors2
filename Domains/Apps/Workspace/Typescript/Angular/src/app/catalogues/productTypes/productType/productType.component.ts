import { Observable, Subject, Subscription } from 'rxjs/Rx';
import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MdSnackBar, MdSnackBarConfig } from '@angular/material';
import { TdMediaService } from '@covalent/core';

import { Scope } from '../../../../allors/angular/base/Scope';
import { AllorsService } from '../../../allors.service';
import { PullRequest, PushResponse, Fetch, Path, Query, Equals, Like, TreeNode, Sort, Page } from '../../../../allors/domain';
import { MetaDomain } from '../../../../allors/meta/index';

import { ProductType, ProductCharacteristic } from '../../../../allors/domain';

@Component({
  templateUrl: './productType.component.html',
})
export class ProductTypeFormComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  m: MetaDomain;

  productType: ProductType;

  characteristics: ProductCharacteristic[];

  constructor(private allors: AllorsService,
    private route: ActivatedRoute,
    public snackBar: MdSnackBar,
    public media: TdMediaService) {
    this.scope = new Scope(allors.database, allors.workspace);
    this.m = this.allors.meta;
  }

  ngOnInit(): void {
    this.subscription = this.route.url
      .mergeMap((url: any) => {

        const id: string = this.route.snapshot.paramMap.get('id');
        const m: MetaDomain = this.m;

        const fetch: Fetch[] = [
          new Fetch({
            name: 'productType',
            id: id,
            include: [
              new TreeNode({ roleType: m.ProductType.ProductCharacteristics }),
            ],
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              name: 'characteristics',
              objectType: this.m.ProductCharacteristic,
            }),
        ];

        this.scope.session.reset();

        return this.scope
          .load('Pull', new PullRequest({ fetch: fetch, query: query }));
      })
      .subscribe(() => {

        this.productType = this.scope.objects.productType as ProductType;
        if (!this.productType) {
          this.productType = this.scope.session.create('ProductType') as ProductType;
        }

        this.characteristics = this.scope.collections.characteristics as ProductCharacteristic[];
      },
      (error: any) => {
        this.snackBar.open(error, 'close', { duration: 5000 });
        this.goBack();
      },
    );
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  save(): void {

    this.scope
      .save()
      .subscribe((pushResponse: PushResponse) => {
        this.goBack();
      },
      (e: any) => {
        this.snackBar.open(e.toString(), 'close', { duration: 5000 });
      });
  }

  goBack(): void {
    window.history.back();
  }
}