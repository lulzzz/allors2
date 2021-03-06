// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// 
// Dual Licensed under
//   a) the Lesser General Public Licence v3 (LGPL)
//   b) the Allors License
// 
// The LGPL License is included in the file lgpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Adapters.Memory
{
    using System;
    using System.Collections.Generic;

    using Adapters;

    using Microsoft.Extensions.DependencyInjection;

    public class Profile : Adapters.Profile
    {
        public Profile()
        {
            var services = new ServiceCollection();
            this.ServiceProvider = services.BuildServiceProvider();
        }

        public override Action[] Markers
        {
            get
            {
                var markers = new List<Action> 
                { 
                    () => { }, 
                    () => this.Session.Commit() 
                };

                if (Settings.ExtraMarkers)
                {
                    markers.Add(
                        () =>
                        {
                            this.Session.Checkpoint();
                        });
                }

                return markers.ToArray();
            }
        }

        public ServiceProvider ServiceProvider { get; set; }

        public override IDatabase CreatePopulation()
        {
            return this.CreateDatabase();
        }

        public override IDatabase CreateDatabase()
        {
            return new Database(this.ServiceProvider, new Configuration { ObjectFactory = this.ObjectFactory });
        }
    }
}