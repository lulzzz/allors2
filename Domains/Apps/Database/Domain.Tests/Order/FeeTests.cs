//------------------------------------------------------------------------------------------------- 
// <copyright file="FeeTests.cs" company="Allors bvba">
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

    
    public class FeeTests : DomainTest
    {
        [Fact]
        public void GivenFee_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var builder = new FeeBuilder(this.Session);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithAmount(1);
            builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);

            builder.WithPercentage(1);
            builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);
        }
    }
}
