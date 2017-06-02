//------------------------------------------------------------------------------------------------- 
// <copyright file="PurchaseInvoiceItemTests.cs" company="Allors bvba">
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
    using Xunit;

    
    public class PurchaseInvoiceItemTests : DomainTest
    {
        [Fact]
        public void GivenInvoiceItem_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var rawMaterial = new RawMaterialBuilder(this.DatabaseSession).WithName("rawmaterial").Build();
            
            this.DatabaseSession.Derive(true);
            this.DatabaseSession.Commit();

            var builder = new PurchaseInvoiceItemBuilder(this.DatabaseSession);
            builder.Build();

            Assert.True(this.DatabaseSession.Derive(false).HasErrors);

            this.DatabaseSession.Rollback();

            builder.WithPart(rawMaterial);
            builder.Build();

            Assert.True(this.DatabaseSession.Derive(false).HasErrors);

            this.DatabaseSession.Rollback();

            builder.WithQuantity(1);
            builder.Build();

            Assert.True(this.DatabaseSession.Derive(false).HasErrors);

            this.DatabaseSession.Rollback();

            builder.WithActualUnitPrice(15M);
            builder.Build();

            Assert.True(this.DatabaseSession.Derive(false).HasErrors);

            this.DatabaseSession.Rollback();

            builder.WithPurchaseInvoiceItemType(new PurchaseInvoiceItemTypes(this.DatabaseSession).PartItem);
            builder.Build();

            Assert.False(this.DatabaseSession.Derive(false).HasErrors);
        }
    }
}