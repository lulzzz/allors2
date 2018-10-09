//-------------------------------------------------------------------------------------------------
// <copyright file="PullInstantiate.cs" company="Allors bvba">
// Copyright 2002-2017 Allors bvba.
//
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
//
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
//
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// For more information visit http://www.allors.com/legal
// </copyright>
// <summary>Defines the ISessionExtension type.</summary>
//-------------------------------------------------------------------------------------------------

namespace Allors.Server
{
    using System.Linq;

    using Allors.Data;
    using Allors.Domain;
    using Allors.Services;

    public class PullInstantiate
    {
        private readonly ISession session;

        private readonly Pull pull;

        private readonly User user;

        private readonly IFetchService fetchService;

        public PullInstantiate(ISession session, Pull pull, User user, IFetchService fetchService)
        {
            this.session = session;
            this.pull = pull;
            this.user = user;
            this.fetchService = fetchService;
        }

        public void Execute(PullResponseBuilder response)
        {
            var @object = this.session.Instantiate(this.pull.Object);

            if (this.pull.Results != null)
            {
                foreach (var result in this.pull.Results)
                {
                    var name = result.Name;

                    var fetch = result.Fetch;
                    if (fetch == null && result.FetchRef.HasValue)
                    {
                        fetch = this.fetchService.Get(result.FetchRef.Value);
                    }

                    if (fetch != null)
                    {
                        var include = fetch.Include ?? fetch.Step?.End.Include;

                        if (fetch.Step != null)
                        {
                            var aclCache = new AccessControlListCache(this.user);

                            var propertyType = fetch.Step.End.PropertyType;

                            if (propertyType.IsOne)
                            {
                                name = name ?? propertyType.SingularName;

                                @object = (IObject)fetch.Step.Get(@object, aclCache);
                                response.AddObject(name, @object, include);
                            }
                            else
                            {
                                name = name ?? propertyType.PluralName;

                                var objects = ((Extent)fetch.Step.Get(@object, aclCache)).ToArray();

                                if (result.Skip.HasValue || result.Take.HasValue)
                                {
                                    var paged = result.Skip.HasValue ? objects.Skip(result.Skip.Value) : objects;
                                    if (result.Take.HasValue)
                                    {
                                        paged = paged.Take(result.Take.Value);
                                    }

                                    paged = paged.ToArray();

                                    response.AddValue(name + "_total", objects.Length);
                                    response.AddCollection(name, paged, include);
                                }
                                else
                                {
                                    response.AddCollection(name, objects, include);
                                }
                            }
                        }
                        else
                        {
                            name = name ?? @object.Strategy.Class.SingularName;
                            response.AddObject(name, @object, include);
                        }
                    }
                    else
                    {
                        name = name ?? @object.Strategy.Class.SingularName;
                        response.AddObject(name, @object);
                    }
                }
            }
            else
            {
                var name = @object.Strategy.Class.SingularName;
                response.AddObject(name, @object);
            }
        }
    }
}