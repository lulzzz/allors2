namespace Allors.Repository
{
    using System;

    using Allors.Repository.Attributes;

    #region Allors
    [Id("3b9f21f4-2f2c-47a9-9c76-15f5ef4f5e00")]
    #endregion
    public partial class CustomerRelationship : PartyRelationship 
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
        [Id("009d073e-8c1b-4da5-8780-bd5bff43db0d")]
        [AssociationId("f7a9d8ed-4efa-4d39-a79d-ab1e3acda26c")]
        [RoleId("bfdae8de-2880-47c5-afd1-93c9b9b24dab")]
        #endregion

        public bool BlockedForDunning { get; set; }
        #region Allors
        [Id("35f92e67-aedd-4e62-aa1b-57f6489c0083")]
        [AssociationId("995ccfb4-f1ca-4894-9fd9-fbf19e2226eb")]
        [RoleId("96eaeb9a-8047-4068-9185-765fc0e48342")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]

        public InternalOrganisation InternalOrganisation { get; set; }
        #region Allors
        [Id("42e3b2c4-376d-4e8b-bb49-2af031881ed0")]
        [AssociationId("bcdd31e8-8101-4b6b-8f13-a4397c43adfa")]
        [RoleId("a9ddfe04-e5fd-4b22-9a9a-702dc0533731")]
        #endregion
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal AmountOverDue { get; set; }
        #region Allors
        [Id("5c7c79e1-6b61-4f64-b8d1-608984f91268")]
        [AssociationId("9ce91d5f-12af-44a5-97a9-16c1b9986f67")]
        [RoleId("74a36a15-f48a-4794-ac10-2c0860cc4ca1")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]

        public Party Customer { get; set; }
        #region Allors
        [Id("76b46019-c145-403d-9f99-cd8e1001c968")]
        [AssociationId("6702ba13-81eb-4d23-b341-8fb84cf7e60f")]
        [RoleId("079e6188-73d0-4161-8327-607554a42613")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public DunningType DunningType { get; set; }
        #region Allors
        [Id("894f4ff2-9c41-4201-ad36-ac10dafd65dd")]
        [AssociationId("c8a336f0-4fae-4ce6-a900-283066052ffd")]
        [RoleId("11fa6c6e-c528-452c-adca-75f474d2f95b")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal AmountDue { get; set; }
        #region Allors
        [Id("a484eb38-4beb-495c-9c54-522238e0e639")]
        [AssociationId("03c7d5c4-4c80-4511-9ab2-2745f3f17596")]
        [RoleId("f4a2fdef-d91a-4c7e-94d5-ebe13ab94338")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal YTDRevenue { get; set; }
        #region Allors
        [Id("af50ade8-5964-4963-819d-c87689c6434e")]
        [AssociationId("a06dda1c-d91d-4e27-b293-05cb53de65ec")]
        [RoleId("7f6da6ca-b069-47f6-983c-6e33d65ffd0e")]
        #endregion

        public DateTime LastReminderDate { get; set; }
        #region Allors
        [Id("dd59ed76-b6da-49a3-8c3e-1edf4d1d0900")]
        [AssociationId("e2afe553-7bbd-4f81-97e8-7279defb49ca")]
        [RoleId("b5e30743-6adc-4bf0-b547-72b17b79879c")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        public decimal CreditLimit { get; set; }
        #region Allors
        [Id("e3a06a1c-998a-4871-8f0e-2f166eac6c7b")]
        [AssociationId("08dfdeb5-1a62-42d6-b8f3-16025960b09f")]
        [RoleId("9400c681-2a68-4842-89fd-3c9ccb3f2a96")]
        #endregion
        [Required]

        public int SubAccountNumber { get; set; }
        #region Allors
        [Id("e924ea41-ae61-4cf1-9bf4-4661497289c1")]
        [AssociationId("b6d5c0a6-f5b4-43df-952f-0a5f82b68b1f")]
        [RoleId("d4bbb472-cf06-4569-9d91-00ee3a98eb41")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal LastYearsRevenue { get; set; }


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