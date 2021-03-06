import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subscription, combineLatest } from 'rxjs';

import { ErrorService, ContextService, MetaService, RefreshService } from '../../../../../angular';
import { PostalAddress, PostalBoundary, Country, Party, PartyContactMechanism } from '../../../../../domain';
import { PullRequest, Sort } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { StateService } from '../../../services/state';
import { switchMap, map } from 'rxjs/operators';
import { EditData, ObjectData } from 'src/allors/material/base/services/object';

@Component({
  templateUrl: './postaladdress-edit.component.html',
  providers: [ContextService]
})
export class PostalAddressEditComponent implements OnInit, OnDestroy {

  readonly m: Meta;

  contactMechanism: PostalAddress;
  postalBoundary: PostalBoundary;
  countries: Country[];
  title: string;

  private subscription: Subscription;
  party: Party;
  partyContactMechanism: PartyContactMechanism;

  constructor(
    @Self() private allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: EditData,
    public dialogRef: MatDialogRef<PostalAddressEditComponent>,
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

          const pulls = [
            pull.ContactMechanism({
              object: this.data.id,
              include: {
                PostalAddress_PostalBoundary: {
                  Country: x
                }
              },
            }),
            pull.Country({
              sort: new Sort(m.Country.Name)
            })
          ];

          return this.allors.context
            .load('Pull', new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {

        this.allors.context.reset();

        this.countries = loaded.collections.Countries as Country[];
        this.contactMechanism = loaded.objects.ContactMechanism as PostalAddress;

        if (this.contactMechanism.CanWriteAddress1) {
          this.title = 'Edit Postal Address';
        } else {
          this.title = 'View Postal Address';
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
          id: this.contactMechanism.id,
          objectType: this.contactMechanism.objectType,
        };

        this.dialogRef.close(data);
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }
}
