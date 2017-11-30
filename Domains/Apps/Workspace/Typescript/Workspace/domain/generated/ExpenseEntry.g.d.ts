import { SessionObject } from "@allors/framework";
import { ServiceEntry } from './ServiceEntry.g';
export declare class ExpenseEntry extends SessionObject implements ServiceEntry {
    readonly CanReadComment: boolean;
    readonly CanWriteComment: boolean;
    Comment: string;
}