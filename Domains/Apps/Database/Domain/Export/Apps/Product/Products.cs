// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Products.cs" company="Allors bvba">
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

    public partial class Products
    {
        private static decimal AppsCatalogPrice(
            SalesOrder salesOrder,
            SalesInvoice salesInvoice,
            Product product,
            DateTime date)
        {
            var productBasePrice = 0M;
            var productDiscount = 0M;
            var productSurcharge = 0M;

            var baseprices = new PriceComponent[0];
            if (product.ExistBasePrices)
            {
                baseprices = product.BasePrices;
            }

            var party = salesOrder != null ? salesOrder.ShipToCustomer : salesInvoice != null ? salesInvoice.BillToCustomer : null;

            foreach (BasePrice priceComponent in baseprices)
            {
                if (priceComponent.FromDate <= date &&
                    (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= date))
                {
                    if (PriceComponents.AppsIsEligible(new PriceComponents.IsEligibleParams
                                                           {
                                                               PriceComponent = priceComponent,
                                                               Customer = party,
                                                               Product = product,
                                                               SalesOrder = salesOrder,
                                                               SalesInvoice = salesInvoice,
                                                           }))
                    {
                        if (priceComponent.ExistPrice)
                        {
                            if (productBasePrice == 0 || priceComponent.Price < productBasePrice)
                            {
                                productBasePrice = priceComponent.Price ?? 0;
                            }
                        }
                    }
                }
            }

            var priceComponents = GetPriceComponents(product, date);

            var revenueBreakDiscount = 0M;
            var revenueBreakSurcharge = 0M;

            foreach (var priceComponent in priceComponents)
            {
                if (priceComponent.Strategy.Class.Equals(M.DiscountComponent.ObjectType) || priceComponent.Strategy.Class.Equals(M.SurchargeComponent.ObjectType))
                {
                    if (PriceComponents.AppsIsEligible(new PriceComponents.IsEligibleParams
                                                           {
                                                               PriceComponent = priceComponent,
                                                               Customer = party,
                                                               Product = product,
                                                               SalesOrder = salesOrder,
                                                               SalesInvoice = salesInvoice,
                                                           }))
                    {
                        if (priceComponent.Strategy.Class.Equals(M.DiscountComponent.ObjectType))
                        {
                            var discountComponent = (DiscountComponent)priceComponent;
                            decimal discount;

                            if (discountComponent.Price.HasValue)
                            {
                                discount = discountComponent.Price.Value;
                                productDiscount += discount;
                            }
                            else
                            {
                                var percentage = discountComponent.Percentage.HasValue ? discountComponent.Percentage.Value : 0;
                                discount = Math.Round((productBasePrice * percentage) / 100, 2);
                                productDiscount += discount;
                            }
                        }

                        if (priceComponent.Strategy.Class.Equals(M.SurchargeComponent.ObjectType))
                        {
                            var surchargeComponent = (SurchargeComponent)priceComponent;
                            decimal surcharge;

                            if (surchargeComponent.Price.HasValue)
                            {
                                surcharge = surchargeComponent.Price.Value;
                                productSurcharge += surcharge;
                            }
                            else
                            {
                                var percentage = surchargeComponent.Percentage.HasValue ? surchargeComponent.Percentage.Value : 0;
                                surcharge = Math.Round((productBasePrice * percentage) / 100, 2);
                                productSurcharge += surcharge;
                            }
                        }
                    }
                }
            }

            return productBasePrice - productDiscount + productSurcharge;
        }

        private static List<PriceComponent> GetPriceComponents(Product product, DateTime date)
        {
            // TODO: Code duplication ?
            var priceComponents = new List<PriceComponent>();

            var session = product.Strategy.Session;
            var extent = new PriceComponents(session).Extent();

            foreach (PriceComponent priceComponent in extent)
            {
                if (priceComponent.ExistProduct && priceComponent.Product.Equals(product) && !priceComponent.ExistProductFeature &&
                    priceComponent.FromDate <= date && (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= date))
                {
                    priceComponents.Add(priceComponent);
                }
            }

            if (priceComponents.Count == 0 && product.ExistProductWhereVariant)
            {
                extent = new PriceComponents(session).Extent();
                foreach (PriceComponent priceComponent in extent)
                {
                    if (priceComponent.ExistProduct && priceComponent.Product.Equals(product.ProductWhereVariant) && !priceComponent.ExistProductFeature &&
                        priceComponent.FromDate <= date && (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= date))
                    {
                        priceComponents.Add(priceComponent);
                    }
                }
            }

            // Discounts and surcharges can be specified without product or product feature, these need te be added to collection of pricecomponents
            extent = new PriceComponents(session).Extent();
            foreach (PriceComponent priceComponent in extent)
            {
                if (!priceComponent.ExistProduct && !priceComponent.ExistProductFeature &&
                    priceComponent.FromDate <= date && (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= date))
                {
                    priceComponents.Add(priceComponent);
                }
            }

            return priceComponents;
        }
    } 
}