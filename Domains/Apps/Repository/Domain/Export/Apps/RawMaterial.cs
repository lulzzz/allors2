namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("9a484067-2003-42f1-b4c4-877e519bb8be")]
    #endregion
    public partial class RawMaterial : Part 
    {
        #region inherited properties

        public InternalOrganisation InternalOrganisation { get; set; }

        public string Name { get; set; }

        public PartSpecification[] PartSpecifications { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public Document[] Documents { get; set; }

        public string ManufacturerId { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }

        public PriceComponent[] PriceComponents { get; set; }

        public InventoryItemKind InventoryItemKind { get; set; }

        public string Sku { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        public Guid UniqueId { get; set; }

        #endregion

        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}



        #endregion
    }
}