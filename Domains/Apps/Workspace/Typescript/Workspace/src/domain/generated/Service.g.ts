// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { Product } from './Product.g';
import { Commentable } from './Commentable.g';
import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { Deletable } from './Deletable.g';
import { ProductCategory } from './ProductCategory.g';
import { LocalisedText } from './LocalisedText.g';
import { ProductFeature } from './ProductFeature.g';
import { Document } from './Document.g';
import { UnitOfMeasure } from './UnitOfMeasure.g';
import { EstimatedProductCost } from './EstimatedProductCost.g';
import { VatRate } from './VatRate.g';
import { PriceComponent } from './PriceComponent.g';
import { GeneralLedgerAccount } from './GeneralLedgerAccount.g';
import { Good } from './Good.g';
import { QuoteItemVersion } from './QuoteItemVersion.g';
import { RequestItemVersion } from './RequestItemVersion.g';
import { SalesInvoiceItemVersion } from './SalesInvoiceItemVersion.g';
import { SalesOrderItemVersion } from './SalesOrderItemVersion.g';
import { OrganisationGlAccount } from './OrganisationGlAccount.g';
import { QuoteItem } from './QuoteItem.g';
import { RequestItem } from './RequestItem.g';
import { SalesInvoiceItem } from './SalesInvoiceItem.g';
import { SalesOrderItem } from './SalesOrderItem.g';

export interface Service extends SessionObject , Product {

    CanExecuteDelete: boolean;
    Delete: Method;

}