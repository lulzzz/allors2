namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("9BF8812F-44BD-411A-9385-09E4EE25B831")]
    #endregion
    public partial class PurchaseOrderPaymentState : ObjectState 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public string Name { get; set; }

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