import { SessionObject, Method } from "@allors/framework";
import { Product } from './Product.g';
import { InventoryItemKind } from './InventoryItemKind.g';
import { FinishedGood } from './FinishedGood.g';
import { Party } from './Party.g';
import { Media } from './Media.g';
import { ProductCategory } from './ProductCategory.g';
import { LocalisedText } from './LocalisedText.g';
import { ProductFeature } from './ProductFeature.g';
import { Document } from './Document.g';
import { UnitOfMeasure } from './UnitOfMeasure.g';
import { EstimatedProductCost } from './EstimatedProductCost.g';
import { VatRate } from './VatRate.g';
import { PriceComponent } from './PriceComponent.g';
export declare class Good extends SessionObject implements Product {
    readonly CanReadQuantityOnHand: boolean;
    readonly QuantityOnHand: number;
    readonly CanReadAvailableToPromise: boolean;
    readonly AvailableToPromise: number;
    readonly CanReadInventoryItemKind: boolean;
    readonly CanWriteInventoryItemKind: boolean;
    InventoryItemKind: InventoryItemKind;
    readonly CanReadBarCode: boolean;
    readonly CanWriteBarCode: boolean;
    BarCode: string;
    readonly CanReadFinishedGood: boolean;
    readonly CanWriteFinishedGood: boolean;
    FinishedGood: FinishedGood;
    readonly CanReadSku: boolean;
    readonly CanWriteSku: boolean;
    Sku: string;
    readonly CanReadArticleNumber: boolean;
    readonly CanWriteArticleNumber: boolean;
    ArticleNumber: string;
    readonly CanReadManufacturedBy: boolean;
    readonly CanWriteManufacturedBy: boolean;
    ManufacturedBy: Party;
    readonly CanReadManufacturerId: boolean;
    readonly CanWriteManufacturerId: boolean;
    ManufacturerId: string;
    readonly CanReadSuppliedBy: boolean;
    readonly CanWriteSuppliedBy: boolean;
    SuppliedBy: Party;
    readonly CanReadProductSubstitutions: boolean;
    readonly CanWriteProductSubstitutions: boolean;
    ProductSubstitutions: Product[];
    AddProductSubstitution(value: Product): void;
    RemoveProductSubstitution(value: Product): void;
    readonly CanReadProductIncompatibilities: boolean;
    readonly CanWriteProductIncompatibilities: boolean;
    ProductIncompatibilities: Product[];
    AddProductIncompatibility(value: Product): void;
    RemoveProductIncompatibility(value: Product): void;
    readonly CanReadPrimaryPhoto: boolean;
    readonly CanWritePrimaryPhoto: boolean;
    PrimaryPhoto: Media;
    readonly CanReadPhotos: boolean;
    readonly CanWritePhotos: boolean;
    Photos: Media[];
    AddPhoto(value: Media): void;
    RemovePhoto(value: Media): void;
    readonly CanReadKeywords: boolean;
    readonly CanWriteKeywords: boolean;
    Keywords: string;
    readonly CanReadInternalComment: boolean;
    readonly CanWriteInternalComment: boolean;
    InternalComment: string;
    readonly CanReadPrimaryProductCategory: boolean;
    readonly CanWritePrimaryProductCategory: boolean;
    PrimaryProductCategory: ProductCategory;
    readonly CanReadSupportDiscontinuationDate: boolean;
    readonly CanWriteSupportDiscontinuationDate: boolean;
    SupportDiscontinuationDate: Date;
    readonly CanReadSalesDiscontinuationDate: boolean;
    readonly CanWriteSalesDiscontinuationDate: boolean;
    SalesDiscontinuationDate: Date;
    readonly CanReadLocalisedNames: boolean;
    readonly CanWriteLocalisedNames: boolean;
    LocalisedNames: LocalisedText[];
    AddLocalisedName(value: LocalisedText): void;
    RemoveLocalisedName(value: LocalisedText): void;
    readonly CanReadLocalisedDescriptions: boolean;
    readonly CanWriteLocalisedDescriptions: boolean;
    LocalisedDescriptions: LocalisedText[];
    AddLocalisedDescription(value: LocalisedText): void;
    RemoveLocalisedDescription(value: LocalisedText): void;
    readonly CanReadLocalisedComments: boolean;
    readonly CanWriteLocalisedComments: boolean;
    LocalisedComments: LocalisedText[];
    AddLocalisedComment(value: LocalisedText): void;
    RemoveLocalisedComment(value: LocalisedText): void;
    readonly CanReadDescription: boolean;
    readonly Description: string;
    readonly CanReadProductComplement: boolean;
    readonly CanWriteProductComplement: boolean;
    ProductComplement: Product;
    readonly CanReadOptionalFeatures: boolean;
    readonly CanWriteOptionalFeatures: boolean;
    OptionalFeatures: ProductFeature[];
    AddOptionalFeature(value: ProductFeature): void;
    RemoveOptionalFeature(value: ProductFeature): void;
    readonly CanReadVariants: boolean;
    readonly CanWriteVariants: boolean;
    Variants: Product[];
    AddVariant(value: Product): void;
    RemoveVariant(value: Product): void;
    readonly CanReadName: boolean;
    readonly Name: string;
    readonly CanReadIntroductionDate: boolean;
    readonly CanWriteIntroductionDate: boolean;
    IntroductionDate: Date;
    readonly CanReadDocuments: boolean;
    readonly CanWriteDocuments: boolean;
    Documents: Document[];
    AddDocument(value: Document): void;
    RemoveDocument(value: Document): void;
    readonly CanReadStandardFeatures: boolean;
    readonly CanWriteStandardFeatures: boolean;
    StandardFeatures: ProductFeature[];
    AddStandardFeature(value: ProductFeature): void;
    RemoveStandardFeature(value: ProductFeature): void;
    readonly CanReadUnitOfMeasure: boolean;
    readonly CanWriteUnitOfMeasure: boolean;
    UnitOfMeasure: UnitOfMeasure;
    readonly CanReadEstimatedProductCosts: boolean;
    readonly CanWriteEstimatedProductCosts: boolean;
    EstimatedProductCosts: EstimatedProductCost[];
    AddEstimatedProductCost(value: EstimatedProductCost): void;
    RemoveEstimatedProductCost(value: EstimatedProductCost): void;
    readonly CanReadProductObsolescences: boolean;
    readonly CanWriteProductObsolescences: boolean;
    ProductObsolescences: Product[];
    AddProductObsolescence(value: Product): void;
    RemoveProductObsolescence(value: Product): void;
    readonly CanReadSelectableFeatures: boolean;
    readonly CanWriteSelectableFeatures: boolean;
    SelectableFeatures: ProductFeature[];
    AddSelectableFeature(value: ProductFeature): void;
    RemoveSelectableFeature(value: ProductFeature): void;
    readonly CanReadVatRate: boolean;
    readonly CanWriteVatRate: boolean;
    VatRate: VatRate;
    readonly CanReadBasePrices: boolean;
    readonly BasePrices: PriceComponent[];
    readonly CanReadProductCategories: boolean;
    readonly CanWriteProductCategories: boolean;
    ProductCategories: ProductCategory[];
    AddProductCategory(value: ProductCategory): void;
    RemoveProductCategory(value: ProductCategory): void;
    readonly CanReadComment: boolean;
    readonly CanWriteComment: boolean;
    Comment: string;
    readonly CanReadUniqueId: boolean;
    readonly CanWriteUniqueId: boolean;
    UniqueId: string;
    readonly CanExecuteDelete: boolean;
    readonly Delete: Method;
}