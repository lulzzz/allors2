// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Allors bvba">
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

namespace Allors.Domain.Query
{
    using System.Collections.Generic;
    using System.Text;

    public class QueryValidation
    {
        private readonly Query query;
        private readonly List<string> errors;

        internal QueryValidation(Query query)
        {
            this.query = query;
            this.errors = new List<string>();
        }

        public bool HasErrors => this.errors.Count > 0;

        public override string ToString()
        {
            var toString = new StringBuilder($"Query {this.query.Name} has {this.errors.Count} errors.");

            foreach (var error in this.errors)
            {
                toString.Append($"\n{error}");
            }

            return toString.ToString();
        }

        public void AddError(string error)
        {
            this.errors.Add(error);
        }
    }
}