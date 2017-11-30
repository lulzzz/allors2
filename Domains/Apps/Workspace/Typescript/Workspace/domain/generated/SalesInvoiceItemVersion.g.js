"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const framework_1 = require("@allors/framework");
class SalesInvoiceItemVersion extends framework_1.SessionObject {
    get CanReadSalesInvoiceItemState() {
        return this.canRead('SalesInvoiceItemState');
    }
    get CanWriteSalesInvoiceItemState() {
        return this.canWrite('SalesInvoiceItemState');
    }
    get SalesInvoiceItemState() {
        return this.get('SalesInvoiceItemState');
    }
    set SalesInvoiceItemState(value) {
        this.set('SalesInvoiceItemState', value);
    }
    get CanReadProductFeature() {
        return this.canRead('ProductFeature');
    }
    get CanWriteProductFeature() {
        return this.canWrite('ProductFeature');
    }
    get ProductFeature() {
        return this.get('ProductFeature');
    }
    set ProductFeature(value) {
        this.set('ProductFeature', value);
    }
    get CanReadRequiredProfitMargin() {
        return this.canRead('RequiredProfitMargin');
    }
    get CanWriteRequiredProfitMargin() {
        return this.canWrite('RequiredProfitMargin');
    }
    get RequiredProfitMargin() {
        return this.get('RequiredProfitMargin');
    }
    set RequiredProfitMargin(value) {
        this.set('RequiredProfitMargin', value);
    }
    get CanReadInitialMarkupPercentage() {
        return this.canRead('InitialMarkupPercentage');
    }
    get InitialMarkupPercentage() {
        return this.get('InitialMarkupPercentage');
    }
    get CanReadMaintainedMarkupPercentage() {
        return this.canRead('MaintainedMarkupPercentage');
    }
    get MaintainedMarkupPercentage() {
        return this.get('MaintainedMarkupPercentage');
    }
    get CanReadProduct() {
        return this.canRead('Product');
    }
    get CanWriteProduct() {
        return this.canWrite('Product');
    }
    get Product() {
        return this.get('Product');
    }
    set Product(value) {
        this.set('Product', value);
    }
    get CanReadUnitPurchasePrice() {
        return this.canRead('UnitPurchasePrice');
    }
    get UnitPurchasePrice() {
        return this.get('UnitPurchasePrice');
    }
    get CanReadSalesOrderItem() {
        return this.canRead('SalesOrderItem');
    }
    get SalesOrderItem() {
        return this.get('SalesOrderItem');
    }
    get CanReadSalesInvoiceItemType() {
        return this.canRead('SalesInvoiceItemType');
    }
    get CanWriteSalesInvoiceItemType() {
        return this.canWrite('SalesInvoiceItemType');
    }
    get SalesInvoiceItemType() {
        return this.get('SalesInvoiceItemType');
    }
    set SalesInvoiceItemType(value) {
        this.set('SalesInvoiceItemType', value);
    }
    get CanReadSalesRep() {
        return this.canRead('SalesRep');
    }
    get CanWriteSalesRep() {
        return this.canWrite('SalesRep');
    }
    get SalesRep() {
        return this.get('SalesRep');
    }
    set SalesRep(value) {
        this.set('SalesRep', value);
    }
    get CanReadInitialProfitMargin() {
        return this.canRead('InitialProfitMargin');
    }
    get InitialProfitMargin() {
        return this.get('InitialProfitMargin');
    }
    get CanReadMaintainedProfitMargin() {
        return this.canRead('MaintainedProfitMargin');
    }
    get MaintainedProfitMargin() {
        return this.get('MaintainedProfitMargin');
    }
    get CanReadRequiredMarkupPercentage() {
        return this.canRead('RequiredMarkupPercentage');
    }
    get CanWriteRequiredMarkupPercentage() {
        return this.canWrite('RequiredMarkupPercentage');
    }
    get RequiredMarkupPercentage() {
        return this.get('RequiredMarkupPercentage');
    }
    set RequiredMarkupPercentage(value) {
        this.set('RequiredMarkupPercentage', value);
    }
    get CanReadInternalComment() {
        return this.canRead('InternalComment');
    }
    get CanWriteInternalComment() {
        return this.canWrite('InternalComment');
    }
    get InternalComment() {
        return this.get('InternalComment');
    }
    set InternalComment(value) {
        this.set('InternalComment', value);
    }
    get CanReadInvoiceTerms() {
        return this.canRead('InvoiceTerms');
    }
    get CanWriteInvoiceTerms() {
        return this.canWrite('InvoiceTerms');
    }
    get InvoiceTerms() {
        return this.get('InvoiceTerms');
    }
    AddInvoiceTerm(value) {
        return this.add('InvoiceTerms', value);
    }
    RemoveInvoiceTerm(value) {
        return this.remove('InvoiceTerms', value);
    }
    set InvoiceTerms(value) {
        this.set('InvoiceTerms', value);
    }
    get CanReadTotalInvoiceAdjustment() {
        return this.canRead('TotalInvoiceAdjustment');
    }
    get TotalInvoiceAdjustment() {
        return this.get('TotalInvoiceAdjustment');
    }
    get CanReadInvoiceVatRateItems() {
        return this.canRead('InvoiceVatRateItems');
    }
    get CanWriteInvoiceVatRateItems() {
        return this.canWrite('InvoiceVatRateItems');
    }
    get InvoiceVatRateItems() {
        return this.get('InvoiceVatRateItems');
    }
    AddInvoiceVatRateItem(value) {
        return this.add('InvoiceVatRateItems', value);
    }
    RemoveInvoiceVatRateItem(value) {
        return this.remove('InvoiceVatRateItems', value);
    }
    set InvoiceVatRateItems(value) {
        this.set('InvoiceVatRateItems', value);
    }
    get CanReadAdjustmentFor() {
        return this.canRead('AdjustmentFor');
    }
    get CanWriteAdjustmentFor() {
        return this.canWrite('AdjustmentFor');
    }
    get AdjustmentFor() {
        return this.get('AdjustmentFor');
    }
    set AdjustmentFor(value) {
        this.set('AdjustmentFor', value);
    }
    get CanReadMessage() {
        return this.canRead('Message');
    }
    get CanWriteMessage() {
        return this.canWrite('Message');
    }
    get Message() {
        return this.get('Message');
    }
    set Message(value) {
        this.set('Message', value);
    }
    get CanReadTotalInvoiceAdjustmentCustomerCurrency() {
        return this.canRead('TotalInvoiceAdjustmentCustomerCurrency');
    }
    get TotalInvoiceAdjustmentCustomerCurrency() {
        return this.get('TotalInvoiceAdjustmentCustomerCurrency');
    }
    get CanReadAmountPaid() {
        return this.canRead('AmountPaid');
    }
    get AmountPaid() {
        return this.get('AmountPaid');
    }
    get CanReadQuantity() {
        return this.canRead('Quantity');
    }
    get CanWriteQuantity() {
        return this.canWrite('Quantity');
    }
    get Quantity() {
        return this.get('Quantity');
    }
    set Quantity(value) {
        this.set('Quantity', value);
    }
    get CanReadDescription() {
        return this.canRead('Description');
    }
    get CanWriteDescription() {
        return this.canWrite('Description');
    }
    get Description() {
        return this.get('Description');
    }
    set Description(value) {
        this.set('Description', value);
    }
    get CanReadDerivationTimeStamp() {
        return this.canRead('DerivationTimeStamp');
    }
    get CanWriteDerivationTimeStamp() {
        return this.canWrite('DerivationTimeStamp');
    }
    get DerivationTimeStamp() {
        return this.get('DerivationTimeStamp');
    }
    set DerivationTimeStamp(value) {
        this.set('DerivationTimeStamp', value);
    }
}
exports.SalesInvoiceItemVersion = SalesInvoiceItemVersion;