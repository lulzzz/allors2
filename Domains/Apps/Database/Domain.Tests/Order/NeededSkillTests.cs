//------------------------------------------------------------------------------------------------- 
// <copyright file="NeededSkillTests.cs" company="Allors bvba">
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

    
    public class NeededSkillTests : DomainTest
    {
        [Fact]
        public void GivenNeededSkill_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var projectManagement = new Skills(this.Session).ProjectManagement;
            var expert = new SkillLevels(this.Session).Expert;

            var builder = new NeededSkillBuilder(this.Session);
            var neededSkill = builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithSkill(projectManagement);
            neededSkill = builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithSkillLevel(expert);
            neededSkill = builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }
    }
}
