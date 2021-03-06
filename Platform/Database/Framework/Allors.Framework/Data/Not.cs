//------------------------------------------------------------------------------------------------- 
// <copyright file="Not.cs" company="Allors bvba">
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

namespace Allors.Data
{
    using System.Collections.Generic;

    using Allors.Data.Protocol;

    public class Not : ICompositePredicate
    {
        public Not(IPredicate operand = null)
        {
            this.Operand = operand;
        }

        public IPredicate Operand { get; set; }

        bool IPredicate.ShouldTreeShake(IReadOnlyDictionary<string, object> arguments) => this.Operand == null || this.Operand.ShouldTreeShake(arguments);

        bool IPredicate.HasMissingArguments(IReadOnlyDictionary<string, object> arguments) => this.Operand != null && this.Operand.HasMissingArguments(arguments);

        void IPredicateContainer.AddPredicate(IPredicate predicate)
        {
            this.Operand = predicate;
        }

        public Predicate Save()
        {
            return new Predicate()
            {
                Kind = PredicateKind.Not,
                Operand = this.Operand?.Save()
            };
        }

        void IPredicate.Build(ISession session, IReadOnlyDictionary<string, object> arguments, Allors.ICompositePredicate compositePredicate)
        {
            var not = compositePredicate.AddNot();

            if (this.Operand != null && !this.Operand.ShouldTreeShake(arguments))
            {
                this.Operand?.Build(session, arguments, not);
            }
        }
    }
}