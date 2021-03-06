// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Salutations.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Allors.Domain
{
    using System;

    public partial class Salutations
    {
        private static readonly Guid MrId = new Guid("970D27DD-CE6F-4943-8BAF-7BE48FC7EE23");
        private static readonly Guid MrsId = new Guid("0CEEB74D-62C5-4166-9823-EA65BDA5A46F");
        private static readonly Guid DrId = new Guid("5827A6B6-375A-4781-9400-FAD8D62064A1");
        private static readonly Guid MsId = new Guid("BE1E6992-EFB6-4445-BDB6-B7AAE849EEEA");
        private static readonly Guid MmeId = new Guid("DF2FC141-D035-47EB-8135-A880A4EBC93C");

        private UniquelyIdentifiableSticky<Salutation> cache;

        public Salutation Mr => this.Cache[MrId];

        public Salutation Mrs => this.Cache[MrsId];

        public Salutation Dr => this.Cache[DrId];

        public Salutation Ms => this.Cache[MsId];

        public Salutation Mme => this.Cache[MmeId];

        private UniquelyIdentifiableSticky<Salutation> Cache => this.cache ?? (this.cache = new UniquelyIdentifiableSticky<Salutation>(this.Session));

        protected override void AppsSetup(Setup setup)
        {
            base.AppsSetup(setup);

            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            new SalutationBuilder(this.Session)
                .WithName("Mr.")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Mr.").WithLocale(dutchLocale).Build())
                .WithUniqueId(MrId)
                .WithIsActive(true)
                .Build();

            new SalutationBuilder(this.Session)
                .WithName("Mrs.")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Mvr.").WithLocale(dutchLocale).Build())
                .WithUniqueId(MrsId)
                .WithIsActive(true)
                .Build();
            
            new SalutationBuilder(this.Session)
                .WithName("Dr.")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Dr.").WithLocale(dutchLocale).Build())
                .WithUniqueId(DrId)
                .WithIsActive(true)
                .Build();
            
            new SalutationBuilder(this.Session)
                .WithName("Ms.")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Juff.").WithLocale(dutchLocale).Build())
                .WithUniqueId(MsId)
                .WithIsActive(true)
                .Build();

            new SalutationBuilder(this.Session)
                .WithName("Mme.")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Mvr.").WithLocale(dutchLocale).Build())
                .WithUniqueId(MmeId)
                .WithIsActive(true)
                .Build();
        }
    }
}
