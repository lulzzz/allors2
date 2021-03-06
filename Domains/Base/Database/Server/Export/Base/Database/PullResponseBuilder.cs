﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PullResponseBuilder.cs" company="Allors bvba">
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

namespace Allors.Server
{
    using System.Collections.Generic;
    using System.Linq;

    using Allors.Data;
    using Allors.Server.Protocol;
    using Allors.Server.Protocol.Pull;

    using Domain;
    using Meta;

    public class PullResponseBuilder
    {
        private static readonly IObject[] EmptyArray = new IObject[0];
        private readonly User user;

        private readonly HashSet<IObject> objects = new HashSet<IObject>();
        private readonly Dictionary<string, IObject> objectByName = new Dictionary<string, IObject>();
        private readonly Dictionary<string, List<IObject>> collectionsByName = new Dictionary<string, List<IObject>>();
        private readonly Dictionary<string, object> valueByName = new Dictionary<string, object>();

        public PullResponseBuilder(User user)
        {
            this.user = user;
        }

        public PullResponse Build()
        {
            return new PullResponse
            {
                UserSecurityHash = this.user.SecurityHash(),
                Objects = this.objects.Select(x => new[] {x.Id.ToString(), x.Strategy.ObjectVersion.ToString()}).ToArray(),
                NamedObjects = this.objectByName.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Id.ToString()),
                NamedCollections = this.collectionsByName.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Select(obj => obj.Id.ToString()).ToArray()),
                NamedValues = this.valueByName,
            };
        }

        public void AddObject(string name, IObject @object, bool full = false)
        {
            if (@object != null)
            {
                Tree tree = null;
                if (full)
                {
                    tree = @object.Strategy.Session.Database.FullTree(@object.Strategy.Class);
                }

                this.AddObject(name, @object, tree);
            }
        }

        public void AddObject(string name, IObject @object, Tree tree)
        {
            if (@object != null)
            {
                if (tree != null)
                {
                    // Prefetch
                    var session = @object.Strategy.Session;
                    var prefetcher = tree.BuildPrefetchPolicy();
                    session.Prefetch(prefetcher, @object);
                }

                this.objects.Add(@object);
                this.objectByName.Add(name, @object);
                tree?.Resolve(@object, this.objects);
            }
        }

        public void AddCollection(string name, IEnumerable<IObject> collection, bool full = false)
        {
            var inputList = (collection as IList<IObject>) ?? collection?.ToArray() ?? EmptyArray;

            Tree tree = null;
            if (full && inputList.Count > 0)
            {
                var @object = inputList.FirstOrDefault();
                tree = @object?.Strategy.Session.Database.FullTree(@object.Strategy.Class);
            }

            this.AddCollection(name, inputList, tree);
        }

        public void AddCollection(string name, IEnumerable<IObject> collection, Tree tree)
        {
            if (collection != null)
            {
                if (!this.collectionsByName.TryGetValue(name, out var list))
                {
                    list = new List<IObject>();
                    this.collectionsByName.Add(name, list);
                }

                var inputList = collection as IList<IObject> ?? collection.ToArray();
                
                // Prefetch
                if (tree != null && inputList.Count > 0)
                {
                    var session = inputList[0].Strategy.Session;
                    var prefetcher = tree.BuildPrefetchPolicy();
                    session.Prefetch(prefetcher, inputList.ToArray());
                }

                list.AddRange(inputList);
                foreach (var namedObject in inputList)
                {
                    this.objects.Add(namedObject);
                    tree?.Resolve(namedObject, this.objects);
                }
            }
        }

        public void AddValue(string name, object value)
        {
            if (value != null)
            {
                this.valueByName.Add(name, value);
            }
        }
    }
}