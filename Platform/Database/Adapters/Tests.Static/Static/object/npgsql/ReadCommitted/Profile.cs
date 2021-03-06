// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="Allors bvba">
//   Copyright 2002-2010 Allors bvba.
// Dual Licensed under
//   a) the Lesser General Public Licence v3 (LGPL)
//   b) the Allors License
// The LGPL License is included in the file lgpl.txt.
// The Allors License is an addendum to your contract.
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Adapters.Object.Npgsql.ReadCommitted
{
    using System;
    using System.Collections.Generic;

    using Allors.Adapters.Database.Npgsql.LongId;
    using Allors.Meta;

    using Microsoft.Extensions.DependencyInjection;

    public class Profile : Npgsql.Profile
    {
        public Profile()
        {
            var services = new ServiceCollection();
            this.ServiceProvider = services.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; set; }

        public override Action[] Markers
        {
            get
            {
                var markers = new List<Action> 
                { 
                    () => { }, 
                    () => this.Session.Commit(), 
                };

                return markers.ToArray();
            }
        }

        protected string ConnectionString => "Server=localhost; User Id=allors; Password=allors; Database=adapters; Pooling=false; Timeout=300; CommandTimeout=300";
        
        public IDatabase CreateDatabase(IMetaPopulation metaPopulation, bool init)
        {
            var configuration = new Adapters.Database.Npgsql.LongId.Configuration
            {
                ObjectFactory = this.ObjectFactory,
                Id = Guid.NewGuid(),
                ConnectionString = this.ConnectionString
            };

            var database = new Database(this.ServiceProvider, configuration);

            if (init)
            {
                database.Init();
            }

            return database;
        }

        public override IDatabase CreateDatabase()
        {
            var configuration = new Adapters.Database.Npgsql.LongId.Configuration
            {
                ObjectFactory = this.ObjectFactory,
                Id = Guid.NewGuid(),
                ConnectionString = this.ConnectionString
            };

            var database = new Database(this.ServiceProvider, configuration);

            return database;
        }
        
        public override IDatabase CreatePopulation()
        {
            return new Memory.Database(this.ServiceProvider, new Memory.Configuration { ObjectFactory = this.ObjectFactory });
        }
    }
}