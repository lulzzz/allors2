import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatCardModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatListModule, MatMenuModule, MatRadioModule, MatToolbarModule, MatTooltipModule, MatOptionModule, MatSelectModule, MatInputModule, MatButtonToggleModule } from '@angular/material';

import { AllorsMaterialFileModule, AllorsMaterialTableModule, AllorsMaterialFactoryFabModule } from '../../../../..';

import { RepeatingSalesInvoiceOverviewPanelComponent } from './repeatingsalesinvoice-overview-panel.component';
export { RepeatingSalesInvoiceOverviewPanelComponent } from './repeatingsalesinvoice-overview-panel.component';

@NgModule({
  declarations: [
    RepeatingSalesInvoiceOverviewPanelComponent,
  ],
  exports: [
    RepeatingSalesInvoiceOverviewPanelComponent,
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
export class RepeatingSalesInvoiceOverviewPanelModule { }
