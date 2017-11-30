// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class PaymentApplication : Allors.IObject , AccessControlledObject
	{
		private readonly IStrategy strategy;

		public PaymentApplication(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaPaymentApplication Meta
		{
			get
			{
				return Allors.Meta.MetaPaymentApplication.Instance;
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

		public static PaymentApplication Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (PaymentApplication) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public global::System.Decimal AmountApplied 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.AmountApplied.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.AmountApplied.RelationType, value);
			}
		}

		virtual public bool ExistAmountApplied{
			get
			{
				return Strategy.ExistUnitRole(Meta.AmountApplied.RelationType);
			}
		}

		virtual public void RemoveAmountApplied()
		{
			Strategy.RemoveUnitRole(Meta.AmountApplied.RelationType);
		}


		virtual public InvoiceItem InvoiceItem
		{ 
			get
			{
				return (InvoiceItem) Strategy.GetCompositeRole(Meta.InvoiceItem.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.InvoiceItem.RelationType, value);
			}
		}

		virtual public bool ExistInvoiceItem
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.InvoiceItem.RelationType);
			}
		}

		virtual public void RemoveInvoiceItem()
		{
			Strategy.RemoveCompositeRole(Meta.InvoiceItem.RelationType);
		}


		virtual public Invoice Invoice
		{ 
			get
			{
				return (Invoice) Strategy.GetCompositeRole(Meta.Invoice.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.Invoice.RelationType, value);
			}
		}

		virtual public bool ExistInvoice
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.Invoice.RelationType);
			}
		}

		virtual public void RemoveInvoice()
		{
			Strategy.RemoveCompositeRole(Meta.Invoice.RelationType);
		}


		virtual public BillingAccount BillingAccount
		{ 
			get
			{
				return (BillingAccount) Strategy.GetCompositeRole(Meta.BillingAccount.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.BillingAccount.RelationType, value);
			}
		}

		virtual public bool ExistBillingAccount
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.BillingAccount.RelationType);
			}
		}

		virtual public void RemoveBillingAccount()
		{
			Strategy.RemoveCompositeRole(Meta.BillingAccount.RelationType);
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



		virtual public Payment PaymentWherePaymentApplication
		{ 
			get
			{
				return (Payment) Strategy.GetCompositeAssociation(Meta.PaymentWherePaymentApplication.RelationType);
			}
		} 

		virtual public bool ExistPaymentWherePaymentApplication
		{
			get
			{
				return Strategy.ExistCompositeAssociation(Meta.PaymentWherePaymentApplication.RelationType);
			}
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new PaymentApplicationOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new PaymentApplicationOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new PaymentApplicationOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new PaymentApplicationOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new PaymentApplicationOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new PaymentApplicationOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new PaymentApplicationOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new PaymentApplicationOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new PaymentApplicationOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new PaymentApplicationOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class PaymentApplicationBuilder : Allors.ObjectBuilder<PaymentApplication> , AccessControlledObjectBuilder, global::System.IDisposable
	{		
		public PaymentApplicationBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(PaymentApplication instance)
		{
			

			if(this.AmountApplied.HasValue)
			{
				instance.AmountApplied = this.AmountApplied.Value;
			}			
		
		

			instance.InvoiceItem = this.InvoiceItem;

		

			instance.Invoice = this.Invoice;

		

			instance.BillingAccount = this.BillingAccount;

		
			if(this.DeniedPermissions!=null)
			{
				instance.DeniedPermissions = this.DeniedPermissions.ToArray();
			}
		
			if(this.SecurityTokens!=null)
			{
				instance.SecurityTokens = this.SecurityTokens.ToArray();
			}
		
		}


				public global::System.Decimal? AmountApplied {get; set;}

				/// <exclude/>
				public PaymentApplicationBuilder WithAmountApplied(global::System.Decimal? value)
		        {
				    if(this.AmountApplied!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.AmountApplied = value;
		            return this;
		        }	

				public InvoiceItem InvoiceItem {get; set;}

				/// <exclude/>
				public PaymentApplicationBuilder WithInvoiceItem(InvoiceItem value)
		        {
		            if(this.InvoiceItem!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.InvoiceItem = value;
		            return this;
		        }		

				
				public Invoice Invoice {get; set;}

				/// <exclude/>
				public PaymentApplicationBuilder WithInvoice(Invoice value)
		        {
		            if(this.Invoice!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.Invoice = value;
		            return this;
		        }		

				
				public BillingAccount BillingAccount {get; set;}

				/// <exclude/>
				public PaymentApplicationBuilder WithBillingAccount(BillingAccount value)
		        {
		            if(this.BillingAccount!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.BillingAccount = value;
		            return this;
		        }		

				
				public global::System.Collections.Generic.List<Permission> DeniedPermissions {get; set;}	

				/// <exclude/>
				public PaymentApplicationBuilder WithDeniedPermission(Permission value)
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
				public PaymentApplicationBuilder WithSecurityToken(SecurityToken value)
		        {
					if(this.SecurityTokens == null)
					{
						this.SecurityTokens = new global::System.Collections.Generic.List<SecurityToken>(); 
					}
		            this.SecurityTokens.Add(value);
		            return this;
		        }		

				

	}

	public partial class PaymentApplications : global::Allors.ObjectsBase<PaymentApplication>
	{
		public PaymentApplications(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaPaymentApplication Meta
		{
			get
			{
				return Allors.Meta.MetaPaymentApplication.Instance;
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