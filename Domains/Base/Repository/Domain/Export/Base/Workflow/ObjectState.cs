//------------------------------------------------------------------------------------------------- 
// <copyright file="ObjectState.cs" company="Allors bvba">
// Copyright 2002-2016 Allors bvba.
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
// <summary>Defines the Extent type.</summary>
//-------------------------------------------------------------------------------------------------

namespace Allors.Repository
{
    using Attributes;

    #region Allors
    [Id("f991813f-3146-4431-96d0-554aa2186887")]
    #endregion
    public partial interface ObjectState : UniquelyIdentifiable 
    {
        #region Allors
        [Id("59338f0b-40e7-49e8-ba1a-3ecebf96aebe")]
        [AssociationId("fca0f3f6-bdd6-4405-93b3-35dd769bff0e")]
        [RoleId("c338f087-559c-4239-9c6a-1f691e58ed16")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        Permission[] DeniedPermissions { get; set; }

        #region Allors
        [Id("b86f9e42-fe10-4302-ab7c-6c6c7d357c39")]
        [AssociationId("052ec640-3150-458a-99d5-0edce6eb6149")]
        [RoleId("945cbba6-4b09-4b87-931e-861b147c3823")]
        #endregion
        [Workspace]
        [Indexed]
        [Size(256)]
        string Name { get; set; }
    }
}