// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InternalOrganisationRevenue.cs" company="Allors bvba">
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
    using Allors.Meta;

    public partial class InternalOrganisationRevenue
    {
        public void AppsOnDerive(ObjectOnDerive method)
        {
            this.Revenue = 0;

            var storeRevenues = this.strategy.Session.Extent<StoreRevenue>();
            storeRevenues.Filter.AddEquals(M.StoreRevenue.Year, this.Year);
            storeRevenues.Filter.AddEquals(M.StoreRevenue.Month, this.Month);

            foreach (StoreRevenue storeRevenue in storeRevenues)
            {
                this.Revenue += storeRevenue.Revenue;
            }
        }
    }
}