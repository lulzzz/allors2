// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Setup.cs" company="Allors bvba">
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

namespace Allors
{
    using System.Collections.Generic;
    using System.IO;

    using Allors.Domain;
    using Allors.Meta;

    public partial class Setup
    {
        private readonly ISession session;

        private readonly Dictionary<IObjectType, IObjects> objectsByObjectType;
        private readonly ObjectsGraph objectsGraph;

        public Setup(ISession session) : this(session, null)
        {
        }

        public Setup(ISession session, DirectoryInfo dataPath)
        {
            this.session = session;
            this.DataPath = dataPath;

            this.objectsByObjectType = new Dictionary<IObjectType, IObjects>();
            foreach (ObjectType objectType in session.Database.MetaPopulation.Composites)
            {
                this.objectsByObjectType[objectType] = objectType.GetObjects(session);
            }

            this.objectsGraph = new ObjectsGraph();
        }

        public DirectoryInfo DataPath { get; private set; }

        public bool ExistDataPath => this.DataPath != null;

        public void Apply()
        {
            this.OnPrePrepare();

            foreach (var objects in this.objectsByObjectType.Values)
            {
                objects.Prepare(this);
            }

            this.OnPostPrepare();

            this.OnPreSetup();

            this.objectsGraph.Invoke(objects => objects.Setup(this));

            this.OnPostSetup();

            this.session.Derive();

            new Security(this.session).Apply();
        }

        public void Add(IObjects objects)
        {
            this.objectsGraph.Add(objects);
        }
        
        /// <summary>
        /// The dependee is set up before the dependent object;
        /// </summary>
        /// <param name="dependent"></param>
        /// <param name="dependee"></param>
        public void AddDependency(ObjectType dependent, ObjectType dependee)
        {
            this.objectsGraph.AddDependency(this.objectsByObjectType[dependent], this.objectsByObjectType[dependee]);
        }

        private void BaseOnPrePrepare()
        {
        }

        private void BaseOnPostSetup()
        {
        }

        private void BaseOnPostPrepare()
        {
        }

        private void BaseOnPreSetup()
        {
        }
    }
}