// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssociationInstanceOf.cs" company="Allors bvba">
//   Copyright 2002-2013 Allors bvba.
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

namespace Allors.Adapters.Database.Sql
{
    using Allors.Meta;

    public sealed class AssociationInstanceOf : Predicate
    {
        private readonly IAssociationType association;
        private readonly IObjectType[] instanceClasses;

        public AssociationInstanceOf(ExtentFiltered extent, IAssociationType association, IObjectType instanceType, IObjectType[] instanceClasses)
        {
            extent.CheckAssociation(association);
            CompositePredicateAssertions.ValidateAssociationInstanceof(association, instanceType);
            this.association = association;
            this.instanceClasses = instanceClasses;
        }

        public override bool BuildWhere(ExtentStatement statement, string alias)
        {
            var schema = statement.Schema;
            if (this.instanceClasses.Length == 1)
            {
                statement.Append(" (" + statement.GetJoinName(this.association) + "." + schema.TypeId + " IS NOT NULL AND ");
                statement.Append(" " + statement.GetJoinName(this.association) + "." + schema.TypeId + "=" + statement.AddParameter(this.instanceClasses[0].Id) + ") ");
            }
            else if (this.instanceClasses.Length > 1)
            {
                statement.Append(" ( ");
                for (var i = 0; i < this.instanceClasses.Length; i++)
                {
                    statement.Append(" (" + statement.GetJoinName(this.association) + "." + schema.TypeId + " IS NOT NULL AND ");
                    statement.Append(" " + statement.GetJoinName(this.association) + "." + schema.TypeId + "=" + statement.AddParameter(this.instanceClasses[i].Id) + ")");
                    if (i < this.instanceClasses.Length - 1)
                    {
                        statement.Append(" OR ");
                    }
                }

                statement.Append(" ) ");
            }

            return this.Include;
        }

        public override void Setup(ExtentStatement statement)
        {
            statement.UseAssociation(this.association);
            statement.UseAssociationInstance(this.association);
        }
    }
}