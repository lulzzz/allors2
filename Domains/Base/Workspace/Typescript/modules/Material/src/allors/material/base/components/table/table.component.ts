import { Component, Input, ViewChild, OnInit } from '@angular/core';

import { BaseTable } from './BaseTable';
import { Column } from './Column';
import { TableRow } from './TableRow';
import { MatSort } from '@angular/material';
import { Table } from './Table';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'a-mat-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class AllorsMaterialTableComponent implements OnInit {

  @Input()
  public table: BaseTable;

  @ViewChild(MatSort) matSort: MatSort;

  ngOnInit(): void {
    this.table.Init(this.matSort);
  }

  cellStyle(row: TableRow, column: Column): string {
    return this.action(row, column) ? 'pointer' : undefined;
  }

  onCellClick(row: TableRow, column: Column) {

    const action = this.action(row, column);
    if (action && !action.disabled(row.object)) {
      action.execute(row.object);
    }
  }

  private action(row: TableRow, column: Column) {
    return column.action || this.table.defaultAction;
  }
}
