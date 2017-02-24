// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonTests.cs" company="Allors bvba">
//   Copyright 2002-2009 Allors bvba.
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
// <summary>
//   Defines the PersonTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using Meta;
    using NUnit.Framework;

    [TestFixture]
    public class PersonTests : DomainTest
    {
        [Test]
        public void GivenPerson_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var builder = new PersonBuilder(this.DatabaseSession);
            builder.Build();
                
            Assert.IsFalse(this.DatabaseSession.Derive().HasErrors);
        }

        [Test]
        public void GivenPerson_WhenEmployed_ThenCurrentEmploymentIsDerived()
        {
            var salesRep = new PersonBuilder(this.DatabaseSession).WithLastName("salesRep").Build();

            var employment = new EmploymentBuilder(this.DatabaseSession)
                .WithEmployee(salesRep)
                .WithEmployer(new InternalOrganisations(this.DatabaseSession).FindBy(M.InternalOrganisation.Name, "internalOrganisation"))
                .WithFromDate(DateTime.UtcNow)
                .Build();

            this.DatabaseSession.Derive(true);

            Assert.AreEqual(employment, salesRep.CurrentEmployment);
        }

        [Test]
        public void GivenLoggedUserIsAdministrator_WhenAccessingInternalOrganisation_ThenLoggedInUserIsGrantedAccess()
        {
            var existingAdministrator = new People(this.DatabaseSession).FindBy(M.Person.UserName, Users.AdministratorUserName);
            var secondAdministrator = new PersonBuilder(this.DatabaseSession).WithLastName("second admin").Build();
            Assert.IsFalse(secondAdministrator.IsAdministrator);

            var internalOrganisation = new InternalOrganisations(this.DatabaseSession).FindBy(M.InternalOrganisation.Name, "internalOrganisation");

            this.DatabaseSession.Derive(true);

            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Users.AdministratorUserName, "Forms"), new string[0]);
            var acl = new AccessControlList(internalOrganisation, existingAdministrator);
            Assert.IsTrue(acl.CanWrite(M.InternalOrganisation.Name));
            
            acl = new AccessControlList(internalOrganisation, secondAdministrator);
            Assert.IsFalse(acl.CanRead(M.InternalOrganisation.Name));

            var administrators = new UserGroups(this.DatabaseSession).Administrators;
            administrators.AddMember(secondAdministrator);

            this.DatabaseSession.Derive(true);

            Assert.IsTrue(secondAdministrator.IsAdministrator);

            acl = new AccessControlList(internalOrganisation, secondAdministrator);
            Assert.IsTrue(acl.CanWrite(M.InternalOrganisation.Name));
        }

        [Test]
        public void GivenPerson_WhenInActiveContactRelationship_ThenPersonIsActiveContact()
        {
            var contact = new PersonBuilder(this.DatabaseSession).WithLastName("organisationContact").Build();
            var organisation = new OrganisationBuilder(this.DatabaseSession).WithName("organisation").Build();

            new CustomerRelationshipBuilder(this.DatabaseSession)
                .WithInternalOrganisation(new InternalOrganisations(this.DatabaseSession).FindBy(M.InternalOrganisation.Name, "internalOrganisation"))
                .WithCustomer(organisation)
                .WithFromDate(DateTimeFactory.CreateDate(2010, 01, 01))
                .Build();

            var organisationContactRelationship = new OrganisationContactRelationshipBuilder(this.DatabaseSession)
                .WithContact(contact)
                .WithOrganisation(organisation)
                .WithFromDate(DateTime.UtcNow.Date)
                .Build();

            Assert.IsTrue(contact.IsActiveContact(DateTime.UtcNow.Date));
            Assert.IsTrue(contact.IsActiveContact(DateTime.UtcNow.Date.AddDays(1)));
            Assert.IsFalse(contact.IsActiveContact(DateTime.UtcNow.Date.AddDays(-1)));

            organisationContactRelationship.FromDate = DateTimeFactory.CreateDate(2010, 01, 01);
            organisationContactRelationship.ThroughDate = DateTimeFactory.CreateDate(2011, 01, 01);

            Assert.IsFalse(contact.IsActiveContact(DateTime.UtcNow.Date));
            Assert.IsTrue(contact.IsActiveContact(DateTimeFactory.CreateDate(2010, 01, 01)));
            Assert.IsTrue(contact.IsActiveContact(DateTimeFactory.CreateDate(2010, 06, 01)));
            Assert.IsTrue(contact.IsActiveContact(DateTimeFactory.CreateDate(2011, 01, 01)));
            Assert.IsFalse(contact.IsActiveContact(DateTimeFactory.CreateDate(2011, 01, 02)));
        }
    }
}