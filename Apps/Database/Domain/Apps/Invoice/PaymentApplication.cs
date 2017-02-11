// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaymentApplication.cs" company="Allors bvba">
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
    using Meta;
    using Resources;

    public partial class PaymentApplication
    {
        public void AppsOnPreDerive(ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            // TODO:
            if (derivation.ChangeSet.Associations.Contains(this.Id))
            {
                var receipt = this.PaymentWherePaymentApplication as Receipt;
                if (receipt != null)
                {
                    derivation.AddDependency(receipt, this);
                }

                if (this.ExistInvoiceItem)
                {
                    derivation.AddDependency(this.InvoiceItem, this);
                }

                if (this.ExistInvoice)
                {
                    derivation.AddDependency(this.Invoice, this);
                }
            }
        }

        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            derivation.Validation.AssertExistsAtMostOne(this, M.PaymentApplication.Invoice, M.PaymentApplication.InvoiceItem);

            if (this.ExistPaymentWherePaymentApplication && this.AmountApplied > this.PaymentWherePaymentApplication.Amount)
            {
                derivation.Validation.AddError(this, M.PaymentApplication.AmountApplied, ErrorMessages.PaymentApplicationNotLargerThanPaymentAmount);
            }

            if (this.ExistInvoice && this.Invoice.AmountPaid > this.Invoice.TotalIncVat)
            {
                derivation.Validation.AddError(this, M.PaymentApplication.AmountApplied, ErrorMessages.PaymentApplicationNotLargerThanInvoiceAmount);
            }

            if (this.ExistInvoiceItem && this.InvoiceItem.AmountPaid > this.InvoiceItem.TotalIncVat)
            {
                derivation.Validation.AddError(this, M.PaymentApplication.AmountApplied, ErrorMessages.PaymentApplicationNotLargerThanInvoiceItemAmount);
            }

            var salesInvoice = this.Invoice as SalesInvoice;
            var purchaseInvoice = this.Invoice as PurchaseInvoice;
            var salesInvoiceItem = this.InvoiceItem as SalesInvoiceItem;
            var purchaseInvoiceItem  = this.InvoiceItem as PurchaseInvoiceItem;

            // if (salesInvoice != null)
            // {
            // salesInvoice.OnDerive(x => x.WithDerivation(derivation));
            // }

            // if (purchaseInvoice != null)
            // {
            // purchaseInvoice.OnDerive(x => x.WithDerivation(derivation));
            // }

            // if (salesInvoiceItem != null)
            // {
            // salesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem.OnDerive(x => x.WithDerivation(derivation));
            // }

            // if (purchaseInvoiceItem != null)
            // {
            // purchaseInvoiceItem.PurchaseInvoiceItemType.OnDerive(x => x.WithDerivation(derivation));
            // }
        }
    }
}