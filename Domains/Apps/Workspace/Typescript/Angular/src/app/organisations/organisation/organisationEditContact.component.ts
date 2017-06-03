import { Observable, Subject, Subscription } from 'rxjs/Rx';
import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MdSnackBar, MdSnackBarConfig } from '@angular/material';
import { TdMediaService } from '@covalent/core';

import { Scope } from '../../../allors/angular/base/Scope';
import { AllorsService } from '../../allors.service';
import { Organisation, Person, Locale, OrganisationContactRelationship, OrganisationContactKind, Enumeration } from '../../../allors/domain';

@Component({
  templateUrl: './organisationContact.component.html',
})
export class OrganisationEditContactComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  locales: Locale[];
  genders: Enumeration[];
  salutations: Enumeration[];
  organisationContactKinds: Enumeration[];

  form: FormGroup;
  id: string;

  constructor(private allors: AllorsService,
    private route: ActivatedRoute,
    public fb: FormBuilder,
    public snackBar: MdSnackBar,
    public media: TdMediaService) {
    this.scope = new Scope('OrganisationContactRelationship', allors.database, allors.workspace);
  }

  ngOnInit(): void {
    this.subscription = this.route.url
      .mergeMap((url: any) => {

        this.id = this.route.snapshot.paramMap.get('contactId');

        this.form = this.fb.group({
          OrganisationContactKind: [''],
          FirstName: [''],
          MiddleName: [''],
          LastName: ['', Validators.required],
          Function: [''],
          Gender: ['', Validators.required],
          Salutation: [''],
          Locale: [''],
        });

        this.scope.session.reset();

        return this.scope
          .load({ id: this.id })
          .do(() => {
            this.locales = this.scope.collections.locales as Locale[];
            this.genders = this.scope.collections.genders as Enumeration[];
            this.salutations = this.scope.collections.salutations as Enumeration[];
            this.organisationContactKinds = this.scope.collections.organisationContactKinds as Enumeration[];

            const organisationContactRelationship: OrganisationContactRelationship = this.scope.objects.organisationContactRelationship as OrganisationContactRelationship;
            const contact: Person = this.scope.objects.contact as Person;

            this.form.controls.OrganisationContactKind.patchValue(organisationContactRelationship.ContactKinds);
            this.form.controls.FirstName.patchValue(contact.FirstName);
            this.form.controls.MiddleName.patchValue(contact.MiddleName);
            this.form.controls.LastName.patchValue(contact.LastName);
            this.form.controls.Gender.patchValue(contact.Gender);
            this.form.controls.Salutation.patchValue(contact.Salutation);
            this.form.controls.Locale.patchValue(contact.Locale);
          })
          .catch((e: any) => {
            this.snackBar.open(e.toString(), 'close', { duration: 5000 });
            this.goBack();
            return Observable.empty()
          });
      })
      .subscribe();
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  save(event: Event): void {

    const organisationContactRelationship: OrganisationContactRelationship = this.scope.session.get(this.id) as OrganisationContactRelationship;

    let person = organisationContactRelationship.Contact as Person
    person.FirstName = this.form.controls.FirstName.value;
    person.MiddleName = this.form.controls.MiddleName.value;
    person.LastName = this.form.controls.LastName.value;
    person.Gender = this.form.controls.Gender.value;
    person.Salutation = this.form.controls.Salutation.value;
    person.Locale = this.form.controls.Locale.value;

    this.scope
      .save()
      .toPromise()
      .then(() => {
        this.goBack();
      })
      .catch((e: any) => {
        this.snackBar.open(e.toString(), 'close', { duration: 5000 });
      });
  }

  goBack(): void {
    window.history.back();
  }
}