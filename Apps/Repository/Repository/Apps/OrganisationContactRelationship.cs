namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("956ecb86-097d-43d4-83b5-a7f45ea75448")]
    #endregion
    public partial class OrganisationContactRelationship : PartyRelationship 
    {
        #region inherited properties
        public PartyRelationshipStatus PartyRelationshipStatus { get; set; }

        public Agreement[] RelationshipAgreements { get; set; }

        public Priority PartyRelationshipPriority { get; set; }

        public decimal SimpleMovingAverage { get; set; }

        public CommunicationEvent[] CommunicationEvents { get; set; }

        public Party[] Parties { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ThroughDate { get; set; }

        public string Comment { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("0ca367d2-0ce2-440d-a4e7-cbf089c1efed")]
        [AssociationId("738d9d62-4823-4045-9e2f-082b91127f3f")]
        [RoleId("fa8ca2da-c75f-4ba9-9c22-6953008c3ba2")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]

        public Person Contact { get; set; }
        #region Allors
        [Id("96f4c9af-eeff-477f-8a93-1168cc383b4c")]
        [AssociationId("a34e218b-26c0-4c88-a202-0353e693833a")]
        [RoleId("3af5a227-4470-4a4e-a66c-245ac0d12be5")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]

        public Organisation Organisation { get; set; }
        #region Allors
        [Id("af7e007e-c325-453a-923e-55299eda2a8c")]
        [AssociationId("337e305a-da68-42da-b508-d9f010138a09")]
        [RoleId("2399e636-f267-4299-b2c7-747497487d63")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]

        public OrganisationContactKind[] ContactKinds { get; set; }


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