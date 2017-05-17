﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskAssignment.cs" company="Allors bvba">
//   Copyright 2002-2017 Allors bvba.
//
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
//
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
//
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    public partial class TaskAssignment
    {
        public void BaseOnPreDerive(ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            derivation.AddDependency(this.User.TaskList, this);
        }
        
        public void BaseOnDerive(ObjectOnDerive method)
        {
            if (!this.ExistTask)
            {
                this.Delete();
            }
            else
            {
                var singleton = Singleton.Instance(this.strategy.Session);
                this.SecurityTokens = new[] { singleton.DefaultSecurityToken, this.User?.OwnerSecurityToken };

                this.Task.ManageNotification(this);
            }
        }
    }
}
