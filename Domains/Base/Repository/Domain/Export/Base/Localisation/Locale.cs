//------------------------------------------------------------------------------------------------- 
// <copyright file="Locale.cs" company="Allors bvba">
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
    [Id("45033ae6-85b5-4ced-87ce-02518e6c27fd")]
    #endregion
    public partial class Locale : AccessControlledObject 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("2a2c6f77-e6a2-4eab-bfe3-5d35a8abd7f7")]
        [AssociationId("09422255-fa17-41d8-991b-d21d7b37c6c5")]
        [RoleId("647db2b3-997b-4c3a-9ae2-d49b410933c1")]
        [Size(256)]
        #endregion
        [Workspace]
        public string Name { get; set; }

        #region Allors
        [Id("d8cac34a-9bb2-4190-bd2a-ec0b87e04cf5")]
        [AssociationId("af501892-3c83-41d1-826b-f5c4cb1de7fe")]
        [RoleId("ed32b12a-00ad-420b-9dfa-f1c6ce773fcd")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]
        [Workspace]
        public Language Language { get; set; }
        
        #region Allors
        [Id("ea778b77-2929-4ab4-ad99-bf2f970401a9")]
        [AssociationId("bb5904f5-feb0-47eb-903a-0351d55f0d8c")]
        [RoleId("b2fc6e06-3881-427e-b4cc-8457a65f8076")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]
        [Workspace]
        public Country Country { get; set; }
        
        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        #endregion
    }
}