import { RoleType } from '../../meta';

import { Predicate } from './Predicate';

export class GreaterThan implements Predicate {
  public roleType: RoleType;
  public value: any;

  constructor(fields?: Partial<GreaterThan>) {
    Object.assign(this, fields);
  }

  public toJSON(): any {
    return {
      kind: 'GreaterThan',
      roletype: this.roleType.id,
      value: this.value,
    };
  }
}
