// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LetterCorrespondence.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Allors.Domain
{
    public partial class LetterCorrespondence
    {
        ObjectState Transitional.CurrentObjectState => this.CurrentObjectState;

        public void AppsOnDerive(ObjectOnDerive method)
        {
            this.AppsOnDeriveFromParties();
            this.AppsOnDeriveToParties();
            this.AppsOnDeriveInvolvedParties();
        }

        public void AppsOnPostDerive(ObjectOnPostDerive method)
        {
            var isNewVersion =
                !this.ExistCurrentVersion ||
                !object.Equals(this.ActualStart, this.CurrentVersion.ActualStart);

            var isNewStateVersion =
                !this.ExistCurrentVersion ||
                !object.Equals(this.CurrentObjectState, this.CurrentVersion.CurrentObjectState);

            if (isNewVersion)
            {
                this.PreviousVersion = this.CurrentVersion;
                this.CurrentVersion = new LetterCorrespondenceVersionBuilder(this.Strategy.Session).WithLetterCorrespondence(this).Build();
                this.AddAllVersion(this.CurrentVersion);
            }

            if (isNewStateVersion)
            {
                this.CurrentStateVersion = CurrentVersion;
                this.AddAllStateVersion(this.CurrentStateVersion);
            }
        }

        public void AppsOnDeriveFromParties()
        {
            this.RemoveFromParties();
            this.FromParties = this.Originators;
        }

        public void AppsOnDeriveToParties()
        {
            this.RemoveToParties();
            this.ToParties = this.Receivers;
        }

        public void AppsOnDeriveInvolvedParties()
        {
            this.RemoveInvolvedParties();
            this.InvolvedParties = this.Receivers;

            foreach (Party originator in this.Originators)
            {
                this.AddInvolvedParty(originator);
            }

            //if (this.ExistOwner && !this.InvolvedParties.Contains(this.Owner))
            //{
            //    this.AddInvolvedParty(this.Owner);
            //}

            if (this.ExistPartyRelationshipWhereCommunicationEvent)
            {
                foreach (Party party in this.PartyRelationshipWhereCommunicationEvent.Parties)
                {
                    this.AddInvolvedParty(party);
                }
            }
        }
    }
}
