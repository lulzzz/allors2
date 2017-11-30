import { Component, EventEmitter, OnInit , Output } from "@angular/core";

import { MetaDomain, SalesOrder, SalesInvoice, Good, SalesInvoiceItem, Catalogue, Singleton, Locale, ProductCategory, CatScope, PartyContactMechanism, Enumeration, ContactMechanismType, TelecommunicationsNumber, WorkEffortAssignment, WorkEffortState, Priority, Person, WorkTask, WorkEffortPurpose, CommunicationEvent, Organisation, OrganisationContactRelationship, ContactMechanism, PersonRole, CustomerRelationship } from "@allors/workspace";
import { Scope, WorkspaceService, Saved, ErrorService, Loaded, Invoked } from "@allors/base-angular";
import { Fetch, TreeNode, Path, Query, PullRequest, And, Predicate, Like, ContainedIn, Page, Sort, Equals } from "@allors/framework";

@Component({
  selector: "person-inline",
  template:
`
  <a-mat-select [object]="person" [roleType]="m.Person.PersonRoles" [options]="roles" display="Name"></a-mat-select>
  <a-mat-input [object]="person" [roleType]="m.Person.FirstName" ></a-mat-input>
  <a-mat-input [object]="person" [roleType]="m.Person.MiddleName" ></a-mat-input>
  <a-mat-input [object]="person" [roleType]="m.Person.LastName" ></a-mat-input>
  <a-mat-select [object]="person" [roleType]="m.Person.Gender" [options]="genders" display="Name" ></a-mat-select>
  <a-mat-select [object]="person" [roleType]="m.Person.Salutation" [options]="salutations" display="Name"></a-mat-select>
  <a-mat-select [object]="person" [roleType]="m.Person.Locale" [options]="locales" display="Name"></a-mat-select>

  <button mat-button color="primary" type="button" (click)="save()">Save</button>
  <button mat-button color="secondary" type="button"(click)="cancel()">Cancel</button>
`,
})
export class PersonInlineComponent implements OnInit {

  @Output()
  public saved: EventEmitter<string> = new EventEmitter<string>();

  @Output()
  public cancelled: EventEmitter<any> = new EventEmitter();

  public person: Person;

  public m: MetaDomain;

  public locales: Locale[];
  public genders: Enumeration[];
  public salutations: Enumeration[];
  public roles: PersonRole[];

  private scope: Scope;

  constructor(private workspaceService: WorkspaceService, private errorService: ErrorService) {

    this.scope = this.workspaceService.createScope()
    this.m = this.workspaceService.metaPopulation.metaDomain;
  }

  public ngOnInit(): void {
    const query: Query[] = [
      new Query(
        {
          name: "locales",
          objectType: this.m.Locale,
        }),
      new Query(
        {
          name: "genders",
          objectType: this.m.GenderType,
        }),
      new Query(
        {
          name: "salutations",
          objectType: this.m.Salutation,
        }),
      new Query(
        {
          name: "roles",
          objectType: this.m.PersonRole,
        }),
    ];

    this.scope
      .load("Pull", new PullRequest({ query }))
      .subscribe((loaded: Loaded) => {
        this.locales = loaded.collections.locales as Locale[];
        this.genders = loaded.collections.genders as Enumeration[];
        this.salutations = loaded.collections.salutations as Enumeration[];
        this.roles = loaded.collections.roles as PersonRole[];

        this.person = this.scope.session.create("Person") as Person;
      },
      (error: any) => {
        this.cancelled.emit();
      },
    );
  }

  public cancel(): void {
    this.cancelled.emit();
  }

  public save(): void {
    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.saved.emit(this.person.id);
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }
}