// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { InternalOrganisation } from './InternalOrganisation.g';

export class Counter extends SessionObject implements UniquelyIdentifiable {
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


}