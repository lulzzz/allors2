import { SessionObject } from "@allors/framework";
import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
export declare class Role extends SessionObject implements UniquelyIdentifiable {
    readonly CanReadUniqueId: boolean;
    readonly CanWriteUniqueId: boolean;
    UniqueId: string;
}