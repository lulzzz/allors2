namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("458F158D-F613-44FC-849A-5438302FA7EB")]
    #endregion
    public partial class DiscountAdjustmentVersion : OrderAdjustmentVersion
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        public Guid DerivationId { get; set; }
        public DateTime DerivationTimeStamp { get; set; }

        public User LastModifiedBy { get; set; }

        public decimal Amount { get; set; }
        public VatRate VatRate { get; set; }
        public decimal Percentage { get; set; }

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