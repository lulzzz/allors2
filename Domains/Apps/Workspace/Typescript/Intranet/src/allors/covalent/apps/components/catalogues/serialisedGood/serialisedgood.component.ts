import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy, OnInit } from "@angular/core";
import { MatSnackBar, MatTabChangeEvent } from "@angular/material";
import { ActivatedRoute, UrlSegment } from "@angular/router";

import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Observable } from "rxjs/Observable";
import { Subscription } from "rxjs/Subscription";

import "rxjs/add/observable/combineLatest";

import { isType } from "@angular/core/src/type";
import { forEach } from "@angular/router/src/utils/collection";
import { ErrorService, Filter, Loaded, MediaService, Saved, Scope, WorkspaceService } from "../../../../../angular";
import { Brand, Facility, Good, InternalOrganisation, InventoryItemKind, Locale, LocalisedText, Model, Organisation, OrganisationRole, Ownership, ProductCategory, ProductFeature, ProductType, SerialisedInventoryItem, SerialisedInventoryItemCharacteristic, SerialisedInventoryItemCharacteristicType, SerialisedInventoryItemState, Singleton, VatRate, VendorProduct } from "../../../../../domain";
import { Contains, Equals, Fetch, Path, PullRequest, Query, Sort, TreeNode } from "../../../../../framework";
import { MetaDomain } from "../../../../../meta";
import { StateService } from "../../../services/StateService";
import { Fetcher } from "../../Fetcher";

@Component({
  templateUrl: "./serialisedgood.component.html",
})
export class SerialisedGoodComponent implements OnInit, OnDestroy {

  public m: MetaDomain;
  public good: Good;

  public title: string;
  public subTitle: string;
  public facility: Facility;
  public locales: Locale[];
  public categories: ProductCategory[];
  public productTypes: ProductType[];
  public manufacturers: Organisation[];
  public suppliers: Organisation[];
  public brands: Brand[];
  public selectedBrand: Brand;
  public models: Model[];
  public selectedModel: Model;
  public inventoryItemKinds: InventoryItemKind[];
  public inventoryItems: SerialisedInventoryItem[];
  public inventoryItem: SerialisedInventoryItem;
  public vendorProduct: VendorProduct;
  public serialisedInventoryItemStates: SerialisedInventoryItemState[];
  public vatRates: VatRate[];
  public ownerships: Ownership[];

  public manufacturersFilter: Filter;
  public suppliersFilter: Filter;

  private subscription: Subscription;
  private scope: Scope;
  private refresh$: BehaviorSubject<Date>;

  private fetcher: Fetcher;

  constructor(
    private workspaceService: WorkspaceService,
    private errorService: ErrorService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    public mediaService: MediaService,
    private stateService: StateService,
  ) {

    this.scope = this.workspaceService.createScope();
    this.m = this.workspaceService.metaPopulation.metaDomain;
    this.manufacturersFilter = new Filter({scope: this.scope, objectType: this.m.Organisation, roleTypes: [this.m.Organisation.Name]});
    this.suppliersFilter = new Filter({scope: this.scope, objectType: this.m.Organisation, roleTypes: [this.m.Organisation.Name]});
    this.refresh$ = new BehaviorSubject<Date>(undefined);

    this.fetcher = new Fetcher(this.stateService, this.m);
  }

  public ngOnInit(): void {

    this.subscription = Observable.combineLatest(this.route.url, this.refresh$, this.stateService.internalOrganisationId$)
      .switchMap(([urlSegments, date, internalOrganisationId]) => {

        const id: string = this.route.snapshot.paramMap.get("id");
        const m: MetaDomain = this.m;

        const fetch: Fetch[] = [
          this.fetcher.locales,
          this.fetcher.internalOrganisation,
          new Fetch({
            id,
            include: [
              new TreeNode({ roleType: m.Good.PrimaryPhoto }),
              new TreeNode({ roleType: m.Good.Photos }),
              new TreeNode({ roleType: m.Good.LocalisedNames, nodes: [new TreeNode({ roleType: m.LocalisedText.Locale })] }),
              new TreeNode({ roleType: m.Good.LocalisedDescriptions, nodes: [new TreeNode({ roleType: m.LocalisedText.Locale })] }),
              new TreeNode({ roleType: m.Good.ProductCategories }),
              new TreeNode({ roleType: m.Good.InventoryItemKind }),
              new TreeNode({ roleType: m.Good.SuppliedBy }),
              new TreeNode({ roleType: m.Good.ManufacturedBy }),
              new TreeNode({ roleType: m.Good.StandardFeatures }),
            ],
            name: "good",
          }),
          new Fetch({
            id,
            include: [
              new TreeNode({  roleType: m.SerialisedInventoryItem.Ownership }),
              new TreeNode({  roleType: m.SerialisedInventoryItem.SerialisedInventoryItemCharacteristics,
                              nodes: [
                                new TreeNode({ roleType: m.SerialisedInventoryItemCharacteristic.SerialisedInventoryItemCharacteristicType,
                                  nodes: [new TreeNode({ roleType: m.SerialisedInventoryItemCharacteristicType.UnitOfMeasure })]  }),
                                new TreeNode({ roleType: m.SerialisedInventoryItemCharacteristic.LocalisedValues,
                                  nodes: [new TreeNode({ roleType: m.LocalisedText.Locale })] }),
                              ],
              }),
            ],
            name: "inventoryItems",
            path: new Path({ step: this.m.Good.InventoryItemsWhereGood }),
          }),
        ];

        const query: Query[] = [
          new Query(this.m.ProductCategory),
          new Query(this.m.ProductType),
          new Query(this.m.VatRate),
          new Query(this.m.Ownership),
          new Query(this.m.InventoryItemKind),
          new Query(this.m.SerialisedInventoryItemState),
          new Query(
            {
              name: "brands",
              objectType: this.m.Brand,
              sort: [new Sort({ roleType: m.Brand.Name, direction: "Asc" })],
            }),
        ];

        return this.scope
          .load("Pull", new PullRequest({ fetch, query }))
          .switchMap((loaded) => {

            this.good = loaded.objects.good as Good;
            this.categories = loaded.collections.ProductCategoryQuery as ProductCategory[];
            this.productTypes = loaded.collections.ProductTypeQuery as ProductType[];
            this.vatRates = loaded.collections.VatRateQuery as VatRate[];
            this.brands = loaded.collections.brands as Brand[];
            this.ownerships = loaded.collections.OwnershipQuery as Ownership[];
            this.inventoryItemKinds = loaded.collections.InventoryItemKindQuery as InventoryItemKind[];
            this.serialisedInventoryItemStates = loaded.collections.SerialisedInventoryItemStateQuery as SerialisedInventoryItemState[];
            this.locales = loaded.collections.locales as Locale[];
            const internalOrganisation = loaded.objects.internalOrganisation as InternalOrganisation;
            this.facility = internalOrganisation.DefaultFacility;
            this.suppliers = internalOrganisation.ActiveSuppliers as Organisation[];

            const vatRateZero = this.vatRates.find((v: VatRate) => v.Rate === 0);
            const inventoryItemKindSerialised = this.inventoryItemKinds.find((v: InventoryItemKind) => v.Name === "Serialised");

            if (this.good === undefined) {
              this.good = this.scope.session.create("Good") as Good;
              this.good.VatRate = vatRateZero;
              this.good.Sku = "";

              this.inventoryItem = this.scope.session.create("SerialisedInventoryItem") as SerialisedInventoryItem;
              this.good.InventoryItemKind = inventoryItemKindSerialised;
              this.inventoryItem.Good = this.good;
              this.inventoryItem.Facility = this.facility;

              this.vendorProduct = this.scope.session.create("VendorProduct") as VendorProduct;
              this.vendorProduct.Product = this.good;
              this.vendorProduct.InternalOrganisation = internalOrganisation;

            } else {
              this.inventoryItems = loaded.collections.inventoryItems as SerialisedInventoryItem[];
              this.inventoryItem = this.inventoryItems[0];

              this.good.StandardFeatures.forEach((feature: ProductFeature) => {
                 if (feature instanceof (Brand)) {
                   this.selectedBrand = feature;
                   this.brandSelected(this.selectedBrand);
                 }
                 if (feature instanceof (Model)) {
                  this.selectedModel = feature;
                }
             });
            }

            this.title = this.good.Name;
            this.subTitle = "Serialised";

            const Query2: Query[] = [
              new Query(
                {
                  name: "manufacturers",
                  objectType: m.Organisation,
                  predicate: new Equals({ roleType: m.Organisation.IsManufacturer, value: true}),
                  sort: [new Sort({ roleType: m.Organisation.PartyName, direction: "Asc" })],
                }),
            ];

            return this.scope.load("Pull", new PullRequest({ query: Query2 }));
          });
      })
      .subscribe((loaded) => {
        this.manufacturers = loaded.collections.manufacturers as Organisation[];
      },
      (error: any) => {
        this.errorService.message(error);
        this.goBack();
      },
    );
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.good.StandardFeatures.forEach((feature: ProductFeature) => {
      this.good.RemoveStandardFeature(feature);
    });

    if (this.selectedBrand != null) {
      this.good.AddStandardFeature(this.selectedBrand);
    }

    if (this.selectedModel != null) {
      this.good.AddStandardFeature(this.selectedModel);
    }

    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.goBack();
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }

  public update(): void {

      this.scope
        .save()
        .subscribe((saved: Saved) => {
          this.refresh();
        },
        (error: Error) => {
          this.errorService.dialog(error);
        });
    }

    public refresh(): void {
      this.refresh$.next(new Date());
  }

  public goBack(): void {
    window.history.back();
  }

  public brandSelected(brand: Brand): void {

    const fetch: Fetch[] = [
      new Fetch(
        {
          id: brand.id,
          include: [new TreeNode({ roleType: this.m.Brand.Models })],
          name: "selectedbrand",
        }),
    ];

    this.scope
      .load("Pull", new PullRequest({ fetch }))
      .subscribe((loaded) => {

        const selectedbrand = loaded.objects.selectedbrand as Brand;
        this.models = selectedbrand.Models;
      },
      (error: Error) => {
        this.errorService.message(error);
        this.goBack();
      },
    );
  }
}
