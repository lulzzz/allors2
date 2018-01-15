// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationTests.cs" company="Allors bvba">
//   Copyright 2002-2016 Allors bvba.
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

namespace Tests
{
    using Allors;
    using Allors.Domain;

    using Xunit;

    
    public class EnumerationTests : DomainTest
    {
        [Fact]
        public void GivenLocalisedTextThenNameIsDerived()
        {
            var defaultLocale = this.Session.GetSingleton().DefaultLocale;

            var gender = new GenderBuilder(this.Session)
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("LGBT").WithLocale(defaultLocale).Build())
                .Build();

            this.Session.Derive(true);
            Assert.Equal("LGBT", gender.Name);

            gender.LocalisedNames[0].Text = "male";

            this.Session.Derive(true);
            Assert.Equal("male", gender.Name);
        }
    }
}