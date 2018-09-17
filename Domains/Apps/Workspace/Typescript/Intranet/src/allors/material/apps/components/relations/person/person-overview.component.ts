import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, UrlSegment, Router } from '@angular/router';

import { BehaviorSubject, Observable, Subscription, combineLatest } from 'rxjs';

import { ErrorService, Invoked, Loaded, Saved, Scope, WorkspaceService, DataService, x } from '../../../../../angular';
import { CommunicationEvent, ContactMechanism, InternalOrganisation, Organisation, OrganisationContactKind, OrganisationContactRelationship, PartyContactMechanism, Person, PersonRole, WorkEffort, WorkEffortAssignment } from '../../../../../domain';
import { Fetch, PullRequest, TreeNode, ISessionObject } from '../../../../../framework';
import { MetaDomain } from '../../../../../meta';
import { StateService } from '../../../services/StateService';
import { Fetcher } from '../../Fetcher';
import { AllorsMaterialDialogService } from '../../../../base/services/dialog';
import { switchMap } from 'rxjs/operators';

@Component({
  templateUrl: './person-overview.component.html',
})
export class PersonOverviewComponent implements OnInit, OnDestroy {

  public m: MetaDomain;

  public title = 'Person Overview';
  public person: Person;
  public organisation: Organisation;
  public internalOrganisation: InternalOrganisation;

  public communicationEvents: CommunicationEvent[];
  public workEffortAssignments: WorkEffortAssignment[];

  public contactMechanismsCollection = 'Current';
  public currentContactMechanisms: PartyContactMechanism[] = [];
  public inactiveContactMechanisms: PartyContactMechanism[] = [];
  public allContactMechanisms: PartyContactMechanism[] = [];
  public contactKindsText: string;

  public roles: PersonRole[];
  public activeRoles: PersonRole[] = [];
  public rolesText: string;
  private customerRole: PersonRole;
  private employeeRole: PersonRole;
  private contactRole: PersonRole;
  private isActiveCustomer: boolean;
  private isActiveEmployee: boolean;

  private refresh$: BehaviorSubject<Date>;
  private subscription: Subscription;
  private scope: Scope;
  private fetcher: Fetcher;

  constructor(
    private workspaceService: WorkspaceService,
    private dataService: DataService,
    private errorService: ErrorService,
    private titleService: Title,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialogService: AllorsMaterialDialogService,
    private stateService: StateService) {

    titleService.setTitle(this.title);

    this.scope = this.workspaceService.createScope();
    this.m = this.workspaceService.metaPopulation.metaDomain;
    this.refresh$ = new BehaviorSubject<Date>(undefined);
    this.fetcher = new Fetcher(this.stateService, this.dataService);
  }

  get contactMechanisms(): any {

    switch (this.contactMechanismsCollection) {
      case 'Current':
        return this.currentContactMechanisms;
      case 'Inactive':
        return this.inactiveContactMechanisms;
      case 'All':
      default:
        return this.allContactMechanisms;
    }
  }

  public ngOnInit(): void {

    const { m, pull, tree } = this.dataService;

    this.subscription = combineLatest(this.route.url, this.refresh$, this.stateService.internalOrganisationId$)
      .pipe(
        switchMap(([urlSegments, date, internalOrganisationId]) => {

          const id: string = this.route.snapshot.paramMap.get('id');

          const partyContactMechanismTree = tree.PartyContactMechanism({
            ContactPurposes: x,
            ContactMechanism: {
              PostalAddress_PostalBoundary: {
                Country: x,
              }
            },
          });

          const pulls = [
            this.fetcher.internalOrganisation,
            pull.Person({
              object: id,
              include: {
                Locale: x,
                LastModifiedBy: x,
                Salutation: x,
                PartyContactMechanisms: partyContactMechanismTree,
                CurrentPartyContactMechanisms: partyContactMechanismTree,
                InactivePartyContactMechanisms: partyContactMechanismTree,
                GeneralCorrespondence: {
                  PostalBoundary: {
                    Country: x,
                  }
                }
              }
            }),
            pull.Party({
              object: id,
              fetch: {
                CommunicationEventsWhereInvolvedParty: {
                  CommunicationEventState: x,
                  FromParties: x,
                  ToParties: x,
                  InvolvedParties: x,
                }
              }
            }),
            pull.Person({
              object: id,
              fetch: {
                WorkEffortAssignmentsWhereProfessional: {
                  include: {
                    Assignment: {
                      WorkEffortState: x,
                      Priority: x,
                    }
                  }
                }
              }
            }),
            pull.Person({
              object: id,
              fetch: {
                OrganisationContactRelationshipsWhereContact: {
                  Organisation: x,
                  ContactKinds: x,
                }
              }
            }),
            pull.PersonRole()
          ];

          return this.scope
            .load('Pull', new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {
        this.scope.session.reset();
        this.internalOrganisation = loaded.objects.internalOrganisation as InternalOrganisation;

        this.person = loaded.objects.person as Person;
        const organisationContactRelationships: OrganisationContactRelationship[] = loaded.collections.organisationContactRelationships as OrganisationContactRelationship[];
        this.organisation = organisationContactRelationships.length > 0 ? organisationContactRelationships[0].Organisation as Organisation : undefined;
        this.contactKindsText = organisationContactRelationships.length > 0 ? organisationContactRelationships[0].ContactKinds
          .map((v: OrganisationContactKind) => v.Description)
          .reduce((acc: string, cur: string) => acc + ', ' + cur) : undefined;
        this.communicationEvents = loaded.collections.communicationEvents as CommunicationEvent[];
        this.workEffortAssignments = loaded.collections.workEffortAssignments as WorkEffortAssignment[];

        this.currentContactMechanisms = this.person.CurrentPartyContactMechanisms as PartyContactMechanism[];
        this.inactiveContactMechanisms = this.person.InactivePartyContactMechanisms as PartyContactMechanism[];
        this.allContactMechanisms = this.currentContactMechanisms.concat(this.inactiveContactMechanisms);

        this.roles = loaded.collections.PersonRoles as PersonRole[];
        this.customerRole = this.roles.find((v: PersonRole) => v.UniqueId.toUpperCase() === 'B29444EF-0950-4D6F-AB3E-9C6DC44C050F');
        this.employeeRole = this.roles.find((v: PersonRole) => v.UniqueId.toUpperCase() === 'DB06A3E1-6146-4C18-A60D-DD10E19F7243');
        this.contactRole = this.roles.find((v: PersonRole) => v.UniqueId.toUpperCase() === 'FA2DF11E-7795-4DF7-8B3F-4FD87D0C4D8E');

        this.activeRoles = [];
        this.rolesText = '';
        if (this.internalOrganisation.ActiveCustomers.includes(this.person)) {
          this.isActiveCustomer = true;
          this.activeRoles.push(this.customerRole);
        }

        if (this.internalOrganisation.ActiveEmployees.includes(this.person)) {
          this.isActiveEmployee = true;
          this.activeRoles.push(this.employeeRole);
        }

        if (this.organisation !== null) {
          this.activeRoles.push(this.contactRole);
        }

        if (this.activeRoles.length > 0) {
          this.rolesText = this.activeRoles
            .map((v: PersonRole) => v.Name)
            .reduce((acc: string, cur: string) => acc + ', ' + cur);
        }
      },
        (error: any) => {
          this.errorService.handle(error);
          this.goBack();
        },
      );
  }

  public removeContactMechanism(partyContactMechanism: PartyContactMechanism): void {
    partyContactMechanism.ThroughDate = new Date();
    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.scope.session.reset();
        this.refresh();
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }

  public activateContactMechanism(partyContactMechanism: PartyContactMechanism): void {
    partyContactMechanism.ThroughDate = undefined;
    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.scope.session.reset();
        this.refresh();
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }

  public deleteContactMechanism(contactMechanism: ContactMechanism): void {
    this.dialogService
      .confirm({ message: 'Are you sure you want to delete this?' })
      .subscribe((confirm: boolean) => {
        if (confirm) {
          this.scope.invoke(contactMechanism.Delete)
            .subscribe((invoked: Invoked) => {
              this.snackBar.open('Successfully deleted.', 'close', { duration: 5000 });
              this.refresh();
            },
              (error: Error) => {
                this.errorService.handle(error);
              });
        }
      });
  }

  public cancelCommunication(communicationEvent: CommunicationEvent): void {
    this.dialogService
      .confirm({ message: 'Are you sure you want to cancel this?' })
      .subscribe((confirm: boolean) => {
        if (confirm) {
          this.scope.invoke(communicationEvent.Cancel)
            .subscribe((invoked: Invoked) => {
              this.snackBar.open('Successfully cancelled.', 'close', { duration: 5000 });
              this.refresh();
            },
              (error: Error) => {
                this.errorService.handle(error);
              });
        }
      });
  }

  public closeCommunication(communicationEvent: CommunicationEvent): void {
    this.dialogService
      .confirm({ message: 'Are you sure you want to close this?' })
      .subscribe((confirm: boolean) => {
        if (confirm) {
          this.scope.invoke(communicationEvent.Close)
            .subscribe((invoked: Invoked) => {
              this.snackBar.open('Successfully closed.', 'close', { duration: 5000 });
              this.refresh();
            },
              (error: Error) => {
                this.errorService.handle(error);
              });
        }
      });
  }

  public reopenCommunication(communicationEvent: CommunicationEvent): void {
    this.dialogService
      .confirm({ message: 'Are you sure you want to reopen this?' })
      .subscribe((confirm: boolean) => {
        if (confirm) {
          this.scope.invoke(communicationEvent.Reopen)
            .subscribe((invoked: Invoked) => {
              this.snackBar.open('Successfully reopened.', 'close', { duration: 5000 });
              this.refresh();
            },
              (error: Error) => {
                this.errorService.handle(error);
              });
        }
      });
  }

  public deleteCommunication(communicationEvent: CommunicationEvent): void {
    this.dialogService
      .confirm({ message: 'Are you sure you want to delete this?' })
      .subscribe((confirm: boolean) => {
        if (confirm) {
          this.scope.invoke(communicationEvent.Delete)
            .subscribe((invoked: Invoked) => {
              this.snackBar.open('Successfully deleted.', 'close', { duration: 5000 });
              this.refresh();
            },
              (error: Error) => {
                this.errorService.handle(error);
              });
        }
      });
  }

  public delete(workEffort: WorkEffort): void {
    this.dialogService
      .confirm({ message: 'Are you sure you want to delete this work effort?' })
      .subscribe((confirm: boolean) => {
        if (confirm) {
          this.scope.invoke(workEffort.Delete)
            .subscribe((invoked: Invoked) => {
              this.snackBar.open('Successfully deleted.', 'close', { duration: 5000 });
              this.refresh();
            },
              (error: Error) => {
                this.errorService.handle(error);
              });
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public refresh(): void {
    this.refresh$.next(new Date());
  }

  public goBack(): void {
    window.history.back();
  }

  public checkType(obj: any): string {
    return obj.objectType.name;
  }
}
