import { SessionObject } from "@allors/framework";
import { Shipment } from './Shipment.g';
import { CustomerShipmentState } from './CustomerShipmentState.g';
import { CustomerShipmentVersion } from './CustomerShipmentVersion.g';
import { User } from './User.g';
export declare class CustomerShipment extends SessionObject implements Shipment {
    readonly CanReadCustomerShipmentState: boolean;
    readonly CanWriteCustomerShipmentState: boolean;
    CustomerShipmentState: CustomerShipmentState;
    readonly CanReadCurrentVersion: boolean;
    readonly CanWriteCurrentVersion: boolean;
    CurrentVersion: CustomerShipmentVersion;
    readonly CanReadAllVersions: boolean;
    readonly CanWriteAllVersions: boolean;
    AllVersions: CustomerShipmentVersion[];
    AddAllVersion(value: CustomerShipmentVersion): void;
    RemoveAllVersion(value: CustomerShipmentVersion): void;
    readonly CanReadPrintContent: boolean;
    readonly CanWritePrintContent: boolean;
    PrintContent: string;
    readonly CanReadComment: boolean;
    readonly CanWriteComment: boolean;
    Comment: string;
    readonly CanReadCreatedBy: boolean;
    readonly CanWriteCreatedBy: boolean;
    CreatedBy: User;
    readonly CanReadLastModifiedBy: boolean;
    readonly CanWriteLastModifiedBy: boolean;
    LastModifiedBy: User;
    readonly CanReadCreationDate: boolean;
    readonly CanWriteCreationDate: boolean;
    CreationDate: Date;
    readonly CanReadLastModifiedDate: boolean;
    readonly CanWriteLastModifiedDate: boolean;
    LastModifiedDate: Date;
}