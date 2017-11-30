// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { InvoiceItem } from './InvoiceItem.g';
import { Priceable } from './Priceable.g';
import { Commentable } from './Commentable.g';
import { Deletable } from './Deletable.g';
import { SalesInvoiceItemState } from './SalesInvoiceItemState.g';
import { SalesInvoiceItemVersion } from './SalesInvoiceItemVersion.g';
import { ProductFeature } from './ProductFeature.g';
import { Product } from './Product.g';
import { SalesOrderItem } from './SalesOrderItem.g';
import { SalesInvoiceItemType } from './SalesInvoiceItemType.g';
import { Person } from './Person.g';
import { AgreementTerm } from './AgreementTerm.g';
import { InvoiceVatRateItem } from './InvoiceVatRateItem.g';
import { DiscountAdjustment } from './DiscountAdjustment.g';
import { VatRegime } from './VatRegime.g';
import { VatRate } from './VatRate.g';
import { SurchargeAdjustment } from './SurchargeAdjustment.g';
import { SalesInvoiceVersion } from './SalesInvoiceVersion.g';
import { SalesInvoice } from './SalesInvoice.g';
import { InvoiceItemVersion } from './InvoiceItemVersion.g';

export class SalesInvoiceItem extends SessionObject implements InvoiceItem {
    get CanReadSalesInvoiceItemState(): boolean {
        return this.canRead('SalesInvoiceItemState');
    }

    get CanWriteSalesInvoiceItemState(): boolean {
        return this.canWrite('SalesInvoiceItemState');
    }

    get SalesInvoiceItemState(): SalesInvoiceItemState {
        return this.get('SalesInvoiceItemState');
    }

    set SalesInvoiceItemState(value: SalesInvoiceItemState) {
        this.set('SalesInvoiceItemState', value);
    }

    get CanReadCurrentVersion(): boolean {
        return this.canRead('CurrentVersion');
    }

    get CanWriteCurrentVersion(): boolean {
        return this.canWrite('CurrentVersion');
    }

    get CurrentVersion(): SalesInvoiceItemVersion {
        return this.get('CurrentVersion');
    }

    set CurrentVersion(value: SalesInvoiceItemVersion) {
        this.set('CurrentVersion', value);
    }

    get CanReadAllVersions(): boolean {
        return this.canRead('AllVersions');
    }

    get CanWriteAllVersions(): boolean {
        return this.canWrite('AllVersions');
    }

    get AllVersions(): SalesInvoiceItemVersion[] {
        return this.get('AllVersions');
    }

    AddAllVersion(value: SalesInvoiceItemVersion) {
        return this.add('AllVersions', value);
    }

    RemoveAllVersion(value: SalesInvoiceItemVersion) {
        return this.remove('AllVersions', value);
    }

    set AllVersions(value: SalesInvoiceItemVersion[]) {
        this.set('AllVersions', value);
    }

    get CanReadProductFeature(): boolean {
        return this.canRead('ProductFeature');
    }

    get CanWriteProductFeature(): boolean {
        return this.canWrite('ProductFeature');
    }

    get ProductFeature(): ProductFeature {
        return this.get('ProductFeature');
    }

    set ProductFeature(value: ProductFeature) {
        this.set('ProductFeature', value);
    }

    get CanReadRequiredProfitMargin(): boolean {
        return this.canRead('RequiredProfitMargin');
    }

    get CanWriteRequiredProfitMargin(): boolean {
        return this.canWrite('RequiredProfitMargin');
    }

    get RequiredProfitMargin(): number {
        return this.get('RequiredProfitMargin');
    }

    set RequiredProfitMargin(value: number) {
        this.set('RequiredProfitMargin', value);
    }

    get CanReadInitialMarkupPercentage(): boolean {
        return this.canRead('InitialMarkupPercentage');
    }

    get InitialMarkupPercentage(): number {
        return this.get('InitialMarkupPercentage');
    }


    get CanReadMaintainedMarkupPercentage(): boolean {
        return this.canRead('MaintainedMarkupPercentage');
    }

    get MaintainedMarkupPercentage(): number {
        return this.get('MaintainedMarkupPercentage');
    }


    get CanReadProduct(): boolean {
        return this.canRead('Product');
    }

    get CanWriteProduct(): boolean {
        return this.canWrite('Product');
    }

    get Product(): Product {
        return this.get('Product');
    }

    set Product(value: Product) {
        this.set('Product', value);
    }

    get CanReadUnitPurchasePrice(): boolean {
        return this.canRead('UnitPurchasePrice');
    }

    get UnitPurchasePrice(): number {
        return this.get('UnitPurchasePrice');
    }


    get CanReadSalesOrderItem(): boolean {
        return this.canRead('SalesOrderItem');
    }

    get SalesOrderItem(): SalesOrderItem {
        return this.get('SalesOrderItem');
    }


    get CanReadSalesInvoiceItemType(): boolean {
        return this.canRead('SalesInvoiceItemType');
    }

    get CanWriteSalesInvoiceItemType(): boolean {
        return this.canWrite('SalesInvoiceItemType');
    }

    get SalesInvoiceItemType(): SalesInvoiceItemType {
        return this.get('SalesInvoiceItemType');
    }

    set SalesInvoiceItemType(value: SalesInvoiceItemType) {
        this.set('SalesInvoiceItemType', value);
    }

    get CanReadSalesRep(): boolean {
        return this.canRead('SalesRep');
    }

    get CanWriteSalesRep(): boolean {
        return this.canWrite('SalesRep');
    }

    get SalesRep(): Person {
        return this.get('SalesRep');
    }

    set SalesRep(value: Person) {
        this.set('SalesRep', value);
    }

    get CanReadInitialProfitMargin(): boolean {
        return this.canRead('InitialProfitMargin');
    }

    get InitialProfitMargin(): number {
        return this.get('InitialProfitMargin');
    }


    get CanReadMaintainedProfitMargin(): boolean {
        return this.canRead('MaintainedProfitMargin');
    }

    get MaintainedProfitMargin(): number {
        return this.get('MaintainedProfitMargin');
    }


    get CanReadRequiredMarkupPercentage(): boolean {
        return this.canRead('RequiredMarkupPercentage');
    }

    get CanWriteRequiredMarkupPercentage(): boolean {
        return this.canWrite('RequiredMarkupPercentage');
    }

    get RequiredMarkupPercentage(): number {
        return this.get('RequiredMarkupPercentage');
    }

    set RequiredMarkupPercentage(value: number) {
        this.set('RequiredMarkupPercentage', value);
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

    get CanReadTotalDiscountAsPercentage(): boolean {
        return this.canRead('TotalDiscountAsPercentage');
    }

    get TotalDiscountAsPercentage(): number {
        return this.get('TotalDiscountAsPercentage');
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

    get CanReadUnitVat(): boolean {
        return this.canRead('UnitVat');
    }

    get UnitVat(): number {
        return this.get('UnitVat');
    }


    get CanReadTotalVatCustomerCurrency(): boolean {
        return this.canRead('TotalVatCustomerCurrency');
    }

    get TotalVatCustomerCurrency(): number {
        return this.get('TotalVatCustomerCurrency');
    }


    get CanReadVatRegime(): boolean {
        return this.canRead('VatRegime');
    }

    get VatRegime(): VatRegime {
        return this.get('VatRegime');
    }


    get CanReadTotalVat(): boolean {
        return this.canRead('TotalVat');
    }

    get TotalVat(): number {
        return this.get('TotalVat');
    }


    get CanReadUnitSurcharge(): boolean {
        return this.canRead('UnitSurcharge');
    }

    get UnitSurcharge(): number {
        return this.get('UnitSurcharge');
    }


    get CanReadUnitDiscount(): boolean {
        return this.canRead('UnitDiscount');
    }

    get UnitDiscount(): number {
        return this.get('UnitDiscount');
    }


    get CanReadTotalExVatCustomerCurrency(): boolean {
        return this.canRead('TotalExVatCustomerCurrency');
    }

    get TotalExVatCustomerCurrency(): number {
        return this.get('TotalExVatCustomerCurrency');
    }


    get CanReadDerivedVatRate(): boolean {
        return this.canRead('DerivedVatRate');
    }

    get DerivedVatRate(): VatRate {
        return this.get('DerivedVatRate');
    }


    get CanReadActualUnitPrice(): boolean {
        return this.canRead('ActualUnitPrice');
    }

    get CanWriteActualUnitPrice(): boolean {
        return this.canWrite('ActualUnitPrice');
    }

    get ActualUnitPrice(): number {
        return this.get('ActualUnitPrice');
    }

    set ActualUnitPrice(value: number) {
        this.set('ActualUnitPrice', value);
    }

    get CanReadTotalIncVatCustomerCurrency(): boolean {
        return this.canRead('TotalIncVatCustomerCurrency');
    }

    get TotalIncVatCustomerCurrency(): number {
        return this.get('TotalIncVatCustomerCurrency');
    }


    get CanReadUnitBasePrice(): boolean {
        return this.canRead('UnitBasePrice');
    }

    get UnitBasePrice(): number {
        return this.get('UnitBasePrice');
    }


    get CanReadCalculatedUnitPrice(): boolean {
        return this.canRead('CalculatedUnitPrice');
    }

    get CalculatedUnitPrice(): number {
        return this.get('CalculatedUnitPrice');
    }


    get CanReadTotalSurchargeCustomerCurrency(): boolean {
        return this.canRead('TotalSurchargeCustomerCurrency');
    }

    get TotalSurchargeCustomerCurrency(): number {
        return this.get('TotalSurchargeCustomerCurrency');
    }


    get CanReadTotalIncVat(): boolean {
        return this.canRead('TotalIncVat');
    }

    get TotalIncVat(): number {
        return this.get('TotalIncVat');
    }


    get CanReadTotalSurchargeAsPercentage(): boolean {
        return this.canRead('TotalSurchargeAsPercentage');
    }

    get TotalSurchargeAsPercentage(): number {
        return this.get('TotalSurchargeAsPercentage');
    }


    get CanReadTotalDiscountCustomerCurrency(): boolean {
        return this.canRead('TotalDiscountCustomerCurrency');
    }

    get TotalDiscountCustomerCurrency(): number {
        return this.get('TotalDiscountCustomerCurrency');
    }


    get CanReadTotalDiscount(): boolean {
        return this.canRead('TotalDiscount');
    }

    get TotalDiscount(): number {
        return this.get('TotalDiscount');
    }


    get CanReadTotalSurcharge(): boolean {
        return this.canRead('TotalSurcharge');
    }

    get TotalSurcharge(): number {
        return this.get('TotalSurcharge');
    }


    get CanReadAssignedVatRegime(): boolean {
        return this.canRead('AssignedVatRegime');
    }

    get CanWriteAssignedVatRegime(): boolean {
        return this.canWrite('AssignedVatRegime');
    }

    get AssignedVatRegime(): VatRegime {
        return this.get('AssignedVatRegime');
    }

    set AssignedVatRegime(value: VatRegime) {
        this.set('AssignedVatRegime', value);
    }

    get CanReadTotalBasePrice(): boolean {
        return this.canRead('TotalBasePrice');
    }

    get TotalBasePrice(): number {
        return this.get('TotalBasePrice');
    }


    get CanReadTotalExVat(): boolean {
        return this.canRead('TotalExVat');
    }

    get TotalExVat(): number {
        return this.get('TotalExVat');
    }


    get CanReadTotalBasePriceCustomerCurrency(): boolean {
        return this.canRead('TotalBasePriceCustomerCurrency');
    }

    get TotalBasePriceCustomerCurrency(): number {
        return this.get('TotalBasePriceCustomerCurrency');
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


    get CanExecuteDelete(): boolean {
        return this.canExecute('Delete');
    }

    get Delete(): Method {
        return new Method(this, 'Delete');
    }
}