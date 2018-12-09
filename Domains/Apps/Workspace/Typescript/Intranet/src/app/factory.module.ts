import { NgModule, ModuleWithProviders, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material';

import { ids } from '../allors/meta/generated';

import { FactoryService, FactoryConfig } from '../allors/angular/base/factory';

import { EmailCommunicationCreateComponent, EmailCommunicationCreateModule } from '../allors/material/apps/objects/emailcommunication/create/emailcommunication-create.module';
import { OrganisationCreateModule, OrganisationCreateComponent } from '../allors/material/apps/objects/organisation/create/organisation-create.module';
import { PersonCreateModule, PersonCreateComponent } from '../allors/material/apps/objects/person/create/person-create.module';

const factoryConfig: FactoryConfig = new FactoryConfig({
  items:
    [
      { id: ids.EmailCommunication, component: EmailCommunicationCreateComponent },
      { id: ids.Organisation, component: OrganisationCreateComponent },
      { id: ids.Person, component: PersonCreateComponent }
    ]
});

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,

    EmailCommunicationCreateModule,
    OrganisationCreateModule,
    PersonCreateModule
  ],
  entryComponents: [
    EmailCommunicationCreateComponent,
    OrganisationCreateComponent,
    PersonCreateComponent
  ],
  providers: [
    FactoryService,
    { provide: FactoryConfig, useValue: factoryConfig },
  ]
})
export class FactoryModule {

  constructor(@Optional() @SkipSelf() core: FactoryModule) {
    if (core) {
      throw new Error('Use FactoryModule from AppModule');
    }
  }

}