namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("29d8d5c2-58f9-41b9-914f-5dce7b69e908")]
    #endregion
    public partial class ProductCategoryRevenueHistory : AccessControlledObject 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("19307e7c-c703-4d76-af03-53add0ad0dec")]
        [AssociationId("9e03ab90-cde9-439a-94ef-7807a1735248")]
        [RoleId("b4027d52-49b4-4991-9294-110e914743ab")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Currency Currency { get; set; }
        #region Allors
        [Id("4db15d5b-129f-412e-9f76-9573a66603c0")]
        [AssociationId("f615a26c-9fb3-44d1-b481-f89fa8440945")]
        [RoleId("57681daa-0588-43cb-a9b0-c1d982fb2408")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        public decimal Revenue { get; set; }
        #region Allors
        [Id("51f81397-a0da-49f7-9f33-96d3aa85f000")]
        [AssociationId("fdee71e1-8c89-4042-ad5d-cab81c88f54d")]
        [RoleId("0d668529-e9e7-4a2c-8451-f4e8b80ec4cc")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public InternalOrganisation InternalOrganisation { get; set; }
        #region Allors
        [Id("72354b14-fce1-4a41-868b-0e315775e506")]
        [AssociationId("03e4a65f-3084-4a8c-993b-8a136d93fcbe")]
        [RoleId("273cd4fa-0a35-4c21-935e-9e01b010e001")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public ProductCategory ProductCategory { get; set; }


        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        #endregion

    }
}