// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartyProductRevenuesTests.cs" company="Allors bvba">
//   Copyright 2002-2009 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    using System;
    using Meta;
    using NUnit.Framework;

    [TestFixture]
    public class PartyProductRevenuesTests : DomainTest
    {
        [Test]
        public void DeriveRevenues()
        {
            var productItem = new SalesInvoiceItemTypes(this.DatabaseSession).ProductItem;
            var contactMechanism = new ContactMechanisms(this.DatabaseSession).Extent().First;

            var customer1 = new OrganisationBuilder(this.DatabaseSession).WithName("customer1").Build();
            var customer2 = new OrganisationBuilder(this.DatabaseSession).WithName("customer2").Build();
            var salesRep1 = new PersonBuilder(this.DatabaseSession).WithLastName("salesRep1").Build();
            var salesRep2 = new PersonBuilder(this.DatabaseSession).WithLastName("salesRep2").Build();
            var catMain = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("main cat").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .Build();
            var cat1 = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("cat for good1").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithParent(catMain)
                .Build();
            var cat2 = new ProductCategoryBuilder(this.DatabaseSession)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("cat for good2").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithParent(catMain)
                .Build();

            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer1).WithProductCategory(cat1).WithSalesRepresentative(salesRep1).Build();
            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer1).WithProductCategory(cat2).WithSalesRepresentative(salesRep2).Build();

            this.DatabaseSession.Derive(true);

            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer2).WithProductCategory(cat1).WithSalesRepresentative(salesRep1).Build();
            new SalesRepRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer2).WithProductCategory(cat2).WithSalesRepresentative(salesRep2).Build();

            this.DatabaseSession.Derive(true);

            var euro = new Currencies(this.DatabaseSession).FindBy(M.Currency.IsoCode, "EUR");
            var vatRate21 = new VatRateBuilder(this.DatabaseSession).WithRate(21).Build();

            var good1 = new GoodBuilder(this.DatabaseSession)
                .WithSku("10101")
                .WithVatRate(vatRate21)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("good1").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithInventoryItemKind(new InventoryItemKinds(this.DatabaseSession).NonSerialized)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.DatabaseSession).Piece)
                .WithPrimaryProductCategory(cat1)
                .Build();

            var good2 = new GoodBuilder(this.DatabaseSession)
                .WithSku("10102")
                .WithVatRate(vatRate21)
                .WithLocalisedName(new LocalisedTextBuilder(this.DatabaseSession).WithText("good2").WithLocale(Singleton.Instance(this.DatabaseSession).DefaultLocale).Build())
                .WithInventoryItemKind(new InventoryItemKinds(this.DatabaseSession).NonSerialized)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.DatabaseSession).Piece)
                .WithPrimaryProductCategory(cat2)
                .Build();

            var internalOrganisation = new InternalOrganisations(this.DatabaseSession).FindBy(M.InternalOrganisation.Name, "internalOrganisation");
            internalOrganisation.PreferredCurrency = euro;

            new CustomerRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer1).WithInternalOrganisation(internalOrganisation).Build();
            new CustomerRelationshipBuilder(this.DatabaseSession).WithFromDate(DateTime.UtcNow).WithCustomer(customer2).WithInternalOrganisation(internalOrganisation).Build();

            this.DatabaseSession.Derive(true);

            var invoice1 = new SalesInvoiceBuilder(this.DatabaseSession)
                .WithInvoiceDate(DateTime.UtcNow)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer1)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.DatabaseSession).SalesInvoice)
                .Build();

            var item1 = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(3).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice1.AddSalesInvoiceItem(item1);

            var item2 = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(3).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice1.AddSalesInvoiceItem(item2);

            var item3 = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good2).WithQuantity(5).WithActualUnitPrice(10).WithSalesInvoiceItemType(productItem).Build();
            invoice1.AddSalesInvoiceItem(item3);

            this.DatabaseSession.Derive(true);

            Singleton.Instance(this.DatabaseSession).DeriveRevenues(new NonLogging.Derivation(this.DatabaseSession));

            var customer1ProductRevenues = customer1.PartyProductRevenuesWhereParty;
            Assert.AreEqual(2, customer1ProductRevenues.Count);

            customer1ProductRevenues = customer1.PartyProductRevenuesWhereParty;
            customer1ProductRevenues.Filter.AddEquals(M.PartyProductRevenue.Product, good1);
            var customer1Good1Revenue = customer1ProductRevenues.First;

            customer1ProductRevenues = customer1.PartyProductRevenuesWhereParty;
            customer1ProductRevenues.Filter.AddEquals(M.PartyProductRevenue.Product, good2);
            var customer1Good2Revenue = customer1ProductRevenues.First;

            Assert.AreEqual(90, customer1Good1Revenue.Revenue);
            Assert.AreEqual(6, customer1Good1Revenue.Quantity);
            Assert.AreEqual(50, customer1Good2Revenue.Revenue);
            Assert.AreEqual(5, customer1Good2Revenue.Quantity);

            var invoice2 = new SalesInvoiceBuilder(this.DatabaseSession)
                .WithInvoiceDate(DateTime.UtcNow)
                .WithInvoiceNumber("1")
                .WithBillToCustomer(customer2)
                .WithBillToContactMechanism(contactMechanism)
                .WithSalesInvoiceType(new SalesInvoiceTypes(this.DatabaseSession).SalesInvoice)
                .Build();

            var item4 = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good1).WithQuantity(1).WithActualUnitPrice(15).WithSalesInvoiceItemType(productItem).Build();
            invoice2.AddSalesInvoiceItem(item4);

            this.DatabaseSession.Derive(true);

            var item5 = new SalesInvoiceItemBuilder(this.DatabaseSession).WithProduct(good2).WithQuantity(1).WithActualUnitPrice(10).WithSalesInvoiceItemType(productItem).Build();
            invoice2.AddSalesInvoiceItem(item5);

            this.DatabaseSession.Derive(true);

            Singleton.Instance(this.DatabaseSession).DeriveRevenues(new NonLogging.Derivation(this.DatabaseSession));

            var customer2ProductRevenues = customer2.PartyProductRevenuesWhereParty;
            Assert.AreEqual(2, customer2ProductRevenues.Count);

            customer2ProductRevenues.Filter.AddEquals(M.PartyProductRevenue.Product, good1);
            var customer2Good1Revenue = customer2ProductRevenues.First;

            customer2ProductRevenues = customer2.PartyProductRevenuesWhereParty;
            customer2ProductRevenues.Filter.AddEquals(M.PartyProductRevenue.Product, good2);
            var customer2Good2Revenue = customer2ProductRevenues.First;

            Assert.AreEqual(15, customer2Good1Revenue.Revenue);
            Assert.AreEqual(1, customer2Good1Revenue.Quantity);
            Assert.AreEqual(10, customer2Good2Revenue.Revenue);
            Assert.AreEqual(1, customer2Good2Revenue.Quantity);
        }
    }
}