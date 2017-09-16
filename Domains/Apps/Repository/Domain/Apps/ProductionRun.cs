namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("37de59b2-ca6c-4fa9-86a2-299fd6f14812")]
    #endregion
    public partial class ProductionRun : WorkEffort, IProductionRun 
    {
        #region inherited properties

        public SecurityToken OwnerSecurityToken { get; set; }
        public AccessControl OwnerAccessControl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkEffortObjectState CurrentObjectState { get; set; }
        public Priority Priority { get; set; }
        public WorkEffortPurpose[] WorkEffortPurposes { get; set; }
        public DateTime ActualCompletion { get; set; }
        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledCompletion { get; set; }
        public decimal ActualHours { get; set; }
        public decimal EstimatedHours { get; set; }
        public WorkEffort[] Precendencies { get; set; }
        public Facility Facility { get; set; }
        public Deliverable[] DeliverablesProduced { get; set; }
        public DateTime ActualStart { get; set; }
        public WorkEffortInventoryAssignment[] InventoryItemsNeeded { get; set; }
        public WorkEffort[] Children { get; set; }
        public OrderItem OrderItemFulfillment { get; set; }
        public WorkEffortType WorkEffortType { get; set; }
        public IInventoryItem[] InventoryItemsProduced { get; set; }
        public Requirement[] RequirementFulfillments { get; set; }
        public string SpecialTerms { get; set; }
        public WorkEffort[] Concurrencies { get; set; }
        public Permission[] DeniedPermissions { get; set; }
        public SecurityToken[] SecurityTokens { get; set; }
        public ObjectState PreviousObjectState { get; set; }
        public ObjectState LastObjectState { get; set; }
        public Guid UniqueId { get; set; }
        public User CreatedBy { get; set; }
        public User LastModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int QuantityProduced { get; set; }
        public int QuantityRejected { get; set; }
        public int QuantityToProduce { get; set; }
        #endregion

        #region Allors
        [Id("350FCFA7-E7A4-4E22-A89B-ECB986C3F656")]
        [AssociationId("7C579167-54F5-4AA0-90C7-14A943452A2E")]
        [RoleId("95D92081-5243-4E6D-B98F-32DB8DA275C1")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public ProductionRunVersion CurrentVersion { get; set; }

        #region Allors
        [Id("D49C9910-1E95-478F-B56F-C4935A80D946")]
        [AssociationId("837F5731-BB36-4CB6-835D-25438D032920")]
        [RoleId("ABDAB01A-30F3-45B1-8FED-4551E1D6E50C")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public ProductionRunVersion PreviousVersion { get; set; }

        #region Allors
        [Id("080CA05B-6BB2-4365-ABC1-448C143123B0")]
        [AssociationId("EBFCE320-05B9-473B-9B38-4CCA740B1B53")]
        [RoleId("BF606013-A904-4666-84D1-E0D7703EFD5A")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Workspace]
        public ProductionRunVersion[] AllVersions { get; set; }

        #region Allors
        [Id("26970CA3-4007-43CF-8CAA-1B45BFB055C4")]
        [AssociationId("605CB286-F9AD-421A-A076-A74A53898665")]
        [RoleId("7B6BD1F7-E4EA-4430-A603-C83A6B94C2DC")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public ProductionRunVersion CurrentStateVersion { get; set; }

        #region Allors
        [Id("313FF652-60B7-4F0D-A0A0-02991C83BCC5")]
        [AssociationId("08D88C1F-A644-4EA0-B6E7-58F288B2C9FD")]
        [RoleId("AC0D9701-22BC-462D-9E9F-66AA705314F2")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Workspace]
        public ProductionRunVersion[] AllStateVersions { get; set; }

        #region inherited methods

        public void OnBuild() { }
        public void OnPostBuild() { }
        public void OnPreDerive() { }
        public void OnDerive() { }
        public void OnPostDerive() { }
        public void Confirm() { }
        public void Finish() { }
        public void Cancel() { }
        public void Reopen() { }
        public void Delete() { }

        #endregion
    }
}