//------------------------------------------------------------------------------------------------- 
// <copyright file="PaymentApplicationTests.cs" company="Allors bvba">
// Copyright 2002-2009 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// <summary>Defines the MediaTests type.</summary>
//-------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    using System;
    using Meta;
    using Xunit;

    public class PaymentApplicationTests : DomainTest
    {
        [Fact]
        public void GivenPaymentApplication_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var billToContactMechanism = new EmailAddressBuilder(this.Session).WithElectronicAddressString("info@allors.com").Build();

            var customer = new PersonBuilder(this.Session).WithLastName("customer").Build();
            new CustomerRelationshipBuilder(this.Session)
                .WithCustomer(customer)
                .Build();

            var good1 = new Goods(this.Session).FindBy(M.Good.Name, "good1");

            new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(billToContactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.Session).SalesInvoice)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session)
                                        .WithProduct(good1)  
                                        .WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem)
                                        .WithQuantity(1)
                                        .WithActualUnitPrice(100M)
                                        .Build())
                .Build();

            var builder = new PaymentApplicationBuilder(this.Session);
            builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenPaymentApplication_WhenDeriving_ThenAmountAppliedCannotBeLargerThenAmountReceived()
        {
            var contactMechanism = new ContactMechanisms(this.Session).Extent().First;
            var good = new Goods(this.Session).FindBy(M.Good.Name, "good1");

            var customer = new PersonBuilder(this.Session).WithLastName("customer").Build();
            new CustomerRelationshipBuilder(this.Session)
                .WithCustomer(customer)
                
                .Build();

            var invoice = new SalesInvoiceBuilder(this.Session)
                .WithBillToCustomer(customer)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceItem(new SalesInvoiceItemBuilder(this.Session).WithProduct(good).WithQuantity(1).WithActualUnitPrice(1000M).WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem).Build())
                .Build();

            this.Session.Derive();

            var receipt = new ReceiptBuilder(this.Session)
                .WithAmount(100)
                .WithEffectiveDate(DateTime.UtcNow)
                .Build();

            var paymentApplication = new PaymentApplicationBuilder(this.Session)
                .WithAmountApplied(200)
                .WithInvoiceItem(invoice.InvoiceItems[0])
                .Build();

            this.Session.Derive();
            this.Session.Commit();
            
            receipt.AddPaymentApplication(paymentApplication);

            var derivationLog = this.Session.Derive(false);
            Assert.True(derivationLog.HasErrors);
            Assert.Contains(M.PaymentApplication.AmountApplied, derivationLog.Errors[0].RoleTypes);
        }
    }
}