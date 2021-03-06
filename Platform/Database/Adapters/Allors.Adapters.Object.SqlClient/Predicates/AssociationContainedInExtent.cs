// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssociationContainedInExtent.cs" company="Allors bvba">
//   Copyright 2002-2017 Allors bvba.
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

namespace Allors.Adapters.Object.SqlClient
{
    using Adapters;

    using Meta;

    internal sealed class AssociationContainedInExtent : In
    {
        private readonly IAssociationType association;
        private readonly SqlExtent inExtent;

        internal AssociationContainedInExtent(ExtentFiltered extent, IAssociationType association, Allors.Extent inExtent)
        {
            extent.CheckAssociation(association);
            PredicateAssertions.AssertAssociationContainedIn(association, inExtent);
            this.association = association;
            this.inExtent = ((Extent)inExtent).ContainedInExtent;
        }

        internal override bool BuildWhere(ExtentStatement statement, string alias)
        {
            var schema = statement.Mapping;
            var inStatement = statement.CreateChild(this.inExtent, this.association);

            inStatement.UseRole(this.association.RoleType);

            if ((this.association.IsMany && this.association.RoleType.IsMany) || !this.association.RelationType.ExistExclusiveClasses)
            {
                statement.Append(" (" + this.association.SingularFullName + "_A." + Mapping.ColumnNameForAssociation + " IS NOT NULL AND ");
                statement.Append(" " + this.association.SingularFullName + "_A." + Mapping.ColumnNameForAssociation + " IN (\n");
                this.inExtent.BuildSql(inStatement);
                statement.Append(" ))\n");
            }
            else
            {
                if (this.association.RoleType.IsMany)
                {
                    statement.Append(" (" + alias + "." + schema.ColumnNameByRelationType[this.association.RelationType] + " IS NOT NULL AND ");
                    statement.Append(" " + alias + "." + schema.ColumnNameByRelationType[this.association.RelationType] + " IN (\n");
                    this.inExtent.BuildSql(inStatement);
                    statement.Append(" ))\n");
                }
                else
                {
                    statement.Append(" (" + this.association.SingularFullName + "_A." + Mapping.ColumnNameForObject + " IS NOT NULL AND ");
                    statement.Append(" " + this.association.SingularFullName + "_A." + Mapping.ColumnNameForObject + " IN (\n");
                    this.inExtent.BuildSql(inStatement);
                    statement.Append(" ))\n");
                }
            }

            return this.Include;
        }

        internal override void Setup(ExtentStatement statement)
        {
            statement.UseAssociation(this.association);
        }
    }
}