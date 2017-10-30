// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheService.cs" company="Allors bvba">
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

namespace Allors.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class CacheService : ICacheService
    {
        private ConcurrentDictionary<Type, object> caches;

        public CacheService(IStateService stateService)
        {
            this.Clear();
            stateService.Register(this);
        }

        public IDictionary<long, T> Get<T>(Type type)
        {
            if (this.caches.TryGetValue(type, out var cache))
            {
                return (IDictionary<long, T>)cache;
            }

            return null;
        }

        public void Set<T>(Type type, IDictionary<long, T> value)
        {
            this.caches[type] = value;
        }

        public void Clear()
        {
            this.caches = new ConcurrentDictionary<Type, object>();
        }
    }
}