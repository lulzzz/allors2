// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierRelationship.cs" company="Allors bvba">
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

using System.Linq;

namespace Allors.Domain
{
    using System;
    using Meta;

    public partial class SupplierRelationship
    {
        public void AppsOnPreDerive(ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            if (this.ExistSupplier)
            {
                derivation.AddDependency(this.Supplier, this);

                foreach (OrganisationContactRelationship contactRelationship in this.Supplier.OrganisationContactRelationshipsWhereOrganisation)
                {
                    derivation.AddDependency(contactRelationship, this);
                }
            }
        }

        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            var internalOrganisations = new Organisations(this.strategy.Session).Extent().Where(v => Equals(v.IsInternalOrganisation, true)).ToArray();

            if (!this.ExistInternalOrganisation && internalOrganisations.Count() == 1)
            {
                this.InternalOrganisation = internalOrganisations.First();
            }

            this.AppsOnDeriveInternalOrganisationSupplier(derivation);
            this.AppsOnDeriveMembership(derivation);

            this.Parties = new Party[] { this.Supplier, this.InternalOrganisation };
        }

        public void AppsOnDeriveInternalOrganisationSupplier(IDerivation derivation)
        {
            if (this.ExistSupplier)
            {
                if (this.FromDate <= DateTime.UtcNow && (!this.ExistThroughDate || this.ThroughDate >= DateTime.UtcNow))
                {
                    this.InternalOrganisation.AddActiveSupplier(this.Supplier);
                }

                if (this.FromDate > DateTime.UtcNow || (this.ExistThroughDate && this.ThroughDate < DateTime.UtcNow))
                {
                    this.InternalOrganisation.RemoveActiveSupplier(this.Supplier);
                }
            }
        }

        public void AppsOnDeriveMembership(IDerivation derivation)
        {
            if (this.ExistSupplier)
            {
                if (this.Supplier.ContactsUserGroup != null)
                {
                    foreach (OrganisationContactRelationship contactRelationship in this.Supplier.OrganisationContactRelationshipsWhereOrganisation)
                    {
                        if (this.FromDate <= DateTime.UtcNow &&
                            (!this.ExistThroughDate || this.ThroughDate >= DateTime.UtcNow))
                        {
                            if (!this.Supplier.ContactsUserGroup.Members.Contains(contactRelationship.Contact))
                            {
                                this.Supplier.ContactsUserGroup.AddMember(contactRelationship.Contact);
                            }
                        }
                        else
                        {
                            if (this.Supplier.ContactsUserGroup.Members.Contains(contactRelationship.Contact))
                            {
                                this.Supplier.ContactsUserGroup.RemoveMember(contactRelationship.Contact);
                            }
                        }
                    }
                }
            }
        }
    }
}