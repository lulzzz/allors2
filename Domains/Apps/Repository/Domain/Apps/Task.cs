namespace Allors.Repository
{
    using System;

    using Allors.Repository.Attributes;

    #region Allors
    [Id("b2cf9a3d-f156-4da7-87bf-ecdeaa13e326")]
    #endregion
    public partial class Task : WorkEffort 
    {
        #region inherited properties
        public WorkEffortStatus CurrentWorkEffortStatus { get; set; }

        public WorkEffort[] Precendencies { get; set; }

        public Facility Facility { get; set; }

        public Deliverable[] DeliverablesProduced { get; set; }

        public DateTime ActualStart { get; set; }

        public WorkEffortInventoryAssignment[] InventoryItemsNeeded { get; set; }

        public WorkEffort[] Children { get; set; }

        public DateTime ActualCompletion { get; set; }

        public OrderItem OrderItemFulfillment { get; set; }

        public WorkEffortStatus[] WorkEffortStatuses { get; set; }

        public WorkEffortType WorkEffortType { get; set; }

        public InventoryItem[] InventoryItemsProduced { get; set; }

        public WorkEffortPurpose[] WorkEffortPurposes { get; set; }

        public Priority Priority { get; set; }

        public string Name { get; set; }

        public Requirement[] RequirementFulfillments { get; set; }

        public string SpecialTerms { get; set; }

        public WorkEffort[] Concurrencies { get; set; }

        public DateTime ScheduledStart { get; set; }

        public decimal ActualHours { get; set; }

        public string Description { get; set; }

        public WorkEffortObjectState CurrentObjectState { get; set; }

        public DateTime ScheduledCompletion { get; set; }

        public decimal EstimatedHours { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        public ObjectState PreviousObjectState { get; set; }

        public ObjectState LastObjectState { get; set; }

        public Guid UniqueId { get; set; }

        #endregion


        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        public void Confirm(){}

        public void Finish(){}

        public void Cancel(){}

        public void Reopen(){}





        public void Delete(){}
        #endregion

    }
}