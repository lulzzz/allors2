import { SessionObject } from "@allors/framework";
import { Version } from './Version.g';
import { QuoteState } from './QuoteState.g';
import { QuoteTerm } from './QuoteTerm.g';
import { Party } from './Party.g';
import { ContactMechanism } from './ContactMechanism.g';
import { Currency } from './Currency.g';
import { QuoteItem } from './QuoteItem.g';
import { Request } from './Request.g';
export interface QuoteVersion extends SessionObject, Version {
    QuoteState: QuoteState;
    InternalComment: string;
    RequiredResponseDate: Date;
    ValidFromDate: Date;
    QuoteTerms: QuoteTerm[];
    AddQuoteTerm(value: QuoteTerm): any;
    RemoveQuoteTerm(value: QuoteTerm): any;
    ValidThroughDate: Date;
    Description: string;
    Receiver: Party;
    FullfillContactMechanism: ContactMechanism;
    Price: number;
    Currency: Currency;
    IssueDate: Date;
    QuoteItems: QuoteItem[];
    AddQuoteItem(value: QuoteItem): any;
    RemoveQuoteItem(value: QuoteItem): any;
    QuoteNumber: string;
    Request: Request;
}