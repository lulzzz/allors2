//------------------------------------------------------------------------------------------------- 
// <copyright file="AgreementItemTest.cs" company="Allors bvba">
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

    
    public class AgreementItemTest : DomainTest
    {
        [Fact]
        public void GivenAgreementExhibit_WhenDeriving_ThenDescriptionIsRequired()
        {
            var builder = new AgreementExhibitBuilder(this.Session);
            var agreementExhibit = builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithDescription("AgreementExhibit");
            agreementExhibit = builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenAgreementPricingProgram_WhenDeriving_ThenDescriptionIsRequired()
        {
            var builder = new AgreementPricingProgramBuilder(this.Session);
            var agreementPricingProgram = builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithDescription("AgreementPricingProgram");
            agreementPricingProgram = builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenAgreementSection_WhenDeriving_ThenDescriptionIsRequired()
        {
            var builder = new AgreementSectionBuilder(this.Session);
            var agreementSection = builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithDescription("AgreementSection");
            agreementSection = builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenSubAgreement_WhenDeriving_ThenDescriptionIsRequired()
        {
            var builder = new SubAgreementBuilder(this.Session);
            var subAgreement = builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithDescription("SubAgreement");
            subAgreement = builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }
    }
}
