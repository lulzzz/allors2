namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("b05371ff-0c9e-4ee3-b31d-e2edeed8649e")]
    #endregion
    public partial interface CommunicationEvent : Transitional, Deletable, Commentable, UniquelyIdentifiable
    {
        #region Allors
        [Id("7535B38A-A9EE-4990-B80B-10B83E29999D")]
        [AssociationId("16F9459A-D6D8-45D5-9CDF-98F03F8719E4")]
        [RoleId("C13E4CD8-30AE-45CA-A8D6-EE7F833AB493")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Indexed]
        [Required]
        [Derived]
        SecurityToken OwnerSecurityToken { get; set; }

        #region Allors
        [Id("193ED0BD-2645-4546-9CDA-AB894CCB569D")]
        [AssociationId("736FD47F-11DB-4408-B8F0-1B02ABC565C9")]
        [RoleId("B7C74220-F30C-49D6-9930-53A582FFDE08")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Indexed]
        [Derived]
        AccessControl OwnerAccessControl { get; set; }

        #region Allors
        [Id("01665c57-a343-441d-9760-53763badce51")]
        [AssociationId("82c1dad0-6d6d-440c-8bf0-f20d35ab0863")]
        [RoleId("0dd9728e-0887-4029-af20-dd69371fbba0")]
        #endregion
        DateTime ScheduledStart { get; set; }

        #region Allors
        [Id("16c8aada-318c-4bbb-b8a7-7fa20120eda4")]
        [AssociationId("1f7eaa6f-ccdf-464e-a58a-439c5a063827")]
        [RoleId("04e87ca8-16f0-408c-996c-23c63358c21b")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Derived]
        [Indexed]
        Party[] ToParties { get; set; }

        #region Allors
        [Id("1aacf179-cf9f-43e1-b950-4121809fde2d")]
        [AssociationId("6c66dc32-0780-4159-afca-b952c3984d1f")]
        [RoleId("bec5291d-f50a-4673-8318-e9c5f553f625")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        ContactMechanism[] ToContactMechanisms { get; set; }

        #region Allors
        [Id("250911c2-1f8d-4946-8c7f-3e3fa47d66a5")]
        [AssociationId("6537fd2e-e4a7-4cee-9494-e0b54d717b62")]
        [RoleId("4cd91320-82a3-4379-b589-cc834a713591")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Derived]
        [Indexed]
        CommunicationEventStatus[] CommunicationEventStatuses { get; set; }

        #region Allors
        [Id("28874ffe-f3b3-4aba-9f28-ba7c15b0cb65")]
        [AssociationId("544164cd-43e9-4e3c-a0b2-a33574accd7c")]
        [RoleId("cbf3c355-cf99-4bd4-8f8b-e0dca835b9d2")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Derived]
        [Indexed]
        Party[] InvolvedParties { get; set; }

        #region Allors
        [Id("2fa315f8-6208-495c-bcc4-2ccda734cc09")]
        [AssociationId("6b5d29f8-7016-4cdb-9af9-8320b1c7304d")]
        [RoleId("8e7c8bab-063d-4f77-99ae-6e7979b63ce4")]
        #endregion
        DateTime InitialScheduledStart { get; set; }

        #region Allors
        [Id("3657016d-01c5-43db-bd03-5203c1aef14d")]
        [AssociationId("4c2863c0-dc44-42e6-a330-a5c82a37151d")]
        [RoleId("69227618-628c-4a54-8ad9-bc20d087413d")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        [Required]
        CommunicationEventObjectState CurrentObjectState { get; set; }

        #region Allors
        [Id("3a5658bd-b1b9-47e3-b542-ea9de348a44e")]
        [AssociationId("6086288c-6880-4b98-a0ef-7b4a7ecd0af9")]
        [RoleId("d55ec601-4f3f-4834-baec-1675234e7ba5")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        CommunicationEventPurpose[] EventPurposes { get; set; }

        #region Allors
        [Id("3bc21bd3-1af9-492d-8dde-b0696e20a11a")]
        [AssociationId("439ec2e8-0f9c-474f-8cca-6b33887897ae")]
        [RoleId("1d09f872-86ef-4970-9459-d03075799145")]
        #endregion
        DateTime ScheduledEnd { get; set; }

        #region Allors
        [Id("43c26f1f-25bd-4b45-9cdf-c81d021b0b37")]
        [AssociationId("feaad4be-f3e2-4f76-9a87-9676d86bda35")]
        [RoleId("10be3680-44d1-41c9-a084-fbd27a36ecbb")]
        #endregion
        DateTime ActualEnd { get; set; }

        #region Allors
        [Id("51f3e08a-7b1b-4d5b-989c-ad2c734a1b2f")]
        [AssociationId("4f409a5c-1de8-4c4f-a157-02f79bef3efb")]
        [RoleId("1fce36c5-aa88-443b-a3a3-c8bd2fd032dd")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        WorkEffort[] WorkEfforts { get; set; }

        #region Allors
        [Id("52adc5f3-d6ef-4804-8755-b86532d8b6fe")]
        [AssociationId("3c7ad2b5-b1c0-4509-b1e3-6e902778bee6")]
        [RoleId("8722394b-3873-4eb2-8bf4-d70abaf0a77a")]
        #endregion
        [Size(-1)]
        string Description { get; set; }

        #region Allors
        [Id("65499ae5-ab06-4d21-8f94-8bf95a665e3d")]
        [AssociationId("e4844fd8-62d1-4057-8a9b-4ad4fdc3186b")]
        [RoleId("346af9bb-6091-4d5b-ad8e-92d254876f4a")]
        #endregion
        DateTime InitialScheduledEnd { get; set; }

        #region Allors
        [Id("7384d5c7-9af9-45b0-9969-dffe9781cc8c")]
        [AssociationId("540ba3fb-0ba9-4a66-97bb-dfdc33f5cfe8")]
        [RoleId("e571e53d-8b4e-4fa9-9b00-191ffd35c3c5")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Derived]
        [Indexed]
        Party[] FromParties { get; set; }

        #region Allors
        [Id("79e945d3-1200-4a90-8e80-eba298bcda40")]
        [AssociationId("da2c6684-c940-439b-a4b0-76bb1c3cfc12")]
        [RoleId("22204173-7328-4fe4-a1a6-c394b5908a54")]
        #endregion
        [Required]
        [Size(-1)]
        string Subject { get; set; }

        #region Allors
        [Id("91a1555b-a126-4727-86a4-e57e20ebb5da")]
        [AssociationId("38c18c13-4e90-459e-8595-60f1b070cd2a")]
        [RoleId("767e994e-523c-4f2d-a974-470bedb64087")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        Media[] Documents { get; set; }

        #region Allors
        [Id("9e52b6a3-3f94-43d6-9fda-879f57499c05")]
        [AssociationId("9dd6ccef-f816-40d6-9bb4-e1e88b2e0c06")]
        [RoleId("7c309ce2-dd9a-4299-b462-b506b8ca54f4")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        Case Case { get; set; }

        #region Allors
        [Id("bdf87e9c-4ca3-4fba-8b3e-c1252f849953")]
        [AssociationId("2dff0c3b-b14e-4d0f-89d7-e6e371051a1f")]
        [RoleId("d8fb04b0-a113-4cf1-ab3d-1761e2423e76")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        Priority Priority { get; set; }

        #region Allors
        [Id("c1655c56-9e3d-4fe3-9592-681087dfac13")]
        [AssociationId("c92e6264-1872-4cc5-b6d3-6ab1c8c0f877")]
        [RoleId("a2b30174-2efe-4517-be55-c8d4b16d4402")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        ContactMechanism[] FromContactMechanisms { get; set; }

        #region Allors
        [Id("c43b6f6f-0fda-4794-9199-84b39373ecb3")]
        [AssociationId("f8f85fd4-3b97-4a67-8b42-12e17938c802")]
        [RoleId("bc58b136-9b36-4065-babb-934ede99aefd")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Required]
        [Indexed]
        Person Owner { get; set; }

        #region Allors
        [Id("d515f7b6-50d5-447f-b69a-2d1c78b465d3")]
        [AssociationId("dbcacd62-f6d0-4c5e-ae39-d3943042c1eb")]
        [RoleId("ff52f71d-40fe-4d0c-9334-800bf9bde1f1")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Derived]
        [Indexed]
        CommunicationEventStatus CurrentCommunicationEventStatus { get; set; }

        #region Allors
        [Id("e85169df-772c-46cc-a0ef-2bf413aec11d")]
        [AssociationId("684ad0be-d99a-4f67-a235-7d17d49ea224")]
        [RoleId("1b5cc695-29d7-48b7-991f-c8271f9a00d4")]
        #endregion
        [Size(-1)]
        string Note { get; set; }

        #region Allors
        [Id("ecc20a6a-ef70-4a09-8a3b-c8dce88eaa27")]
        [AssociationId("abdb3a26-ae86-4500-a9d9-d9546fb6f856")]
        [RoleId("406f48d7-a0be-48c9-81f5-7b506b41e114")]
        #endregion

        DateTime ActualStart { get; set; }

        #region Allors
        [Id("F1D66D21-15CC-45C3-980C-E4179F66FD57")]
        #endregion
        void Cancel();

        #region Allors
        [Id("97011DA3-10B1-4B27-A4A0-E06D5D6CE04A")]
        #endregion
        void Close();

        #region Allors
        [Id("731D1CF2-01CE-44FE-8065-762E4DB1C5E0")]
        #endregion
        void Reopen();
    }
}