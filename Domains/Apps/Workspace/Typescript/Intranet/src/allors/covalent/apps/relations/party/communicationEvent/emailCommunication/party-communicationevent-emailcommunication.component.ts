import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy , OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material";
import { ActivatedRoute, UrlSegment } from "@angular/router";
import { TdDialogService, TdMediaService } from "@covalent/core";

import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Observable } from "rxjs/Observable";
import { Subscription } from "rxjs/Subscription";

import "rxjs/add/observable/combineLatest";

import { ErrorService, Filter, Invoked, Loaded, Saved, Scope, WorkspaceService } from "../../../../../../angular";
import { Brand, Catalogue, CatScope, CommunicationEventPurpose, ContactMechanism, Currency, EmailAddress, EmailCommunication, EmailTemplate,
  Facility, Good, InventoryItemKind, InventoryItemVariance, Locale, LocalisedText, Model,
  NonSerialisedInventoryItem, NonSerialisedInventoryItemState, Organisation, OrganisationContactRelationship, OrganisationRole, Party, PartyContactMechanism,
  Person, ProcessFlow, ProductCategory, ProductCharacteristic, ProductCharacteristicValue, ProductFeature, ProductQuote, ProductType, QuoteItem, RequestForQuote,
  SalesInvoice, SalesInvoiceItem, SalesOrder, SalesOrderItem, Singleton, TelecommunicationsNumber, VarianceReason, VatRate, VatRegime } from "../../../../../../domain";
import { And, ContainedIn, Contains, Fetch, Like, Page, Path, Predicate, PullRequest, Query, Sort, TreeNode } from "../../../../../../framework";
import { MetaDomain } from "../../../../../../meta";

@Component({
  templateUrl: "./party-communicationevent-emailcommunication.component.html",
})
export class PartyCommunicationEventEmailCommunicationComponent implements OnInit, AfterViewInit, OnDestroy {

  public title: string = "Email Communication";
  public subTitle: string;

  public addOriginator: boolean = false;
  public addAddressee: boolean = false;

  public m: MetaDomain;

  public singleton: Singleton;
  public communicationEvent: EmailCommunication;
  public employees: Person[];
  public party: Party;
  public purposes: CommunicationEventPurpose[];
  public emailAddresses: ContactMechanism[] = [];
  public emailTemplate: EmailTemplate;

  private refresh$: BehaviorSubject<Date>;
  private subscription: Subscription;
  private scope: Scope;

  constructor(
    private workspaceService: WorkspaceService,
    private errorService: ErrorService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private dialogService: TdDialogService,
    public media: TdMediaService,
    private changeDetectorRef: ChangeDetectorRef) {

    this.scope = this.workspaceService.createScope()
    this.m = this.workspaceService.metaPopulation.metaDomain;
    this.refresh$ = new BehaviorSubject<Date>(undefined);
  }

  public ngOnInit(): void {
    const route$: Observable<UrlSegment[]> = this.route.url;

    const combined$: Observable<[UrlSegment[], Date]> = Observable.combineLatest(route$, this.refresh$);

    this.subscription = combined$
      .switchMap(([urlSegments, date]: [UrlSegment[], Date]) => {

        const id: string = this.route.snapshot.paramMap.get("id");
        const roleId: string = this.route.snapshot.paramMap.get("roleId");

        const m: MetaDomain = this.workspaceService.metaPopulation.metaDomain;

        const fetch: Fetch[] = [
          new Fetch({
            name: "party",
            id,
          }),
          new Fetch({
            id: roleId,
            include: [
              new TreeNode({ roleType: m.EmailCommunication.Originator }),
              new TreeNode({ roleType: m.EmailCommunication.Addressees }),
              new TreeNode({ roleType: m.EmailCommunication.EmailTemplate }),
              new TreeNode({ roleType: m.CommunicationEvent.EventPurposes }),
              new TreeNode({ roleType: m.CommunicationEvent.CommunicationEventState }),
            ],
            name: "communicationEvent",
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              include: [
                new TreeNode({
                  nodes: [
                    new TreeNode({
                      nodes: [
                        new TreeNode({
                          nodes: [
                            new TreeNode({ roleType: m.PartyContactMechanism.ContactMechanism }),
                          ],
                          roleType: m.Party.CurrentPartyContactMechanisms,
                        }),
                      ],
                      roleType: m.InternalOrganisation.ActiveEmployees,
                    }),
                  ],
                  roleType: m.Singleton.InternalOrganisation,
                }),
              ],
              name: "singletons",
              objectType: this.m.Singleton,
            }),
          new Query(
            {
              name: "purposes",
              objectType: this.m.CommunicationEventPurpose,
            }),
        ];

        return this.scope
          .load("Pull", new PullRequest({ fetch, query }));
      })
      .subscribe((loaded: Loaded) => {

        this.scope.session.reset();

        this.party = loaded.objects.party as Party;
        this.singleton = loaded.collections.singletons[0] as Singleton;
        this.employees = this.singleton.InternalOrganisation.ActiveEmployees;
        this.purposes = loaded.collections.purposes as CommunicationEventPurpose[];
        this.communicationEvent = loaded.objects.communicationEvent as EmailCommunication;

        if (!this.communicationEvent) {
          this.communicationEvent = this.scope.session.create("EmailCommunication") as EmailCommunication;
          this.emailTemplate = this.scope.session.create("EmailTemplate") as EmailTemplate;
          this.communicationEvent.EmailTemplate = this.emailTemplate;
          this.communicationEvent.Originator = this.party.GeneralEmail;
        }

        for (const employee of this.employees) {
          const employeeContactMechanisms: ContactMechanism[] = employee.CurrentPartyContactMechanisms.map((v: PartyContactMechanism) => v.ContactMechanism);
          for (const contactMechanism of employeeContactMechanisms) {
            if (contactMechanism instanceof (EmailAddress)) {
              this.emailAddresses.push(contactMechanism);
            }
          }
        }

        const contactMechanisms: ContactMechanism[] = this.party.CurrentPartyContactMechanisms.map((v: PartyContactMechanism) => v.ContactMechanism);
        for (const contactMechanism of contactMechanisms) {
          if (contactMechanism instanceof (EmailAddress)) {
            this.emailAddresses.push(contactMechanism);
          }
        }
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

  public originatorCancelled(): void {
    this.addOriginator = false;
  }

  public addresseeCancelled(): void {
    this.addAddressee = false;
  }

  public originatorAdded(id: string): void {
    this.addOriginator = false;

    const emailAddress: EmailAddress = this.scope.session.get(id) as EmailAddress;
    const partyContactMechanism: PartyContactMechanism = this.scope.session.create("PartyContactMechanism") as PartyContactMechanism;
    partyContactMechanism.ContactMechanism = emailAddress;
    this.party.AddPartyContactMechanism(partyContactMechanism);

    this.emailAddresses.push(emailAddress);
    this.communicationEvent.Originator = emailAddress;
  }

  public addresseeAdded(id: string): void {
    this.addAddressee = false;

    const emailAddress: EmailAddress = this.scope.session.get(id) as EmailAddress;
    const partyContactMechanism: PartyContactMechanism = this.scope.session.create("PartyContactMechanism") as PartyContactMechanism;
    partyContactMechanism.ContactMechanism = emailAddress;
    this.party.AddPartyContactMechanism(partyContactMechanism);

    this.emailAddresses.push(emailAddress);
    this.communicationEvent.AddAddressee(emailAddress);
  }

  public cancel(): void {
    const cancelFn: () => void = () => {
      this.scope.invoke(this.communicationEvent.Cancel)
        .subscribe((invoked: Invoked) => {
          this.refresh();
          this.snackBar.open("Successfully cancelled.", "close", { duration: 5000 });
        },
        (error: Error) => {
          this.errorService.dialog(error);
        });
    };

    if (this.scope.session.hasChanges) {
      this.dialogService
        .openConfirm({ message: "Save changes?" })
        .afterClosed().subscribe((confirm: boolean) => {
          if (confirm) {
            this.scope
              .save()
              .subscribe((saved: Saved) => {
                this.scope.session.reset();
                cancelFn();
              },
              (error: Error) => {
                this.errorService.dialog(error);
              });
          } else {
            cancelFn();
          }
        });
    } else {
      cancelFn();
    }
  }

  public close(): void {
    const cancelFn: () => void = () => {
      this.scope.invoke(this.communicationEvent.Close)
        .subscribe((invoked: Invoked) => {
          this.refresh();
          this.snackBar.open("Successfully closed.", "close", { duration: 5000 });
        },
        (error: Error) => {
          this.errorService.dialog(error);
        });
    };

    if (this.scope.session.hasChanges) {
      this.dialogService
        .openConfirm({ message: "Save changes?" })
        .afterClosed().subscribe((confirm: boolean) => {
          if (confirm) {
            this.scope
              .save()
              .subscribe((saved: Saved) => {
                this.scope.session.reset();
                cancelFn();
              },
              (error: Error) => {
                this.errorService.dialog(error);
              });
          } else {
            cancelFn();
          }
        });
    } else {
      cancelFn();
    }
  }

  public reopen(): void {
    const cancelFn: () => void = () => {
      this.scope.invoke(this.communicationEvent.Reopen)
        .subscribe((invoked: Invoked) => {
          this.refresh();
          this.snackBar.open("Successfully reopened.", "close", { duration: 5000 });
        },
        (error: Error) => {
          this.errorService.dialog(error);
        });
    };

    if (this.scope.session.hasChanges) {
      this.dialogService
        .openConfirm({ message: "Save changes?" })
        .afterClosed().subscribe((confirm: boolean) => {
          if (confirm) {
            this.scope
              .save()
              .subscribe((saved: Saved) => {
                this.scope.session.reset();
                cancelFn();
              },
              (error: Error) => {
                this.errorService.dialog(error);
              });
          } else {
            cancelFn();
          }
        });
    } else {
      cancelFn();
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

  public refresh(): void {
    this.refresh$.next(new Date());
  }

  public goBack(): void {
    window.history.back();
  }
}
