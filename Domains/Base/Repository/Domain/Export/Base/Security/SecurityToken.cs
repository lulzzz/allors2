//------------------------------------------------------------------------------------------------- 
// <copyright file="SecurityToken.cs" company="Allors bvba">
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
    [Id("a53f1aed-0e3f-4c3c-9600-dc579cccf893")]
    #endregion
    public partial class SecurityToken : Deletable 
    {
        #region inherited properties
        #endregion

        #region Allors
        [Id("6503574b-8bab-4da8-a19d-23a9bcffe01e")]
        [AssociationId("cae9e5c2-afa1-46f4-b930-69d4e810038f")]
        [RoleId("ab2b4b9c-87dd-4712-b123-f5f9271c6193")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        public AccessControl[] AccessControls { get; set; }

        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        public void Delete(){}
        #endregion
    }
}