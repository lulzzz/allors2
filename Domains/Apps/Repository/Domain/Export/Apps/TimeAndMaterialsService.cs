namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("da504b46-2fd0-4500-ae23-61fa73151077")]
    #endregion
    public partial class TimeAndMaterialsService : Service 
    {
        #region inherited properties

        public ProductType ProductType { get; set; }

        public string InternalComment { get; set; }
        public ProductCategory PrimaryProductCategory { get; set; }

        public DateTime SupportDiscontinuationDate { get; set; }

        public DateTime SalesDiscontinuationDate { get; set; }

        public LocalisedText[] LocalisedNames { get; set; }

        public LocalisedText[] LocalisedDescriptions { get; set; }

        public string Description { get; set; }

        public PriceComponent[] VirtualProductPriceComponents { get; set; }

        public string IntrastatCode { get; set; }

        public ProductCategory[] ProductCategoriesExpanded { get; set; }

        public Product ProductComplement { get; set; }

        public ProductFeature[] OptionalFeatures { get; set; }

        public Product[] Variants { get; set; }

        public string Name { get; set; }

        public DateTime IntroductionDate { get; set; }

        public Document[] Documents { get; set; }

        public ProductFeature[] StandardFeatures { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public EstimatedProductCost[] EstimatedProductCosts { get; set; }

        public Product[] ProductObsolescences { get; set; }

        public ProductFeature[] SelectableFeatures { get; set; }

        public VatRate VatRate { get; set; }

        public PriceComponent[] BasePrices { get; set; }

        public ProductCategory[] ProductCategories { get; set; }

        public Guid UniqueId { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        public void Delete() { }
        #endregion

        public string Comment { get; set; }
    }
}