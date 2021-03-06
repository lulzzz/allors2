//------------------------------------------------------------------------------------------------- 
// <copyright file="PartSpecificationTests.cs" company="Allors bvba">
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
    public class PartSpecificationTests : DomainTest
    {
        [Fact]
        public void GivenConstraintSpecification_WhenBuild_ThenLastObjectStateEqualsCurrencObjectState()
        {
            var specification = new PartSpecificationBuilder(this.Session).WithDescription("specification").Build();

            this.Session.Derive();

            Assert.Equal(new PartSpecificationStates(this.Session).Created, specification.PartSpecificationState);
            Assert.Equal(specification.LastPartSpecificationState, specification.PartSpecificationState);
        }

        [Fact]
        public void GivenConstraintSpecification_WhenBuild_ThenPreviousObjectStateIsNull()
        {
            var specification = new PartSpecificationBuilder(this.Session).WithDescription("specification").Build();

            this.Session.Derive();

            Assert.Null(specification.PreviousPartSpecificationState);
        }
    }
}
