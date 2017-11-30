// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class Organisation : Allors.IObject , Deletable, UniquelyIdentifiable, AccessControlledObject
	{
		private readonly IStrategy strategy;

		public Organisation(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaOrganisation Meta
		{
			get
			{
				return Allors.Meta.MetaOrganisation.Instance;
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

		public static Organisation Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (Organisation) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::Allors.Extent<Address> Addresses
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Addresses.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Addresses.RelationType, value);
			}
		}

		virtual public void AddAddress (Address value)
		{
			Strategy.AddCompositeRole(Meta.Addresses.RelationType, value);
		}

		virtual public void RemoveAddress (Address value)
		{
			Strategy.RemoveCompositeRole(Meta.Addresses.RelationType, value);
		}

		virtual public bool ExistAddresses
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Addresses.RelationType);
			}
		}

		virtual public void RemoveAddresses()
		{
			Strategy.RemoveCompositeRoles(Meta.Addresses.RelationType);
		}


		virtual public global::System.String Description 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Description.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Description.RelationType, value);
			}
		}

		virtual public bool ExistDescription{
			get
			{
				return Strategy.ExistUnitRole(Meta.Description.RelationType);
			}
		}

		virtual public void RemoveDescription()
		{
			Strategy.RemoveUnitRole(Meta.Description.RelationType);
		}


		virtual public global::Allors.Extent<Person> Employees
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Employees.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Employees.RelationType, value);
			}
		}

		virtual public void AddEmployee (Person value)
		{
			Strategy.AddCompositeRole(Meta.Employees.RelationType, value);
		}

		virtual public void RemoveEmployee (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.Employees.RelationType, value);
		}

		virtual public bool ExistEmployees
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Employees.RelationType);
			}
		}

		virtual public void RemoveEmployees()
		{
			Strategy.RemoveCompositeRoles(Meta.Employees.RelationType);
		}


		virtual public global::Allors.Extent<Media> Images
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Images.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Images.RelationType, value);
			}
		}

		virtual public void AddImage (Media value)
		{
			Strategy.AddCompositeRole(Meta.Images.RelationType, value);
		}

		virtual public void RemoveImage (Media value)
		{
			Strategy.RemoveCompositeRole(Meta.Images.RelationType, value);
		}

		virtual public bool ExistImages
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Images.RelationType);
			}
		}

		virtual public void RemoveImages()
		{
			Strategy.RemoveCompositeRoles(Meta.Images.RelationType);
		}


		virtual public global::System.Boolean? Incorporated 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.Incorporated.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Incorporated.RelationType, value);
			}
		}

		virtual public bool ExistIncorporated{
			get
			{
				return Strategy.ExistUnitRole(Meta.Incorporated.RelationType);
			}
		}

		virtual public void RemoveIncorporated()
		{
			Strategy.RemoveUnitRole(Meta.Incorporated.RelationType);
		}


		virtual public global::System.DateTime? IncorporationDate 
		{
			get
			{
				return (global::System.DateTime?) Strategy.GetUnitRole(Meta.IncorporationDate.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.IncorporationDate.RelationType, value);
			}
		}

		virtual public bool ExistIncorporationDate{
			get
			{
				return Strategy.ExistUnitRole(Meta.IncorporationDate.RelationType);
			}
		}

		virtual public void RemoveIncorporationDate()
		{
			Strategy.RemoveUnitRole(Meta.IncorporationDate.RelationType);
		}


		virtual public global::System.String Information 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Information.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Information.RelationType, value);
			}
		}

		virtual public bool ExistInformation{
			get
			{
				return Strategy.ExistUnitRole(Meta.Information.RelationType);
			}
		}

		virtual public void RemoveInformation()
		{
			Strategy.RemoveUnitRole(Meta.Information.RelationType);
		}


		virtual public global::System.Boolean? IsSupplier 
		{
			get
			{
				return (global::System.Boolean?) Strategy.GetUnitRole(Meta.IsSupplier.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.IsSupplier.RelationType, value);
			}
		}

		virtual public bool ExistIsSupplier{
			get
			{
				return Strategy.ExistUnitRole(Meta.IsSupplier.RelationType);
			}
		}

		virtual public void RemoveIsSupplier()
		{
			Strategy.RemoveUnitRole(Meta.IsSupplier.RelationType);
		}


		virtual public Media Logo
		{ 
			get
			{
				return (Media) Strategy.GetCompositeRole(Meta.Logo.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Logo.RelationType, value);
			}
		}

		virtual public bool ExistLogo
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Logo.RelationType);
			}
		}

		virtual public void RemoveLogo()
		{
			Strategy.RemoveCompositeRole(Meta.Logo.RelationType);
		}


		virtual public Address MainAddress
		{ 
			get
			{
				return (Address) Strategy.GetCompositeRole(Meta.MainAddress.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.MainAddress.RelationType, value);
			}
		}

		virtual public bool ExistMainAddress
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.MainAddress.RelationType);
			}
		}

		virtual public void RemoveMainAddress()
		{
			Strategy.RemoveCompositeRole(Meta.MainAddress.RelationType);
		}


		virtual public Person Manager
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.Manager.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Manager.RelationType, value);
			}
		}

		virtual public bool ExistManager
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Manager.RelationType);
			}
		}

		virtual public void RemoveManager()
		{
			Strategy.RemoveCompositeRole(Meta.Manager.RelationType);
		}


		virtual public global::System.String Name 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Name.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Name.RelationType, value);
			}
		}

		virtual public bool ExistName{
			get
			{
				return Strategy.ExistUnitRole(Meta.Name.RelationType);
			}
		}

		virtual public void RemoveName()
		{
			Strategy.RemoveUnitRole(Meta.Name.RelationType);
		}


		virtual public Person Owner
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.Owner.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Owner.RelationType, value);
			}
		}

		virtual public bool ExistOwner
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Owner.RelationType);
			}
		}

		virtual public void RemoveOwner()
		{
			Strategy.RemoveCompositeRole(Meta.Owner.RelationType);
		}


		virtual public global::Allors.Extent<Person> Shareholders
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.Shareholders.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.Shareholders.RelationType, value);
			}
		}

		virtual public void AddShareholder (Person value)
		{
			Strategy.AddCompositeRole(Meta.Shareholders.RelationType, value);
		}

		virtual public void RemoveShareholder (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.Shareholders.RelationType, value);
		}

		virtual public bool ExistShareholders
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.Shareholders.RelationType);
			}
		}

		virtual public void RemoveShareholders()
		{
			Strategy.RemoveCompositeRoles(Meta.Shareholders.RelationType);
		}


		virtual public global::System.String Size 
		{
			get
			{
				return (global::System.String) Strategy.GetUnitRole(Meta.Size.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Size.RelationType, value);
			}
		}

		virtual public bool ExistSize{
			get
			{
				return Strategy.ExistUnitRole(Meta.Size.RelationType);
			}
		}

		virtual public void RemoveSize()
		{
			Strategy.RemoveUnitRole(Meta.Size.RelationType);
		}


		virtual public Person CycleOne
		{ 
			get
			{
				return (Person) Strategy.GetCompositeRole(Meta.CycleOne.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.CycleOne.RelationType, value);
			}
		}

		virtual public bool ExistCycleOne
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.CycleOne.RelationType);
			}
		}

		virtual public void RemoveCycleOne()
		{
			Strategy.RemoveCompositeRole(Meta.CycleOne.RelationType);
		}


		virtual public global::Allors.Extent<Person> CycleMany
		{ 
			get
			{
				return Strategy.GetCompositeRoles(Meta.CycleMany.RelationType);
			}
			set
			{
				Strategy.SetCompositeRoles(Meta.CycleMany.RelationType, value);
			}
		}

		virtual public void AddCycleMany (Person value)
		{
			Strategy.AddCompositeRole(Meta.CycleMany.RelationType, value);
		}

		virtual public void RemoveCycleMany (Person value)
		{
			Strategy.RemoveCompositeRole(Meta.CycleMany.RelationType, value);
		}

		virtual public bool ExistCycleMany
		{
			get
			{
				return Strategy.ExistCompositeRoles(Meta.CycleMany.RelationType);
			}
		}

		virtual public void RemoveCycleMany()
		{
			Strategy.RemoveCompositeRoles(Meta.CycleMany.RelationType);
		}


		virtual public global::System.Guid UniqueId 
		{
			get
			{
				return (global::System.Guid) Strategy.GetUnitRole(Meta.UniqueId.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.UniqueId.RelationType, value);
			}
		}

		virtual public bool ExistUniqueId{
			get
			{
				return Strategy.ExistUnitRole(Meta.UniqueId.RelationType);
			}
		}

		virtual public void RemoveUniqueId()
		{
			Strategy.RemoveUnitRole(Meta.UniqueId.RelationType);
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



		virtual public global::Allors.Extent<Person> PeopleWhereCycleOne
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PeopleWhereCycleOne.RelationType);
			}
		}

		virtual public bool ExistPeopleWhereCycleOne
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PeopleWhereCycleOne.RelationType);
			}
		}


		virtual public global::Allors.Extent<Person> PeopleWhereCycleMany
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.PeopleWhereCycleMany.RelationType);
			}
		}

		virtual public bool ExistPeopleWhereCycleMany
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.PeopleWhereCycleMany.RelationType);
			}
		}


		virtual public global::Allors.Extent<BadUI> BadUIsWhereCompanyOne
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.BadUIsWhereCompanyOne.RelationType);
			}
		}

		virtual public bool ExistBadUIsWhereCompanyOne
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.BadUIsWhereCompanyOne.RelationType);
			}
		}


		virtual public global::Allors.Extent<BadUI> BadUIsWhereCompanyMany
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.BadUIsWhereCompanyMany.RelationType);
			}
		}

		virtual public bool ExistBadUIsWhereCompanyMany
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.BadUIsWhereCompanyMany.RelationType);
			}
		}


		virtual public global::Allors.Extent<Notification> NotificationsWhereTarget
		{ 
			get
			{
				return Strategy.GetCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}

		virtual public bool ExistNotificationsWhereTarget
		{
			get
			{
				return Strategy.ExistCompositeAssociations(Meta.NotificationsWhereTarget.RelationType);
			}
		}



		public OrganisationJustDoIt JustDoIt()
		{ 
			var method = new OrganisationJustDoIt(this);
            method.Execute();
            return method;
		}

		public OrganisationJustDoIt JustDoIt(System.Action<OrganisationJustDoIt> action)
		{ 
			var method = new OrganisationJustDoIt(this);
            action(method);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete()
		{ 
			var method = new OrganisationDelete(this);
            method.Execute();
            return method;
		}

		public DeletableDelete Delete(System.Action<DeletableDelete> action)
		{ 
			var method = new OrganisationDelete(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild()
		{ 
			var method = new OrganisationOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new OrganisationOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new OrganisationOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new OrganisationOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new OrganisationOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new OrganisationOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new OrganisationOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new OrganisationOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new OrganisationOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new OrganisationOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class OrganisationBuilder : Allors.ObjectBuilder<Organisation> , DeletableBuilder, UniquelyIdentifiableBuilder, AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public OrganisationBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(Organisation instance)
		{

			instance.Description = this.Description;
		
		
			

			if(this.Incorporated.HasValue)
			{
				instance.Incorporated = this.Incorporated.Value;
			}			
		
		
			

			if(this.IncorporationDate.HasValue)
			{
				instance.IncorporationDate = this.IncorporationDate.Value;
			}			
		
		

			instance.Information = this.Information;
		
		
			

			if(this.IsSupplier.HasValue)
			{
				instance.IsSupplier = this.IsSupplier.Value;
			}			
		
		

			instance.Name = this.Name;
		
		

			instance.Size = this.Size;
		
		
			

			if(this.UniqueId.HasValue)
			{
				instance.UniqueId = this.UniqueId.Value;
			}			
		
		
			if(this.Addresses!=null)
			{
				instance.Addresses = this.Addresses.ToArray();
			}
		
			if(this.Employees!=null)
			{
				instance.Employees = this.Employees.ToArray();
			}
		
			if(this.Images!=null)
			{
				instance.Images = this.Images.ToArray();
			}
		

			instance.Logo = this.Logo;

		

			instance.MainAddress = this.MainAddress;

		

			instance.Manager = this.Manager;

		

			instance.Owner = this.Owner;

		
			if(this.Shareholders!=null)
			{
				instance.Shareholders = this.Shareholders.ToArray();
			}
		

			instance.CycleOne = this.CycleOne;

		
			if(this.CycleMany!=null)
			{
				instance.CycleMany = this.CycleMany.ToArray();
			}
		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Collections.Generic.List<Address> Addresses {get; set;}	

				/// <exclude/>
				public OrganisationBuilder WithAddress(Address value)
		        {
					if(this.Addresses == null)
					{
						this.Addresses = new global::System.Collections.Generic.List<Address>(); 
					}
		            this.Addresses.Add(value);
		            return this;
		        }		

				
				public global::System.String Description {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithDescription(global::System.String value)
		        {
				    if(this.Description!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Description = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Person> Employees {get; set;}	

				/// <exclude/>
				public OrganisationBuilder WithEmployee(Person value)
		        {
					if(this.Employees == null)
					{
						this.Employees = new global::System.Collections.Generic.List<Person>(); 
					}
		            this.Employees.Add(value);
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Media> Images {get; set;}	

				/// <exclude/>
				public OrganisationBuilder WithImage(Media value)
		        {
					if(this.Images == null)
					{
						this.Images = new global::System.Collections.Generic.List<Media>(); 
					}
		            this.Images.Add(value);
		            return this;
		        }		

				
				public global::System.Boolean? Incorporated {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithIncorporated(global::System.Boolean? value)
		        {
				    if(this.Incorporated!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Incorporated = value;
		            return this;
		        }	

				public global::System.DateTime? IncorporationDate {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithIncorporationDate(global::System.DateTime? value)
		        {
				    if(this.IncorporationDate!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IncorporationDate = value;
		            return this;
		        }	

				public global::System.String Information {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithInformation(global::System.String value)
		        {
				    if(this.Information!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Information = value;
		            return this;
		        }	

				public global::System.Boolean? IsSupplier {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithIsSupplier(global::System.Boolean? value)
		        {
				    if(this.IsSupplier!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.IsSupplier = value;
		            return this;
		        }	

				public Media Logo {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithLogo(Media value)
		        {
		            if(this.Logo!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Logo = value;
		            return this;
		        }		

				
				public Address MainAddress {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithMainAddress(Address value)
		        {
		            if(this.MainAddress!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.MainAddress = value;
		            return this;
		        }		

				
				public Person Manager {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithManager(Person value)
		        {
		            if(this.Manager!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Manager = value;
		            return this;
		        }		

				
				public global::System.String Name {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithName(global::System.String value)
		        {
				    if(this.Name!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Name = value;
		            return this;
		        }	

				public Person Owner {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithOwner(Person value)
		        {
		            if(this.Owner!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Owner = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Person> Shareholders {get; set;}	

				/// <exclude/>
				public OrganisationBuilder WithShareholder(Person value)
		        {
					if(this.Shareholders == null)
					{
						this.Shareholders = new global::System.Collections.Generic.List<Person>(); 
					}
		            this.Shareholders.Add(value);
		            return this;
		        }		

				
				public global::System.String Size {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithSize(global::System.String value)
		        {
				    if(this.Size!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Size = value;
		            return this;
		        }	

				public Person CycleOne {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithCycleOne(Person value)
		        {
		            if(this.CycleOne!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.CycleOne = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Person> CycleMany {get; set;}	

				/// <exclude/>
				public OrganisationBuilder WithCycleMany(Person value)
		        {
					if(this.CycleMany == null)
					{
						this.CycleMany = new global::System.Collections.Generic.List<Person>(); 
					}
		            this.CycleMany.Add(value);
		            return this;
		        }		

				
				public global::System.Guid? UniqueId {get; set;}

				/// <exclude/>
				public OrganisationBuilder WithUniqueId(global::System.Guid? value)
		        {
				    if(this.UniqueId!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.UniqueId = value;
		            return this;
		        }	

				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public OrganisationBuilder WithDeniedPermission(Permission value)
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
				public OrganisationBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class Organisations : global::Allors.ObjectsBase<Organisation>
	{
		public Organisations(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaOrganisation Meta
		{
			get
			{
				return Allors.Meta.MetaOrganisation.Instance;
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