import { SessionObject } from "@allors/framework";
import { Localised } from './Localised.g';
import { Commentable } from './Commentable.g';
import { Printable } from './Printable.g';
import { Auditable } from './Auditable.g';
import { Currency } from './Currency.g';
import { ShippingAndHandlingCharge } from './ShippingAndHandlingCharge.g';
import { Fee } from './Fee.g';
import { DiscountAdjustment } from './DiscountAdjustment.g';
import { BillingAccount } from './BillingAccount.g';
import { SurchargeAdjustment } from './SurchargeAdjustment.g';
import { InvoiceTerm } from './InvoiceTerm.g';
import { VatRegime } from './VatRegime.g';
import { Person } from './Person.g';
export interface Invoice extends SessionObject, Localised, Commentable, Printable, Auditable {
    InternalComment: string;
    TotalShippingAndHandlingCustomerCurrency: number;
    CustomerCurrency: Currency;
    Description: string;
    ShippingAndHandlingCharge: ShippingAndHandlingCharge;
    TotalFeeCustomerCurrency: number;
    Fee: Fee;
    TotalExVatCustomerCurrency: number;
    CustomerReference: string;
    DiscountAdjustment: DiscountAdjustment;
    AmountPaid: number;
    TotalDiscount: number;
    BillingAccount: BillingAccount;
    TotalIncVat: number;
    TotalSurcharge: number;
    TotalBasePrice: number;
    TotalVatCustomerCurrency: number;
    InvoiceDate: Date;
    EntryDate: Date;
    TotalIncVatCustomerCurrency: number;
    TotalShippingAndHandling: number;
    TotalBasePriceCustomerCurrency: number;
    SurchargeAdjustment: SurchargeAdjustment;
    TotalExVat: number;
    InvoiceTerms: InvoiceTerm[];
    AddInvoiceTerm(value: InvoiceTerm): any;
    RemoveInvoiceTerm(value: InvoiceTerm): any;
    TotalSurchargeCustomerCurrency: number;
    InvoiceNumber: string;
    Message: string;
    VatRegime: VatRegime;
    TotalDiscountCustomerCurrency: number;
    TotalVat: number;
    TotalFee: number;
    ContactPerson: Person;
}