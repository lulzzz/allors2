namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("1ee19062-e36d-4836-b0e6-928a3957bd57")]
    #endregion
    public partial class PurchaseInvoiceItem : InvoiceItem, IPurchaseInvoiceItem 
    {
        #region inherited properties

        public string InternalComment { get; set; }
        public AgreementTerm[] InvoiceTerms { get; set; }
        public decimal TotalInvoiceAdjustment { get; set; }
        public InvoiceVatRateItem[] InvoiceVatRateItems { get; set; }
        public IInvoiceItem AdjustmentFor { get; set; }
        public SerialisedInventoryItem SerializedInventoryItem { get; set; }
        public string Message { get; set; }
        public decimal TotalInvoiceAdjustmentCustomerCurrency { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public Permission[] DeniedPermissions { get; set; }
        public SecurityToken[] SecurityTokens { get; set; }
        public ObjectState PreviousObjectState { get; set; }
        public ObjectState LastObjectState { get; set; }
        public string Comment { get; set; }
        public decimal TotalDiscountAsPercentage { get; set; }
        public DiscountAdjustment DiscountAdjustment { get; set; }
        public decimal UnitVat { get; set; }
        public decimal TotalVatCustomerCurrency { get; set; }
        public VatRegime VatRegime { get; set; }
        public decimal TotalVat { get; set; }
        public decimal UnitSurcharge { get; set; }
        public decimal UnitDiscount { get; set; }
        public decimal TotalExVatCustomerCurrency { get; set; }
        public VatRate DerivedVatRate { get; set; }
        public decimal ActualUnitPrice { get; set; }
        public decimal TotalIncVatCustomerCurrency { get; set; }
        public decimal UnitBasePrice { get; set; }
        public decimal CalculatedUnitPrice { get; set; }
        public decimal TotalSurchargeCustomerCurrency { get; set; }
        public decimal TotalIncVat { get; set; }
        public decimal TotalSurchargeAsPercentage { get; set; }
        public decimal TotalDiscountCustomerCurrency { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalSurcharge { get; set; }
        public VatRegime AssignedVatRegime { get; set; }
        public decimal TotalBasePrice { get; set; }
        public decimal TotalExVat { get; set; }
        public decimal TotalBasePriceCustomerCurrency { get; set; }
        public PriceComponent[] CurrentPriceComponents { get; set; }
        public SurchargeAdjustment SurchargeAdjustment { get; set; }
        public PurchaseInvoiceItemType PurchaseInvoiceItemType { get; set; }
        public Part Part { get; set; }
        public PurchaseInvoiceItemObjectState CurrentObjectState { get; set; }
        #endregion

        #region Allors
        [Id("F41279D9-A0F9-44EB-857D-3C76D9CBE634")]
        [AssociationId("46FD1730-7AED-4B5F-8858-279FFE7F30CC")]
        [RoleId("5D1A28E5-0694-417C-B508-7AE40FA60BBC")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public PurchaseInvoiceItemVersion CurrentVersion { get; set; }

        #region Allors
        [Id("8C554269-1115-4C83-BB6E-A946D329E2A1")]
        [AssociationId("F78062F1-C79F-4AB4-8BC8-F2B50960C096")]
        [RoleId("A32CD93D-1DCA-4685-B700-5ADCDE93AB60")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public PurchaseInvoiceItemVersion PreviousVersion { get; set; }

        #region Allors
        [Id("E17BF428-BA56-451B-90D9-371CDA61E0E6")]
        [AssociationId("EDCC5A53-993F-40B6-81B1-F9070E04D584")]
        [RoleId("0CC8F3F3-A774-41E2-9242-FCEBE88D93B7")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Workspace]
        public PurchaseInvoiceItemVersion[] AllVersions { get; set; }

        #region Allors
        [Id("6EBE8723-7097-4B53-A680-E543C3959AF3")]
        [AssociationId("49EEEA7B-1DEF-4A3C-836C-E56443825638")]
        [RoleId("4F671D13-1BB8-4EAC-B481-C9F60FF5D7BD")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public PurchaseInvoiceItemVersion CurrentStateVersion { get; set; }

        #region Allors
        [Id("4B709651-1366-49AB-9957-B1714C2C2967")]
        [AssociationId("236D2097-7529-484B-A2E3-E97A9157E36D")]
        [RoleId("FC536635-1F1E-46CD-8DF6-D9860500A8F8")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Workspace]
        public PurchaseInvoiceItemVersion[] AllStateVersions { get; set; }

        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}





        #endregion
    }
}