// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SalesRepRelationship.cs" company="Allors bvba">
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

    public partial class SalesRepRelationship
    {
        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            if (this.ExistCustomer && this.ExistSalesRepresentative)
            {
                Party tempQualifier = this.Customer;
                tempQualifier.RemoveCurrentSalesReps();

                foreach (SalesRepRelationship salesRepRelationship in tempQualifier.SalesRepRelationshipsWhereCustomer)
                {
                    if (salesRepRelationship.FromDate <= DateTime.UtcNow &&
                        (!salesRepRelationship.ExistThroughDate || salesRepRelationship.ThroughDate >= DateTime.UtcNow))
                    {
                        tempQualifier.AddCurrentSalesRep(salesRepRelationship.SalesRepresentative);
                    }
                }

                this.SalesRepresentative.OnDerive(x => x.WithDerivation(derivation));
            }

            this.Parties = new[] { this.Customer };
    
            if (!this.ExistCustomer | !this.ExistSalesRepresentative)
            {
                this.Delete();
            }
        }
    }
}