namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("4117ba43-c7fd-4ba5-965e-50e2ce5b5058")]
    #endregion
    public partial class DunningType : Enumeration 
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

        #region Allors
        [Id("FB73B5FB-C2A7-48F2-9244-0CD931C63B63")]
        #endregion
        [Workspace]
        public void Delete() { }
    }
}