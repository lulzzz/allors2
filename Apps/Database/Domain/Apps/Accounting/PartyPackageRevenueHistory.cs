// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartyPackageRevenueHistory.cs" company="Allors bvba">
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

    public partial class PartyPackageRevenueHistory
    {
        internal void AppsOnDeriveHistory()
        {
            this.Revenue = 0;

            var startDate = DateTime.UtcNow.AddYears(-1);
            var year = startDate.Year;
            var month = startDate.Month;

            var revenues = this.Party.PartyPackageRevenuesWhereParty;

            //// sum revenue trailing twelve months + revenue current month
            foreach (PartyPackageRevenue revenue in revenues)
            {
                if (revenue.InternalOrganisation.Equals(this.InternalOrganisation) &&
                    revenue.Package == this.Package &&
                    ((revenue.Year == year && revenue.Month >= month) || (revenue.Year == DateTime.UtcNow.Year && revenue.Month <= month)))
                {
                    this.Revenue += revenue.Revenue;
                }
            }
        }
    }
}