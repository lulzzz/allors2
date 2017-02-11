namespace Allors.Repository.Domain
{
    using System;

    #region Allors
    [Id("ecf2996a-7f8b-45d5-afac-56c88c62136a")]
    #endregion
    public partial class WebSiteCommunication : CommunicationEvent 
    {
        #region inherited properties

        public SecurityToken OwnerSecurityToken { get; set; }

        public AccessControl OwnerAccessControl { get; set; }

        public DateTime ScheduledStart { get; set; }

        public Party[] ToParties { get; set; }

        public ContactMechanism[] ToContactMechanisms { get; set; }

        public CommunicationEventStatus[] CommunicationEventStatuses { get; set; }

        public Party[] InvolvedParties { get; set; }

        public DateTime InitialScheduledStart { get; set; }

        public CommunicationEventObjectState CurrentObjectState { get; set; }

        public CommunicationEventPurpose[] EventPurposes { get; set; }

        public DateTime ScheduledEnd { get; set; }

        public DateTime ActualEnd { get; set; }

        public WorkEffort[] WorkEfforts { get; set; }

        public string Description { get; set; }

        public DateTime InitialScheduledEnd { get; set; }

        public Party[] FromParties { get; set; }

        public string Subject { get; set; }

        public Media[] Documents { get; set; }

        public Case Case { get; set; }

        public Priority Priority { get; set; }

        public ContactMechanism[] FromContactMechanisms { get; set; }

        public Person Owner { get; set; }

        public CommunicationEventStatus CurrentCommunicationEventStatus { get; set; }

        public string Note { get; set; }

        public DateTime ActualStart { get; set; }

        public ObjectState PreviousObjectState { get; set; }

        public ObjectState LastObjectState { get; set; }

        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        public string Comment { get; set; }

        public Guid UniqueId { get; set; }

        #endregion

        #region Allors
        [Id("18faf993-316a-4990-8ffd-8bda40f61164")]
        [AssociationId("b6c8df26-71f6-49a8-86d0-f38b9717fdc4")]
        [RoleId("96f92902-be8e-41f8-893a-afe4e93ef6d5")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Party Originator { get; set; }
        #region Allors
        [Id("39077571-13b2-4cc4-be85-517dbc11703e")]
        [AssociationId("be25f23d-6c17-4940-abe6-b6936244bcea")]
        [RoleId("f956749a-b0b3-45a4-a4b8-b0bf913d24c2")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]

        public Party Receiver { get; set; }


        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        public void Cancel(){}

        public void Close(){}

        public void Reopen(){}




        public void Delete(){}


        #endregion

    }
}