// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { Order } from './Order.g';
import { Printable } from './Printable.g';
import { Commentable } from './Commentable.g';
import { Localised } from './Localised.g';
import { Auditable } from './Auditable.g';
import { SalesOrderState } from './SalesOrderState.g';
import { SalesOrderPaymentState } from './SalesOrderPaymentState.g';
import { SalesOrderShipmentState } from './SalesOrderShipmentState.g';
import { SalesOrderVersion } from './SalesOrderVersion.g';
import { ContactMechanism } from './ContactMechanism.g';
import { Party } from './Party.g';
import { ShipmentMethod } from './ShipmentMethod.g';
import { PostalAddress } from './PostalAddress.g';
import { Person } from './Person.g';
import { Store } from './Store.g';
import { PaymentMethod } from './PaymentMethod.g';
import { SalesChannel } from './SalesChannel.g';
import { SalesOrderItem } from './SalesOrderItem.g';
import { ProductQuote } from './ProductQuote.g';
import { Currency } from './Currency.g';
import { Fee } from './Fee.g';
import { OrderTerm } from './OrderTerm.g';
import { OrderItem } from './OrderItem.g';
import { DiscountAdjustment } from './DiscountAdjustment.g';
import { OrderKind } from './OrderKind.g';
import { VatRegime } from './VatRegime.g';
import { ShippingAndHandlingCharge } from './ShippingAndHandlingCharge.g';
import { SurchargeAdjustment } from './SurchargeAdjustment.g';
import { Locale } from './Locale.g';
import { User } from './User.g';
import { SalesInvoiceVersion } from './SalesInvoiceVersion.g';
import { SalesInvoice } from './SalesInvoice.g';

export class SalesOrder extends SessionObject implements Order {
    get CanReadSalesOrderState(): boolean {
        return this.canRead('SalesOrderState');
    }

    get CanWriteSalesOrderState(): boolean {
        return this.canWrite('SalesOrderState');
    }

    get SalesOrderState(): SalesOrderState {
        return this.get('SalesOrderState');
    }

    set SalesOrderState(value: SalesOrderState) {
        this.set('SalesOrderState', value);
    }

    get CanReadSalesOrderPaymentState(): boolean {
        return this.canRead('SalesOrderPaymentState');
    }

    get CanWriteSalesOrderPaymentState(): boolean {
        return this.canWrite('SalesOrderPaymentState');
    }

    get SalesOrderPaymentState(): SalesOrderPaymentState {
        return this.get('SalesOrderPaymentState');
    }

    set SalesOrderPaymentState(value: SalesOrderPaymentState) {
        this.set('SalesOrderPaymentState', value);
    }

    get CanReadSalesOrderShipmentState(): boolean {
        return this.canRead('SalesOrderShipmentState');
    }

    get CanWriteSalesOrderShipmentState(): boolean {
        return this.canWrite('SalesOrderShipmentState');
    }

    get SalesOrderShipmentState(): SalesOrderShipmentState {
        return this.get('SalesOrderShipmentState');
    }

    set SalesOrderShipmentState(value: SalesOrderShipmentState) {
        this.set('SalesOrderShipmentState', value);
    }

    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): SalesOrderVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: SalesOrderVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): SalesOrderVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: SalesOrderVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: SalesOrderVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: SalesOrderVersion[]) {
        this.set('AllVersions', value);
    }

    get CanReadTakenByContactMechanism(): boolean {
        return this.canRead('TakenByContactMechanism');
    }

    get CanWriteTakenByContactMechanism(): boolean {
        return this.canWrite('TakenByContactMechanism');
    }

    get TakenByContactMechanism(): ContactMechanism {
        return this.get('TakenByContactMechanism');
    }

    set TakenByContactMechanism(value: ContactMechanism) {
        this.set('TakenByContactMechanism', value);
    }

    get CanReadShipToCustomer(): boolean {
        return this.canRead('ShipToCustomer');
    }

    get CanWriteShipToCustomer(): boolean {
        return this.canWrite('ShipToCustomer');
    }

    get ShipToCustomer(): Party {
        return this.get('ShipToCustomer');
    }

    set ShipToCustomer(value: Party) {
        this.set('ShipToCustomer', value);
    }

    get CanReadBillToCustomer(): boolean {
        return this.canRead('BillToCustomer');
    }

    get CanWriteBillToCustomer(): boolean {
        return this.canWrite('BillToCustomer');
    }

    get BillToCustomer(): Party {
        return this.get('BillToCustomer');
    }

    set BillToCustomer(value: Party) {
        this.set('BillToCustomer', value);
    }

    get CanReadTotalPurchasePrice(): boolean {
        return this.canRead('TotalPurchasePrice');
    }

    get TotalPurchasePrice(): number {
        return this.get('TotalPurchasePrice');
    }


    get CanReadShipmentMethod(): boolean {
        return this.canRead('ShipmentMethod');
    }

    get CanWriteShipmentMethod(): boolean {
        return this.canWrite('ShipmentMethod');
    }

    get ShipmentMethod(): ShipmentMethod {
        return this.get('ShipmentMethod');
    }

    set ShipmentMethod(value: ShipmentMethod) {
        this.set('ShipmentMethod', value);
    }

    get CanReadTotalListPriceCustomerCurrency(): boolean {
        return this.canRead('TotalListPriceCustomerCurrency');
    }

    get TotalListPriceCustomerCurrency(): number {
        return this.get('TotalListPriceCustomerCurrency');
    }


    get CanReadMaintainedProfitMargin(): boolean {
        return this.canRead('MaintainedProfitMargin');
    }

    get MaintainedProfitMargin(): number {
        return this.get('MaintainedProfitMargin');
    }


    get CanReadShipToAddress(): boolean {
        return this.canRead('ShipToAddress');
    }

    get CanWriteShipToAddress(): boolean {
        return this.canWrite('ShipToAddress');
    }

    get ShipToAddress(): PostalAddress {
        return this.get('ShipToAddress');
    }

    set ShipToAddress(value: PostalAddress) {
        this.set('ShipToAddress', value);
    }

    get CanReadBillToContactMechanism(): boolean {
        return this.canRead('BillToContactMechanism');
    }

    get CanWriteBillToContactMechanism(): boolean {
        return this.canWrite('BillToContactMechanism');
    }

    get BillToContactMechanism(): ContactMechanism {
        return this.get('BillToContactMechanism');
    }

    set BillToContactMechanism(value: ContactMechanism) {
        this.set('BillToContactMechanism', value);
    }

    get CanReadSalesReps(): boolean {
        return this.canRead('SalesReps');
    }

    get SalesReps(): Person[] {
        return this.get('SalesReps');
    }


    get CanReadInitialProfitMargin(): boolean {
        return this.canRead('InitialProfitMargin');
    }

    get InitialProfitMargin(): number {
        return this.get('InitialProfitMargin');
    }


    get CanReadTotalListPrice(): boolean {
        return this.canRead('TotalListPrice');
    }

    get TotalListPrice(): number {
        return this.get('TotalListPrice');
    }


    get CanReadStore(): boolean {
        return this.canRead('Store');
    }

    get CanWriteStore(): boolean {
        return this.canWrite('Store');
    }

    get Store(): Store {
        return this.get('Store');
    }

    set Store(value: Store) {
        this.set('Store', value);
    }

    get CanReadMaintainedMarkupPercentage(): boolean {
        return this.canRead('MaintainedMarkupPercentage');
    }

    get MaintainedMarkupPercentage(): number {
        return this.get('MaintainedMarkupPercentage');
    }


    get CanReadBillFromContactMechanism(): boolean {
        return this.canRead('BillFromContactMechanism');
    }

    get CanWriteBillFromContactMechanism(): boolean {
        return this.canWrite('BillFromContactMechanism');
    }

    get BillFromContactMechanism(): ContactMechanism {
        return this.get('BillFromContactMechanism');
    }

    set BillFromContactMechanism(value: ContactMechanism) {
        this.set('BillFromContactMechanism', value);
    }

    get CanReadPaymentMethod(): boolean {
        return this.canRead('PaymentMethod');
    }

    get CanWritePaymentMethod(): boolean {
        return this.canWrite('PaymentMethod');
    }

    get PaymentMethod(): PaymentMethod {
        return this.get('PaymentMethod');
    }

    set PaymentMethod(value: PaymentMethod) {
        this.set('PaymentMethod', value);
    }

    get CanReadPlacingContactMechanism(): boolean {
        return this.canRead('PlacingContactMechanism');
    }

    get CanWritePlacingContactMechanism(): boolean {
        return this.canWrite('PlacingContactMechanism');
    }

    get PlacingContactMechanism(): ContactMechanism {
        return this.get('PlacingContactMechanism');
    }

    set PlacingContactMechanism(value: ContactMechanism) {
        this.set('PlacingContactMechanism', value);
    }

    get CanReadSalesChannel(): boolean {
        return this.canRead('SalesChannel');
    }

    get CanWriteSalesChannel(): boolean {
        return this.canWrite('SalesChannel');
    }

    get SalesChannel(): SalesChannel {
        return this.get('SalesChannel');
    }

    set SalesChannel(value: SalesChannel) {
        this.set('SalesChannel', value);
    }

    get CanReadPlacingCustomer(): boolean {
        return this.canRead('PlacingCustomer');
    }

    get CanWritePlacingCustomer(): boolean {
        return this.canWrite('PlacingCustomer');
    }

    get PlacingCustomer(): Party {
        return this.get('PlacingCustomer');
    }

    set PlacingCustomer(value: Party) {
        this.set('PlacingCustomer', value);
    }

    get CanReadSalesOrderItems(): boolean {
        return this.canRead('SalesOrderItems');
    }

    get CanWriteSalesOrderItems(): boolean {
        return this.canWrite('SalesOrderItems');
    }

    get SalesOrderItems(): SalesOrderItem[] {
        return this.get('SalesOrderItems');
    }

    AddSalesOrderItem(value: SalesOrderItem) {
        return this.add('SalesOrderItems', value);
    }

    RemoveSalesOrderItem(value: SalesOrderItem) {
        return this.remove('SalesOrderItems', value);
    }

    set SalesOrderItems(value: SalesOrderItem[]) {
        this.set('SalesOrderItems', value);
    }

    get CanReadInitialMarkupPercentage(): boolean {
        return this.canRead('InitialMarkupPercentage');
    }

    get InitialMarkupPercentage(): number {
        return this.get('InitialMarkupPercentage');
    }


    get CanReadQuote(): boolean {
        return this.canRead('Quote');
    }

    get CanWriteQuote(): boolean {
        return this.canWrite('Quote');
    }

    get Quote(): ProductQuote {
        return this.get('Quote');
    }

    set Quote(value: ProductQuote) {
        this.set('Quote', value);
    }

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

    get CanReadCustomerCurrency(): boolean {
        return this.canRead('CustomerCurrency');
    }

    get CustomerCurrency(): Currency {
        return this.get('CustomerCurrency');
    }


    get CanReadTotalBasePriceCustomerCurrency(): boolean {
        return this.canRead('TotalBasePriceCustomerCurrency');
    }

    get TotalBasePriceCustomerCurrency(): number {
        return this.get('TotalBasePriceCustomerCurrency');
    }


    get CanReadTotalIncVatCustomerCurrency(): boolean {
        return this.canRead('TotalIncVatCustomerCurrency');
    }

    get TotalIncVatCustomerCurrency(): number {
        return this.get('TotalIncVatCustomerCurrency');
    }


    get CanReadTotalDiscountCustomerCurrency(): boolean {
        return this.canRead('TotalDiscountCustomerCurrency');
    }

    get TotalDiscountCustomerCurrency(): number {
        return this.get('TotalDiscountCustomerCurrency');
    }


    get CanReadCustomerReference(): boolean {
        return this.canRead('CustomerReference');
    }

    get CanWriteCustomerReference(): boolean {
        return this.canWrite('CustomerReference');
    }

    get CustomerReference(): string {
        return this.get('CustomerReference');
    }

    set CustomerReference(value: string) {
        this.set('CustomerReference', value);
    }

    get CanReadFee(): boolean {
        return this.canRead('Fee');
    }

    get CanWriteFee(): boolean {
        return this.canWrite('Fee');
    }

    get Fee(): Fee {
        return this.get('Fee');
    }

    set Fee(value: Fee) {
        this.set('Fee', value);
    }

    get CanReadTotalExVat(): boolean {
        return this.canRead('TotalExVat');
    }

    get TotalExVat(): number {
        return this.get('TotalExVat');
    }


    get CanReadOrderTerms(): boolean {
        return this.canRead('OrderTerms');
    }

    get CanWriteOrderTerms(): boolean {
        return this.canWrite('OrderTerms');
    }

    get OrderTerms(): OrderTerm[] {
        return this.get('OrderTerms');
    }

    AddOrderTerm(value: OrderTerm) {
        return this.add('OrderTerms', value);
    }

    RemoveOrderTerm(value: OrderTerm) {
        return this.remove('OrderTerms', value);
    }

    set OrderTerms(value: OrderTerm[]) {
        this.set('OrderTerms', value);
    }

    get CanReadTotalVat(): boolean {
        return this.canRead('TotalVat');
    }

    get TotalVat(): number {
        return this.get('TotalVat');
    }


    get CanReadTotalSurcharge(): boolean {
        return this.canRead('TotalSurcharge');
    }

    get TotalSurcharge(): number {
        return this.get('TotalSurcharge');
    }


    get CanReadValidOrderItems(): boolean {
        return this.canRead('ValidOrderItems');
    }

    get ValidOrderItems(): OrderItem[] {
        return this.get('ValidOrderItems');
    }


    get CanReadOrderNumber(): boolean {
        return this.canRead('OrderNumber');
    }

    get OrderNumber(): string {
        return this.get('OrderNumber');
    }


    get CanReadTotalVatCustomerCurrency(): boolean {
        return this.canRead('TotalVatCustomerCurrency');
    }

    get TotalVatCustomerCurrency(): number {
        return this.get('TotalVatCustomerCurrency');
    }


    get CanReadTotalDiscount(): boolean {
        return this.canRead('TotalDiscount');
    }

    get TotalDiscount(): number {
        return this.get('TotalDiscount');
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

    get CanReadTotalShippingAndHandlingCustomerCurrency(): boolean {
        return this.canRead('TotalShippingAndHandlingCustomerCurrency');
    }

    get TotalShippingAndHandlingCustomerCurrency(): number {
        return this.get('TotalShippingAndHandlingCustomerCurrency');
    }


    get CanReadEntryDate(): boolean {
        return this.canRead('EntryDate');
    }

    get EntryDate(): Date {
        return this.get('EntryDate');
    }


    get CanReadDiscountAdjustment(): boolean {
        return this.canRead('DiscountAdjustment');
    }

    get CanWriteDiscountAdjustment(): boolean {
        return this.canWrite('DiscountAdjustment');
    }

    get DiscountAdjustment(): DiscountAdjustment {
        return this.get('DiscountAdjustment');
    }

    set DiscountAdjustment(value: DiscountAdjustment) {
        this.set('DiscountAdjustment', value);
    }

    get CanReadOrderKind(): boolean {
        return this.canRead('OrderKind');
    }

    get CanWriteOrderKind(): boolean {
        return this.canWrite('OrderKind');
    }

    get OrderKind(): OrderKind {
        return this.get('OrderKind');
    }

    set OrderKind(value: OrderKind) {
        this.set('OrderKind', value);
    }

    get CanReadTotalIncVat(): boolean {
        return this.canRead('TotalIncVat');
    }

    get TotalIncVat(): number {
        return this.get('TotalIncVat');
    }


    get CanReadTotalSurchargeCustomerCurrency(): boolean {
        return this.canRead('TotalSurchargeCustomerCurrency');
    }

    get TotalSurchargeCustomerCurrency(): number {
        return this.get('TotalSurchargeCustomerCurrency');
    }


    get CanReadVatRegime(): boolean {
        return this.canRead('VatRegime');
    }

    get CanWriteVatRegime(): boolean {
        return this.canWrite('VatRegime');
    }

    get VatRegime(): VatRegime {
        return this.get('VatRegime');
    }

    set VatRegime(value: VatRegime) {
        this.set('VatRegime', value);
    }

    get CanReadTotalFeeCustomerCurrency(): boolean {
        return this.canRead('TotalFeeCustomerCurrency');
    }

    get TotalFeeCustomerCurrency(): number {
        return this.get('TotalFeeCustomerCurrency');
    }


    get CanReadTotalShippingAndHandling(): boolean {
        return this.canRead('TotalShippingAndHandling');
    }

    get TotalShippingAndHandling(): number {
        return this.get('TotalShippingAndHandling');
    }


    get CanReadShippingAndHandlingCharge(): boolean {
        return this.canRead('ShippingAndHandlingCharge');
    }

    get CanWriteShippingAndHandlingCharge(): boolean {
        return this.canWrite('ShippingAndHandlingCharge');
    }

    get ShippingAndHandlingCharge(): ShippingAndHandlingCharge {
        return this.get('ShippingAndHandlingCharge');
    }

    set ShippingAndHandlingCharge(value: ShippingAndHandlingCharge) {
        this.set('ShippingAndHandlingCharge', value);
    }

    get CanReadOrderDate(): boolean {
        return this.canRead('OrderDate');
    }

    get CanWriteOrderDate(): boolean {
        return this.canWrite('OrderDate');
    }

    get OrderDate(): Date {
        return this.get('OrderDate');
    }

    set OrderDate(value: Date) {
        this.set('OrderDate', value);
    }

    get CanReadTotalExVatCustomerCurrency(): boolean {
        return this.canRead('TotalExVatCustomerCurrency');
    }

    get TotalExVatCustomerCurrency(): number {
        return this.get('TotalExVatCustomerCurrency');
    }


    get CanReadDeliveryDate(): boolean {
        return this.canRead('DeliveryDate');
    }

    get CanWriteDeliveryDate(): boolean {
        return this.canWrite('DeliveryDate');
    }

    get DeliveryDate(): Date {
        return this.get('DeliveryDate');
    }

    set DeliveryDate(value: Date) {
        this.set('DeliveryDate', value);
    }

    get CanReadTotalBasePrice(): boolean {
        return this.canRead('TotalBasePrice');
    }

    get TotalBasePrice(): number {
        return this.get('TotalBasePrice');
    }


    get CanReadTotalFee(): boolean {
        return this.canRead('TotalFee');
    }

    get TotalFee(): number {
        return this.get('TotalFee');
    }


    get CanReadSurchargeAdjustment(): boolean {
        return this.canRead('SurchargeAdjustment');
    }

    get CanWriteSurchargeAdjustment(): boolean {
        return this.canWrite('SurchargeAdjustment');
    }

    get SurchargeAdjustment(): SurchargeAdjustment {
        return this.get('SurchargeAdjustment');
    }

    set SurchargeAdjustment(value: SurchargeAdjustment) {
        this.set('SurchargeAdjustment', value);
    }

    get CanReadContactPerson(): boolean {
        return this.canRead('ContactPerson');
    }

    get CanWriteContactPerson(): boolean {
        return this.canWrite('ContactPerson');
    }

    get ContactPerson(): Person {
        return this.get('ContactPerson');
    }

    set ContactPerson(value: Person) {
        this.set('ContactPerson', value);
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

    get CanReadLocale(): boolean {
        return this.canRead('Locale');
    }

    get CanWriteLocale(): boolean {
        return this.canWrite('Locale');
    }

    get Locale(): Locale {
        return this.get('Locale');
    }

    set Locale(value: Locale) {
        this.set('Locale', value);
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


    get CanExecuteApprove(): boolean {
        return this.canExecute('Approve');
    }

    get Approve(): Method {
        return new Method(this, 'Approve');
    }
    get CanExecuteReject(): boolean {
        return this.canExecute('Reject');
    }

    get Reject(): Method {
        return new Method(this, 'Reject');
    }
    get CanExecuteHold(): boolean {
        return this.canExecute('Hold');
    }

    get Hold(): Method {
        return new Method(this, 'Hold');
    }
    get CanExecuteContinue(): boolean {
        return this.canExecute('Continue');
    }

    get Continue(): Method {
        return new Method(this, 'Continue');
    }
    get CanExecuteConfirm(): boolean {
        return this.canExecute('Confirm');
    }

    get Confirm(): Method {
        return new Method(this, 'Confirm');
    }
    get CanExecuteCancel(): boolean {
        return this.canExecute('Cancel');
    }

    get Cancel(): Method {
        return new Method(this, 'Cancel');
    }
    get CanExecuteComplete(): boolean {
        return this.canExecute('Complete');
    }

    get Complete(): Method {
        return new Method(this, 'Complete');
    }
}