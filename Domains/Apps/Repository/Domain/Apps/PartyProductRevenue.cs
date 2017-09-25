namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("3a0364f4-d872-4c47-a3ef-73d624128693")]
    #endregion
    public partial class PartyProductRevenue : Deletable, AccessControlledObject 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("3f8b0163-f038-4f3e-b426-e72ddeee3581")]
        [AssociationId("c4f6804f-46db-4007-8873-ef37652ce8b7")]
        [RoleId("51febfc1-c684-47d5-b1cb-9e43405c14d8")]
        #endregion
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal Revenue { get; set; }
        #region Allors
        [Id("5428d606-6bd8-4090-aea0-25e042afad5c")]
        [AssociationId("052f574b-477c-488c-87c0-6c2edd882b1a")]
        [RoleId("cc9d93ce-a2aa-409d-951e-a929dea264d7")]
        #endregion
        [Required]

        public int Month { get; set; }
        #region Allors
        [Id("5b22f74d-19eb-46f4-ac0b-1288bd00538c")]
        [AssociationId("bdb224cb-a727-4598-9ed8-7f8cb575cb47")]
        [RoleId("5be79e8e-c413-43ae-b524-e1a70641ddc3")]
        #endregion
        [Indexed]
        [Required]

        public int Year { get; set; }
        #region Allors
        [Id("8cb4b613-88f7-4767-90c2-1a4fd4e8a368")]
        [AssociationId("3ba77a3f-1fac-441b-b498-5a7187c386a0")]
        [RoleId("3b2b5aff-ab2c-4c5e-b24f-42f4463f00a7")]
        #endregion
        [Size(256)]

        public string PartyProductName { get; set; }
        #region Allors
        [Id("8edddcd2-07f2-47dc-8b5a-c63401ea5042")]
        [AssociationId("fc01ed7e-157b-4d5a-824c-8406530f5cf7")]
        [RoleId("559fc116-0a38-431e-acbc-1281bef6b503")]
        #endregion
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal Quantity { get; set; }
        #region Allors
        [Id("98ad9944-62a5-4045-b4ba-0317240f5a61")]
        [AssociationId("297ff711-7ebd-45e0-87ed-2c68e8c71fce")]
        [RoleId("8bb7005b-3d03-4ecd-b3d0-413a814f682a")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Currency Currency { get; set; }
        #region Allors
        [Id("b2bad0dc-c3d2-498d-a434-dfbe2c29d903")]
        [AssociationId("8bc50d0b-dacb-499c-92ed-a27f0bced17c")]
        [RoleId("eae57a6c-8efe-4e55-b18e-10d2ca0e3296")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Party Party { get; set; }

        #region Allors
        [Id("ff1b20d3-602b-4f43-92c7-d3f412950672")]
        [AssociationId("3bdf82fa-e7c4-4ab4-b766-af73c6a4ce27")]
        [RoleId("a1587822-ec41-4bdc-8655-491f5012ac1b")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Product Product { get; set; }


        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        public void Delete(){}

        #endregion

    }
}