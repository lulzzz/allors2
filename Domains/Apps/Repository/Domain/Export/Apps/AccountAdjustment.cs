namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("4211ece6-a127-4359-9fa4-6537943a37a5")]
    #endregion
    public partial class AccountAdjustment : FinancialAccountTransaction 
    {
        #region inherited properties
        public string Description { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime TransactionDate { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion
        
        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        #endregion
    }
}