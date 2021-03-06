// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivationBase.cs" company="Allors bvba">
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

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Allors;
    using Allors.Meta;

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Allors Object")]
    public abstract class DerivationBase : IDerivation
    {
        private readonly Dictionary<long, ISet<RelationType>> relationsByMarkedAsModified;
        private readonly HashSet<Object> derivedObjects;
        
        private Dictionary<string, object> properties;

        private IValidation validation;

        private int generation;
        private DerivationGraphBase derivationGraph;
        private HashSet<IObject> addedDerivables;

        protected DerivationBase(ISession session, DerivationConfig config)
        {
            this.Config = config ?? new DerivationConfig();

            this.Id = Guid.NewGuid();
            this.TimeStamp = session.Now();

            this.Session = session;

            this.relationsByMarkedAsModified = new Dictionary<long, ISet<RelationType>>();
            this.derivedObjects = new HashSet<Object>();

            this.ChangeSet = session.Checkpoint();

            this.generation = 0;
        }

        public DerivationConfig Config { get; }

        public Guid Id { get; }

        public DateTime TimeStamp { get; }

        public ISession Session { get; }

        public IValidation Validation
        {
            get => this.validation;

            protected set => this.validation = value;
        }

        public IChangeSet ChangeSet { get; private set; }

        public ISet<Object> DerivedObjects => this.derivedObjects;

        public int Generation => this.generation;

        public object this[string name]
        {
            get
            {
                var lowerName = name.ToLowerInvariant();

                if (this.properties != null && this.properties.TryGetValue(lowerName, out var value))
                {
                    return value;
                }

                return null;
            }

            set
            {
                var lowerName = name.ToLowerInvariant();

                if (value == null)
                {
                    if (this.properties != null)
                    {
                        this.properties.Remove(lowerName);
                        if (this.properties.Count == 0)
                        {
                            this.properties = null;
                        }
                    }
                }
                else
                {
                    if (this.properties == null)
                    {
                        this.properties = new Dictionary<string, object>();
                    }

                    this.properties[lowerName] = value;
                }
            }
        }

        public bool IsModified(Object @object)
        {
            return this.IsMarkedAsModified(@object) || this.IsCreated(@object) || this.HasChangedRoles(@object);
        }

        public bool IsModified(Object @object, RelationKind kind)
        {
            return this.IsMarkedAsModified(@object) || this.IsCreated(@object) || this.HasChangedRoles(@object, kind);
        }

        public bool IsCreated(Object derivable)
        {
            return this.ChangeSet.Created.Contains(derivable.Id);
        }

        public bool HasChangedRole(Object derivable, RoleType roleType)
        {
            this.ChangeSet.RoleTypesByAssociation.TryGetValue(derivable.Id, out var changedRoleTypes);
            return changedRoleTypes?.Contains(roleType) ?? false;
        }

        public bool HasChangedRoles(Object derivable, params RoleType[] roleTypes)
        {
            this.ChangeSet.RoleTypesByAssociation.TryGetValue(derivable.Id, out var changedRoleTypes);
            if (changedRoleTypes != null)
            {
                if (roleTypes.Length == 0 || roleTypes.Any(roleType => changedRoleTypes.Contains(roleType)))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasChangedRoles(Object derivable, RelationKind relationKind)
        {
            Func<IRoleType, bool> check;
            switch (relationKind)
            {
                case RelationKind.Regular:
                    check = (roleType) => !roleType.RelationType.IsDerived && !roleType.RelationType.IsSynced;
                    break;

                case RelationKind.Derived:
                    check = (roleType) => roleType.RelationType.IsDerived;
                    break;

                case RelationKind.Synced:
                    check = (roleType) => roleType.RelationType.IsSynced;
                    break;
                
                default:
                    check = (roleType) => true;
                    break;
            }

            this.ChangeSet.RoleTypesByAssociation.TryGetValue(derivable.Id, out var changedRoleTypes);
            if (changedRoleTypes != null)
            {
                if (changedRoleTypes.Any(roleType => check(roleType)))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasChangedAssociation(Object derivable, AssociationType associationType)
        {
            this.ChangeSet.AssociationTypesByRole.TryGetValue(derivable.Id, out var changedAssociationTypes);
            return changedAssociationTypes?.Contains(associationType) ?? false;
        }

        public bool HasChangedAssociations(Object derivable, params AssociationType[] associationTypes)
        {
            this.ChangeSet.AssociationTypesByRole.TryGetValue(derivable.Id, out var changedAssociationTypes);
            if (changedAssociationTypes != null)
            {
                if (associationTypes.Length == 0 || associationTypes.Any(associationType => changedAssociationTypes.Contains(associationType)))
                {
                    return true;
                }
            }

            return false;
        }


        public bool IsMarkedAsModified(Object derivable)
        {
            return this.relationsByMarkedAsModified.ContainsKey(derivable.Id);
        }

        public void MarkAsModified(Object derivable, RelationType relationType = null)
        {
            if (derivable != null)
            {
                if (!this.relationsByMarkedAsModified.TryGetValue(derivable.Id, out var relationTypes) && relationType == null)
                {
                    this.relationsByMarkedAsModified.Add(derivable.Id, null);
                }

                if (relationType != null)
                {
                    if (relationTypes == null)
                    {
                        relationTypes = new HashSet<RelationType>();
                        this.relationsByMarkedAsModified[derivable.Id] = relationTypes;
                    }

                    relationTypes.Add(relationType);
                }
            }
        }

        public void MarkAsModified(Object derivable, RoleType roleType)
        {
            this.MarkAsModified(derivable, roleType.RelationType);
        }

        public void MarkAsModified(IEnumerable<Object> derivables)
        {
            foreach (var derivable in derivables)
            {
                this.MarkAsModified(derivable);
            }
        }

        public ISet<RelationType> MarkedAsModifiedBy(Object markedAsModified)
        {
            this.relationsByMarkedAsModified.TryGetValue(markedAsModified.Id, out var relationTypes);
            return relationTypes;
        }

        public void AddDerivable(Object derivable)
        {
            if (this.generation == 0)
            {
                throw new Exception("AddDerivable can only be called during a derivation. Use MarkAsModified() instead.");
            }

            if (derivable != null)
            {
                if (this.DerivedObjects.Contains(derivable))
                {
                    this.OnCycleDetected(derivable);
                    if (this.Config.ThrowExceptionOnCycleDetected)
                    {
                        throw new ArgumentException("Object has already been derived.");
                    }
                }

                this.derivationGraph.Add(derivable);
                this.addedDerivables.Add(derivable);

                this.OnAddedDerivable(derivable);
            }
        }

        public void AddDerivables(IEnumerable<Object> derivables)
        {
            foreach (var derivable in derivables)
            {
                this.AddDerivable(derivable);
            }
        }

        public void AddDependency(Object dependent, Object dependee)
        {
            if (this.generation == 0)
            {
                throw new Exception("AddDependency can only be called during a derivation.");
            }

            if (dependent != null && dependee != null)
            {
                if (this.DerivedObjects.Contains(dependent) || this.DerivedObjects.Contains(dependee))
                {
                    this.OnCycleDetected(dependent, dependee);
                    if (this.Config.ThrowExceptionOnCycleDetected)
                    {
                        throw new ArgumentException("Object has already been derived.");
                    }
                }

                this.addedDerivables.Add(dependent);
                this.addedDerivables.Add(dependee);
                this.derivationGraph.AddDependency(dependent, dependee);

                this.OnAddedDependency(dependent, dependee);
            }
        }

        public IValidation Derive()
        {
            if (this.generation != 0)
            {
                throw new Exception("Derive can only be called once. Create a new Derivation object.");
            }

            var changedObjectIds = new HashSet<long>(this.ChangeSet.Associations);
            changedObjectIds.UnionWith(this.ChangeSet.Roles);
            changedObjectIds.UnionWith(this.ChangeSet.Created);
            changedObjectIds.UnionWith(this.relationsByMarkedAsModified.Keys);

            var preparedObjects = new HashSet<IObject>();
            var changedObjects = new HashSet<IObject>(this.Session.Instantiate(changedObjectIds.ToArray()));

            while (changedObjects.Count > 0)
            {
                this.generation++;

                this.OnStartedGeneration(this.generation);

                this.addedDerivables = new HashSet<IObject>();

                var preparationRun = 1;

                this.OnStartedPreparation(preparationRun);

                this.derivationGraph = this.CreateDerivationGraph(this);
                foreach (var changedObject in changedObjects)
                {
                    if (this.Session.Instantiate(changedObject) is Object derivable)
                    {
                        this.OnPreDeriving(derivable);

                        derivable.OnPreDerive(x => x.WithDerivation(this));

                        this.OnPreDerived(derivable);

                        preparedObjects.Add(derivable);
                    }
                }

                while (this.addedDerivables.Count > 0)
                {
                    preparationRun++;
                    this.OnStartedPreparation(preparationRun);

                    var dependencyObjectsToPrepare = new HashSet<IObject>(this.addedDerivables);
                    dependencyObjectsToPrepare.ExceptWith(preparedObjects);

                    this.addedDerivables = new HashSet<IObject>();

                    foreach (var o in dependencyObjectsToPrepare)
                    {
                        var dependencyObject = (Object)o;

                        this.OnPreDeriving(dependencyObject);

                        dependencyObject.OnPreDerive(x => x.WithDerivation(this));

                        this.OnPreDerived(dependencyObject);

                        preparedObjects.Add(dependencyObject);
                    }
                }

                if (this.derivationGraph.Count == 0)
                {
                    break;
                }

                this.derivationGraph.Derive();

                this.ChangeSet = this.Session.Checkpoint();

                changedObjectIds = new HashSet<long>(this.ChangeSet.Associations);
                changedObjectIds.UnionWith(this.ChangeSet.Roles);
                changedObjectIds.UnionWith(this.ChangeSet.Created);

                changedObjects = new HashSet<IObject>(this.Session.Instantiate(changedObjectIds.ToArray()));
                changedObjects.ExceptWith(this.derivedObjects);

                this.derivationGraph = null;
            }

            return this.validation;
        }

        internal void AddDerivedObject(Object derivable)
        {
            this.derivedObjects.Add(derivable);
        }

        protected abstract DerivationGraphBase CreateDerivationGraph(DerivationBase derivation);

        protected abstract void OnAddedDerivable(Object derivable);

        protected abstract void OnAddedDependency(Object dependent, Object dependee);

        protected abstract void OnStartedGeneration(int generation);

        protected abstract void OnStartedPreparation(int preparationRun);

        protected abstract void OnPreDeriving(Object derivable);

        protected abstract void OnPreDerived(Object derivable);

        protected abstract void OnCycleDetected(Object derivable);

        protected abstract void OnCycleDetected(Object dependent, Object dependee);
    }
}