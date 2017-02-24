namespace Allors.Repository
{
    using System;

    using Allors.Repository.Attributes;

    #region Allors
    [Id("084abb92-31fd-46e6-ab85-9a7a88c9d72b")]
    #endregion
	public partial interface PartyRelationship : Period, Commentable, AccessControlledObject, Deletable 
    {


        #region Allors
        [Id("1da069bb-5e29-49e0-93a8-b869a7f2d61a")]
        [AssociationId("5a6aeb4c-b76a-4044-b43a-2d226225bac1")]
        [RoleId("86b546d6-d286-4048-bf5c-2de020b39690")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        PartyRelationshipStatus PartyRelationshipStatus { get; set; }


        #region Allors
        [Id("296628f5-ad97-47b0-8865-6221a43f45e9")]
        [AssociationId("c04bb236-5c81-445d-a363-125002b01cea")]
        [RoleId("0a2a7b62-da4d-4099-b89e-7bf451ed9009")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]

        Agreement[] RelationshipAgreements { get; set; }


        #region Allors
        [Id("37273d64-63d7-4878-a5c0-1d4a834ebc9f")]
        [AssociationId("72d44569-cb28-42a4-8b70-a3298ef36dfd")]
        [RoleId("426a2ea4-2335-4a9c-8e1d-3258c4f58639")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        Priority PartyRelationshipPriority { get; set; }


        #region Allors
        [Id("9a0effb1-eff9-402a-9864-470569be9e7b")]
        [AssociationId("fbb79a3b-013d-4ec9-93ae-3b80b759f6eb")]
        [RoleId("f4e6833d-da52-484e-8c6f-b1f55730178e")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        decimal SimpleMovingAverage { get; set; }


        #region Allors
        [Id("9dc11de2-ddf4-4f38-8cbe-776d9fad599d")]
        [AssociationId("f4b2e224-e024-471e-b145-4d2f819d7e8b")]
        [RoleId("f2d86632-03c8-4724-bf11-3aad09bea789")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]

        CommunicationEvent[] CommunicationEvents { get; set; }


        #region Allors
        [Id("8472a037-3a42-4d1c-a7cb-f8866141f65d")]
        [AssociationId("48ebe634-9189-4d7c-b796-b6db43d33063")]
        [RoleId("9377f1f2-581a-44ae-94c6-e2f8dbccffd0")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Derived]
        [Indexed]

        Party[] Parties { get; set; }

    }
}