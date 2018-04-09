// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneCommunication.cs" company="Allors bvba">
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

using System;
using Allors.Meta;
using Resources;

namespace Allors.Domain
{
    public partial class PhoneCommunication
    {
        public static readonly TransitionalConfiguration[] StaticTransitionalConfigurations =
            {
                new TransitionalConfiguration(M.PhoneCommunication, M.PhoneCommunication.CommunicationEventState),
            };

        public TransitionalConfiguration[] TransitionalConfigurations => StaticTransitionalConfigurations;

        public void AppsOnDerive(ObjectOnDerive method)
        {
            this.AppsOnDeriveFromParties();
            this.AppsOnDeriveToParties();
            this.AppsOnDeriveInvolvedParties();

            if (this.Callers.Count == 0 || this.Receivers.Count == 0)
            {
                this.Delete();
            }
        }

        public void AppsOnDeriveFromParties()
        {
            this.RemoveFromParties();
            this.FromParties = (Extent) this.Callers;

            if (this.IncomingCall)
            {
                foreach (Party party in this.PartiesWhereCommunicationEvent)
                {
                    this.AddFromParty(party);
                }
            }
        }

        public void AppsOnDeriveToParties()
        {
            this.RemoveToParties();
            this.ToParties = (Extent)this.Receivers;

            if (this.ExistPartiesWhereCommunicationEvent && !this.IncomingCall)
            {
                foreach (Party party in this.PartiesWhereCommunicationEvent)
                {
                    this.AddToParty(party);
                }
            }
        }

        public void AppsOnDeriveInvolvedParties()
        {
            this.RemoveInvolvedParties();

            foreach (Party party in this.FromParties)
            {
                this.AddInvolvedParty(party);
            }

            foreach (Party party in this.ToParties)
            {
                this.AddInvolvedParty(party);
            }

            if (this.ExistOwner && !this.InvolvedParties.Contains(this.Owner))
            {
                this.AddInvolvedParty(this.Owner);
            }

            foreach (Party party in this.InvolvedParties)
            {
                if (party is Person person)
                {
                    foreach (OrganisationContactRelationship organisationContactRelationship in person.OrganisationContactRelationshipsWhereContact)
                    {
                        if (organisationContactRelationship.FromDate <= DateTime.UtcNow &&
                            (!organisationContactRelationship.ExistThroughDate || organisationContactRelationship.ThroughDate >= DateTime.UtcNow))
                        {
                            this.AddInvolvedParty(organisationContactRelationship.Organisation);
                        }
                    }
                }
            }
        }
    }
}