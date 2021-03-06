// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactMechanism.cs" company="Allors bvba">
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
    public partial interface ContactMechanism
    {
        bool IsPostalAddress { get; }
    }

    public static partial class ContactMechanismExtensions
    {
        public static void AppsOnPreDerive(this ContactMechanism @this, ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            foreach (PartyContactMechanism partyContactMechanism in @this.PartyContactMechanismsWhereContactMechanism)
            {
                derivation.AddDependency(partyContactMechanism, @this);
            }
        }

        public static void AppsDelete(this ContactMechanism @this, DeletableDelete method)
        {
            foreach (PartyContactMechanism partyContactMechanism in @this.PartyContactMechanismsWhereContactMechanism)
            {
                partyContactMechanism.Delete();
            }
        }
    }
}