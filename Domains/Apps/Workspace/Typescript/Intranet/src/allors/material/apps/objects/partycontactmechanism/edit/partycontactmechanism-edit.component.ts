import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subscription, combineLatest } from 'rxjs';

import { ErrorService, ContextService, MetaService, RefreshService } from '../../../../../angular';
import { Enumeration, TelecommunicationsNumber, ElectronicAddress, ContactMechanism, PartyContactMechanism, Organisation, OrganisationContactRelationship, Party } from '../../../../../domain';
import { PullRequest, Sort, Equals } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { StateService } from '../../../services/state';
import { switchMap, map } from 'rxjs/operators';
import { EditData, CreateData, ObjectData } from 'src/allors/material/base/services/object';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  templateUrl: './partycontactmechanism-edit.component.html',
  providers: [ContextService]
})
export class PartyContactmechanismEditComponent implements OnInit, OnDestroy {

  readonly m: Meta;

  partyContactMechanism: PartyContactMechanism;
  contactMechanismPurposes: Enumeration[];
  contactMechanisms: ContactMechanism[] = [];
  organisationContactMechanisms: ContactMechanism[];
  ownContactMechanisms: ContactMechanism[] = [];
  title: string;

  private subscription: Subscription;
  party: Party;

  constructor(
    @Self() private allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: CreateData & EditData,
    public dialogRef: MatDialogRef<PartyContactmechanismEditComponent>,
    public metaService: MetaService,
    public refreshService: RefreshService,
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

          const pulls = [
            pull.PartyContactMechanism({
              object: this.data.id,
              include: {
                ContactMechanism: {
                  PostalAddress_PostalBoundary: {
                    Country: x
                  }
                }
              },
            }),
            pull.Party({
              object: this.data.associationId,
            }),
            pull.Person({
              object: this.data.associationId,
              fetch: {
                CurrentOrganisationContactMechanisms: {
                  include: {
                    PostalAddress_PostalBoundary: {
                      Country: x
                    }
                  }
                }
              }
            }),
            pull.Party({
              object: this.data.associationId,
              name: 'test',
              fetch: {
                PartyContactMechanisms: {
                  include: {
                    ContactMechanism: {
                      PostalAddress_PostalBoundary: {
                        Country: x
                      }
                    }
                  }
                }
              }
            }),
            pull.ContactMechanismPurpose({
              predicate: new Equals({ propertyType: m.ContactMechanismPurpose.IsActive, value: true }),
              sort: new Sort(this.m.ContactMechanismPurpose.Name)
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

        this.contactMechanisms = [];
        this.ownContactMechanisms = [];

        this.contactMechanismPurposes = loaded.collections.ContactMechanismPurposes as Enumeration[];
        this.organisationContactMechanisms = loaded.collections.CurrentOrganisationContactMechanisms as ContactMechanism[];

        const partyContactMechanisms = loaded.collections.test as PartyContactMechanism[];
        partyContactMechanisms.forEach(v => this.ownContactMechanisms.push(v.ContactMechanism));

        if (this.organisationContactMechanisms !== undefined) {
          this.contactMechanisms = this.contactMechanisms.concat(this.organisationContactMechanisms);
        }

        if (this.ownContactMechanisms !== undefined) {
          this.contactMechanisms = this.contactMechanisms.concat(this.ownContactMechanisms);
        }

        if (isCreate) {
          this.title = 'Add Party ContactMechanism';

          this.partyContactMechanism = this.allors.context.create('PartyContactMechanism') as PartyContactMechanism;
          this.partyContactMechanism.FromDate = new Date();
          this.partyContactMechanism.UseAsDefault = true;

          this.party = loaded.objects.Party as Party;
          this.party.AddPartyContactMechanism(this.partyContactMechanism);
        } else {
          this.partyContactMechanism = loaded.objects.PartyContactMechanism as PartyContactMechanism;

          if (this.partyContactMechanism.CanWriteComment) {
            this.title = 'Edit Party ContactMechanism';
          } else {
            this.title = 'View Party ContactMechanism';
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

    this.allors.context.save()
      .subscribe(() => {
        const data: ObjectData = {
          id: this.partyContactMechanism.id,
          objectType: this.partyContactMechanism.objectType,
        };

        this.dialogRef.close(data);
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }
}
