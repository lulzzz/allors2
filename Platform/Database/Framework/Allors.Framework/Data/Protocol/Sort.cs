//------------------------------------------------------------------------------------------------- 
// <copyright file="Sort.cs" company="Allors bvba">
// Copyright 2002-2017 Allors bvba.
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
//-------------------------------------------------------------------------------------------------

namespace Allors.Data.Protocol
{
    using System;

    using Allors.Meta;

    public class Sort
    {
        public Guid? RoleType { get; set; }

        public bool Descending { get; set; }

        public Data.Sort Load(ISession session)
        {
            return new Data.Sort
            {
                Descending = this.Descending,
                RoleType = this.RoleType != null ? (IRoleType)session.Database.ObjectFactory.MetaPopulation.Find(this.RoleType.Value) : null
            };
        }
    }
}