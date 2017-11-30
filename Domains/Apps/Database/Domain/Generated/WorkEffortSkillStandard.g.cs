// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class WorkEffortSkillStandard : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public WorkEffortSkillStandard(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaWorkEffortSkillStandard Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortSkillStandard.Instance;
			}
		}

		public long Id
		{
			get { return this.strategy.ObjectId; }
		}

		public IStrategy Strategy
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this.strategy; }
        }

		public static WorkEffortSkillStandard Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (WorkEffortSkillStandard) allorsSession.Instantiate(allorsObjectId);		
		}

		public override bool Equals(object obj)
        {
            var typedObj = obj as IObject;
            return typedObj != null &&
                   typedObj.Strategy.ObjectId.Equals(this.Strategy.ObjectId) &&
                   typedObj.Strategy.Session.Database.Id.Equals(this.Strategy.Session.Database.Id);
        }

		public override int GetHashCode()
        {
            return this.Strategy.ObjectId.GetHashCode();
        }



		virtual public Skill Skill
		{ 
			get
			{
				return (Skill) Strategy.GetCompositeRole(Meta.Skill.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Skill.RelationType, value);
			}
		}

		virtual public bool ExistSkill
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Skill.RelationType);
			}
		}

		virtual public void RemoveSkill()
		{
			Strategy.RemoveCompositeRole(Meta.Skill.RelationType);
		}


		virtual public global::System.Int32? EstimatedNumberOfPeople 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.EstimatedNumberOfPeople.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedNumberOfPeople.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedNumberOfPeople{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedNumberOfPeople.RelationType);
			}
		}

		virtual public void RemoveEstimatedNumberOfPeople()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedNumberOfPeople.RelationType);
		}


		virtual public global::System.Decimal? EstimatedDuration 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.EstimatedDuration.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedDuration.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedDuration{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedDuration.RelationType);
			}
		}

		virtual public void RemoveEstimatedDuration()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedDuration.RelationType);
		}


		virtual public global::System.Decimal? EstimatedCost 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.EstimatedCost.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedCost.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedCost{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedCost.RelationType);
			}
		}

		virtual public void RemoveEstimatedCost()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedCost.RelationType);
		}


		virtual public global::Allors.Extent<Permission> DeniedPermissions
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.DeniedPermissions.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.DeniedPermissions.RelationType, value);
			}
		}

		virtual public void AddDeniedPermission (Permission value)
		{
			Strategy.AddCompositeRole(Meta.DeniedPermissions.RelationType, value);
		}

		virtual public void RemoveDeniedPermission (Permission value)
		{
			Strategy.RemoveCompositeRole(Meta.DeniedPermissions.RelationType, value);
		}

		virtual public bool ExistDeniedPermissions
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.DeniedPermissions.RelationType);
			}
		}

		virtual public void RemoveDeniedPermissions()
		{
			Strategy.RemoveCompositeRoles(Meta.DeniedPermissions.RelationType);
		}


		virtual public global::Allors.Extent<SecurityToken> SecurityTokens
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.SecurityTokens.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.SecurityTokens.RelationType, value);
			}
		}

		virtual public void AddSecurityToken (SecurityToken value)
		{
			Strategy.AddCompositeRole(Meta.SecurityTokens.RelationType, value);
		}

		virtual public void RemoveSecurityToken (SecurityToken value)
		{
			Strategy.RemoveCompositeRole(Meta.SecurityTokens.RelationType, value);
		}

		virtual public bool ExistSecurityTokens
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.SecurityTokens.RelationType);
			}
		}

		virtual public void RemoveSecurityTokens()
		{
			Strategy.RemoveCompositeRoles(Meta.SecurityTokens.RelationType);
		}



		virtual public WorkEffortType WorkEffortTypeWhereWorkEffortSkillStandard
		{ 
			get
			{
				return (WorkEffortType) Strategy.GetCompositeAssociation(Meta.WorkEffortTypeWhereWorkEffortSkillStandard.RelationType);
			}
		} 

		virtual public bool ExistWorkEffortTypeWhereWorkEffortSkillStandard
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.WorkEffortTypeWhereWorkEffortSkillStandard.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new WorkEffortSkillStandardOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new WorkEffortSkillStandardOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new WorkEffortSkillStandardOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new WorkEffortSkillStandardOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new WorkEffortSkillStandardOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new WorkEffortSkillStandardOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new WorkEffortSkillStandardOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new WorkEffortSkillStandardOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new WorkEffortSkillStandardOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new WorkEffortSkillStandardOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class WorkEffortSkillStandardBuilder : Allors.ObjectBuilder<WorkEffortSkillStandard> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public WorkEffortSkillStandardBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(WorkEffortSkillStandard instance)
		{
			

			if(this.EstimatedNumberOfPeople.HasValue)
			{
				instance.EstimatedNumberOfPeople = this.EstimatedNumberOfPeople.Value;
			}			
		
		
			

			if(this.EstimatedDuration.HasValue)
			{
				instance.EstimatedDuration = this.EstimatedDuration.Value;
			}			
		
		
			

			if(this.EstimatedCost.HasValue)
			{
				instance.EstimatedCost = this.EstimatedCost.Value;
			}			
		
		

			instance.Skill = this.Skill;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Skill Skill {get; set;}

				/// <exclude/>
				public WorkEffortSkillStandardBuilder WithSkill(Skill value)
		        {
		            if(this.Skill!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Skill = value;
		            return this;
		        }		

				
				public global::System.Int32? EstimatedNumberOfPeople {get; set;}

				/// <exclude/>
				public WorkEffortSkillStandardBuilder WithEstimatedNumberOfPeople(global::System.Int32? value)
		        {
				    if(this.EstimatedNumberOfPeople!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedNumberOfPeople = value;
		            return this;
		        }	

				public global::System.Decimal? EstimatedDuration {get; set;}

				/// <exclude/>
				public WorkEffortSkillStandardBuilder WithEstimatedDuration(global::System.Decimal? value)
		        {
				    if(this.EstimatedDuration!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedDuration = value;
		            return this;
		        }	

				public global::System.Decimal? EstimatedCost {get; set;}

				/// <exclude/>
				public WorkEffortSkillStandardBuilder WithEstimatedCost(global::System.Decimal? value)
		        {
				    if(this.EstimatedCost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedCost = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public WorkEffortSkillStandardBuilder WithDeniedPermission(Permission value)
		        {
					if(this.DeniedPermissions == null)
					{
						this.DeniedPermissions = new global::System.Collections.Generic.List<Permission>(); 
					}
		            this.DeniedPermissions.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<SecurityToken> SecurityTokens {get; set;}	

				/// <exclude/>
				public WorkEffortSkillStandardBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class WorkEffortSkillStandards : global::Allors.ObjectsBase<WorkEffortSkillStandard>
	{
		public WorkEffortSkillStandards(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaWorkEffortSkillStandard Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortSkillStandard.Instance;
			}
		}

		public override Allors.Meta.Composite ObjectType
		{
			get
			{
				return Meta.ObjectType;
			}
		}
	}

}