// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Carriers.cs" company="Allors bvba">
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

    public partial class Carriers
    {
        public static readonly Guid GlsId = new Guid("69C1CD1D-4D4E-4F2D-AF3C-4E1F740C7F62");
        public static readonly Guid UpsId = new Guid("74331516-5A0E-48F5-9166-75CC53E8B25D");
        public static readonly Guid FedexId = new Guid("D626E669-6AA9-40D1-B18B-5B06564C59A4");
        public static readonly Guid DhlId = new Guid("4901794C-B611-4DE4-8613-183B1C08E0AD");

        private UniquelyIdentifiableCache<Carrier> cache;

        public Carrier Gls => this.Cache.Get(GlsId);

        public Carrier Ups => this.Cache.Get(UpsId);

        public Carrier Fedex => this.Cache.Get(FedexId);

        public Carrier Dhl => this.Cache.Get(DhlId);

        private UniquelyIdentifiableCache<Carrier> Cache => this.cache ?? (this.cache = new UniquelyIdentifiableCache<Carrier>(this.Session));

        protected override void AppsSetup(Setup setup)
        {
            base.AppsSetup(setup);

            new CarrierBuilder(this.Session).WithName("GLS").WithUniqueId(GlsId).Build();
            new CarrierBuilder(this.Session).WithName("UPS").WithUniqueId(UpsId).Build();
            new CarrierBuilder(this.Session).WithName("FEDEX").WithUniqueId(FedexId).Build();
            new CarrierBuilder(this.Session).WithName("DHL").WithUniqueId(DhlId).Build();
        }
    }
}