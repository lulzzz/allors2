import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy , OnInit } from "@angular/core";
import { Validators } from "@angular/forms";
import { MatSnackBar, MatSnackBarConfig } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { TdMediaService } from "@covalent/core";
import { Observable, Subject, Subscription } from "rxjs/Rx";

import { AllorsService, ErrorService, Loaded, Saved, Scope } from "@allors";
import { Equals, Fetch, Like, Page, Path, PullRequest, PushResponse, Query, Sort, TreeNode } from "@allors";
import { Locale, ProductCharacteristic, Singleton } from "@allors";
import { MetaDomain } from "@allors";

@Component({
  templateUrl: "./edit.component.html",
})
export class ProductCharacteristicEditComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  m: MetaDomain;

  productCharacteristic: ProductCharacteristic;

  singleton: Singleton;
  locales: Locale[];

  constructor(
    private allors: AllorsService,
    private errorService: ErrorService,
    private route: ActivatedRoute,
    public media: TdMediaService, private changeDetectorRef: ChangeDetectorRef) {

    this.scope = new Scope(allors.database, allors.workspace);
    this.m = this.allors.meta;
  }

  ngOnInit(): void {
    this.subscription = this.route.url
      .switchMap((url: any) => {

        const id: string = this.route.snapshot.paramMap.get("id");
        const m: MetaDomain = this.m;

        const fetch: Fetch[] = [
          new Fetch({
            name: "productCharacteristic",
            id,
            include: [
              new TreeNode({ roleType: m.ProductCharacteristic.LocalisedNames }),
            ],
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              name: "singletons",
              objectType: this.m.Singleton,
              include: [
                new TreeNode({ roleType: m.Singleton.Locales }),
              ],
            }),
        ];

        this.scope.session.reset();

        return this.scope
          .load("Pull", new PullRequest({ fetch, query }));
      })
      .subscribe((loaded: Loaded) => {

        this.productCharacteristic = loaded.objects.productCharacteristic as ProductCharacteristic;
        if (!this.productCharacteristic) {
          this.productCharacteristic = this.scope.session.create("ProductCharacteristic") as ProductCharacteristic;
        }

        this.singleton = loaded.collections.singletons[0] as Singleton;
        this.locales = this.singleton.Locales;
      },
      (error: any) => {
        this.errorService.message(error);
        this.goBack();
      },
    );
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
    this.changeDetectorRef.detectChanges();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  save(): void {

    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.goBack();
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }

  goBack(): void {
    window.history.back();
  }
}