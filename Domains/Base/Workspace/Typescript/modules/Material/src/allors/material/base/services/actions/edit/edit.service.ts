import { Injectable } from '@angular/core';

import {RefreshService } from '../../../../../angular';
import { ObjectService } from '../../../../../material/base/services/object';

import { EditAction } from './EditAction';

@Injectable({
  providedIn: 'root',
})
export class EditService {

  constructor(
    private objectService: ObjectService,
    private refreshService: RefreshService,
    ) {}

  edit() {
    return new EditAction(this.objectService, this.refreshService);
  }

}
