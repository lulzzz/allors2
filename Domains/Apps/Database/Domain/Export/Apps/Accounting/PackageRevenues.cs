// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageRevenues.cs" company="Allors bvba">
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
    using System.Collections.Generic;
    using Meta;
    
    public partial class PackageRevenues
    {
        public static PackageRevenue AppsFindOrCreateAsDependable(ISession session, PartyPackageRevenue dependant)
        {
            var packageRevenues = dependant.Package.PackageRevenuesWherePackage;
            packageRevenues.Filter.AddEquals(M.PackageRevenue.Year, dependant.Year);
            packageRevenues.Filter.AddEquals(M.PackageRevenue.Month, dependant.Month);
            var packageRevenue = packageRevenues.First ?? new PackageRevenueBuilder(session)
                                                                .WithPackage(dependant.Package)
                                                                .WithYear(dependant.Year)
                                                                .WithMonth(dependant.Month)
                                                                .WithCurrency(dependant.Currency)
                                                                .Build();

            return packageRevenue;
        }

        public static void AppsOnDeriveRevenues(ISession session)
        {
            var packageRevenues = session.Extent<PackageRevenue>();

            var packageRevenuesByPeriodByPackage = new Dictionary<Package, Dictionary<DateTime, PackageRevenue>>();
            foreach (PackageRevenue packageRevenue in packageRevenues)
            {
                packageRevenue.Revenue = 0;
                var date = DateTimeFactory.CreateDate(packageRevenue.Year, packageRevenue.Month, 01);

                Dictionary<DateTime, PackageRevenue> packageRevenuesByPeriod;
                if (!packageRevenuesByPeriodByPackage.TryGetValue(packageRevenue.Package, out packageRevenuesByPeriod))
                {
                    packageRevenuesByPeriod = new Dictionary<DateTime, PackageRevenue>();
                    packageRevenuesByPeriodByPackage[packageRevenue.Package] = packageRevenuesByPeriod;
                }

                PackageRevenue revenue;
                if (!packageRevenuesByPeriod.TryGetValue(date, out revenue))
                {
                    packageRevenuesByPeriod.Add(date, packageRevenue);
                }
            }

            var revenues = new HashSet<long>();

            var salesInvoices = session.Extent<SalesInvoice>();
            var year = 0;
            foreach (SalesInvoice salesInvoice in salesInvoices)
            {
                if (year != salesInvoice.InvoiceDate.Year)
                {
                    session.Commit();
                    year = salesInvoice.InvoiceDate.Year;
                }

                var date = DateTimeFactory.CreateDate(salesInvoice.InvoiceDate.Year, salesInvoice.InvoiceDate.Month, 01);

                foreach (SalesInvoiceItem salesInvoiceItem in salesInvoice.SalesInvoiceItems)
                {
                    if (salesInvoiceItem.ExistProduct && salesInvoiceItem.Product.ExistPrimaryProductCategory && salesInvoiceItem.Product.PrimaryProductCategory.ExistPackage)
                    {
                        CreatePackageRevenue(session, packageRevenuesByPeriodByPackage, date, revenues, salesInvoiceItem, salesInvoiceItem.Product.PrimaryProductCategory.Package);
                    }
                }
            }

            foreach (PackageRevenue packageRevenue in packageRevenues)
            {
                if (!revenues.Contains(packageRevenue.Id))
                {
                    packageRevenue.Delete();
                }
            }
        }

        private static void CreatePackageRevenue(
            ISession session,
            Dictionary<Package, Dictionary<DateTime, PackageRevenue>> packageRevenuesByPeriodByPackage,
            DateTime date,
            HashSet<long> revenues,
            SalesInvoiceItem salesInvoiceItem,
            Package package)
        {
            PackageRevenue packageRevenue;
            Dictionary<DateTime, PackageRevenue> packageRevenuesByPeriod;
            if (!packageRevenuesByPeriodByPackage.TryGetValue(package, out packageRevenuesByPeriod))
            {
                packageRevenue = CreatePackageRevenue(session, salesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem, package);

                packageRevenuesByPeriod = new Dictionary<DateTime, PackageRevenue> { { date, packageRevenue } };

                packageRevenuesByPeriodByPackage[package] = packageRevenuesByPeriod;
            }

            if (!packageRevenuesByPeriod.TryGetValue(date, out packageRevenue))
            {
                packageRevenue = CreatePackageRevenue(session, salesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem, package);
                packageRevenuesByPeriod.Add(date, packageRevenue);
            }

            revenues.Add(packageRevenue.Id);
            packageRevenue.Revenue += salesInvoiceItem.TotalExVat;
        }

        private static PackageRevenue CreatePackageRevenue(ISession session, SalesInvoice invoice, Package package)
        {
            return new PackageRevenueBuilder(session)
                        .WithPackage(package)
                        .WithPackageName(package.Name)
                        .WithYear(invoice.InvoiceDate.Year)
                        .WithMonth(invoice.InvoiceDate.Month)
                        .WithCurrency(invoice.Currency)
                        .Build();
        }
    }
}