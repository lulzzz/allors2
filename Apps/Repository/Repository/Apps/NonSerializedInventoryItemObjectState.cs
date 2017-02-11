namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("9dd17a3f-0e3c-4d87-b840-2f23a96dd165")]
    #endregion
    public partial class NonSerializedInventoryItemObjectState : ObjectState 
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