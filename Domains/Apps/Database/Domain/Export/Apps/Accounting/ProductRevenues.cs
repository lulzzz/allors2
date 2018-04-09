// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductRevenues.cs" company="Allors bvba">
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

    public partial class ProductRevenues
    {
        public static ProductRevenue AppsFindOrCreateAsDependable(ISession session, PartyProductRevenue dependant)
        {
            var productRevenues = dependant.Product.ProductRevenuesWhereProduct;
            productRevenues.Filter.AddEquals(M.ProductRevenue.Year, dependant.Year);
            productRevenues.Filter.AddEquals(M.ProductRevenue.Month, dependant.Month);
            var productRevenue = productRevenues.First ?? new ProductRevenueBuilder(session)
                                                                .WithProduct(dependant.Product)
                                                                .WithYear(dependant.Year)
                                                                .WithMonth(dependant.Month)
                                                                .WithCurrency(dependant.Currency)
                                                                .Build();
            return productRevenue;
        }

        public static void AppsOnDeriveRevenues(ISession session)
        {
            var productRevenuesByPeriodByProduct = new Dictionary<Product, Dictionary<DateTime, ProductRevenue>>();

            var productRevenues = session.Extent<ProductRevenue>();

            foreach (ProductRevenue productRevenue in productRevenues)
            {
                productRevenue.Revenue = 0;
                var date = DateTimeFactory.CreateDate(productRevenue.Year, productRevenue.Month, 01);
                Dictionary<DateTime, ProductRevenue> productRevenuesByPeriod;
                if (!productRevenuesByPeriodByProduct.TryGetValue(productRevenue.Product, out productRevenuesByPeriod))
                {
                    productRevenuesByPeriod = new Dictionary<DateTime, ProductRevenue>();
                    productRevenuesByPeriodByProduct[productRevenue.Product] = productRevenuesByPeriod;
                }

                ProductRevenue revenue;
                if (!productRevenuesByPeriod.TryGetValue(date, out revenue))
                {
                    productRevenuesByPeriod.Add(date, productRevenue);
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
                    if (salesInvoiceItem.ExistProduct && salesInvoiceItem.Product.ExistPrimaryProductCategory)
                    {
                        ProductRevenue productRevenue;

                        Dictionary<DateTime, ProductRevenue> productRevenuesByPeriod;
                        if (!productRevenuesByPeriodByProduct.TryGetValue(salesInvoiceItem.Product, out productRevenuesByPeriod))
                        {
                            productRevenue = CreateProductRevenue(session, salesInvoiceItem);

                            productRevenuesByPeriod = new Dictionary<DateTime, ProductRevenue>
                            {
                                { date, productRevenue } 
                            };

                            productRevenuesByPeriodByProduct[salesInvoiceItem.Product] = productRevenuesByPeriod;
                        }

                        if (!productRevenuesByPeriod.TryGetValue(date, out productRevenue))
                        {
                            productRevenue = CreateProductRevenue(session, salesInvoiceItem);
                            productRevenuesByPeriod.Add(date, productRevenue);
                        }

                        revenues.Add(productRevenue.Id);
                        productRevenue.Revenue += salesInvoiceItem.TotalExVat;
                    }
                }
            }

            foreach (ProductRevenue productRevenue in productRevenues)
            {
                if (!revenues.Contains(productRevenue.Id))
                {
                    productRevenue.Delete();
                }
            }
        }

        private static ProductRevenue CreateProductRevenue(ISession session, SalesInvoiceItem item)
        {
            return new ProductRevenueBuilder(session)
                        .WithProduct(item.Product)
                        .WithYear(item.SalesInvoiceWhereSalesInvoiceItem.InvoiceDate.Year)
                        .WithMonth(item.SalesInvoiceWhereSalesInvoiceItem.InvoiceDate.Month)
                        .WithCurrency(item.SalesInvoiceWhereSalesInvoiceItem.Currency)
                        .Build();
        }
    }
}