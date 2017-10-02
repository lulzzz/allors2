// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartSpecificationTypes.cs" company="Allors bvba">
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

    public partial class PartSpecificationTypes
    {
        private static readonly Guid ConstraintSpecificationId = new Guid("0B3247BF-5E17-458F-BE52-9255EC0E5A4D");
        private static readonly Guid OperatingConditionId = new Guid("6D49DEFC-27DD-40AB-B0DA-AFFC257FFB1C");
        private static readonly Guid PartSpecificationId = new Guid("E9F306C0-3CE2-48BD-82E8-E341181A36A9");
        private static readonly Guid PerformanceSpecificationId = new Guid("96A0ABA2-6CEE-4CB9-A0DA-076E46DD2312");
        private static readonly Guid TestingRequirementId = new Guid("EC007D79-D657-44BC-B7C5-CB4B7893582E");
        private static readonly Guid ToleranceId = new Guid("E6425782-ACED-47A1-AB5A-4EC97A2C80EA");

        private UniquelyIdentifiableCache<PartSpecificationType> cache;

        public PartSpecificationType ConstraintSpecification => this.Cache.Get(ConstraintSpecificationId);

        public PartSpecificationType OperatingCondition => this.Cache.Get(OperatingConditionId);

        public PartSpecificationType PartSpecification => this.Cache.Get(PartSpecificationId);

        public PartSpecificationType PerformanceSpecification => this.Cache.Get(PerformanceSpecificationId);

        public PartSpecificationType TestingRequirement => this.Cache.Get(TestingRequirementId);

        public PartSpecificationType Tolerance => this.Cache.Get(ToleranceId);

        private UniquelyIdentifiableCache<PartSpecificationType> Cache => this.cache ?? (this.cache = new UniquelyIdentifiableCache<PartSpecificationType>(this.Session));

        protected override void AppsSetup(Setup setup)
        {
            base.AppsSetup(setup);

            var englishLocale = new Locales(this.Session).EnglishGreatBritain;
            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            new PartSpecificationTypeBuilder(this.Session)
                .WithName("Poor")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Constraint Specification").WithLocale(englishLocale).Build())
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Constraint Specification").WithLocale(dutchLocale).Build())
                .WithUniqueId(ConstraintSpecificationId)
                .Build();
            
            new PartSpecificationTypeBuilder(this.Session)
                .WithName("Fair")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Operating Condition").WithLocale(englishLocale).Build())
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Operating Condition").WithLocale(dutchLocale).Build())
                .WithUniqueId(OperatingConditionId)
                .Build();
            
            new PartSpecificationTypeBuilder(this.Session)
                .WithName("Good")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Part Specification").WithLocale(englishLocale).Build())
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Part Specification").WithLocale(dutchLocale).Build())
                .WithUniqueId(PartSpecificationId)
                .Build();
            
            new PartSpecificationTypeBuilder(this.Session)
                .WithName("Outstanding")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Performance Specification").WithLocale(englishLocale).Build())
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Performance Specification").WithLocale(dutchLocale).Build())
                .WithUniqueId(PerformanceSpecificationId)
                .Build();

            new PartSpecificationTypeBuilder(this.Session)
                .WithName("Good")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Testing Requirement").WithLocale(englishLocale).Build())
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Testing Requirement").WithLocale(dutchLocale).Build())
                .WithUniqueId(TestingRequirementId)
                .Build();

            new PartSpecificationTypeBuilder(this.Session)
                .WithName("Outstanding")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Tolerance").WithLocale(englishLocale).Build())
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Tolerance").WithLocale(dutchLocale).Build())
                .WithUniqueId(ToleranceId)
                .Build();
        }
    }
}