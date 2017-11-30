// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Domain
{
	public partial interface EstimatedProductCost :  Period,AccessControlledObject, Allors.IObject
	{


		global::System.Decimal Cost 
		{
			get;
			set;
		}

		bool ExistCost{get;}

		void RemoveCost();


		Currency Currency
		{ 
			get;
			set;
		}

		bool ExistCurrency
		{
			get;
		}

		void RemoveCurrency();


		Organisation Organisation
		{ 
			get;
			set;
		}

		bool ExistOrganisation
		{
			get;
		}

		void RemoveOrganisation();


		global::System.String Description 
		{
			get;
			set;
		}

		bool ExistDescription{get;}

		void RemoveDescription();


		GeographicBoundary GeographicBoundary
		{ 
			get;
			set;
		}

		bool ExistGeographicBoundary
		{
			get;
		}

		void RemoveGeographicBoundary();



		Product ProductWhereEstimatedProductCost
		{
			get;
		}

		bool ExistProductWhereEstimatedProductCost
		{
			get;
		}


		ProductFeature ProductFeatureWhereEstimatedProductCost
		{
			get;
		}

		bool ExistProductFeatureWhereEstimatedProductCost
		{
			get;
		}

	}

	public partial interface EstimatedProductCostBuilder : PeriodBuilder ,AccessControlledObjectBuilder , global::System.IDisposable
	{	
		global::System.Decimal? Cost {get;}
		

		Currency Currency {get;}

		

		Organisation Organisation {get;}

		

		global::System.String Description {get;}
		

		GeographicBoundary GeographicBoundary {get;}

		

	}

	public partial class EstimatedProductCosts : global::Allors.ObjectsBase<EstimatedProductCost>
	{
		public EstimatedProductCosts(Allors.ISession session) : base(session)
		{
		}

		public Allors.Meta.MetaEstimatedProductCost Meta
		{
			get
			{
				return Allors.Meta.MetaEstimatedProductCost.Instance;
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