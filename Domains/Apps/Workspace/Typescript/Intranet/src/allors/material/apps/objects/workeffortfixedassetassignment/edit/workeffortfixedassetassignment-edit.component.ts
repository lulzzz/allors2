import { Component, OnDestroy, OnInit, Self, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subscription, combineLatest } from 'rxjs';

import { ErrorService, ContextService, MetaService, RefreshService } from '../../../../../angular';
import { WorkEffort, WorkEffortFixedAssetAssignment, Enumeration, SerialisedItem } from '../../../../../domain';
import { PullRequest, Sort, Equals } from '../../../../../framework';
import { Meta } from '../../../../../meta';
import { StateService } from '../../../services/state';
import { switchMap, map } from 'rxjs/operators';
import { EditData, CreateData, ObjectData } from 'src/allors/material/base/services/object';

@Component({
  templateUrl: './workeffortfixedassetassignment-edit.component.html',
  providers: [ContextService]
})
export class WorkEffortFixedAssetAssignmentEditComponent implements OnInit, OnDestroy {

  readonly m: Meta;

  workEffortFixedAssetAssignment: WorkEffortFixedAssetAssignment;
  workEfforts: WorkEffort[];
  workEffort: WorkEffort;
  assignment: WorkEffort;
  serialisedItems: SerialisedItem[];
  serialisedItem: SerialisedItem;
  assetAssignmentStatuses: Enumeration[];
  title: string;

  private subscription: Subscription;

  constructor(
    @Self() private allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: CreateData & EditData,
    public dialogRef: MatDialogRef<WorkEffortFixedAssetAssignmentEditComponent>,
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
            pull.WorkEffortFixedAssetAssignment({
              object: this.data.id,
              include: {
                Assignment: x,
                FixedAsset: x,
                AssetAssignmentStatus: x
              }
            }),
            pull.WorkEffort({
              object: this.data.associationId
            }),
            pull.SerialisedItem({
              object: this.data.associationId,
              sort: new Sort(m.SerialisedItem.Name)
            }),
            pull.WorkEffort({
              sort: new Sort(m.WorkEffort.Name)
            }),
            pull.SerialisedItem({
              sort: new Sort(m.SerialisedItem.Name)
            }),
            pull.AssetAssignmentStatus({
              predicate: new Equals({ propertyType: m.AssetAssignmentStatus.IsActive, value: true }),
              sort: new Sort(m.AssetAssignmentStatus.Name)
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

        this.workEffort = loaded.objects.WorkEffort as WorkEffort;
        this.workEfforts = loaded.collections.WorkEfforts as WorkEffort[];
        this.serialisedItem = loaded.objects.SerialisedItem as SerialisedItem;
        this.serialisedItems = loaded.collections.SerialisedItems as SerialisedItem[];
        this.assetAssignmentStatuses = loaded.collections.AssetAssignmentStatuses as Enumeration[];

        if (isCreate) {
          this.title = 'Add Work Effort Assignment';

          this.workEffortFixedAssetAssignment = this.allors.context.create('WorkEffortFixedAssetAssignment') as WorkEffortFixedAssetAssignment;

          if (this.serialisedItem !== undefined) {
            this.workEffortFixedAssetAssignment.FixedAsset = this.serialisedItem;
          }

          if (this.workEffort !== undefined && this.workEffort.objectType.name === m.WorkTask.name) {
            this.assignment = this.workEffort as WorkEffort;
            this.workEffortFixedAssetAssignment.Assignment = this.assignment;
          }

        } else {
          this.workEffortFixedAssetAssignment = loaded.objects.WorkEffortFixedAssetAssignment as WorkEffortFixedAssetAssignment;

          if (this.workEffortFixedAssetAssignment.CanWriteFromDate) {
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
          id: this.workEffortFixedAssetAssignment.id,
          objectType: this.workEffortFixedAssetAssignment.objectType,
        };

        this.dialogRef.close(data);
      },
        (error: Error) => {
          this.errorService.handle(error);
        });
  }
}
