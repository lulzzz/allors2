import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatDialogModule, MatChipsModule, MatToolbarModule, MatStepperModule, MatSelectModule } from '@angular/material';

import { AllorsFocusModule } from '../../../../angular';
import { AllorsMaterialFilterDialogComponent } from './filter-dialog.component';

export { FilterDefinition } from './FilterDefinition';
export { FilterType } from './FilterType';
export { FilterPredicate } from './FilterPredicate';

import { AllorsMaterialFilterService } from './filter.service';
export { AllorsMaterialFilterService } from './filter.service';

import { AllorsMaterialFilterComponent } from './filter.component';
export { AllorsMaterialFilterComponent } from './filter.component';

@NgModule({
  declarations: [
    AllorsMaterialFilterComponent,
    AllorsMaterialFilterDialogComponent
  ],
  exports: [
    AllorsMaterialFilterComponent,
    AllorsMaterialFilterDialogComponent
  ],
  entryComponents: [
    AllorsMaterialFilterDialogComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatChipsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatStepperModule,
    MatToolbarModule,
    AllorsFocusModule
  ],
})
export class AllorsMaterialFilterModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AllorsMaterialFilterModule,
      providers: [ AllorsMaterialFilterService ]
    };
  }
}
