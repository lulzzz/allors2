namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("9c6f4ad8-5a4e-4b6e-96b7-876f7aabcffb")]
    #endregion
    public partial interface Shipment : Printable, Commentable, Auditable, Transitional
    {
        #region Allors
        [Id("05221b28-9c80-4d3b-933f-12a8a17bc261")]
        [AssociationId("c59ef057-da9a-433f-90d3-5ff657aa1e48")]
        [RoleId("6fe551cd-0808-466b-9ec9-833098ebad79")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Required]
        [Indexed]
        ShipmentMethod ShipmentMethod { get; set; }

        #region Allors
        [Id("05b0841b-d546-4fd6-9305-492b0ce20f8a")]
        [AssociationId("26be1e2b-ee3c-4c37-9ccc-07a916e6af29")]
        [RoleId("313a2875-bafc-430a-b7c4-1aa45e825233")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        ContactMechanism BillToContactMechanism { get; set; }

        #region Allors
        [Id("165b529f-df1c-45b6-bbed-d19ffcb375f2")]
        [AssociationId("c71e40be-1f55-483d-9bfa-0d2dfb26c7d9")]
        [RoleId("18a5331e-120e-45e6-8ef4-35a1f48237e0")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        ShipmentPackage[] ShipmentPackages { get; set; }

        #region Allors
        [Id("17234c66-6b61-4ac9-a23b-4388e19f4888")]
        [AssociationId("bc2164ec-5d7e-4dff-8db6-4d1eeab970e6")]
        [RoleId("f939af72-bcb4-44bc-b47d-758c27304a7d")]
        #endregion
        [Required]
        [Size(256)]
        string ShipmentNumber { get; set; }

        #region Allors
        [Id("18808545-f941-4c5a-8809-0f1fb0cca2d8")]
        [AssociationId("44940303-b210-42bd-8791-906004294261")]
        [RoleId("a65dbc06-f659-4e34-bf2d-af4b4717972e")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        Document[] Documents { get; set; }

        #region Allors
        [Id("50f36218-ae61-4d67-af4d-d05cc8b2266d")]
        [AssociationId("a8ff4824-3ccd-49a8-82e6-e7723ccb8348")]
        [RoleId("b7ead377-a5d4-4eab-98d9-e9527177090a")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        Party BillToParty { get; set; }

        #region Allors
        [Id("5891b368-89cd-4a0e-aaef-439f442909c8")]
        [AssociationId("5fef9e9f-bd3d-454a-8aa1-10b262a34a4b")]
        [RoleId("dd5e8d80-0395-413d-addb-ca66f36c50e8")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        Party ShipToParty { get; set; }

        #region Allors
        [Id("f1e92d31-db63-419c-8ed7-49f5db66c63d")]
        [AssociationId("fffbc8b5-a541-402d-8df6-3134cc52b306")]
        [RoleId("566b9c3a-3fec-455f-a40d-b23338d3508c")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        Party ShipFromParty { get; set; }

        #region Allors
        [Id("6a568bea-6718-414a-b822-d8304502be7b")]
        [AssociationId("499bb422-b2f0-48cf-bf09-0544e768b5de")]
        [RoleId("b8724e90-9888-4f81-b70d-1eceb93af3d3")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        ShipmentItem[] ShipmentItems { get; set; }

        #region Allors
        [Id("78e7e7a5-2d8c-4184-b917-10095dc033b1")]
        [AssociationId("f924c450-6c83-4853-9449-b34efb52cc78")]
        [RoleId("b9c80d27-7278-4883-b1f3-d01712463109")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        ContactMechanism ReceiverContactMechanism { get; set; }

        #region Allors
        [Id("7e1325e0-a072-46da-adb5-b997dde9980a")]
        [AssociationId("f73c3f6d-cc9c-4bda-a4c6-ef4f406a491d")]
        [RoleId("14f6385d-4e20-4ffe-89e7-f7a261eda78e")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Required]
        [Indexed]
        PostalAddress ShipToAddress { get; set; }

        #region Allors
        [Id("894ecdf3-1322-4513-bf94-63882c5c29bf")]
        [AssociationId("da1adb58-e2be-4018-97b0-fb2ef107a661")]
        [RoleId("7e28940e-6039-4698-b1f5-b31769aa7bbb")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        decimal EstimatedShipCost { get; set; }

        #region Allors
        [Id("97788e21-ec31-4fb2-9ef7-0b7b5a7367a1")]
        [AssociationId("227f8e47-58af-44be-bcaf-0da60e2c13d4")]
        [RoleId("338e2be0-6eb5-42ad-b51c-83dd9b7f0194")]
        #endregion
        DateTime EstimatedShipDate { get; set; }

        #region Allors
        [Id("a74391e5-bd03-4247-93b8-e7081d939823")]
        [AssociationId("41060c75-fb34-4391-96f3-d0d267344ba3")]
        [RoleId("eb3f084c-9d59-4fff-9fc3-186d7b9a19b3")]
        #endregion
        DateTime LatestCancelDate { get; set; }

        #region Allors
        [Id("b37c7c90-0287-4f12-b000-025e2505499c")]
        [AssociationId("13e8d5af-43ff-431b-85d8-5e7706dc2f75")]
        [RoleId("81367cbd-4713-46bd-8f4d-0df30c3daf96")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        Carrier Carrier { get; set; }

        #region Allors
        [Id("b5dabbcc-508a-4998-a21a-6b86d7193688")]
        [AssociationId("43d9bbc8-319c-4971-a651-11f246fafa97")]
        [RoleId("ebf2b41f-a922-4689-83d4-51569a3d85d3")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        ContactMechanism InquireAboutContactMechanism { get; set; }

        #region Allors
        [Id("b69c6812-bdc4-4a06-a782-fa8ff4a71aca")]
        [AssociationId("988cafce-2323-4c0d-b1cd-026045764ba4")]
        [RoleId("cd02effa-d176-4f6e-8407-ec12d23b9f2a")]
        #endregion
        DateTime EstimatedReadyDate { get; set; }

        #region Allors
        [Id("c8b0eff8-4dff-449c-9d44-a7235cd24928")]
        [AssociationId("556c0ae6-045e-4f35-8f63-ffb41f57dc44")]
        [RoleId("5c34f5ee-5f25-42dd-97a8-7aa3aeb9973e")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        PostalAddress ShipFromAddress { get; set; }

        #region Allors
        [Id("ea57219b-217e-444d-9741-c1c4e7aee9f7")]
        [AssociationId("2d0935d0-cdb5-4c3e-9726-e27ea731c43b")]
        [RoleId("d7184821-3b9c-4800-874f-32d7cd9b72e3")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        ContactMechanism BillFromContactMechanism { get; set; }

        #region Allors
        [Id("ee49c6ca-bb03-40d3-97f1-004cc5a31132")]
        [AssociationId("167b541c-d2dd-4d9b-9fe1-6cd8d1a5f727")]
        [RoleId("39a0ed41-436e-44bd-afc7-5d848397433b")]
        #endregion
        [Size(-1)]
        string HandlingInstruction { get; set; }

        #region Allors
        [Id("f1059139-6664-43d5-801f-79a4cc4288a6")]
        [AssociationId("92807e93-ed03-4dbc-9296-c508c879705b")]
        [RoleId("3f2699b9-9652-4af4-98d7-2ff803677692")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        Store Store { get; set; }

        #region Allors
        [Id("f403ab39-cc81-4e09-8794-a45db9ef178f")]
        [AssociationId("78c8d202-0277-4c3a-9e24-74041cc56872")]
        [RoleId("8086c3d5-1577-4c32-bf73-abe72aac725c")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        ShipmentRouteSegment[] ShipmentRouteSegments { get; set; }

        #region Allors
        [Id("fdac3beb-edf8-4d1b-80d4-21b643ef43ce")]
        [AssociationId("63d8adfc-6afb-499f-bd27-2f1d3f78bee6")]
        [RoleId("8f56ce24-500e-4db9-abce-c7a301c38fe6")]
        #endregion
        DateTime EstimatedArrivalDate { get; set; }

        #region Allors
        [Id("F6B4B2D0-A896-480E-A441-F15AB11A3CC9")]
        #endregion
        [Workspace]
        void Invoice();
    }
}