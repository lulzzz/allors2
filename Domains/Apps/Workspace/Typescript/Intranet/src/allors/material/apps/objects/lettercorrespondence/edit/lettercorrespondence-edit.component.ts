import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

import { Subscription, combineLatest } from 'rxjs';

import { ErrorService, ContextService, NavigationService, MetaService, RefreshService } from '../../../../../angular';
import { CommunicationEventPurpose, ContactMechanism, LetterCorrespondence, Organisation, OrganisationContactRelationship, Party, PartyContactMechanism, Person, PostalAddress, CommunicationEventState } from '../../../../../domain';
import { PullRequest, Sort, Equals } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { StateService } from '../../../services/state';
import { switchMap, map } from 'rxjs/operators';
import { ObjectData, EditData, CreateData } from 'src/allors/material/base/services/object';

@Component({
  templateUrl: './lettercorrespondence-edit.component.html',
  providers: [ContextService]
})
export class LetterCorrespondenceEditComponent implements OnInit, OnDestroy {

  readonly m: Meta;

  addFromParty = false;
  addToParty = false;
  addFromAddress = false;
  addToAddress = false;

  party: Party;
  person: Person;
  organisation: Organisation;
  purposes: CommunicationEventPurpose[];
  fromPostalAddresses: ContactMechanism[] = [];
  toPostalAddresses: ContactMechanism[] = [];
  communicationEvent: LetterCorrespondence;
  eventStates: CommunicationEventState[];
  contacts: Party[] = [];
  parties: Party[];
  title: string;

  private subscription: Subscription;

  constructor(
    @Self() private allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: CreateData & EditData,
    public dialogRef: MatDialogRef<LetterCorrespondenceEditComponent>,
    public refreshService: RefreshService,
    public metaService: MetaService,
    public navigation: NavigationService,
    private errorService: ErrorService,
    private stateService: StateService) {

    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    const { m, pull, x } = this.metaService;

    this.subscription = combineLatest(this.refreshService.refresh$, this.stateService.internalOrganisationId$)
      .pipe(
        switchMap(([]) => {

          const isCreate = (this.data as EditData).id === undefined;

          let pulls = [
            pull.LetterCorrespondence({
              object: this.data.id,
              include: {
                FromParty: {
                  CurrentPartyContactMechanisms: {
                    ContactMechanism: x
                  }
                },
                ToParty: {
                  CurrentPartyContactMechanisms: {
                    ContactMechanism: x
                  }
                },
                PostalAddress: {
                  PostalBoundary: {
                    Country: x
                  }
                },
                EventPurposes: x,
                CommunicationEventState: x
              }
            }),
            pull.Organisation({
              object: this.stateService.internalOrganisationId,
              name: 'InternalOrganisation',
              include: {
                ActiveEmployees: {
                  CurrentPartyContactMechanisms: {
                    ContactMechanism: {
                      PostalAddress_PostalBoundary: {
                        Country: x,
                      }
                    },
                  }
                }
              }
            }),
            pull.CommunicationEventPurpose({
              predicate: new Equals({ propertyType: m.CommunicationEventPurpose.IsActive, value: true }),
              sort: new Sort(m.CommunicationEventPurpose.Name)
            }),
            pull.CommunicationEventState({
              sort: new Sort(m.CommunicationEventState.Name)
            }),
          ];

          if (isCreate) {
            pulls = [
              ...pulls,
              pull.Organisation({
                object: this.data.associationId,
                include: {
                  CurrentContacts: x,
                  CurrentPartyContactMechanisms: {
                    ContactMechanism: {
                      PostalAddress_PostalBoundary: {
                        Country: x,
                      }
                    },
                  }
                }
              }),
              pull.Person({
                object: this.data.associationId,
              }),
              pull.Person({
                object: this.data.associationId,
                fetch: {
                  OrganisationContactRelationshipsWhereContact: {
                    Organisation: {
                      include: {
                        CurrentContacts: x,
                        CurrentPartyContactMechanisms: {
                          ContactMechanism: {
                            PostalAddress_PostalBoundary: {
                              Country: x,
                            }
                          },
                        }
                      }
                    }
                  }
                }
              })
            ];
          }

          if (!isCreate) {
            pulls = [
              ...pulls,
              pull.CommunicationEvent({
                object: this.data.id,
                fetch: {
                  PartiesWhereCommunicationEvent: x,
                }
              }),
            ];
          }

          return this.allors.context
            .load('Pull', new PullRequest({ pulls }))
            .pipe(
              map((loaded) => ({ loaded, isCreate }))
            );
        })
      )
      .subscribe(({ loaded, isCreate }) => {

        this.allors.context.reset();

        this.purposes = loaded.collections.CommunicationEventPurposes as CommunicationEventPurpose[];
        this.eventStates = loaded.collections.CommunicationEventStates as CommunicationEventState[];
        this.parties = loaded.collections.Parties as Party[];

        const internalOrganisation = loaded.objects.InternalOrganisation as Organisation;

        this.person = loaded.objects.Person as Person;
        this.organisation = loaded.objects.Organisation as Organisation;

        this.contacts = [];

        if (internalOrganisation.ActiveEmployees !== undefined) {
          this.contacts = this.contacts.concat(internalOrganisation.ActiveEmployees);
        }

        if (!!this.organisation) {
          this.contacts = this.contacts.concat(this.organisation);
        }

        if (!!this.organisation && this.organisation.CurrentContacts !== undefined) {
          this.contacts = this.contacts.concat(this.organisation.CurrentContacts);
        }

        if (!!this.person) {
          this.contacts.push(this.person);
        }

        if (!!this.parties) {
          this.contacts.push(...this.parties);
          this.parties.forEach((party) => {
            this.contacts.push(...party.CurrentContacts);
          });
        }

        if (isCreate) {
          this.title = 'Add Letter';
          this.communicationEvent = this.allors.context.create('LetterCorrespondence') as LetterCorrespondence;

          this.party = this.organisation || this.person;
        } else {
          this.communicationEvent = loaded.objects.LetterCorrespondence as LetterCorrespondence;

          this.updateFromParty(this.communicationEvent.FromParty);
          this.updateToParty(this.communicationEvent.ToParty);

          if (this.communicationEvent.CanWriteActualEnd) {
            this.title = 'Edit Letter';
          } else {
            this.title = 'View Letter';
          }
        }
      }, this.errorService.handler);
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public fromAddressAdded(partyContactMechanism: PartyContactMechanism): void {

    if (!!this.communicationEvent.FromParty) {
      this.communicationEvent.FromParty.AddPartyContactMechanism(partyContactMechanism);
    }

    const address = partyContactMechanism.ContactMechanism as PostalAddress;

    this.fromPostalAddresses.push(address);
    this.communicationEvent.PostalAddress = address;
  }

  public toAddressAdded(partyContactMechanism: PartyContactMechanism): void {

    if (!!this.communicationEvent.ToParty) {
      this.communicationEvent.ToParty.AddPartyContactMechanism(partyContactMechanism);
    }

    const address = partyContactMechanism.ContactMechanism as PostalAddress;

    this.toPostalAddresses.push(address);
    this.communicationEvent.PostalAddress = address;
  }

  public fromPartyAdded(fromParty: Person): void {
    this.addContactRelationship(fromParty);
    this.communicationEvent.FromParty = fromParty;
    this.contacts.push(fromParty);
  }

  public toPartyAdded(toParty: Person): void {
    this.addContactRelationship(toParty);
    this.communicationEvent.ToParty = toParty;
    this.contacts.push(toParty);
  }

  private addContactRelationship(party: Person): void {
    if (this.organisation) {
      const relationShip: OrganisationContactRelationship = this.allors.context.create('OrganisationContactRelationship') as OrganisationContactRelationship;
      relationShip.Contact = party;
      relationShip.Organisation = this.organisation;
    }
  }

  public fromPartySelected(party: Party) {
    if (party) {
      this.updateFromParty(party);
    }
  }

  private updateFromParty(party: Party): void {
    const { pull, tree, x } = this.metaService;

    const pulls = [
      pull.Party({
        object: party.id,
        fetch: {
          PartyContactMechanisms: {
            include: {
              ContactMechanism: {
                ContactMechanismType: x
              }
            }
          }
        },
      })
    ];

    this.allors.context
      .load('Pull', new PullRequest({ pulls }))
      .subscribe((loaded) => {

        const partyContactMechanisms: PartyContactMechanism[] = loaded.collections.PartyContactMechanisms as PartyContactMechanism[];
        this.fromPostalAddresses = partyContactMechanisms.filter((v) => v.ContactMechanism.objectType === this.metaService.m.PostalAddress).map((v) => v.ContactMechanism);
      }, this.errorService.handler);
  }

  public toPartySelected(party: Party) {
    if (party) {
      this.updateToParty(party);
    }
  }

  private updateToParty(party: Party): void {
    const { pull, tree, x } = this.metaService;

    const pulls = [
      pull.Party({
        object: party.id,
        fetch: {
          PartyContactMechanisms: {
            include: {
              ContactMechanism: {
                ContactMechanismType: x
              }
            }
          }
        },
      })
    ];

    this.allors.context
      .load('Pull', new PullRequest({ pulls }))
      .subscribe((loaded) => {

        const partyContactMechanisms: PartyContactMechanism[] = loaded.collections.PartyContactMechanisms as PartyContactMechanism[];
        this.toPostalAddresses = partyContactMechanisms.filter((v) => v.ContactMechanism.objectType === this.metaService.m.PostalAddress).map((v) => v.ContactMechanism);
      }, this.errorService.handler);
  }
  public addressAdded(partyContactMechanism: PartyContactMechanism): void {

    this.party.AddPartyContactMechanism(partyContactMechanism);

    const postalAddress = partyContactMechanism.ContactMechanism as PostalAddress;
    this.fromPostalAddresses.push(postalAddress);
    this.communicationEvent.PostalAddress = postalAddress;
  }

  public save(): void {

    this.allors.context.save().subscribe(
      () => {
        const data: ObjectData = {
          id: this.communicationEvent.id,
          objectType: this.communicationEvent.objectType,
        };

        this.dialogRef.close(data);
      },
      (error: Error) => {
        this.errorService.handle(error);
      }
    );
  }
}
