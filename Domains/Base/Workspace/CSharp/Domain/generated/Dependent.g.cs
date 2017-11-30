// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Workspace.Domain
{
	public partial class Dependent : SessionObject , Deletable
	{
		public Dependent(Session session)
		: base(session)
		{
		}

		public Allors.Workspace.Meta.MetaDependent Meta
		{
			get
			{
				return Allors.Workspace.Meta.MetaDependent.Instance;
			}
		}

		public static Dependent Instantiate (Session allorsSession, long allorsObjectId)
		{
			return (Dependent) allorsSession.Get(allorsObjectId);		
		}

		public override bool Equals(object obj)
        {
            var that = obj as SessionObject;
		    if (that == null)
		    {
		        return false;
		    }

		    return this.Id.Equals(that.Id);
        }

		public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }



			public bool CanExecuteDelete 
			{
				get
				{
					return this.CanExecute(this.Meta.Delete);
				}
			}

			public Method Delete 
			{
				get
				{
					return new Method(this, "Delete");
				}
			}
	}
}