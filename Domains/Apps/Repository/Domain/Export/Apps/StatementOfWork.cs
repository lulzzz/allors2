namespace Allors.Repository
{
    using System;
    using Attributes;

    #region Allors
    [Id("5459f555-cf6a-49c1-8015-b43cad74da17")]
    #endregion
    [Plural("StatementsOfWork")]
    public partial class StatementOfWork : Quote, Versioned
    {
        #region inherited properties

        public ObjectState[] PreviousObjectStates { get; set; }

        public ObjectState[] LastObjectStates { get; set; }

        public ObjectState[] ObjectStates { get; set; }

        public QuoteState PreviousQuoteState { get; set; }

        public QuoteState LastQuoteState { get; set; }

        public QuoteState QuoteState { get; set; }

        public InternalOrganisation Issuer { get; set; }

        public string InternalComment { get; set; }
        public DateTime RequiredResponseDate { get; set; }
        public DateTime ValidFromDate { get; set; }
        public QuoteTerm[] QuoteTerms { get; set; }
        public DateTime ValidThroughDate { get; set; }
        public string Description { get; set; }
        public Party Receiver { get; set; }
        public ContactMechanism FullfillContactMechanism { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public DateTime IssueDate { get; set; }
        public QuoteItem[] QuoteItems { get; set; }
        public string QuoteNumber { get; set; }
        public Request Request { get; set; }

        public Person ContactPerson { get; set; }

        public Permission[] DeniedPermissions { get; set; }
        public SecurityToken[] SecurityTokens { get; set; }
        public PrintDocument PrintDocument { get; set; }

        public User CreatedBy { get; set; }
        public User LastModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Comment { get; set; }

        public LocalisedText[] LocalisedComments { get; set; }

        #endregion

        #region Versioning
        #region Allors
        [Id("9AEF9F40-E043-4FEE-AFE4-49E991114286")]
        [AssociationId("B32718B2-3EFB-4942-A33E-CFB7CF5DB2FA")]
        [RoleId("C54D2A3F-7CC7-4313-ADF4-B6AD952DAE01")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public StatementOfWorkVersion CurrentVersion { get; set; }

        #region Allors
        [Id("01BCD729-E71D-41A1-B996-9FC9A808C0ED")]
        [AssociationId("661B7791-8604-48A4-8034-1A8ECE394B4D")]
        [RoleId("3D5460FF-8BEE-425A-8E53-655444E1BC10")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Workspace]
        public StatementOfWorkVersion[] AllVersions { get; set; }
        #endregion

        #region inherited methods

        public void OnBuild() { }

        public void OnPostBuild() { }

        public void OnPreDerive() { }

        public void OnDerive() { }

        public void OnPostDerive() { }

        public void Approve() { }

        public void Reject() { }

        public void Cancel() { }

        public void Print() { }

        #endregion
    }
}