import { Component, Input } from '@angular/core';
import { ISessionObject } from '../../../../allors/domain';
import { MetaDomain, RoleType } from '../../../../allors/meta';

import { Field } from './Field';

@Component({
  selector: 'a-md-checkbox',
  template: `
<md-input-container>
  <md-checkbox [(ngModel)]="model" [name]="name" [disabled]="!canWrite" [required]="required">
  {{label}}
  </md-checkbox>
</md-input-container>
`,
})
export class CheckboxComponent extends Field {
}