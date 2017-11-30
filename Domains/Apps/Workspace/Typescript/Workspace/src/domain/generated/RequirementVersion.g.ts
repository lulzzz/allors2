// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { Version } from './Version.g';
import { RequirementState } from './RequirementState.g';
import { RequirementType } from './RequirementType.g';
import { Party } from './Party.g';
import { Requirement } from './Requirement.g';
import { Facility } from './Facility.g';

export class RequirementVersion extends SessionObject implements Version {
    get CanReadRequirementState(): boolean {
        return this.canRead('RequirementState');
    }

    get CanWriteRequirementState(): boolean {
        return this.canWrite('RequirementState');
    }

    get RequirementState(): RequirementState {
        return this.get('RequirementState');
    }

    set RequirementState(value: RequirementState) {
        this.set('RequirementState', value);
    }

    get CanReadRequiredByDate(): boolean {
        return this.canRead('RequiredByDate');
    }

    get CanWriteRequiredByDate(): boolean {
        return this.canWrite('RequiredByDate');
    }

    get RequiredByDate(): Date {
        return this.get('RequiredByDate');
    }

    set RequiredByDate(value: Date) {
        this.set('RequiredByDate', value);
    }

    get CanReadRequirementType(): boolean {
        return this.canRead('RequirementType');
    }

    get CanWriteRequirementType(): boolean {
        return this.canWrite('RequirementType');
    }

    get RequirementType(): RequirementType {
        return this.get('RequirementType');
    }

    set RequirementType(value: RequirementType) {
        this.set('RequirementType', value);
    }

    get CanReadAuthorizer(): boolean {
        return this.canRead('Authorizer');
    }

    get CanWriteAuthorizer(): boolean {
        return this.canWrite('Authorizer');
    }

    get Authorizer(): Party {
        return this.get('Authorizer');
    }

    set Authorizer(value: Party) {
        this.set('Authorizer', value);
    }

    get CanReadReason(): boolean {
        return this.canRead('Reason');
    }

    get CanWriteReason(): boolean {
        return this.canWrite('Reason');
    }

    get Reason(): string {
        return this.get('Reason');
    }

    set Reason(value: string) {
        this.set('Reason', value);
    }

    get CanReadChildren(): boolean {
        return this.canRead('Children');
    }

    get CanWriteChildren(): boolean {
        return this.canWrite('Children');
    }

    get Children(): Requirement[] {
        return this.get('Children');
    }

    AddChild(value: Requirement) {
        return this.add('Children', value);
    }

    RemoveChild(value: Requirement) {
        return this.remove('Children', value);
    }

    set Children(value: Requirement[]) {
        this.set('Children', value);
    }

    get CanReadNeededFor(): boolean {
        return this.canRead('NeededFor');
    }

    get CanWriteNeededFor(): boolean {
        return this.canWrite('NeededFor');
    }

    get NeededFor(): Party {
        return this.get('NeededFor');
    }

    set NeededFor(value: Party) {
        this.set('NeededFor', value);
    }

    get CanReadOriginator(): boolean {
        return this.canRead('Originator');
    }

    get CanWriteOriginator(): boolean {
        return this.canWrite('Originator');
    }

    get Originator(): Party {
        return this.get('Originator');
    }

    set Originator(value: Party) {
        this.set('Originator', value);
    }

    get CanReadFacility(): boolean {
        return this.canRead('Facility');
    }

    get CanWriteFacility(): boolean {
        return this.canWrite('Facility');
    }

    get Facility(): Facility {
        return this.get('Facility');
    }

    set Facility(value: Facility) {
        this.set('Facility', value);
    }

    get CanReadServicedBy(): boolean {
        return this.canRead('ServicedBy');
    }

    get CanWriteServicedBy(): boolean {
        return this.canWrite('ServicedBy');
    }

    get ServicedBy(): Party {
        return this.get('ServicedBy');
    }

    set ServicedBy(value: Party) {
        this.set('ServicedBy', value);
    }

    get CanReadEstimatedBudget(): boolean {
        return this.canRead('EstimatedBudget');
    }

    get CanWriteEstimatedBudget(): boolean {
        return this.canWrite('EstimatedBudget');
    }

    get EstimatedBudget(): number {
        return this.get('EstimatedBudget');
    }

    set EstimatedBudget(value: number) {
        this.set('EstimatedBudget', value);
    }

    get CanReadDescription(): boolean {
        return this.canRead('Description');
    }

    get CanWriteDescription(): boolean {
        return this.canWrite('Description');
    }

    get Description(): string {
        return this.get('Description');
    }

    set Description(value: string) {
        this.set('Description', value);
    }

    get CanReadQuantity(): boolean {
        return this.canRead('Quantity');
    }

    get CanWriteQuantity(): boolean {
        return this.canWrite('Quantity');
    }

    get Quantity(): number {
        return this.get('Quantity');
    }

    set Quantity(value: number) {
        this.set('Quantity', value);
    }

    get CanReadDerivationTimeStamp(): boolean {
        return this.canRead('DerivationTimeStamp');
    }

    get CanWriteDerivationTimeStamp(): boolean {
        return this.canWrite('DerivationTimeStamp');
    }

    get DerivationTimeStamp(): Date {
        return this.get('DerivationTimeStamp');
    }

    set DerivationTimeStamp(value: Date) {
        this.set('DerivationTimeStamp', value);
    }


}