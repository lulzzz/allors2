// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class WorkEffortGoodStandard : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public WorkEffortGoodStandard(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaWorkEffortGoodStandard Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortGoodStandard.Instance;
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

		public static WorkEffortGoodStandard Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (WorkEffortGoodStandard) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Good Good
		{ 
			get
			{
				return (Good) Strategy.GetCompositeRole(Meta.Good.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Good.RelationType, value);
			}
		}

		virtual public bool ExistGood
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Good.RelationType);
			}
		}

		virtual public void RemoveGood()
		{
			Strategy.RemoveCompositeRole(Meta.Good.RelationType);
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


		virtual public global::System.Int32? EstimatedQuantity 
		{
			get
			{
				return (global::System.Int32?) Strategy.GetUnitRole(Meta.EstimatedQuantity.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.EstimatedQuantity.RelationType, value);
			}
		}

		virtual public bool ExistEstimatedQuantity{
			get
			{
				return Strategy.ExistUnitRole(Meta.EstimatedQuantity.RelationType);
			}
		}

		virtual public void RemoveEstimatedQuantity()
		{
			Strategy.RemoveUnitRole(Meta.EstimatedQuantity.RelationType);
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



		virtual public WorkEffortType WorkEffortTypeWhereWorkEffortGoodStandard
		{ 
			get
			{
				return (WorkEffortType) Strategy.GetCompositeAssociation(Meta.WorkEffortTypeWhereWorkEffortGoodStandard.RelationType);
			}
		} 

		virtual public bool ExistWorkEffortTypeWhereWorkEffortGoodStandard
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.WorkEffortTypeWhereWorkEffortGoodStandard.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new WorkEffortGoodStandardOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new WorkEffortGoodStandardOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new WorkEffortGoodStandardOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new WorkEffortGoodStandardOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new WorkEffortGoodStandardOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new WorkEffortGoodStandardOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new WorkEffortGoodStandardOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new WorkEffortGoodStandardOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new WorkEffortGoodStandardOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new WorkEffortGoodStandardOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class WorkEffortGoodStandardBuilder : Allors.ObjectBuilder<WorkEffortGoodStandard> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public WorkEffortGoodStandardBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(WorkEffortGoodStandard instance)
		{
			

			if(this.EstimatedCost.HasValue)
			{
				instance.EstimatedCost = this.EstimatedCost.Value;
			}			
		
		
			

			if(this.EstimatedQuantity.HasValue)
			{
				instance.EstimatedQuantity = this.EstimatedQuantity.Value;
			}			
		
		

			instance.Good = this.Good;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Good Good {get; set;}

				/// <exclude/>
				public WorkEffortGoodStandardBuilder WithGood(Good value)
		        {
		            if(this.Good!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Good = value;
		            return this;
		        }		

				
				public global::System.Decimal? EstimatedCost {get; set;}

				/// <exclude/>
				public WorkEffortGoodStandardBuilder WithEstimatedCost(global::System.Decimal? value)
		        {
				    if(this.EstimatedCost!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedCost = value;
		            return this;
		        }	

				public global::System.Int32? EstimatedQuantity {get; set;}

				/// <exclude/>
				public WorkEffortGoodStandardBuilder WithEstimatedQuantity(global::System.Int32? value)
		        {
				    if(this.EstimatedQuantity!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.EstimatedQuantity = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public WorkEffortGoodStandardBuilder WithDeniedPermission(Permission value)
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
				public WorkEffortGoodStandardBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class WorkEffortGoodStandards : global::Allors.ObjectsBase<WorkEffortGoodStandard>
	{
		public WorkEffortGoodStandards(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaWorkEffortGoodStandard Meta
		{
			get
			{
				return Allors.Meta.MetaWorkEffortGoodStandard.Instance;
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