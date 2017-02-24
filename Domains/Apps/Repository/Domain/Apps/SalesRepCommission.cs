namespace Allors.Repository
{
    using System;

    using Allors.Repository.Attributes;

    #region Allors
    [Id("bb5e8196-f821-4fb8-98cb-f19416d1427c")]
    #endregion
    public partial class SalesRepCommission : AccessControlledObject 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("24a89a6a-dc83-431c-b94c-b2c976bc1784")]
        [AssociationId("f7da0085-eeb3-4a4c-bc5c-2b0b32340d80")]
        [RoleId("3927fecb-c2fc-442e-b84e-1922a197acde")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        public decimal Commission { get; set; }
        #region Allors
        [Id("af3ad6bb-70a1-4682-945c-4cad1407ecf2")]
        [AssociationId("cf6d2b69-9646-46d2-a7a1-d02f8b8ec954")]
        [RoleId("6361ff04-7d8e-45f3-b3a5-efe1f6c983be")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public InternalOrganisation InternalOrganisation { get; set; }
        #region Allors
        [Id("d1afca2c-802a-4e66-8c76-42a2e6a1e0a6")]
        [AssociationId("5215dffe-8b1d-43d2-8f88-c16d3e328456")]
        [RoleId("803e015d-6022-4397-a7be-2dd1c2556cca")]
        #endregion
        [Size(256)]

        public string SalesRepName { get; set; }
        #region Allors
        [Id("d3cb9001-ff8c-47e0-b91d-4d3d3fd245ed")]
        [AssociationId("120813ab-5471-4fb6-aa85-417bfbf18559")]
        [RoleId("c17a6b73-52de-41da-9d4d-f00faa10f60a")]
        #endregion

        public int Month { get; set; }
        #region Allors
        [Id("e7d499e6-9a91-41ea-837c-ede30bb19333")]
        [AssociationId("f8469819-f8fc-4762-a3fc-0117bb186269")]
        [RoleId("51481c72-d94f-469f-a22e-57dbe9c1c8ca")]
        #endregion
        [Required]

        public int Year { get; set; }
        #region Allors
        [Id("ea8de270-d03a-44cf-9b97-c233e1615d9e")]
        [AssociationId("7c2854ac-f4db-41e5-8b2f-7a9e9b376dff")]
        [RoleId("bd39c031-3391-4b20-a57f-86c6e4c5b130")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Currency Currency { get; set; }
        #region Allors
        [Id("f6d1ce52-7d8e-42e2-a76e-acc35e2b5dd8")]
        [AssociationId("743000d8-a71b-4638-9b3e-a5be4e45fd29")]
        [RoleId("7e4d3cd9-4066-4186-a311-b1cd5155d632")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Person SalesRep { get; set; }


        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        #endregion

    }
}