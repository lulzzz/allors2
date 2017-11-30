import { SessionObject } from "@allors/framework";
import { OrderVersion } from './OrderVersion.g';
import { User } from './User.g';
import { Currency } from './Currency.g';
import { Fee } from './Fee.g';
import { OrderTerm } from './OrderTerm.g';
import { OrderItem } from './OrderItem.g';
import { DiscountAdjustment } from './DiscountAdjustment.g';
import { OrderKind } from './OrderKind.g';
import { VatRegime } from './VatRegime.g';
import { ShippingAndHandlingCharge } from './ShippingAndHandlingCharge.g';
import { SurchargeAdjustment } from './SurchargeAdjustment.g';
export declare class PurchaseOrderVersion extends SessionObject implements OrderVersion {
    readonly CanReadComment: boolean;
    readonly CanWriteComment: boolean;
    Comment: string;
    readonly CanReadCreatedBy: boolean;
    readonly CanWriteCreatedBy: boolean;
    CreatedBy: User;
    readonly CanReadLastModifiedBy: boolean;
    readonly CanWriteLastModifiedBy: boolean;
    LastModifiedBy: User;
    readonly CanReadCreationDate: boolean;
    readonly CanWriteCreationDate: boolean;
    CreationDate: Date;
    readonly CanReadLastModifiedDate: boolean;
    readonly CanWriteLastModifiedDate: boolean;
    LastModifiedDate: Date;
    readonly CanReadInternalComment: boolean;
    readonly CanWriteInternalComment: boolean;
    InternalComment: string;
    readonly CanReadCustomerCurrency: boolean;
    readonly CustomerCurrency: Currency;
    readonly CanReadTotalBasePriceCustomerCurrency: boolean;
    readonly TotalBasePriceCustomerCurrency: number;
    readonly CanReadTotalIncVatCustomerCurrency: boolean;
    readonly TotalIncVatCustomerCurrency: number;
    readonly CanReadTotalDiscountCustomerCurrency: boolean;
    readonly TotalDiscountCustomerCurrency: number;
    readonly CanReadCustomerReference: boolean;
    readonly CanWriteCustomerReference: boolean;
    CustomerReference: string;
    readonly CanReadFee: boolean;
    readonly CanWriteFee: boolean;
    Fee: Fee;
    readonly CanReadTotalExVat: boolean;
    readonly TotalExVat: number;
    readonly CanReadOrderTerms: boolean;
    readonly CanWriteOrderTerms: boolean;
    OrderTerms: OrderTerm[];
    AddOrderTerm(value: OrderTerm): void;
    RemoveOrderTerm(value: OrderTerm): void;
    readonly CanReadTotalVat: boolean;
    readonly TotalVat: number;
    readonly CanReadTotalSurcharge: boolean;
    readonly TotalSurcharge: number;
    readonly CanReadValidOrderItems: boolean;
    readonly ValidOrderItems: OrderItem[];
    readonly CanReadOrderNumber: boolean;
    readonly OrderNumber: string;
    readonly CanReadTotalVatCustomerCurrency: boolean;
    readonly TotalVatCustomerCurrency: number;
    readonly CanReadTotalDiscount: boolean;
    readonly TotalDiscount: number;
    readonly CanReadMessage: boolean;
    readonly CanWriteMessage: boolean;
    Message: string;
    readonly CanReadTotalShippingAndHandlingCustomerCurrency: boolean;
    readonly TotalShippingAndHandlingCustomerCurrency: number;
    readonly CanReadEntryDate: boolean;
    readonly EntryDate: Date;
    readonly CanReadDiscountAdjustment: boolean;
    readonly CanWriteDiscountAdjustment: boolean;
    DiscountAdjustment: DiscountAdjustment;
    readonly CanReadOrderKind: boolean;
    readonly CanWriteOrderKind: boolean;
    OrderKind: OrderKind;
    readonly CanReadTotalIncVat: boolean;
    readonly TotalIncVat: number;
    readonly CanReadTotalSurchargeCustomerCurrency: boolean;
    readonly TotalSurchargeCustomerCurrency: number;
    readonly CanReadVatRegime: boolean;
    readonly CanWriteVatRegime: boolean;
    VatRegime: VatRegime;
    readonly CanReadTotalFeeCustomerCurrency: boolean;
    readonly TotalFeeCustomerCurrency: number;
    readonly CanReadTotalShippingAndHandling: boolean;
    readonly TotalShippingAndHandling: number;
    readonly CanReadShippingAndHandlingCharge: boolean;
    readonly CanWriteShippingAndHandlingCharge: boolean;
    ShippingAndHandlingCharge: ShippingAndHandlingCharge;
    readonly CanReadOrderDate: boolean;
    readonly CanWriteOrderDate: boolean;
    OrderDate: Date;
    readonly CanReadTotalExVatCustomerCurrency: boolean;
    readonly TotalExVatCustomerCurrency: number;
    readonly CanReadDeliveryDate: boolean;
    readonly CanWriteDeliveryDate: boolean;
    DeliveryDate: Date;
    readonly CanReadTotalBasePrice: boolean;
    readonly TotalBasePrice: number;
    readonly CanReadTotalFee: boolean;
    readonly TotalFee: number;
    readonly CanReadSurchargeAdjustment: boolean;
    readonly CanWriteSurchargeAdjustment: boolean;
    SurchargeAdjustment: SurchargeAdjustment;
    readonly CanReadDerivationTimeStamp: boolean;
    readonly CanWriteDerivationTimeStamp: boolean;
    DerivationTimeStamp: Date;
}