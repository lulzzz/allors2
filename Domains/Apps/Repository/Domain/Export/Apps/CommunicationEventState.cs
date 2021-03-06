namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("f6ad2546-e977-4176-b03d-d30fb101270c")]
    #endregion
    public partial class CommunicationEventState : ObjectState 
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