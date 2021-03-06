// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductFeatureApplicabilityKinds.cs" company="Allors bvba">
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

    public partial class ProductFeatureApplicabilityKinds
    {
        private static readonly Guid RequiredId = new Guid("7FBDCDDF-5983-4653-A0FC-768AECA686D0");
        private static readonly Guid StandardId = new Guid("76E0AC21-842F-4D84-A69B-E2AA5E8DD6CF");
        private static readonly Guid OptionalId = new Guid("4210498F-7252-454C-A1D1-E61F5139D8DB");
        private static readonly Guid SelectableId = new Guid("FAD59954-725E-4E40-BCD5-66F1E30990BF");

        private UniquelyIdentifiableSticky<ProductFeatureApplicabilityKind> cache;

        public ProductFeatureApplicabilityKind Required => this.Cache[RequiredId];

        public ProductFeatureApplicabilityKind Standard => this.Cache[StandardId];

        public ProductFeatureApplicabilityKind Optional => this.Cache[OptionalId];

        public ProductFeatureApplicabilityKind Selectable => this.Cache[SelectableId];

        private UniquelyIdentifiableSticky<ProductFeatureApplicabilityKind> Cache => this.cache ?? (this.cache = new UniquelyIdentifiableSticky<ProductFeatureApplicabilityKind>(this.Session));

        protected override void AppsSetup(Setup setup)
        {
            base.AppsSetup(setup);

            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            new ProductFeatureApplicabilityKindBuilder(this.Session)
                .WithName("Required")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Verplicht").WithLocale(dutchLocale).Build())
                .WithUniqueId(RequiredId)
                .WithIsActive(true)
                .Build();
            
            new ProductFeatureApplicabilityKindBuilder(this.Session)
                .WithName("Standard")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Standaard").WithLocale(dutchLocale).Build())
                .WithUniqueId(StandardId)
                .WithIsActive(true)
                .Build();
            
            new ProductFeatureApplicabilityKindBuilder(this.Session)
                .WithName("Optional")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Optioneel").WithLocale(dutchLocale).Build())
                .WithUniqueId(OptionalId)
                .WithIsActive(true)
                .Build();
            
            new ProductFeatureApplicabilityKindBuilder(this.Session)
                .WithName("Selectable")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Selecteerbaar").WithLocale(dutchLocale).Build())
                .WithUniqueId(SelectableId)
                .WithIsActive(true)
                .Build();
        }
    }
}
