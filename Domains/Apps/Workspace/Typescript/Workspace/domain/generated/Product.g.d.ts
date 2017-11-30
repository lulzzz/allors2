import { SessionObject, Method } from "@allors/framework";
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
export interface Product extends SessionObject, Commentable, UniquelyIdentifiable, Deletable {
    InternalComment: string;
    PrimaryProductCategory: ProductCategory;
    SupportDiscontinuationDate: Date;
    SalesDiscontinuationDate: Date;
    LocalisedNames: LocalisedText[];
    AddLocalisedName(value: LocalisedText): any;
    RemoveLocalisedName(value: LocalisedText): any;
    LocalisedDescriptions: LocalisedText[];
    AddLocalisedDescription(value: LocalisedText): any;
    RemoveLocalisedDescription(value: LocalisedText): any;
    LocalisedComments: LocalisedText[];
    AddLocalisedComment(value: LocalisedText): any;
    RemoveLocalisedComment(value: LocalisedText): any;
    Description: string;
    ProductComplement: Product;
    OptionalFeatures: ProductFeature[];
    AddOptionalFeature(value: ProductFeature): any;
    RemoveOptionalFeature(value: ProductFeature): any;
    Variants: Product[];
    AddVariant(value: Product): any;
    RemoveVariant(value: Product): any;
    Name: string;
    IntroductionDate: Date;
    Documents: Document[];
    AddDocument(value: Document): any;
    RemoveDocument(value: Document): any;
    StandardFeatures: ProductFeature[];
    AddStandardFeature(value: ProductFeature): any;
    RemoveStandardFeature(value: ProductFeature): any;
    UnitOfMeasure: UnitOfMeasure;
    EstimatedProductCosts: EstimatedProductCost[];
    AddEstimatedProductCost(value: EstimatedProductCost): any;
    RemoveEstimatedProductCost(value: EstimatedProductCost): any;
    ProductObsolescences: Product[];
    AddProductObsolescence(value: Product): any;
    RemoveProductObsolescence(value: Product): any;
    SelectableFeatures: ProductFeature[];
    AddSelectableFeature(value: ProductFeature): any;
    RemoveSelectableFeature(value: ProductFeature): any;
    VatRate: VatRate;
    BasePrices: PriceComponent[];
    ProductCategories: ProductCategory[];
    AddProductCategory(value: ProductCategory): any;
    RemoveProductCategory(value: ProductCategory): any;
    CanExecuteDelete: boolean;
    Delete: Method;
}