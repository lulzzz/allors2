// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Model.cs" company="Allors bvba">
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

namespace Allors.Domain.Print.WorkTaskModel
{
    using System.Linq;

    public class Model
    {
        public Model(WorkTask workTask)
        {
            this.WorkTask = new WorkTaskModel(workTask);
            this.Customer = new CustomerModel(workTask.Customer);
            this.TimeEntries = workTask.ServiceEntriesWhereWorkEffort.OfType<TimeEntry>().Select(v => new TimeEntryModel(v)).ToArray();
            this.InventoryAssignments = workTask.WorkEffortInventoryAssignmentsWhereAssignment.Select(v => new InventoryAssignmentModel(v)).ToArray();
        }
        public WorkTaskModel WorkTask { get; }

        public CustomerModel Customer { get; }

        public TimeEntryModel[] TimeEntries { get; }

        public InventoryAssignmentModel[] InventoryAssignments { get; }
    }
}
