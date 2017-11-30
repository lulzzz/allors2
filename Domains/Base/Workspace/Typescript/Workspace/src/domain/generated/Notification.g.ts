// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { NotificationList } from './NotificationList.g';

export class Notification extends SessionObject  {
    get CanReadConfirmed(): boolean {
        return this.canRead('Confirmed');
    }

    get CanWriteConfirmed(): boolean {
        return this.canWrite('Confirmed');
    }

    get Confirmed(): boolean {
        return this.get('Confirmed');
    }

    set Confirmed(value: boolean) {
        this.set('Confirmed', value);
    }

    get CanReadTitle(): boolean {
        return this.canRead('Title');
    }

    get CanWriteTitle(): boolean {
        return this.canWrite('Title');
    }

    get Title(): string {
        return this.get('Title');
    }

    set Title(value: string) {
        this.set('Title', value);
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

    get CanReadDateCreated(): boolean {
        return this.canRead('DateCreated');
    }

    get DateCreated(): Date {
        return this.get('DateCreated');
    }



}