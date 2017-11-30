// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial class OrderItemBilling : Allors.IObject , Object
	{
		private readonly IStrategy strategy;

		public OrderItemBilling(Allors.IStrategy strategy) 
		{
			this.strategy = strategy;
		}

		public Allors.Meta.MetaOrderItemBilling Meta
		{
			get
			{
				return Allors.Meta.MetaOrderItemBilling.Instance;
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

		public static OrderItemBilling Instantiate (Allors.ISession allorsSession, string allorsObjectId)
		{
			return (OrderItemBilling) allorsSession.Instantiate(allorsObjectId);		
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



		virtual public OrderItem OrderItem
		{ 
			get
			{
				return (OrderItem) Strategy.GetCompositeRole(Meta.OrderItem.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.OrderItem.RelationType, value);
			}
		}

		virtual public bool ExistOrderItem
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.OrderItem.RelationType);
			}
		}

		virtual public void RemoveOrderItem()
		{
			Strategy.RemoveCompositeRole(Meta.OrderItem.RelationType);
		}


		virtual public SalesInvoiceItem SalesInvoiceItem
		{ 
			get
			{
				return (SalesInvoiceItem) Strategy.GetCompositeRole(Meta.SalesInvoiceItem.RelationType);
			}
			set
			{
				Strategy.SetCompositeRole(Meta.SalesInvoiceItem.RelationType, value);
			}
		}

		virtual public bool ExistSalesInvoiceItem
		{
			get
			{
				return Strategy.ExistCompositeRole(Meta.SalesInvoiceItem.RelationType);
			}
		}

		virtual public void RemoveSalesInvoiceItem()
		{
			Strategy.RemoveCompositeRole(Meta.SalesInvoiceItem.RelationType);
		}


		virtual public global::System.Decimal Amount 
		{
			get
			{
				return (global::System.Decimal) Strategy.GetUnitRole(Meta.Amount.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Amount.RelationType, value);
			}
		}

		virtual public bool ExistAmount{
			get
			{
				return Strategy.ExistUnitRole(Meta.Amount.RelationType);
			}
		}

		virtual public void RemoveAmount()
		{
			Strategy.RemoveUnitRole(Meta.Amount.RelationType);
		}


		virtual public global::System.Decimal? Quantity 
		{
			get
			{
				return (global::System.Decimal?) Strategy.GetUnitRole(Meta.Quantity.RelationType);
			}
			set
			{
				Strategy.SetUnitRole(Meta.Quantity.RelationType, value);
			}
		}

		virtual public bool ExistQuantity{
			get
			{
				return Strategy.ExistUnitRole(Meta.Quantity.RelationType);
			}
		}

		virtual public void RemoveQuantity()
		{
			Strategy.RemoveUnitRole(Meta.Quantity.RelationType);
		}



		public ObjectOnBuild OnBuild()
		{ 
			var method = new OrderItemBillingOnBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnBuild OnBuild(System.Action<ObjectOnBuild> action)
		{ 
			var method = new OrderItemBillingOnBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild()
		{ 
			var method = new OrderItemBillingOnPostBuild(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostBuild OnPostBuild(System.Action<ObjectOnPostBuild> action)
		{ 
			var method = new OrderItemBillingOnPostBuild(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive()
		{ 
			var method = new OrderItemBillingOnPreDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPreDerive OnPreDerive(System.Action<ObjectOnPreDerive> action)
		{ 
			var method = new OrderItemBillingOnPreDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive()
		{ 
			var method = new OrderItemBillingOnDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnDerive OnDerive(System.Action<ObjectOnDerive> action)
		{ 
			var method = new OrderItemBillingOnDerive(this);
            action(method);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive()
		{ 
			var method = new OrderItemBillingOnPostDerive(this);
            method.Execute();
            return method;
		}

		public ObjectOnPostDerive OnPostDerive(System.Action<ObjectOnPostDerive> action)
		{ 
			var method = new OrderItemBillingOnPostDerive(this);
            action(method);
            method.Execute();
            return method;
		}
	}

	public partial class OrderItemBillingBuilder : Allors.ObjectBuilder<OrderItemBilling> , ObjectBuilder, global::System.IDisposable
	{		
		public OrderItemBillingBuilder(Allors.ISession session) : base(session)
	    {
	    }

		protected override void OnBuild(OrderItemBilling instance)
		{
			

			if(this.Amount.HasValue)
			{
				instance.Amount = this.Amount.Value;
			}			
		
		
			

			if(this.Quantity.HasValue)
			{
				instance.Quantity = this.Quantity.Value;
			}			
		
		

			instance.OrderItem = this.OrderItem;

		

			instance.SalesInvoiceItem = this.SalesInvoiceItem;

		
		}


				public OrderItem OrderItem {get; set;}

				/// <exclude/>
				public OrderItemBillingBuilder WithOrderItem(OrderItem value)
		        {
		            if(this.OrderItem!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.OrderItem = value;
		            return this;
		        }		

				
				public SalesInvoiceItem SalesInvoiceItem {get; set;}

				/// <exclude/>
				public OrderItemBillingBuilder WithSalesInvoiceItem(SalesInvoiceItem value)
		        {
		            if(this.SalesInvoiceItem!=null){throw new global::System.ArgumentException("One multicplicity");}
					this.SalesInvoiceItem = value;
		            return this;
		        }		

				
				public global::System.Decimal? Amount {get; set;}

				/// <exclude/>
				public OrderItemBillingBuilder WithAmount(global::System.Decimal? value)
		        {
				    if(this.Amount!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Amount = value;
		            return this;
		        }	

				public global::System.Decimal? Quantity {get; set;}

				/// <exclude/>
				public OrderItemBillingBuilder WithQuantity(global::System.Decimal? value)
		        {
				    if(this.Quantity!=null){throw new global::System.ArgumentException("One multicplicity");}
		            this.Quantity = value;
		            return this;
		        }	


	}

	public partial class OrderItemBillings : global::Allors.ObjectsBase<OrderItemBilling>
	{
		public OrderItemBillings(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaOrderItemBilling Meta
		{
			get
			{
				return Allors.Meta.MetaOrderItemBilling.Instance;
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