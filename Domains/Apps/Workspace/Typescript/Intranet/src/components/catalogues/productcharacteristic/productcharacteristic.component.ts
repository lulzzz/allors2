import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy , OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { TdMediaService } from "@covalent/core";
import { Subscription } from "rxjs/Rx";

import { PostalAddress, MetaDomain, SalesOrder, SalesInvoice, Good, SalesInvoiceItem, Catalogue, Singleton, Locale, ProductCategory, CatScope, PartyContactMechanism, Enumeration, ContactMechanismType, TelecommunicationsNumber, WorkEffortAssignment, WorkEffortState, Priority, Person, WorkTask, WorkEffortPurpose, CommunicationEvent, Organisation, OrganisationContactRelationship, ContactMechanism, PersonRole, CustomerRelationship, Country, ProductCharacteristic } from "@allors/workspace";
import { Scope, WorkspaceService, Saved, ErrorService, Loaded, Invoked } from "@allors/base-angular";
import { Fetch, TreeNode, Path, Query, PullRequest, And, Predicate, Like, ContainedIn, Page, Sort, Equals } from "@allors/framework";

@Component({
  templateUrl: "./productcharacteristic.component.html",
})
export class ProductCharacteristicComponent implements OnInit, AfterViewInit, OnDestroy {

  public m: MetaDomain;

  public productCharacteristic: ProductCharacteristic;

  public singleton: Singleton;
  public locales: Locale[];

  private subscription: Subscription;
  private scope: Scope;

  constructor(
    private workspaceService: WorkspaceService,
    private errorService: ErrorService,
    private route: ActivatedRoute,
    public media: TdMediaService, private changeDetectorRef: ChangeDetectorRef) {

    this.scope = this.workspaceService.createScope()
    this.m = this.workspaceService.metaPopulation.metaDomain;
  }

  public ngOnInit(): void {
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

  public ngAfterViewInit(): void {
    this.media.broadcast();
    this.changeDetectorRef.detectChanges();
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {

    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.goBack();
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }

  public goBack(): void {
    window.history.back();
  }
}
