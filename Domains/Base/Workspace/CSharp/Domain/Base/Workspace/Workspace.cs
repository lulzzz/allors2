﻿namespace Allors.Workspace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Server;

    public class Workspace
    {
        public ObjectFactory ObjectFactory { get; }

        private readonly Dictionary<long, WorkspaceObject> workspaceObjectById = new Dictionary<long, WorkspaceObject>();
        
        public Workspace(ObjectFactory objectFactory)
        {
            this.ObjectFactory = objectFactory;
        }

        public SyncRequest Diff(PullResponse response)
        {
            var userSecurityHash = response.UserSecurityHash;

            var requireLoadIds = new SyncRequest
                                     {
                                         Objects = response.Objects.Where(v =>
                                                 {
                                                     var id = long.Parse(v[0]);
                                                     var version = long.Parse(v[1]);
                                                     WorkspaceObject workspaceObject;
                                                     this.workspaceObjectById.TryGetValue(id, out workspaceObject);
                                                     return workspaceObject == null || !workspaceObject.Version.Equals(version) || !workspaceObject.UserSecurityHash.Equals(userSecurityHash);
                                                 }).Select(v => v[0]).ToArray()
                                     };

            return requireLoadIds;
        }

        public void Sync(SyncResponse syncResponse)
        {
            foreach (var objectData in syncResponse.Objects)
            {
                var workspaceObject = new WorkspaceObject(this, syncResponse, objectData);
                this.workspaceObjectById[workspaceObject.Id] = workspaceObject;
            }
        }

        public WorkspaceObject Get(long id) {
            var workspaceObject = this.workspaceObjectById[id];
            if (workspaceObject == null)
            {
                throw new Exception($"Object with id {id} is not present.");
            }

            return workspaceObject;
        }
    }
}