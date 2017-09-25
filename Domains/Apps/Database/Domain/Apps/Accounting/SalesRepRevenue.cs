// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SalesRepRevenue.cs" company="Allors bvba">
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
    using Meta;

    public partial class SalesRepRevenue
    {
        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            this.SalesRepName = this.SalesRep.PartyName;

            this.AppsOnDeriveRevenue();
        }

        public void AppsOnDeriveRevenue()
        {
            this.Revenue = 0;

            var salesRepPartiesRevenue = this.SalesRep.SalesRepPartyRevenuesWhereSalesRep;
            salesRepPartiesRevenue.Filter.AddEquals(M.SalesRepPartyRevenue.Year, this.Year);
            salesRepPartiesRevenue.Filter.AddEquals(M.SalesRepPartyRevenue.Month, this.Month);

            foreach (SalesRepPartyRevenue salesRepPartyRevenue in salesRepPartiesRevenue)
            {
                this.Revenue += salesRepPartyRevenue.Revenue;
            }

            var months = ((DateTime.UtcNow.Year - this.Year) * 12) + DateTime.UtcNow.Month - this.Month;
            if (months <= 12)
            {
                var histories = this.SalesRep.SalesRepRevenueHistoriesWhereSalesRep;
                var history = histories.First ?? new SalesRepRevenueHistoryBuilder(this.Strategy.Session)
                                                     .WithCurrency(this.Currency)
                                                     .WithSalesRep(this.SalesRep)
                                                     .Build();

                history.AppsOnDeriveRevenue();
            }
        }
    }
}
