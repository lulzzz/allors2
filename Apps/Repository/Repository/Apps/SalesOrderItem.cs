namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("80de925c-04cc-412c-83a5-60405b0e63e6")]
    #endregion
    public partial class SalesOrderItem : OrderItem 
    {
        #region inherited properties
        public BudgetItem BudgetItem { get; set; }

        public decimal PreviousQuantity { get; set; }

        public decimal QuantityOrdered { get; set; }

        public string Description { get; set; }

        public PurchaseOrder CorrespondingPurchaseOrder { get; set; }

        public decimal TotalOrderAdjustmentCustomerCurrency { get; set; }

        public decimal TotalOrderAdjustment { get; set; }

        public QuoteItem QuoteItem { get; set; }

        public DateTime AssignedDeliveryDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public OrderTerm[] OrderTerms { get; set; }

        public string ShippingInstruction { get; set; }

        public OrderItem[] Associations { get; set; }

        public string Message { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        public string Comment { get; set; }

        public ObjectState PreviousObjectState { get; set; }

        public ObjectState LastObjectState { get; set; }

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

        #endregion

        #region Allors
        [Id("0229942b-e102-4e97-af8d-97ee8383203e")]
        [AssociationId("e1e640d4-4096-42df-9c12-6bf54e5314db")]
        [RoleId("16e9993a-6604-41e9-9ed0-053480d45d46")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal InitialProfitMargin { get; set; }
        
        #region Allors
        [Id("14d596e8-adec-46bc-b260-af37d24a1035")]
        [AssociationId("4f846efe-5546-4709-8f31-2470a3e3650e")]
        [RoleId("ad606374-6b77-4ddc-b907-e190faf7da0e")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public SalesOrderItemStatus CurrentPaymentStatus { get; set; }
        
        #region Allors
        [Id("1e1ed439-ae25-4446-83e6-295d8627a7b5")]
        [AssociationId("67bc37d9-0d6f-4227-81c9-8f03a1e0da47")]
        [RoleId("d8ab230a-92d2-44cb-8e45-502285dd9a5e")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityShortFalled { get; set; }
        
        #region Allors
        [Id("1ea02a2c-280a-4a48-9ffb-1517789c56f1")]
        [AssociationId("851f33e4-6c43-468d-ab0d-0f5f83bdb179")]
        [RoleId("213d2b36-dbfd-4e2d-a854-82ba271f0d94")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        public OrderItem[] OrderedWithFeatures { get; set; }
        
        #region Allors
        [Id("1edd9008-537a-43ba-b4a1-56d3c3211c36")]
        [AssociationId("db9987b4-b71c-4ece-b4c1-53bb27a02dff")]
        [RoleId("ae3bd8e0-1f58-45e1-a6dc-191d7668e358")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal MaintainedProfitMargin { get; set; }
        
        #region Allors
        [Id("2bd8163c-b2cd-49bc-922a-b8c859c24031")]
        [AssociationId("3f66929d-a2f1-4e9b-a701-4364e3a25e1d")]
        [RoleId("1fbf819e-b7fe-4ce3-86af-efea369db2fa")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        public decimal RequiredProfitMargin { get; set; }
        
        #region Allors
        [Id("3072d12f-e8de-43ba-a63c-f557744a1d5d")]
        [AssociationId("9b642b30-ec44-4877-a191-974704f6d8df")]
        [RoleId("1eb0ad30-68f6-4d63-9e07-96f7e90005ee")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Derived]
        [Indexed]
        public SalesOrderItemStatus[] OrderItemStatuses { get; set; }
        
        #region Allors
        [Id("3dbd9a9b-8cda-4cf3-890d-2e6af4e47018")]
        [AssociationId("fba228cb-4b3f-4f50-8b6a-f16572ba3977")]
        [RoleId("9d69d9af-7c23-4a1d-a4f2-09ef58881ce8")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public SalesOrderItemStatus CurrentShipmentStatus { get; set; }
        
        #region Allors
        [Id("3e798309-d5d5-4860-87ec-ba3766e96c9e")]
        [AssociationId("4626b586-07e1-468c-877a-d1a8f1b196c5")]
        [RoleId("b2aef5ac-45f7-41aa-8e1b-f2d79d3d9fad")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        public NonSerializedInventoryItem PreviousReservedFromInventoryItem { get; set; }
        
        #region Allors
        [Id("40111efb-f609-4726-85c1-a9dd7160df72")]
        [AssociationId("1f0c1c76-4e49-4c31-9b35-cfa5d842039b")]
        [RoleId("4e3983f7-09db-4e06-bf47-a2a4dbcdfa40")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityShipNow { get; set; }
        
        #region Allors
        [Id("48e40504-bb22-4b11-949d-569b3a556416")]
        [AssociationId("979f6fa2-29f4-43c0-86d7-761509719112")]
        [RoleId("6b6dab9b-1583-4f3d-8d97-1a8a53af9e75")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        public decimal RequiredMarkupPercentage { get; set; }
        
        #region Allors
        [Id("545eb094-63d8-4d25-a069-7c3e91f26eb7")]
        [AssociationId("686d5956-c2dc-46d5-b812-52020d392f0f")]
        [RoleId("3a8adaf6-82e6-45a6-bd5f-61860125d77b")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityShipped { get; set; }
        
        #region Allors
        [Id("5bf138bd-27c1-4291-91da-b543170bf160")]
        [AssociationId("c4fab99d-b408-437a-aea3-05cf32afa5d4")]
        [RoleId("76f3c438-e027-492d-bae4-932d81f455df")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Derived]
        [Indexed]
        public SalesOrderItemStatus CurrentOrderItemStatus { get; set; }
        
        #region Allors
        [Id("5cc50f26-361b-46d7-a8e6-a9f53f7d2722")]
        [AssociationId("0d8906e9-3bfd-4d9b-8b24-8526fdfb2e33")]
        [RoleId("000b641f-00be-4b9c-84aa-a8c968024ece")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        public PostalAddress ShipToAddress { get; set; }
        
        #region Allors
        [Id("64edd3e6-0b78-4b34-8a11-aa9c0a1b1f35")]
        [AssociationId("667a1304-05ae-410a-94a1-5e87a40dc53b")]
        [RoleId("d15456ab-66c1-4ecc-bfc5-910b7d9c4869")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityPicked { get; set; }
        
        #region Allors
        [Id("6826e05e-eb9a-4dc4-a653-0230dec934a9")]
        [AssociationId("aa2b8b0a-672c-423b-9ca8-2fd40f8d1306")]
        [RoleId("793f4946-ed12-49ca-9764-8df534941cca")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        public Product PreviousProduct { get; set; }
        
        #region Allors
        [Id("710e0b05-01d1-4592-b652-f0fada3dfa45")]
        [AssociationId("9ab86597-c31b-46d7-b546-89ebfd1411cd")]
        [RoleId("9533bbb6-359f-49a3-959b-98fcdd5cc2a7")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        [Required]
        public SalesOrderItemObjectState CurrentObjectState { get; set; }
        
        #region Allors
        [Id("75a13fdc-90b2-4550-9b2f-fc0a9387d569")]
        [AssociationId("94922e2d-1570-4667-af8f-5d4415fd6d78")]
        [RoleId("39d62b69-520c-456d-b3f1-6ca640ffc4cb")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal UnitPurchasePrice { get; set; }
        
        #region Allors
        [Id("7a8255f5-4283-4803-9f96-60a9adc2743b")]
        [AssociationId("2c9b2182-7b93-46c9-86ac-d13add6d52b5")]
        [RoleId("7596f471-e54c-4491-8af6-02f0e8d7d015")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        public Party ShipToParty { get; set; }
        
        #region Allors
        [Id("7ae1b939-b387-4e6e-9da2-bc0364e04f7b")]
        [AssociationId("808f88ba-3866-4785-812c-c062c5f268a4")]
        [RoleId("64639736-a7d0-47cb-8afb-fa751a19670d")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public PostalAddress AssignedShipToAddress { get; set; }
        
        #region Allors
        [Id("8145fbd3-a30f-44a0-9520-6b72ac20a82d")]
        [AssociationId("59383e9d-690e-46aa-9cc0-1dd39db14f60")]
        [RoleId("31087f2f-10e8-4558-9e0a-a5dbceb3204a")]
        #endregion
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityReturned { get; set; }
        
        #region Allors
        [Id("85d11891-5ffe-488f-9f23-5b2c7bc1c480")]
        [AssociationId("283cdb9a-e7e3-4486-92da-5e94653505a8")]
        [RoleId("fd06dd18-c1d4-40c7-b62e-273a8522f580")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityReserved { get; set; }
        
        #region Allors
        [Id("911abda0-2eb0-477e-80be-e9e7d358205e")]
        [AssociationId("23af5657-ed05-43c2-aeed-d268204528d2")]
        [RoleId("42a88fb9-84bc-4e35-83ff-6cb5c0cf3c96")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        [Indexed]
        public Person SalesRep { get; set; }
        
        #region Allors
        [Id("ae30b852-d1d9-4966-a65a-6f16120652f6")]
        [AssociationId("c3a3e068-8683-44b7-a255-47e49a63c453")]
        [RoleId("7a4a9d1b-2cff-4f9c-8b7c-94f08fb68c46")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Derived]
        [Indexed]
        public SalesOrderItemStatus[] ShipmentStatuses { get; set; }
        
        #region Allors
        [Id("b2d2645e-0d3f-473e-b277-6f890b9b911e")]
        [AssociationId("68281397-74f8-4356-b9fc-014f792ab914")]
        [RoleId("1292e876-1c61-42cb-8f01-8b3eb6cf0fa0")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public Party AssignedShipToParty { get; set; }
        
        #region Allors
        [Id("b2f7dabb-8b87-41bc-8903-166d77bba1c5")]
        [AssociationId("ad7dfb12-d00d-4a93-a011-7cb09c1e9aa9")]
        [RoleId("ba9a9c6c-4df0-4488-b5fa-6181e45c6f18")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityPendingShipment { get; set; }
        
        #region Allors
        [Id("b8d116ca-dbab-4119-84ca-c0e196d9c018")]
        [AssociationId("3f2cc31e-84e9-4e49-bfbe-0a436e2236be")]
        [RoleId("7cee282f-ff61-42fc-9a2e-54164e8b6390")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal MaintainedMarkupPercentage { get; set; }
        
        #region Allors
        [Id("d5639e07-37b8-46db-9e35-fa98301d31dd")]
        [AssociationId("43ee44b6-2e51-4ade-8bb7-9b10a780ba2e")]
        [RoleId("38e21291-b24a-4331-b781-f7950df3f501")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal InitialMarkupPercentage { get; set; }
        
        #region Allors
        [Id("d7c25b48-d82f-4250-b09d-1e935eab665b")]
        [AssociationId("67e9a9d9-74ff-4b04-9aa1-dd08c5348a3e")]
        [RoleId("4bfc1720-a2f6-4204-974b-42ca42c0d2e1")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public NonSerializedInventoryItem ReservedFromInventoryItem { get; set; }
        
        #region Allors
        [Id("e8980105-2c4d-41de-bd67-802a8c0720f1")]
        [AssociationId("8b747457-bf7a-4274-b245-d04607b2a5ba")]
        [RoleId("90d69cb4-d485-418f-9608-44063f116ff4")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public Product Product { get; set; }
        
        #region Allors
        [Id("ed586b2f-c687-4d97-9416-52f7156b7b11")]
        [AssociationId("cb5c31c4-2daa-405b-8dc9-5ea6c87f66b3")]
        [RoleId("c5b07ead-1a71-407e-91f8-4ec39853888a")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public ProductFeature ProductFeature { get; set; }
        
        #region Allors
        [Id("f148e660-1e09-4e76-97fb-de62a7ee7482")]
        [AssociationId("0105885d-f722-44bd-9f57-6231c38191b5")]
        [RoleId("9132a260-1b35-4b5a-b14c-8dceb6383581")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal QuantityRequestsShipping { get; set; }

        #region Allors
        [Id("f2ccd5d6-95e3-4d72-938b-9f430f36ae59")]
        [AssociationId("77472c36-b500-4788-b1b3-22741adec0c0")]
        [RoleId("748df737-edab-476d-a2f2-0f362828c0e7")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Derived]
        [Indexed]
        public SalesOrderItemStatus[] PaymentStatuses { get; set; }

        #region Allors
        [Id("323F3F47-9577-47C6-A77F-DC11CBAEA91C")]
        #endregion
        public void Continue() { }

        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        public void Cancel(){}

        public void Reject(){}

        public void Confirm(){}

        public void Approve(){}

        public void Finish(){}

        public void Delete(){}




        #endregion
    }
}