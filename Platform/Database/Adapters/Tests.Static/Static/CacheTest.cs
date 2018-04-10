// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheTest.cs" company="Allors bvba">
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

namespace Allors.Adapters
{
    using System;

    using Allors;

    using Domain;

    using Xunit;

    using IDatabase = IDatabase;

    public abstract class CacheTest : IDisposable
    {
        public abstract void Dispose();


        [Fact(Skip="Cache invalidation")]
        public void InitDifferentDatabase()
        {
            var database = this.CreateDatabase();
            database.Init();

            using (ISession session = database.CreateSession())
            {
                var c1 = C1.Create(session);
                c1.C1AllorsString = "a";
                session.Commit();
            }

            using (ISession session = database.CreateSession())
            {
                var c1 = session.Extent<C1>().First;
                Assert.Equal("a", c1.C1AllorsString);
            }

            database.Init();

            var database2 = this.CreateDatabase();

            using (ISession session = database.CreateSession())
            {
                var c1 = C1.Create(session);
                c1.C1AllorsString = "b";
                session.Commit();
            }

            using (ISession session = database2.CreateSession())
            {
                var c1 = session.Extent<C1>().First;
                c1.C1AllorsString = "c";
            }

            using (ISession session = database.CreateSession())
            {
                var c1 = session.Extent<C1>().First;
                Assert.Equal("c", c1.C1AllorsString);
            }
        }
        
        [Fact]
        public void FlushCacheOnInit()
        {
            var database = this.CreateDatabase();
            database.Init();

            using (ISession session = database.CreateSession())
            {
                var c1a = C1.Create(session);
                var c2a = C2.Create(session);
                c1a.C1C2one2one = c2a;
                session.Commit();

                // load cache
                c2a = c1a.C1C2one2one;
            }
            
            database.Init();

            using (ISession session = database.CreateSession())
            {
                var c1a = C1.Create(session);
                var c1b = C1.Create(session);

                session.Commit();

                c1a = C1.Instantiate(session, c1a.Id);

                Assert.Null(c1a.C1C2one2one);
            }
        }

        [Fact]
        public void CacheUnitRole()
        {
            var database = this.CreateDatabase();
            database.Init();

            using (var session = database.CreateSession())
            {
                var c1 = C1.Create(session);
                c1.C1AllorsString = "Test";
                
                session.Commit();

            }
        }


        [Fact]
        public void FailedCommit()
        {
            var database = this.CreateDatabase();
            database.Init();

            long c1Id = 0;
            long c2Id = 0;

            using (var session = database.CreateSession())
            {
                var c1 = C1.Create(session);
                var c2 = C2.Create(session);

                c1Id = c1.Id;
                c2Id = c2.Id;

                c1.C1C2one2one = c2;

                session.Commit();

                c1.C1AllorsString = "Session 1";
                
                using (var session2 = database.CreateSession())
                {
                    var session2C1 = (C1)session2.Instantiate(c1);
                    session2C1.C1AllorsString = "Session 2";

                    session2C1.C1C2one2one = null;

                    session2.Commit();

                    var session2C2 = (C2)session2.Instantiate(c2);
                    session2C2.Strategy.Delete();

                    session2.Commit();
                }

                var triggerCache = c1.C1C2one2one;

                var exceptionThrown = false;
                try
                {
                    session.Commit();
                }
                catch(Exception e)
                {
                    exceptionThrown = true;
                }

                Assert.True(exceptionThrown);
            }
            
            using (var session = database.CreateSession())
            {
                var c1 = (C1)session.Instantiate(c1Id);
                var c2 = session.Instantiate(c2Id);
 
                Assert.Null(c1.C1C2one2one);
            }
        }


        protected abstract IDatabase CreateDatabase();
    }
}