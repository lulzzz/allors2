// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { Shipment } from './Shipment.g';
import { Printable } from './Printable.g';
import { Commentable } from './Commentable.g';
import { Auditable } from './Auditable.g';
import { DropShipmentState } from './DropShipmentState.g';
import { DropShipmentVersion } from './DropShipmentVersion.g';
import { User } from './User.g';
import { SalesInvoiceVersion } from './SalesInvoiceVersion.g';
import { SalesInvoice } from './SalesInvoice.g';

export class DropShipment extends SessionObject implements Shipment {
    get CanReadDropShipmentState(): boolean {
        return this.canRead('DropShipmentState');
    }

    get CanWriteDropShipmentState(): boolean {
        return this.canWrite('DropShipmentState');
    }

    get DropShipmentState(): DropShipmentState {
        return this.get('DropShipmentState');
    }

    set DropShipmentState(value: DropShipmentState) {
        this.set('DropShipmentState', value);
    }

    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): DropShipmentVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: DropShipmentVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): DropShipmentVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: DropShipmentVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: DropShipmentVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: DropShipmentVersion[]) {
        this.set('AllVersions', value);
    }

    get CanReadPrintContent(): boolean {
        return this.canRead('PrintContent');
    }

    get CanWritePrintContent(): boolean {
        return this.canWrite('PrintContent');
    }

    get PrintContent(): string {
        return this.get('PrintContent');
    }

    set PrintContent(value: string) {
        this.set('PrintContent', value);
    }

    get CanReadComment(): boolean {
        return this.canRead('Comment');
    }

    get CanWriteComment(): boolean {
        return this.canWrite('Comment');
    }

    get Comment(): string {
        return this.get('Comment');
    }

    set Comment(value: string) {
        this.set('Comment', value);
    }

    get CanReadCreatedBy(): boolean {
        return this.canRead('CreatedBy');
    }

    get CanWriteCreatedBy(): boolean {
        return this.canWrite('CreatedBy');
    }

    get CreatedBy(): User {
        return this.get('CreatedBy');
    }

    set CreatedBy(value: User) {
        this.set('CreatedBy', value);
    }

    get CanReadLastModifiedBy(): boolean {
        return this.canRead('LastModifiedBy');
    }

    get CanWriteLastModifiedBy(): boolean {
        return this.canWrite('LastModifiedBy');
    }

    get LastModifiedBy(): User {
        return this.get('LastModifiedBy');
    }

    set LastModifiedBy(value: User) {
        this.set('LastModifiedBy', value);
    }

    get CanReadCreationDate(): boolean {
        return this.canRead('CreationDate');
    }

    get CanWriteCreationDate(): boolean {
        return this.canWrite('CreationDate');
    }

    get CreationDate(): Date {
        return this.get('CreationDate');
    }

    set CreationDate(value: Date) {
        this.set('CreationDate', value);
    }

    get CanReadLastModifiedDate(): boolean {
        return this.canRead('LastModifiedDate');
    }

    get CanWriteLastModifiedDate(): boolean {
        return this.canWrite('LastModifiedDate');
    }

    get LastModifiedDate(): Date {
        return this.get('LastModifiedDate');
    }

    set LastModifiedDate(value: Date) {
        this.set('LastModifiedDate', value);
    }


}