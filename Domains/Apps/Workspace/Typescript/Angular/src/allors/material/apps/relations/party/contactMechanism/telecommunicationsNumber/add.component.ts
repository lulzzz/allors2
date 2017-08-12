import { Observable, Subject, Subscription } from 'rxjs/Rx';
import { Component, OnInit, AfterViewInit, OnDestroy , ChangeDetectorRef } from '@angular/core';
import { Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MdSnackBar, MdSnackBarConfig } from '@angular/material';
import { TdMediaService } from '@covalent/core';

import { MetaDomain } from '../../../../../../meta/index';
import { PullRequest, PushResponse, Fetch, Path, Query, Equals, Like, TreeNode, Sort, Page } from '../../../../../../domain';
import { Party, ContactMechanismType, PartyContactMechanism, TelecommunicationsNumber, Enumeration } from '../../../../../../domain';
import { AllorsService, ErrorService, Scope, Loaded, Saved } from '../../../../../../angular';

@Component({
  templateUrl: './form.component.html',
})
export class PartyContactMechanismAddTelecommunicationsNumberComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  title: string = 'Telecommunications Number';
  subTitle: string = 'add a telecommunications number';

  m: MetaDomain;

  party: Party;
  partyContactMechanism: PartyContactMechanism;
  contactMechanism: TelecommunicationsNumber;
  contactMechanismPurposes: Enumeration[];
  contactMechanismTypes: ContactMechanismType[];

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

        const id: string = this.route.snapshot.paramMap.get('id');
        const m: MetaDomain = this.m;

        const fetch: Fetch[] = [
          new Fetch({
            name: 'party',
            id: id,
            include: [
              new TreeNode({
                roleType: m.Party.PartyContactMechanisms,
                nodes: [
                  new TreeNode({ roleType: m.PartyContactMechanism.ContactPurposes }),
                  new TreeNode({
                    roleType: m.PartyContactMechanism.ContactMechanism,
                    nodes: [ new TreeNode( { roleType: m.ContactMechanism.ContactMechanismType})],
                   }),
                ],
              }),
            ],
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              name: 'contactMechanismPurposes',
              objectType: this.m.ContactMechanismPurpose,
            }),
          new Query(
            {
              name: 'contactMechanismTypes',
              objectType: this.m.ContactMechanismType,
            }),
        ];

        this.scope.session.reset();

        return this.scope
          .load('Pull', new PullRequest({ fetch: fetch, query: query }));
      })
      .subscribe((loaded: Loaded) => {
        this.contactMechanismPurposes = loaded.collections.contactMechanismPurposes as Enumeration[];
        this.contactMechanismTypes = loaded.collections.contactMechanismTypes as ContactMechanismType[];
        const phone: ContactMechanismType = this.contactMechanismTypes.find((v: ContactMechanismType) => v.Name === 'Phone');
        this.party = loaded.objects.party as Party;

        if (!this.contactMechanism) {
          this.contactMechanism = this.scope.session.create('TelecommunicationsNumber') as TelecommunicationsNumber;
          this.contactMechanism.ContactMechanismType = phone;
        }

        this.partyContactMechanism = this.scope.session.create('PartyContactMechanism') as PartyContactMechanism;
        this.partyContactMechanism.ContactMechanism = this.contactMechanism;
        this.partyContactMechanism.UseAsDefault = true;

        this.party.AddPartyContactMechanism(this.partyContactMechanism);
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