import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatListModule, MatMenuModule, MatRadioModule, MatToolbarModule, MatTooltipModule, MatOptionModule, MatSelectModule, MatInputModule, MatTabsModule, MatDatepickerModule } from '@angular/material';


import { AllorsMaterialChipsModule } from '../../../../base/components/chips';
import { AllorsMaterialDatepickerModule } from '../../../../base/components/datepicker';
import { AllorsMaterialDatetimepickerModule } from '../../../../base/components/datetimepicker';
import { AllorsMaterialFileModule } from '../../../../base/components/file';
import { AllorsMaterialFooterModule } from '../../../../base/components/footer';
import { AllorsMaterialInputModule } from '../../../../base/components/input';
import { AllorsMaterialSelectModule } from '../../../../base/components/select';
import { AllorsMaterialSideNavToggleModule } from '../../../../base/components/sidenavtoggle';
import { AllorsMaterialSlideToggleModule } from '../../../../base/components/slidetoggle';
import { AllorsMaterialStaticModule } from '../../../../base/components/static';
import { AllorsMaterialTextAreaModule } from '../../../../base/components/textarea';

import { PersonInlineModule } from '../../person/inline/person-inline.module';
import { TelecommunicationsNumberInlineModule } from '../../telecommunicationsnumber/inline/telecommunicationsnumber-inline.module';

import { EditPhoneCommunicationComponent } from './phonecommunication-edit.component';
export { EditPhoneCommunicationComponent } from './phonecommunication-edit.component';

@NgModule({
  declarations: [
    EditPhoneCommunicationComponent,
  ],
  exports: [
    EditPhoneCommunicationComponent,
  ],
  imports: [

    AllorsMaterialChipsModule,
    AllorsMaterialDatepickerModule,
    AllorsMaterialDatetimepickerModule,
    AllorsMaterialFileModule,
    AllorsMaterialFooterModule,
    AllorsMaterialInputModule,
    AllorsMaterialSelectModule,
    AllorsMaterialSideNavToggleModule,
    AllorsMaterialSlideToggleModule,
    AllorsMaterialStaticModule,
    AllorsMaterialTextAreaModule,
    CommonModule,

    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatRadioModule,
    MatSelectModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatOptionModule,
    TelecommunicationsNumberInlineModule,
    PersonInlineModule,
    ReactiveFormsModule,
    RouterModule,
  ],
})
export class PhoneCommunicationModule { }