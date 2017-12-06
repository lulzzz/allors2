// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "../../framework";

import { Deletable } from './Deletable.g';
import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { Person } from './Person.g';

export class Organisation extends SessionObject implements Deletable, UniquelyIdentifiable {
    get CanReadEmployees(): boolean {
        return this.canRead('Employees');
    }

    get CanWriteEmployees(): boolean {
        return this.canWrite('Employees');
    }

    get Employees(): Person[] {
        return this.get('Employees');
    }

    AddEmployee(value: Person) {
        return this.add('Employees', value);
    }

    RemoveEmployee(value: Person) {
        return this.remove('Employees', value);
    }

    set Employees(value: Person[]) {
        this.set('Employees', value);
    }

    get CanReadManager(): boolean {
        return this.canRead('Manager');
    }

    get CanWriteManager(): boolean {
        return this.canWrite('Manager');
    }

    get Manager(): Person {
        return this.get('Manager');
    }

    set Manager(value: Person) {
        this.set('Manager', value);
    }

    get CanReadName(): boolean {
        return this.canRead('Name');
    }

    get CanWriteName(): boolean {
        return this.canWrite('Name');
    }

    get Name(): string {
        return this.get('Name');
    }

    set Name(value: string) {
        this.set('Name', value);
    }

    get CanReadOwner(): boolean {
        return this.canRead('Owner');
    }

    get CanWriteOwner(): boolean {
        return this.canWrite('Owner');
    }

    get Owner(): Person {
        return this.get('Owner');
    }

    set Owner(value: Person) {
        this.set('Owner', value);
    }

    get CanReadShareholders(): boolean {
        return this.canRead('Shareholders');
    }

    get CanWriteShareholders(): boolean {
        return this.canWrite('Shareholders');
    }

    get Shareholders(): Person[] {
        return this.get('Shareholders');
    }

    AddShareholder(value: Person) {
        return this.add('Shareholders', value);
    }

    RemoveShareholder(value: Person) {
        return this.remove('Shareholders', value);
    }

    set Shareholders(value: Person[]) {
        this.set('Shareholders', value);
    }

    get CanReadCycleOne(): boolean {
        return this.canRead('CycleOne');
    }

    get CanWriteCycleOne(): boolean {
        return this.canWrite('CycleOne');
    }

    get CycleOne(): Person {
        return this.get('CycleOne');
    }

    set CycleOne(value: Person) {
        this.set('CycleOne', value);
    }

    get CanReadCycleMany(): boolean {
        return this.canRead('CycleMany');
    }

    get CanWriteCycleMany(): boolean {
        return this.canWrite('CycleMany');
    }

    get CycleMany(): Person[] {
        return this.get('CycleMany');
    }

    AddCycleMany(value: Person) {
        return this.add('CycleMany', value);
    }

    RemoveCycleMany(value: Person) {
        return this.remove('CycleMany', value);
    }

    set CycleMany(value: Person[]) {
        this.set('CycleMany', value);
    }

    get CanReadUniqueId(): boolean {
        return this.canRead('UniqueId');
    }

    get CanWriteUniqueId(): boolean {
        return this.canWrite('UniqueId');
    }

    get UniqueId(): string {
        return this.get('UniqueId');
    }

    set UniqueId(value: string) {
        this.set('UniqueId', value);
    }


    get CanExecuteJustDoIt(): boolean {
        return this.canExecute('JustDoIt');
    }

    get JustDoIt(): Method {
        return new Method(this, 'JustDoIt');
    }
    get CanExecuteDelete(): boolean {
        return this.canExecute('Delete');
    }

    get Delete(): Method {
        return new Method(this, 'Delete');
    }
}