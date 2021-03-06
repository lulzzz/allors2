import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatIconModule, MatInputModule } from '@angular/material';

import { AllorsFocusModule } from '../../../../../angular';

import { AllorsMaterialFileComponent } from './file.component';
export { AllorsMaterialFileComponent } from './file.component';

@NgModule({
  declarations: [
    AllorsMaterialFileComponent,
  ],
  exports: [
    AllorsMaterialFileComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatInputModule,
    AllorsFocusModule
  ],
})
export class AllorsMaterialFileModule {}
