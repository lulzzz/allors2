import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatCardModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatListModule, MatMenuModule, MatRadioModule, MatToolbarModule, MatTooltipModule, MatOptionModule, MatSelectModule, MatInputModule, MatExpansionModule } from '@angular/material';


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

import { CatalogueComponent } from './catalogue.component';
export { CatalogueComponent } from './catalogue.component';

@NgModule({
  declarations: [
    CatalogueComponent,
  ],
  exports: [
    CatalogueComponent,
  ],
  imports: [
    AllorsMaterialFileModule,
    AllorsMaterialInputModule,
    AllorsMaterialLocalisedTextModule,
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
    MatExpansionModule,
    MatRadioModule,
    MatSelectModule,
    MatToolbarModule,
    MatTooltipModule,
    MatOptionModule,
    ReactiveFormsModule,
    RouterModule,
  ],
})
export class CatalogueModule { }