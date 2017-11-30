// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class CustomerRelationship : Allors.IObject , Period, Deletable, AccessControlledObject
	{
		private readonly IStrategy strategy;

		public CustomerRelationship(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaCustomerRelationship Meta
		{
			get
			{
				return Allors.Meta.MetaCustomerRelationship.Instance;
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

		public static CustomerRelationship Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (CustomerRelationship) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public Party Customer
		{ 
			get
			{
				return (Party) Strategy.GetCompositeRole(Meta.Customer.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Customer.RelationType, value);
			}
		}

		virtual public bool ExistCustomer
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Customer.RelationType);
			}
		}

		virtual public void RemoveCustomer()
		{
			Strategy.RemoveCompositeRole(Meta.Customer.RelationType);
		}


		virtual public global::System.DateTime FromDate 
		{
			get
			{
				return (global::System.DateTime) Strategy.GetUnitRole(Meta.FromDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.FromDate.RelationType, value);
			}
		}

		virtual public bool ExistFromDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.FromDate.RelationType);
			}
		}

		virtual public void RemoveFromDate()
		{
			Strategy.RemoveUnitRole(Meta.FromDate.RelationType);
		}


		virtual public global::System.DateTime? ThroughDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.ThroughDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.ThroughDate.RelationType, value);
			}
		}

		virtual public bool ExistThroughDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.ThroughDate.RelationType);
			}
		}

		virtual public void RemoveThroughDate()
		{
			Strategy.RemoveUnitRole(Meta.ThroughDate.RelationType);
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



		public ObjectOnBuild OnBuild()
		{ 
			var method = new CustomerRelationshipOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new CustomerRelationshipOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new CustomerRelationshipOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new CustomerRelationshipOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new CustomerRelationshipOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new CustomerRelationshipOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new CustomerRelationshipOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new CustomerRelationshipOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new CustomerRelationshipOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new CustomerRelationshipOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new CustomerRelationshipDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new CustomerRelationshipDelete(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class CustomerRelationshipBuilder : Allors.ObjectBuilder<CustomerRelationship> , PeriodBuilder, DeletableBuilder, AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public CustomerRelationshipBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(CustomerRelationship instance)
		{
			

			if(this.FromDate.HasValue)
			{
				instance.FromDate = this.FromDate.Value;
			}			
		
		
			

			if(this.ThroughDate.HasValue)
			{
				instance.ThroughDate = this.ThroughDate.Value;
			}			
		
		

			instance.Customer = this.Customer;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public Party Customer {get; set;}

				/// <exclude/>
				public CustomerRelationshipBuilder WithCustomer(Party value)
		        {
		            if(this.Customer!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Customer = value;
		            return this;
		        }		

				
				public global::System.DateTime? FromDate {get; set;}

				/// <exclude/>
				public CustomerRelationshipBuilder WithFromDate(global::System.DateTime? value)
		        {
				    if(this.FromDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.FromDate = value;
		            return this;
		        }	

				public global::System.DateTime? ThroughDate {get; set;}

				/// <exclude/>
				public CustomerRelationshipBuilder WithThroughDate(global::System.DateTime? value)
		        {
				    if(this.ThroughDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.ThroughDate = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public CustomerRelationshipBuilder WithDeniedPermission(Permission value)
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
				public CustomerRelationshipBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class CustomerRelationships : global::Allors.ObjectsBase<CustomerRelationship>
	{
		public CustomerRelationships(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaCustomerRelationship Meta
		{
			get
			{
				return Allors.Meta.MetaCustomerRelationship.Instance;
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