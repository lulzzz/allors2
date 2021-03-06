//------------------------------------------------------------------------------------------------- 
// <copyright file="OrderRequirementCommitmentTests.cs" company="Allors bvba">
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
    using Allors.Meta;

    using Xunit;

    public class OrderRequirementCommitmentTests : DomainTest
    {
        [Fact]
        public void GivenOrderRequirementCommitment_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var shipToCustomer = new OrganisationBuilder(this.Session).WithName("shipToCustomer").Build();
            var billToCustomer = new OrganisationBuilder(this.Session).WithName("billToCustomer").Build();

            new CustomerRelationshipBuilder(this.Session)
                .WithCustomer(billToCustomer)
                
                .Build();

            new CustomerRelationshipBuilder(this.Session)
                .WithCustomer(shipToCustomer)
                
                .Build();

            var good = new Goods(this.Session).FindBy(M.Good.Name, "good1");

            this.Session.Derive();

            var salesOrder = new SalesOrderBuilder(this.Session)
                .WithShipToCustomer(shipToCustomer)
                .WithBillToCustomer(billToCustomer)
                .WithVatRegime(new VatRegimes(this.Session).Export)
                .Build();

            var goodOrderItem = new SalesOrderItemBuilder(this.Session)
                .WithInvoiceItemType(new InvoiceItemTypes(this.Session).ProductItem)
                .WithProduct(good)
                .WithQuantityOrdered(1)
                .Build();

            salesOrder.AddSalesOrderItem(goodOrderItem);

            var customerRequirement = new RequirementBuilder(this.Session).WithDescription("100 gizmo's").Build();

            this.Session.Derive();
            this.Session.Commit();

            var builder = new OrderRequirementCommitmentBuilder(this.Session);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithOrderItem(goodOrderItem);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithRequirement(customerRequirement);
            var tsts = builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }
    }
}