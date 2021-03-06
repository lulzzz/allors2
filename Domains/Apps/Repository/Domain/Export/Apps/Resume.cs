namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("4f7703b0-7201-4f7a-a0b4-f177d64a2c31")]
    #endregion
    public partial class Resume : AccessControlledObject 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("5ebf789b-f66a-40c9-99d6-bfaedc581c78")]
        [AssociationId("f90810ba-d62d-4e51-b9c7-5aac4e7d4d87")]
        [RoleId("62592457-6263-4e92-b45d-b929245fa750")]
        #endregion
        [Required]

        public DateTime ResumeDate { get; set; }
        #region Allors
        [Id("f2330d10-d7da-4085-8eff-f0b77cb91763")]
        [AssociationId("d38024ac-2e0b-40f1-a6e4-252c5ffc0bcc")]
        [RoleId("b83ee648-06c2-40c6-a907-5d477d57d7db")]
        #endregion
        [Required]
        [Size(-1)]

        public string ResumeText { get; set; }


        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        #endregion

    }
}