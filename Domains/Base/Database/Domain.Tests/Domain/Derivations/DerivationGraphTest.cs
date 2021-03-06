// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivationGraphTest.cs" company="Allors bvba">
//   Copyright 2002-2016 Allors bvba.
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
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tests
{
    using System;
    using System.Collections.Generic;

    using Allors;
    using Allors.Domain;
    using Allors.Domain.NonLogging;

    using Xunit;

    public class DerivationGraphTest : DomainTest
    {
        [Fact]
        public void Sort()
        {
            var x = new C1Builder(this.Session).Build();
            var y = new C1Builder(this.Session).Build();
            var z = new C1Builder(this.Session).Build();

            x.AddDependency(y);
            y.AddDependency(z);

            var derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});

            var sequence = new List<IObject>();
            derivation["sequence"] = sequence;

            derivation.Derive();

            Assert.Equal(z, sequence[0]);
            Assert.Equal(y, sequence[1]);
            Assert.Equal(x, sequence[2]);

            Assert.Equal(1, x.DerivationCount);
            Assert.Equal(1, y.DerivationCount);
            Assert.Equal(1, z.DerivationCount);
        }

        [Fact]
        public void SortDiamond()
        {
            var a = new C1Builder(this.Session).Build();
            var b = new C1Builder(this.Session).Build();
            var c = new C1Builder(this.Session).Build();
            var d = new C1Builder(this.Session).Build();

            a.AddDependency(b);
            a.AddDependency(c);

            b.AddDependency(d);
            c.AddDependency(d);

            var derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});

            var sequence = new List<IObject>();
            derivation["sequence"] = sequence;

            derivation.Derive();

            Assert.Equal(d, sequence[0]);
            Assert.Equal(a, sequence[3]);

            Assert.Equal(1, a.DerivationCount);
            Assert.Equal(1, b.DerivationCount);
            Assert.Equal(1, c.DerivationCount);
            Assert.Equal(1, d.DerivationCount);
        }

        [Fact]
        public void Dependency()
        {
            var left = new LeftBuilder(this.Session).Build();
            var middle = new MiddleBuilder(this.Session).Build();
            var right = new RightBuilder(this.Session).Build();

            left.Middle = middle;
            middle.Right = right;

            var derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(1, left.DerivationCount);
            Assert.Equal(1, middle.DerivationCount);
            Assert.Equal(1, right.DerivationCount);

            left.Counter += 1;
            middle.Counter += 1;
            right.Counter += 1;

            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(2, left.DerivationCount);
            Assert.Equal(2, middle.DerivationCount);
            Assert.Equal(2, right.DerivationCount);

            middle.Counter += 1;
            left.Counter += 1;
            right.Counter += 1;

            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(3, left.DerivationCount);
            Assert.Equal(3, middle.DerivationCount);
            Assert.Equal(3, right.DerivationCount);

            right.Counter += 1;
            middle.Counter += 1;
            left.Counter += 1;

            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(4, left.DerivationCount);
            Assert.Equal(4, middle.DerivationCount);
            Assert.Equal(4, right.DerivationCount);

            right.Counter += 1;
            left.Counter += 1;
            middle.Counter += 1;

            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(5, left.DerivationCount);
            Assert.Equal(5, middle.DerivationCount);
            Assert.Equal(5, right.DerivationCount);

            left.Counter += 1;
            middle.Counter += 1;

            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(6, left.DerivationCount);
            Assert.Equal(6, middle.DerivationCount);
            Assert.Equal(6, right.DerivationCount);

            middle.Counter += 1;
            left.Counter += 1;

            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(7, left.DerivationCount);
            Assert.Equal(7, middle.DerivationCount);
            Assert.Equal(7, right.DerivationCount);

            right.Counter += 1;
            middle.Counter += 1;

            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(8, left.DerivationCount);
            Assert.Equal(8, middle.DerivationCount);
            Assert.Equal(8, right.DerivationCount);

            middle.Counter += 1;
            right.Counter += 1;
            
            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(9, left.DerivationCount);
            Assert.Equal(9, middle.DerivationCount);
            Assert.Equal(9, right.DerivationCount);

            middle.Counter += 1;
            
            derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            derivation.Derive();
            this.Session.Commit();

            Assert.Equal(10, left.DerivationCount);
            Assert.Equal(10, middle.DerivationCount);
            Assert.Equal(10, right.DerivationCount);
        }

        [Fact]
        public void CreateCyclicDependencyDuringDerive()
        {
            var left = new LeftBuilder(this.Session).Build();

            left.CreateMiddle = true;

            var errorThrown = false;

            var derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            try
            {
                derivation.Derive();
            }
            catch(Exception)
            {
                errorThrown = true;
            }

            Assert.True(errorThrown);

            Assert.Equal(1, left.DerivationCount);
            Assert.Equal(0, left.Middle.DerivationCount);
        }

        [Fact]
        public void NoCyclicDependencyDuringSyncCreate()
        {
            var syncRoot = new SyncRootBuilder(this.Session).Build();

            var errorThrown = false;

            var derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            try
            {
                derivation.Derive();
            }
            catch(Exception)
            {
                errorThrown = true;
            }

            Assert.False(errorThrown);

            Assert.Equal(1, syncRoot.DerivationCount);
            Assert.Equal(1, syncRoot.SyncDepth1.DerivationCount);
            Assert.Equal(1, syncRoot.SyncDepth1.SyncDepth2.DerivationCount);
        }

        [Fact]
        public void NoCyclicDependencyDuringSyncExisting()
        {
            var syncRoot = new SyncRootBuilder(this.Session).Build();
            this.Session.Derive();
            this.Session.Commit();

            var errorThrown = false;

            syncRoot.SyncDepth1.SyncDepth2.Value = 1;

            var derivation = new Derivation(this.Session, new DerivationConfig { ThrowExceptionOnCycleDetected = true});
            try
            {
                derivation.Derive();
            }
            catch(Exception)
            {
                errorThrown = true;
            }

            Assert.False(errorThrown);

            Assert.Equal(2, syncRoot.DerivationCount);
            Assert.Equal(2, syncRoot.SyncDepth1.DerivationCount);
            Assert.Equal(2, syncRoot.SyncDepth1.SyncDepth2.DerivationCount);
        }
    }
}