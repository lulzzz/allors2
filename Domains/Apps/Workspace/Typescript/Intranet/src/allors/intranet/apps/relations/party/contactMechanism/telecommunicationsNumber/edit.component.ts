import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy, OnInit } from "@angular/core";
import { Validators } from "@angular/forms";
import { MatSnackBar, MatSnackBarConfig } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { TdMediaService } from "@covalent/core";
import { Observable, Subject, Subscription } from "rxjs/Rx";

import { MetaDomain } from "@allors";
import { Equals, Fetch, Like, Page, Path, PullRequest, PushResponse, Query, Sort, TreeNode } from "@allors";
import { Enumeration, Organisation, PartyContactMechanism, TelecommunicationsNumber } from "@allors";
import { AllorsService, ErrorService, Loaded, Saved, Scope } from "@allors";

@Component({
  templateUrl: "./form.component.html",
})
export class PartyContactMechanismEditTelecommunicationsNumberComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  title: string = "Telecommunications Number";
  subTitle: string = "edit telecommunications number";

  m: MetaDomain;

  partyContactMechanism: PartyContactMechanism;
  contactMechanism: TelecommunicationsNumber;
  contactMechanismPurposes: Enumeration[];
  contactMechanismTypes: Enumeration[];

  constructor(
    private allors: AllorsService,
    private errorService: ErrorService,
    private route: ActivatedRoute,
    public media: TdMediaService, private changeDetectorRef: ChangeDetectorRef) {

    this.scope = new Scope(allors.database, allors.workspace);
    this.m = this.allors.meta;
  }

  ngOnInit(): void {
    this.subscription = this.route.url
      .switchMap((url: any) => {

        const roleId: string = this.route.snapshot.paramMap.get("roleId");
        const m: MetaDomain = this.m;

        const fetch: Fetch[] = [
          new Fetch({
            name: "partyContactMechanism",
            id: roleId,
            include: [
              new TreeNode({ roleType: m.PartyContactMechanism.ContactPurposes }),
              new TreeNode({
                roleType: m.PartyContactMechanism.ContactMechanism,
                nodes: [new TreeNode({ roleType: m.ContactMechanism.ContactMechanismType })],
              }),
            ],
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              name: "contactMechanismPurposes",
              objectType: this.m.ContactMechanismPurpose,
            }),
          new Query(
            {
              name: "contactMechanismTypes",
              objectType: this.m.ContactMechanismType,
            }),
        ];

        this.scope.session.reset();

        return this.scope
          .load("Pull", new PullRequest({ fetch, query }));
      })
      .subscribe((loaded: Loaded) => {

        this.partyContactMechanism = loaded.objects.partyContactMechanism as PartyContactMechanism;
        this.contactMechanism = this.partyContactMechanism.ContactMechanism as TelecommunicationsNumber;
        this.contactMechanismPurposes = loaded.collections.contactMechanismPurposes as Enumeration[];
        this.contactMechanismTypes = loaded.collections.contactMechanismTypes as Enumeration[];
      },
      (error: any) => {
        this.errorService.message(error);
        this.goBack();
      },
    );
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
    this.changeDetectorRef.detectChanges();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  save(): void {

    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.goBack();
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }

  goBack(): void {
    window.history.back();
  }
}