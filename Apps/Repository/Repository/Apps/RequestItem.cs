namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("daf83fcc-832e-4d5e-ba71-5a08f42355db")]
    #endregion
    public partial class RequestItem : AccessControlledObject, Commentable 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        public string Comment { get; set; }

        #endregion

        #region Allors
        [Id("542f3de9-e808-443b-b6e6-baf2db1ec2b1")]
        [AssociationId("30b2b652-b7a8-42ec-bd10-dd606a1be951")]
        [RoleId("c176a9ff-7656-4c22-bf00-e19cdcd16566")]
        #endregion
        [Size(256)]

        public string Description { get; set; }
        #region Allors
        [Id("5c0f0069-b7f9-47f1-8346-c30f14afbc0c")]
        [AssociationId("0f924664-8b58-45f4-b6f3-d8201610de8f")]
        [RoleId("3560f38b-1945-4eb1-9b9a-c3e84d267647")]
        #endregion

        public int Quantity { get; set; }
        #region Allors
        [Id("6544faeb-a4cf-447c-a696-b6561c45086e")]
        [AssociationId("3d03cbae-7618-458e-b705-94112c8f66db")]
        [RoleId("0204dc28-cec2-4d6b-b525-c7e4c65f958b")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]

        public Requirement[] Requirements { get; set; }
        #region Allors
        [Id("a5d1bef9-3086-4c32-9a6d-ce33c4f09539")]
        [AssociationId("1d3eedcb-dc13-46ad-ac43-e6979995e00b")]
        [RoleId("474a6350-abba-4c53-ba26-0320c60aa8a8")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Deliverable Deliverable { get; set; }
        #region Allors
        [Id("bf40cb6b-e561-4df1-9ac4-e5a72933c7db")]
        [AssociationId("2eddcab2-e293-4699-8392-c198018a8ce4")]
        [RoleId("90b8c610-e703-4109-92c7-bad2f5e1501b")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public ProductFeature ProductFeature { get; set; }
        #region Allors
        [Id("d02d15ae-2938-4753-95f1-686ea8b02f47")]
        [AssociationId("0abe5f12-ae64-4a8e-b5cc-175d7d2ea1d7")]
        [RoleId("91d62ba3-943e-4aa5-b4fc-6a1f62fcd63f")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public NeededSkill NeededSkill { get; set; }
        #region Allors
        [Id("f03c07b5-44f2-4e61-ad23-7c373851dafc")]
        [AssociationId("d4cce9f6-ebe0-4b72-86f6-d41c8cdf072e")]
        [RoleId("bd7d900b-d5c6-46dc-8843-e4041429858b")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Product Product { get; set; }
        #region Allors
        [Id("fa33c3e6-53c4-428a-bd9c-feba1dd9ed45")]
        [AssociationId("1aa99128-9989-4933-8204-9acefc7b040d")]
        [RoleId("99251c00-d729-4363-8ce8-403ace61725e")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        public decimal MaximumAllowedPrice { get; set; }
        #region Allors
        [Id("ff41a43c-997d-4158-984e-e669eb935148")]
        [AssociationId("b46ffa62-adcb-4928-bdb0-79d0eef9e676")]
        [RoleId("7c4353a9-efd5-437e-8789-fae92a0be1ed")]
        #endregion

        public DateTime RequiredByDate { get; set; }


        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        #endregion

    }
}