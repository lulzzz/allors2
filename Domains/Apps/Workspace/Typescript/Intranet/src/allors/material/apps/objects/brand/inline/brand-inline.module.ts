import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatListModule, MatMenuModule, MatRadioModule, MatToolbarModule, MatTooltipModule, MatOptionModule, MatSelectModule, MatInputModule, MatTabsModule, MatDatepickerModule, MatExpansionModule, MatDialogModule } from '@angular/material';

import { AllorsMaterialAutoCompleteModule } from '../../../../base/components/role/autocomplete';

import { AllorsMaterialChipsModule } from '../../../../base/components/role/chips';
import { AllorsMaterialDatepickerModule } from '../../../../base/components/role/datepicker';
import { AllorsMaterialFileModule } from '../../../../base/components/role/file';
import { AllorsMaterialInputModule } from '../../../../base/components/role/input';
import { AllorsMaterialLocalisedTextModule } from '../../../../base/components/role/localisedtext';
import { AllorsMaterialSelectModule } from '../../../../base/components/role/select';
import { AllorsMaterialSlideToggleModule } from '../../../../base/components/role/slidetoggle';
import { AllorsMaterialStaticModule } from '../../../../base/components/role/static';
import { AllorsMaterialTextAreaModule } from '../../../../base/components/role/textarea';

import { InlineBrandComponent } from './brand-inline.component';
export { InlineBrandComponent } from './brand-inline.component';

@NgModule({
  declarations: [
    InlineBrandComponent,
  ],
  exports: [
    InlineBrandComponent,

  ],
  imports: [
    AllorsMaterialAutoCompleteModule,

    AllorsMaterialChipsModule,
    AllorsMaterialDatepickerModule,
    AllorsMaterialFileModule,
    AllorsMaterialInputModule,
    AllorsMaterialLocalisedTextModule,
    AllorsMaterialSelectModule,
    AllorsMaterialSlideToggleModule,
    AllorsMaterialStaticModule,
    AllorsMaterialTextAreaModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
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
    ReactiveFormsModule,
    RouterModule,
  ],
})
export class BrandInlineModule { }
