// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { Printable } from './Printable.g';
import { Commentable } from './Commentable.g';
import { Localised } from './Localised.g';
import { Auditable } from './Auditable.g';
import { Currency } from './Currency.g';
import { Fee } from './Fee.g';
import { OrderTerm } from './OrderTerm.g';
import { OrderItem } from './OrderItem.g';
import { DiscountAdjustment } from './DiscountAdjustment.g';
import { OrderKind } from './OrderKind.g';
import { VatRegime } from './VatRegime.g';
import { ShippingAndHandlingCharge } from './ShippingAndHandlingCharge.g';
import { SurchargeAdjustment } from './SurchargeAdjustment.g';
import { Person } from './Person.g';
import { Locale } from './Locale.g';
import { User } from './User.g';

export interface Order extends SessionObject , Printable, Commentable, Localised, Auditable {
        InternalComment : string;


        CustomerCurrency : Currency;


        TotalBasePriceCustomerCurrency : number;


        TotalIncVatCustomerCurrency : number;


        TotalDiscountCustomerCurrency : number;


        CustomerReference : string;


        Fee : Fee;


        TotalExVat : number;


        OrderTerms : OrderTerm[];
        AddOrderTerm(value: OrderTerm);
        RemoveOrderTerm(value: OrderTerm);


        TotalVat : number;


        TotalSurcharge : number;


        ValidOrderItems : OrderItem[];


        OrderNumber : string;


        TotalVatCustomerCurrency : number;


        TotalDiscount : number;


        Message : string;


        Description : string;


        TotalShippingAndHandlingCustomerCurrency : number;


        EntryDate : Date;


        DiscountAdjustment : DiscountAdjustment;


        OrderKind : OrderKind;


        TotalIncVat : number;


        TotalSurchargeCustomerCurrency : number;


        VatRegime : VatRegime;


        TotalFeeCustomerCurrency : number;


        TotalShippingAndHandling : number;


        ShippingAndHandlingCharge : ShippingAndHandlingCharge;


        OrderDate : Date;


        TotalExVatCustomerCurrency : number;


        DeliveryDate : Date;


        TotalBasePrice : number;


        TotalFee : number;


        SurchargeAdjustment : SurchargeAdjustment;


        ContactPerson : Person;


    CanExecuteApprove: boolean;
    Approve: Method;

    CanExecuteReject: boolean;
    Reject: Method;

    CanExecuteHold: boolean;
    Hold: Method;

    CanExecuteContinue: boolean;
    Continue: Method;

    CanExecuteConfirm: boolean;
    Confirm: Method;

    CanExecuteCancel: boolean;
    Cancel: Method;

    CanExecuteComplete: boolean;
    Complete: Method;

}