import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subscription, combineLatest } from 'rxjs';

import { ErrorService, ContextService, MetaService, RefreshService } from '../../../../../angular';
import { WorkEffortPartyAssignment, Person, WorkEffort, Party } from '../../../../../domain';
import { PullRequest, Sort } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { StateService } from '../../../services/state';
import { switchMap, map } from 'rxjs/operators';
import { EditData, CreateData, ObjectData } from 'src/allors/material/base/services/object';

@Component({
  templateUrl: './workeffortpartyassignment-edit.component.html',
  providers: [ContextService]
})
export class WorkEffortPartyAssignmentEditComponent implements OnInit, OnDestroy {

  readonly m: Meta;

  workEffortPartyAssignment: WorkEffortPartyAssignment;
  people: Person[];
  person: Person;
  party: Party;
  workEffort: WorkEffort;
  assignment: WorkEffort;
  contacts: Person[] = [];
  title: string;

  private subscription: Subscription;

  constructor(
    @Self() private allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: CreateData & EditData,
    public dialogRef: MatDialogRef<WorkEffortPartyAssignmentEditComponent>,
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
            pull.WorkEffortPartyAssignment({
              object: this.data.id,
              include: {
                Assignment: x,
                Party: x
              }
            }),
            pull.Party({
              object: this.data.associationId
            }),
            pull.WorkEffort({
              object: this.data.associationId
            }),
            pull.Person({
              sort: new Sort(m.Person.PartyName)
            }),
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

        this.people = loaded.collections.People as Person[];
        this.party = loaded.objects.Party as Party;
        this.workEffort = loaded.objects.WorkEffort as WorkEffort;

        if (isCreate) {
          this.title = 'Add Work Effort Assignment';

          this.workEffortPartyAssignment = this.allors.context.create('WorkEffortPartyAssignment') as WorkEffortPartyAssignment;

          if (this.party !== undefined && this.party.objectType.name === m.Person.name) {
            this.person = this.party as Person;
            this.workEffortPartyAssignment.Party = this.person;
          }

          if (this.workEffort !== undefined && this.workEffort.objectType.name === m.WorkTask.name) {
            this.assignment = this.workEffort as WorkEffort;
            this.workEffortPartyAssignment.Assignment = this.assignment;
          }

        } else {
          this.workEffortPartyAssignment = loaded.objects.WorkEffortPartyAssignment as WorkEffortPartyAssignment;
          this.person = this.workEffortPartyAssignment.Party as Person;
          this.assignment = this.workEffortPartyAssignment.Assignment;

          if (this.workEffortPartyAssignment.CanWriteFromDate) {
            this.title = 'Edit Work Effort Assignment';
          } else {
            this.title = 'View Work Effort Assignment';
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
          id: this.workEffortPartyAssignment.id,
          objectType: this.workEffortPartyAssignment.objectType,
        };

        this.dialogRef.close(data);
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }
}
