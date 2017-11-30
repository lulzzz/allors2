// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { InvoiceItemVersion } from './InvoiceItemVersion.g';
import { PriceableVersion } from './PriceableVersion.g';
import { Version } from './Version.g';
import { AgreementTerm } from './AgreementTerm.g';
import { InvoiceVatRateItem } from './InvoiceVatRateItem.g';
import { InvoiceItem } from './InvoiceItem.g';
import { PurchaseInvoiceItem } from './PurchaseInvoiceItem.g';

export class PurchaseInvoiceItemVersion extends SessionObject implements InvoiceItemVersion {
    get CanReadInternalComment(): boolean {
        return this.canRead('InternalComment');
    }

    get CanWriteInternalComment(): boolean {
        return this.canWrite('InternalComment');
    }

    get InternalComment(): string {
        return this.get('InternalComment');
    }

    set InternalComment(value: string) {
        this.set('InternalComment', value);
    }

    get CanReadInvoiceTerms(): boolean {
        return this.canRead('InvoiceTerms');
    }

    get CanWriteInvoiceTerms(): boolean {
        return this.canWrite('InvoiceTerms');
    }

    get InvoiceTerms(): AgreementTerm[] {
        return this.get('InvoiceTerms');
    }

    AddInvoiceTerm(value: AgreementTerm) {
        return this.add('InvoiceTerms', value);
    }

    RemoveInvoiceTerm(value: AgreementTerm) {
        return this.remove('InvoiceTerms', value);
    }

    set InvoiceTerms(value: AgreementTerm[]) {
        this.set('InvoiceTerms', value);
    }

    get CanReadTotalInvoiceAdjustment(): boolean {
        return this.canRead('TotalInvoiceAdjustment');
    }

    get TotalInvoiceAdjustment(): number {
        return this.get('TotalInvoiceAdjustment');
    }


    get CanReadInvoiceVatRateItems(): boolean {
        return this.canRead('InvoiceVatRateItems');
    }

    get CanWriteInvoiceVatRateItems(): boolean {
        return this.canWrite('InvoiceVatRateItems');
    }

    get InvoiceVatRateItems(): InvoiceVatRateItem[] {
        return this.get('InvoiceVatRateItems');
    }

    AddInvoiceVatRateItem(value: InvoiceVatRateItem) {
        return this.add('InvoiceVatRateItems', value);
    }

    RemoveInvoiceVatRateItem(value: InvoiceVatRateItem) {
        return this.remove('InvoiceVatRateItems', value);
    }

    set InvoiceVatRateItems(value: InvoiceVatRateItem[]) {
        this.set('InvoiceVatRateItems', value);
    }

    get CanReadAdjustmentFor(): boolean {
        return this.canRead('AdjustmentFor');
    }

    get CanWriteAdjustmentFor(): boolean {
        return this.canWrite('AdjustmentFor');
    }

    get AdjustmentFor(): InvoiceItem {
        return this.get('AdjustmentFor');
    }

    set AdjustmentFor(value: InvoiceItem) {
        this.set('AdjustmentFor', value);
    }

    get CanReadMessage(): boolean {
        return this.canRead('Message');
    }

    get CanWriteMessage(): boolean {
        return this.canWrite('Message');
    }

    get Message(): string {
        return this.get('Message');
    }

    set Message(value: string) {
        this.set('Message', value);
    }

    get CanReadTotalInvoiceAdjustmentCustomerCurrency(): boolean {
        return this.canRead('TotalInvoiceAdjustmentCustomerCurrency');
    }

    get TotalInvoiceAdjustmentCustomerCurrency(): number {
        return this.get('TotalInvoiceAdjustmentCustomerCurrency');
    }


    get CanReadAmountPaid(): boolean {
        return this.canRead('AmountPaid');
    }

    get AmountPaid(): number {
        return this.get('AmountPaid');
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