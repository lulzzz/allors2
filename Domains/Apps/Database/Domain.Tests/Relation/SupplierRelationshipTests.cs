//------------------------------------------------------------------------------------------------- 
// <copyright file="SupplierRelationshipTests.cs" company="Allors bvba">
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

using System.Linq;

namespace Allors.Domain
{
    using System;
    using Meta;
    using Xunit;

    public class SupplierRelationshipTests : DomainTest
    {
        private Person contact;
        private Organisation supplier;
        private SupplierRelationship supplierRelationship;
        private OrganisationContactRelationship organisationContactRelationship;

        public SupplierRelationshipTests()
        {
            this.contact = new PersonBuilder(this.Session).WithLastName("contact").Build();
            this.supplier = new OrganisationBuilder(this.Session)
                .WithName("supplier")
                .WithLocale(new Locales(this.Session).EnglishGreatBritain)
                
                .Build();

            this.organisationContactRelationship = new OrganisationContactRelationshipBuilder(this.Session)
                .WithOrganisation(this.supplier)
                .WithContact(this.contact)
                .WithFromDate(DateTime.UtcNow)
                .Build();

            this.supplierRelationship = new SupplierRelationshipBuilder(this.Session)
                .WithSupplier(this.supplier)
                .WithFromDate(DateTime.UtcNow.AddYears(-1))
                .Build();

            this.Session.Derive();
            this.Session.Commit();
        }

        [Fact]
        public void GivenSupplierRelationshipBuilder_WhenBuild_ThenSubAccountNumerIsValidElevenTestNumber()
        {
            this.InternalOrganisation.SubAccountCounter.Value = 1000;

            this.Session.Commit();

            var supplier1 = new OrganisationBuilder(this.Session).WithName("supplier1").Build();
            var supplierRelationship1 = new SupplierRelationshipBuilder(this.Session).WithSupplier(supplier1).Build();

            this.Session.Derive();

            var partyFinancial1 = supplier1.PartyFinancialRelationshipsWhereParty.First(v => Equals(v.InternalOrganisation, supplierRelationship1.InternalOrganisation));

            this.Session.Derive();

            Assert.Equal(1007, partyFinancial1.SubAccountNumber);

            var supplier2 = new OrganisationBuilder(this.Session).WithName("supplier2").Build();
            var supplierRelationship2 = new SupplierRelationshipBuilder(this.Session).WithSupplier(supplier2).Build();

            this.Session.Derive();

            var partyFinancial2 = supplier2.PartyFinancialRelationshipsWhereParty.First(v => Equals(v.InternalOrganisation, supplierRelationship2.InternalOrganisation));

            this.Session.Derive();

            Assert.Equal(1015, partyFinancial2.SubAccountNumber);

            var supplier3 = new OrganisationBuilder(this.Session).WithName("supplier3").Build();
            var supplierRelationship3 = new SupplierRelationshipBuilder(this.Session).WithSupplier(supplier3).Build();

            this.Session.Derive();

            var partyFinancial3 = supplier3.PartyFinancialRelationshipsWhereParty.First(v => Equals(v.InternalOrganisation, supplierRelationship3.InternalOrganisation));

            this.Session.Derive();

            Assert.Equal(1023, partyFinancial3.SubAccountNumber);
        }

        [Fact]
        public void GivenSupplierRelationship_WhenDeriving_ThenSubAccountNumberMustBeUniqueWithinInternalOrganisation()
        {
            var supplier2 = new OrganisationBuilder(this.Session).WithName("supplier").Build();

            this.Session.Derive();

            var belgium = new Countries(this.Session).CountryByIsoCode["BE"];
            var euro = belgium.Currency;

            var bank = new BankBuilder(this.Session).WithCountry(belgium).WithName("ING Belgi�").WithBic("BBRUBEBB").Build();

            var ownBankAccount = new OwnBankAccountBuilder(this.Session)
                .WithDescription("BE23 3300 6167 6391")
                .WithBankAccount(new BankAccountBuilder(this.Session).WithBank(bank).WithCurrency(euro).WithIban("BE23 3300 6167 6391").WithNameOnAccount("Koen").Build())
                .Build();

            var internalOrganisation2 = new OrganisationBuilder(this.Session)
                .WithIsInternalOrganisation(true)
                .WithName("internalOrganisation2")
                .WithDefaultCollectionMethod(ownBankAccount)
                .Build();

            this.Session.Derive();

            var supplierRelationship2 = new SupplierRelationshipBuilder(this.Session)
                .WithSupplier(supplier2)
                .WithInternalOrganisation(internalOrganisation2)
                .WithFromDate(DateTime.UtcNow)
                .Build();

            this.Session.Derive();

            var partyFinancial2 = supplier2.PartyFinancialRelationshipsWhereParty.First(v => Equals(v.InternalOrganisation, supplierRelationship2.InternalOrganisation));

            partyFinancial2.SubAccountNumber = 19;

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenSupplierRelationship_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            this.InstantiateObjects(this.Session);

            var builder = new SupplierRelationshipBuilder(this.Session);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithSupplier(this.supplier);
            builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenSupplierOrganisation_WhenOrganisationContactRelationshipIsCreated_ThenPersonIsAddedToUserGroup()
        {
            this.InstantiateObjects(this.Session);

            Assert.Equal(1, this.supplierRelationship.Supplier.ContactsUserGroup.Members.Count);
            Assert.True(this.supplierRelationship.Supplier.ContactsUserGroup.Members.Contains(this.contact));
        }

        [Fact]
        public void GivenSupplierRelationship_WhenRelationshipPeriodIsNotValid_ThenContactIsNotInContactsUserGroup()
        {
            this.InstantiateObjects(this.Session);

            Assert.Equal(1, this.supplierRelationship.Supplier.ContactsUserGroup.Members.Count);
            Assert.True(this.supplierRelationship.Supplier.ContactsUserGroup.Members.Contains(this.contact));

            this.organisationContactRelationship.FromDate = DateTime.UtcNow.AddDays(+1);
            this.organisationContactRelationship.RemoveThroughDate();

            this.Session.Derive();

            Assert.Equal(0, this.supplierRelationship.Supplier.ContactsUserGroup.Members.Count);

            this.organisationContactRelationship.FromDate = DateTime.UtcNow.AddSeconds(-1);
            this.organisationContactRelationship.RemoveThroughDate();

            this.Session.Derive();

            Assert.Equal(1, this.supplierRelationship.Supplier.ContactsUserGroup.Members.Count);
            Assert.True(this.supplierRelationship.Supplier.ContactsUserGroup.Members.Contains(this.contact));

            this.organisationContactRelationship.FromDate = DateTime.UtcNow.AddDays(-2);
            this.organisationContactRelationship.ThroughDate = DateTime.UtcNow.AddDays(-1);

            this.Session.Derive();

            Assert.Equal(0, this.supplierRelationship.Supplier.ContactsUserGroup.Members.Count);
        }

        [Fact]
        public void GivenSupplierRelationship_WhenContactForOrganisationEnds_ThenContactIsRemovedfromContactsUserGroup()
        {
            this.InstantiateObjects(this.Session);

            var contact2 = new PersonBuilder(this.Session).WithLastName("contact2").Build();
            var contactRelationship2 = new OrganisationContactRelationshipBuilder(this.Session)
                .WithOrganisation(this.supplier)
                .WithContact(contact2)
                .WithFromDate(DateTime.UtcNow)
                .Build();

            this.Session.Derive();

            Assert.Equal(2, this.supplierRelationship.Supplier.ContactsUserGroup.Members.Count);
            Assert.True(this.supplierRelationship.Supplier.ContactsUserGroup.Members.Contains(this.contact));

            contactRelationship2.ThroughDate = DateTime.UtcNow.AddDays(-1);

            this.Session.Derive();

            Assert.Equal(1, this.supplierRelationship.Supplier.ContactsUserGroup.Members.Count);
            Assert.True(this.supplierRelationship.Supplier.ContactsUserGroup.Members.Contains(this.contact));
            Assert.False(this.supplierRelationship.Supplier.ContactsUserGroup.Members.Contains(contact2));
        }

        [Fact]
        public void GivenActiveSupplierRelationship_WhenDeriving_ThenInternalOrganisationSuppliersContainsSupplier()
        {
            Assert.Contains(this.supplier, this.InternalOrganisation.ActiveSuppliers);
        }

        [Fact]
        public void GivenSupplierRelationshipToCome_WhenDeriving_ThenInternalOrganisationSuppliersDosNotContainSupplier()
        {
            this.supplierRelationship.FromDate = DateTime.UtcNow.AddDays(1);
            this.Session.Derive();

            Assert.False(InternalOrganisation.ActiveSuppliers.Contains(supplier));
        }

        [Fact]
        public void GivenSupplierRelationshipThatHasEnded_WhenDeriving_ThenInternalOrganisationSuppliersDosNotContainSupplier()
        {
            this.supplierRelationship.FromDate = DateTime.UtcNow.AddDays(-10);
            this.supplierRelationship.ThroughDate = DateTime.UtcNow.AddDays(-1);

            this.Session.Derive();

            Assert.False(InternalOrganisation.ActiveSuppliers.Contains(supplier));
        }

        private void InstantiateObjects(ISession session)
        {
            this.contact = (Person)session.Instantiate(this.contact);
            this.supplier = (Organisation)session.Instantiate(this.supplier);
            this.supplierRelationship = (SupplierRelationship)session.Instantiate(this.supplierRelationship);
            this.organisationContactRelationship = (OrganisationContactRelationship)session.Instantiate(this.organisationContactRelationship);
        }
    }
}
