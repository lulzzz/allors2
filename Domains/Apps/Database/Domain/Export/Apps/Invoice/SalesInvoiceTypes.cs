// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SalesInvoiceTypes.cs" company="Allors bvba">
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

    public partial class SalesInvoiceTypes
    {
        private static readonly Guid SalesInvoiceId = new Guid("92411BF1-835E-41f8-80AF-6611EFCE5B32");
        private static readonly Guid CreditNoteId = new Guid("EF5B7C52-E782-416D-B46F-89C8C7A5C24D");
        private static readonly Guid InterestId = new Guid("D1FB37DF-39C9-4212-8EAB-5B0D540EF5E3");

        private UniquelyIdentifiableSticky<SalesInvoiceType> cache;

        public SalesInvoiceType SalesInvoice => this.Cache[SalesInvoiceId];

        public SalesInvoiceType CreditNote => this.Cache[CreditNoteId];

        public SalesInvoiceType Interest => this.Cache[InterestId];

        private UniquelyIdentifiableSticky<SalesInvoiceType> Cache => this.cache ?? (this.cache = new UniquelyIdentifiableSticky<SalesInvoiceType>(this.Session));

        protected override void AppsSetup(Setup setup)
        {
            base.AppsSetup(setup);
           
            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            new SalesInvoiceTypeBuilder(this.Session)
                .WithName("Sales invoice")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Verkoop factuur").WithLocale(dutchLocale).Build())
                .WithUniqueId(SalesInvoiceId)
                .WithIsActive(true)
                .Build();
            
            new SalesInvoiceTypeBuilder(this.Session)
                .WithName("Credit Note")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Credit Nota").WithLocale(dutchLocale).Build())
                .WithUniqueId(CreditNoteId)
                .WithIsActive(true)
                .Build();
            
            new SalesInvoiceTypeBuilder(this.Session)
                .WithName("Interest")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Interest").WithLocale(dutchLocale).Build())
                .WithUniqueId(InterestId)
                .WithIsActive(true)
                .Build();
        }
    }
}
