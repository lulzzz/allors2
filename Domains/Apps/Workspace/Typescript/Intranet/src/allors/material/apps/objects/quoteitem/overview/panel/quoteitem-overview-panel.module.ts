import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatCardModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatListModule, MatMenuModule, MatRadioModule, MatToolbarModule, MatTooltipModule, MatOptionModule, MatSelectModule, MatInputModule, MatButtonToggleModule } from '@angular/material';

import { AllorsMaterialFileModule, AllorsMaterialTableModule, AllorsMaterialFactoryFabModule } from '../../../../..';

import { QuoteItemOverviewPanelComponent } from './quoteitem-overview-panel.component';
export { QuoteItemOverviewPanelComponent } from './quoteitem-overview-panel.component';

@NgModule({
  declarations: [
    QuoteItemOverviewPanelComponent,
  ],
  exports: [
    QuoteItemOverviewPanelComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,

    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatRadioModule,
    MatSelectModule,
    MatToolbarModule,
    MatTooltipModule,
    MatButtonToggleModule,
    MatOptionModule,

    AllorsMaterialFactoryFabModule,
    AllorsMaterialFileModule,
    AllorsMaterialTableModule,
  ],
})
export class QuoteItemOverviewPanelModule { }
