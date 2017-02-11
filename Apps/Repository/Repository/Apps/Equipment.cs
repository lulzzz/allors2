namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("da852ff9-0c87-4fa6-a93a-90d97d28029c")]
    #endregion
    [Plural("Equipments")]
    public partial class Equipment : FixedAsset 
    {
        #region inherited properties
        public string Name { get; set; }

        public DateTime LastServiceDate { get; set; }

        public DateTime AcquiredDate { get; set; }

        public string Description { get; set; }

        public decimal ProductionCapacity { get; set; }

        public DateTime NextServiceDate { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

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