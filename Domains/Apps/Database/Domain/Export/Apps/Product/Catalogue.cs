// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Catalogue.cs" company="Allors bvba">
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
    using System.Collections.Generic;
    using System.Linq;

    using Meta;
    using Resources;

    public partial class Catalogue
    {
        public void AppsOnBuild(ObjectOnBuild method)
        {
            if (!this.ExistCatScope)
            {
                this.CatScope = new CatScopes(this.strategy.Session).Public;
            }
        }

        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;
            var defaultLocale = this.strategy.Session.GetSingleton().DefaultLocale;

            if (this.LocalisedNames.Any(x => x.Locale.Equals(defaultLocale)))
            {
                this.Name = this.LocalisedNames.First(x => x.Locale.Equals(defaultLocale)).Text;
            }

            if (this.LocalisedDescriptions.Any(x => x.Locale.Equals(defaultLocale)))
            {
                this.Description = this.LocalisedDescriptions.First(x => x.Locale.Equals(defaultLocale)).Text;
            }

            if (!this.ExistCatalogueImage)
            {
                this.CatalogueImage = this.strategy.Session.GetSingleton().Settings.NoImageAvailableImage;
            }
        }
    }
}