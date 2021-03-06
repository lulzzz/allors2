// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerialisedInventoryItemState.cs" company="Allors bvba">
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
    using Meta;

    public partial class SerialisedInventoryItemState
    {
        public bool IsGood => this.Equals(new SerialisedInventoryItemStates(this.strategy.Session).Good);

        public bool IsBeingRepaired => this.Equals(new SerialisedInventoryItemStates(this.strategy.Session).BeingRepaired);

        public bool IsSlightlyDamaged => this.Equals(new SerialisedInventoryItemStates(this.strategy.Session).SlightlyDamaged);

        public bool IsDefective => this.Equals(new SerialisedInventoryItemStates(this.strategy.Session).Defective);

        public bool IsScrap => this.Equals(new SerialisedInventoryItemStates(this.strategy.Session).Scrap);

        public bool IsAvailable => this.Equals(new SerialisedInventoryItemStates(this.strategy.Session).Available);

        public bool IsAssigned => this.Equals(new SerialisedInventoryItemStates(this.strategy.Session).Assigned);
    }
}