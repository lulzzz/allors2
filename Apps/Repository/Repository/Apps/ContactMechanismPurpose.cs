namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("0c6880e7-b41c-47a6-ab40-83e391c7a025")]
    #endregion
    public partial class ContactMechanismPurpose : Enumeration 
    {
        #region inherited properties
        public LocalisedText[] LocalisedNames { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

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