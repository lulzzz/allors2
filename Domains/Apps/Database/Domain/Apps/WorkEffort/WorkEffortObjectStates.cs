// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkEffortObjectStates.cs" company="Allors bvba">
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

    public partial class WorkEffortObjectStates
    {
        private static readonly Guid NeedsActionId = new Guid("0D2618A7-A3B7-40f5-88C4-30DADE4D5164");
        private static readonly Guid ConfirmedId = new Guid("61E5FCB6-7814-4FED-8CE7-28C26EB88EE6");
        private static readonly Guid DeclinedId = new Guid("0DFFC51A-4982-4DDA-808B-8F70D46F2749");
        private static readonly Guid CompletedId = new Guid("E8E941CD-7175-4931-AB1E-50E52DC6D720");
        private static readonly Guid CancelledId = new Guid("D3EBD54F-35B0-4bc4-AC8E-4EC583028B0A");
        private static readonly Guid DelegatedId = new Guid("0EB0E562-5094-4F48-AAAC-EF5DF239CF07");
        private static readonly Guid InPlanningId = new Guid("007B3B09-218D-4898-AE32-A78FAEFA097E");
        private static readonly Guid PlannedId = new Guid("E120D688-150C-4B19-BD7B-28A6D7617599");
        private static readonly Guid SentId = new Guid("5A0A160B-9A48-47A1-A0E9-07A84F0A3F95");
        private static readonly Guid AcceptedId = new Guid("09148AB2-28B4-4A84-B403-17884149156C");
        private static readonly Guid TentativeId = new Guid("A2FAAC53-49EC-45F4-84F3-10C9558A366E");

        private UniquelyIdentifiableCache<WorkEffortObjectState> stateCache;

        public WorkEffortObjectState NeedsAction => this.StateCache.Get(NeedsActionId);

        public WorkEffortObjectState Confirmed => this.StateCache.Get(ConfirmedId);

        public WorkEffortObjectState InProgress => this.StateCache.Get(DeclinedId);

        public WorkEffortObjectState Completed => this.StateCache.Get(CompletedId);

        public WorkEffortObjectState Cancelled => this.StateCache.Get(CancelledId);

        public WorkEffortObjectState Delagated => this.StateCache.Get(DelegatedId);

        public WorkEffortObjectState InPlanning => this.StateCache.Get(InPlanningId);

        public WorkEffortObjectState Planned => this.StateCache.Get(PlannedId);

        public WorkEffortObjectState Sent => this.StateCache.Get(SentId);

        public WorkEffortObjectState Accepted => this.StateCache.Get(AcceptedId);

        public WorkEffortObjectState Tentative => this.StateCache.Get(TentativeId);

        private UniquelyIdentifiableCache<WorkEffortObjectState> StateCache => this.stateCache ?? (this.stateCache = new UniquelyIdentifiableCache<WorkEffortObjectState>(this.Session));

        protected override void AppsSetup(Setup setup)
        {
            base.AppsSetup(setup);

            var englishLocale = new Locales(this.Session).EnglishGreatBritain;
            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(NeedsActionId)
                .WithName("NeedsAction")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(ConfirmedId)
                .WithName("Confirmed")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(DeclinedId)
                .WithName("Declined")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(CompletedId)
                .WithName("Completed")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(CancelledId)
                .WithName("Cancelled")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(DelegatedId)
                .WithName("Delegated")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(InPlanningId)
                .WithName("In planning")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(PlannedId)
                .WithName("Planned")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(SentId)
                .WithName("Sent")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(AcceptedId)
                .WithName("Accepted")
                .Build();

            new WorkEffortObjectStateBuilder(this.Session)
                .WithUniqueId(TentativeId)
                .WithName("Tentative")
                .Build();
        }
    }
}