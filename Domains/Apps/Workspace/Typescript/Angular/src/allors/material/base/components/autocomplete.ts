import { Component, Input, Output, OnInit, EventEmitter , ChangeDetectorRef } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ISessionObject } from '../../../../allors/domain';
import { MetaDomain, RoleType } from '../../../../allors/meta';
import { Observable } from 'rxjs';

import { Field } from '../../../angular';

@Component({
  selector: 'a-md-autocomplete',
  template: `
<md-input-container fxLayout="column" fxLayoutAlign="top stretch">
  <input type="text" mdInput (focusout)="focusout($event)" [formControl]="searchControl" [mdAutocomplete]="usersComp" [placeholder]="label" [required]="required" [disabled]="disabled" [readonly]="readonly">
  <md-hint *ngIf="hint">{{hint}}</md-hint>
</md-input-container>

<md-autocomplete #usersComp="mdAutocomplete" [displayWith]="displayFn()">
  <md-option *ngFor="let option of filteredOptions | async" [value]="option" (onSelectionChange)="selected(option)">
  {{option[this.display]}}
  </md-option>
</md-autocomplete>
`,
})
export class AutocompleteComponent extends Field implements OnInit {
  @Input()
  display: string = 'display';

  @Input()
  debounceTime: number = 400;

  @Input()
  options: ISessionObject[];

  @Input()
  filter: ((search: string) => Observable<ISessionObject[]>);

  @Output()
  onSelect: EventEmitter<ISessionObject> = new EventEmitter();

  filteredOptions: Observable<ISessionObject[]>;

  searchControl: FormControl = new FormControl();

  ngOnInit(): void {
    if (this.filter) {
      this.filteredOptions = Observable.of(new Array<ISessionObject>())
        .concat(this.searchControl
          .valueChanges
          .debounceTime(this.debounceTime)
          .distinctUntilChanged()
          .switchMap((search: string) => {
            return this.filter(search);
          }));
    } else {
      this.filteredOptions = Observable.of(new Array<ISessionObject>())
        .concat(this.searchControl
          .valueChanges
          .debounceTime(this.debounceTime)
          .distinctUntilChanged()
          .map((search: string) => {
            const lowerCaseSearch: string = search.trim().toLowerCase();
            return this.options
              .filter((v: ISessionObject) => {
                const optionDisplay: string = v[this.display] ? v[this.display].toString().toLowerCase() : undefined;
                if (optionDisplay) {
                  return optionDisplay.indexOf(lowerCaseSearch) !== -1;
                }
              })
              .sort((a: ISessionObject, b: ISessionObject) => a[this.display] !== b[this.display] ? a[this.display] < b[this.display] ? -1 : 1 : 0);
          }));
    }

    this.searchControl.setValue(this.model);
  }

  displayFn(): (val: ISessionObject) => string {
    return (val: ISessionObject) => {
      if (val) {
        return val ? val[this.display] : '';
      }
    };
  }

  selected(option: ISessionObject): void {
    this.model = option;
    this.onSelect.emit(option);
  }

  focusout(): void {
    if (!this.searchControl.value) {
      this.model = undefined;
      this.onSelect.emit(undefined);
    } else {
    }
  }
}