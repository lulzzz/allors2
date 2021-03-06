namespace Allors.Repository
{
    using Attributes;

    #region Allors
    [Id("73F2577B-D217-47B1-B5DC-19D18C102554")]
    #endregion
    public partial class PartNumber : ProductIdentification
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        public string Identification { get; set; }

        public ProductIdentificationType ProductIdentificationType { get; set; }

        #endregion

        #region inherited methods

        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        public void Delete() { }

        #endregion
    }
}