// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriceComponentExtensions.cs" company="Allors bvba">
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

using System.Linq;
using System.Runtime.CompilerServices;

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using Meta;

    public static class PriceComponentExtensions
    {
        public static void AppsOnDerive(this PriceComponent @this, ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            var internalOrganisations = new Organisations(@this.Strategy.Session).Extent().Where(v => Equals(v.IsInternalOrganisation, true)).ToArray();

            if (!@this.ExistPricedBy && internalOrganisations.Count() == 1)
            {
                @this.PricedBy = internalOrganisations.First();
            }
        }
    }
}