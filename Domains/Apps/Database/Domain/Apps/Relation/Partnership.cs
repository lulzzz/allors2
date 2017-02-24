// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Partnership.cs" company="Allors bvba">
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
    using System;

    public partial class Partnership
    {
        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            this.AppsOnDeriveMembership();
            this.AppsOnDerivePartnerContacts(derivation);

            this.Parties = new Party[] { this.Partner, this.InternalOrganisation };

            if (!this.ExistInternalOrganisation | !this.ExistPartner)
            {
                this.Delete();
            }
        }

        public void AppsOnDerivePartnerContacts(IDerivation derivation)
        {
            if (this.ExistPartner)
            {
                var partner = this.Partner;
                foreach (OrganisationContactRelationship contactRelationship in partner.OrganisationContactRelationshipsWhereOrganisation)
                {
                    contactRelationship.Contact.OnDerive(x => x.WithDerivation(derivation));
                }
            }
        }

        public void AppsOnDeriveMembership()
        {
            if (this.ExistPartner && this.ExistInternalOrganisation)
            {
                if (this.Partner.ContactsUserGroup != null)
                {
                    foreach (OrganisationContactRelationship contactRelationship in this.Partner.OrganisationContactRelationshipsWhereOrganisation)
                    {
                        if (this.FromDate <= DateTime.UtcNow &&
                            (!this.ExistThroughDate || this.ThroughDate >= DateTime.UtcNow))
                        {
                            if (!this.Partner.ContactsUserGroup.Members.Contains(contactRelationship.Contact))
                            {
                                this.Partner.ContactsUserGroup.AddMember(contactRelationship.Contact);
                            }
                        }
                        else
                        {
                            if (this.Partner.ContactsUserGroup.Members.Contains(contactRelationship.Contact))
                            {
                                this.Partner.ContactsUserGroup.RemoveMember(contactRelationship.Contact);
                            }
                        }
                    }
                }
            }
        }
    }
}