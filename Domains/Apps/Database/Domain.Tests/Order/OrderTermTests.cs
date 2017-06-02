//------------------------------------------------------------------------------------------------- 
// <copyright file="OrderTermTests.cs" company="Allors bvba">
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

    
    public class OrderTermTests : DomainTest
    {
        [Fact]
        public void GivenOrderTerm_WhenDeriving_ThenDescriptionIsRequired()
        {
            var builder = new OrderTermBuilder(this.DatabaseSession);
            var orderTerm = builder.Build();

            Assert.True(this.DatabaseSession.Derive(false).HasErrors);

            this.DatabaseSession.Rollback();

            builder.WithTermType(new TermTypes(this.DatabaseSession).PercentageCancellationCharge);
            orderTerm = builder.Build();

            Assert.False(this.DatabaseSession.Derive(false).HasErrors);
        }
    }
}
