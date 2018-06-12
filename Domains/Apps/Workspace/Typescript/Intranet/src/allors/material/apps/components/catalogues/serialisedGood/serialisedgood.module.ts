import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatCardModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatListModule, MatMenuModule, MatRadioModule, MatToolbarModule, MatTooltipModule, MatOptionModule, MatSelectModule, MatInputModule, MatTabsModule, MatAutocompleteModule, MatExpansionModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AllorsMaterialAutoCompleteModule } from '../../../../base/components/autocomplete';
import { AllorsMaterialChipsModule } from '../../../../base/components/chips';
import { AllorsMaterialDatepickerModule } from '../../../../base/components/datepicker';
import { AllorsMaterialFileModule } from '../../../../base/components/file';
import { AllorsMaterialFilesModule } from '../../../../base/components/files';
import { AllorsMaterialInputModule } from '../../../../base/components/input';
import { AllorsMaterialLocalisedTextModule } from '../../../../base/components/localisedtext';
import { AllorsMaterialSelectModule } from '../../../../base/components/select';
import { AllorsMaterialSideNavToggleModule } from '../../../../base/components/sidenavtoggle';
import { AllorsMaterialSlideToggleModule } from '../../../../base/components/slidetoggle';
import { AllorsMaterialStaticModule } from '../../../../base/components/static';
import { AllorsMaterialTextAreaModule } from '../../../../base/components/textarea';

import { BrandInlineModule } from '../brand/brand-inline.module';
import { ModelInlineModule } from '../model/model-inline.module';

import { SerialisedGoodComponent } from './serialisedgood.component';
export { SerialisedGoodComponent } from './serialisedgood.component';

@NgModule({
  declarations: [
    SerialisedGoodComponent,
  ],
  exports: [
    SerialisedGoodComponent,
  ],
  imports: [
    AllorsMaterialAutoCompleteModule,
    AllorsMaterialDatepickerModule,
    AllorsMaterialFileModule,
    AllorsMaterialFilesModule,
    AllorsMaterialInputModule,
    AllorsMaterialLocalisedTextModule,
    AllorsMaterialSelectModule,
    AllorsMaterialSideNavToggleModule,
    AllorsMaterialSlideToggleModule,
    AllorsMaterialStaticModule,
    AllorsMaterialTextAreaModule,
    BrandInlineModule,
    CommonModule,
    FlexLayoutModule,
    FormsModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatCardModule,
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
    ModelInlineModule,
    ReactiveFormsModule,
    RouterModule,  
  ],
})
export class SerialisedGoodModule { }
