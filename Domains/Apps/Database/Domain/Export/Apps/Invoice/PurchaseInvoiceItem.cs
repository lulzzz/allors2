// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PurchaseInvoiceItem.cs" company="Allors bvba">
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

    using Allors.Meta;

    public partial class PurchaseInvoiceItem
    {
        public static readonly TransitionalConfiguration[] StaticTransitionalConfigurations =
            {
                new TransitionalConfiguration(M.PurchaseInvoiceItem, M.PurchaseInvoiceItem.PurchaseInvoiceItemState),
            };

        public TransitionalConfiguration[] TransitionalConfigurations => StaticTransitionalConfigurations;

        public decimal PriceAdjustment => this.TotalSurcharge - this.TotalDiscount;

        public void AppsOnBuild(ObjectOnBuild method)
        {
            if (!this.ExistPurchaseInvoiceItemState)
            {
                this.PurchaseInvoiceItemState= new PurchaseInvoiceItemStates(this.Strategy.Session).Received;
            }

            if (this.ExistPart && !this.ExistInvoiceItemType)
            {
                this.InvoiceItemType = new InvoiceItemTypes(this.Strategy.Session).PartItem;
            }
        }

        public void AppsOnPreDerive(ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            var invoice = this.PurchaseInvoiceWherePurchaseInvoiceItem;
            if (invoice != null)
            {
                // TODO:
                if (derivation.ChangeSet.Associations.Contains(this.Id))
                {
                    derivation.AddDependency(invoice, this);
                }
            }
        }

        public void AppsOnDerivePrices()
        {
            this.UnitBasePrice = 0;
            this.UnitDiscount = 0;
            this.UnitSurcharge = 0;

            if (this.ExistActualUnitPrice)
            {
                this.UnitBasePrice = this.ActualUnitPrice??  0;
                this.CalculatedUnitPrice = this.ActualUnitPrice?? 0;

                var discountAdjustment = this.GetDiscountAdjustment();

                if (discountAdjustment != null)
                {
                    if (discountAdjustment.Percentage.HasValue)
                    {
                        this.UnitDiscount += Math.Round((this.UnitBasePrice * discountAdjustment.Percentage.Value) / 100, 2);
                    }
                    else
                    {
                        if (discountAdjustment.Amount.HasValue)
                        {
                            this.UnitDiscount += discountAdjustment.Amount.Value;
                        }
                    }
                }

                var surchargeAdjustment = this.GetSurchargeAdjustment();

                if (surchargeAdjustment != null)
                {
                    if (surchargeAdjustment.Percentage.HasValue)
                    {
                        this.UnitSurcharge += Math.Round((this.UnitBasePrice * surchargeAdjustment.Percentage.Value) / 100, 2);
                    }
                    else
                    {
                        if (surchargeAdjustment.Amount.HasValue)
                        {
                            this.UnitSurcharge += surchargeAdjustment.Amount.Value;
                        }
                    }
                }

                decimal vat = 0;

                if (this.ExistDerivedVatRate)
                {
                    var vatRate = this.DerivedVatRate.Rate;
                    var vatBase = this.UnitBasePrice - this.UnitDiscount + this.UnitSurcharge;
                    vat = Math.Round((vatBase * vatRate) / 100, 2);
                }

                this.UnitVat = vat;
                this.TotalBasePrice = this.UnitBasePrice * this.Quantity;
                this.TotalDiscount = this.UnitDiscount * this.Quantity;
                this.TotalSurcharge = this.UnitSurcharge * this.Quantity;
                this.CalculatedUnitPrice = this.UnitBasePrice - this.UnitDiscount + this.UnitSurcharge;
                this.TotalVat = this.UnitVat * this.Quantity;
                this.TotalExVat = this.CalculatedUnitPrice * this.Quantity;
                this.TotalIncVat = this.TotalExVat + this.TotalVat;
            }
        }

        private SurchargeAdjustment GetSurchargeAdjustment()
        {
            var surchargeAdjustment = this.ExistSurchargeAdjustment ? this.SurchargeAdjustment : null;
            if (surchargeAdjustment == null && this.ExistPurchaseInvoiceWherePurchaseInvoiceItem)
            {
                surchargeAdjustment = this.PurchaseInvoiceWherePurchaseInvoiceItem.ExistSurchargeAdjustment ? this.PurchaseInvoiceWherePurchaseInvoiceItem.SurchargeAdjustment : null;
            }

            return surchargeAdjustment;
        }

        private DiscountAdjustment GetDiscountAdjustment()
        {
            var discountAdjustment = this.ExistDiscountAdjustment ? this.DiscountAdjustment : null;
            if (discountAdjustment == null && this.ExistPurchaseInvoiceWherePurchaseInvoiceItem)
            {
                discountAdjustment = this.PurchaseInvoiceWherePurchaseInvoiceItem.ExistDiscountAdjustment ? this.PurchaseInvoiceWherePurchaseInvoiceItem.DiscountAdjustment : null;
            }

            return discountAdjustment;
        }
    }
}