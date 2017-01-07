using System;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	
	public class TableGenericModel : IDisposable
	{
		#region Protected Fields

		
		protected bool enabled;

		
		protected string selectAllStoredProcdureName;

		#endregion Protected Fields

		#region Private Fields

		
		private string modelName;

		#endregion Private Fields

		#region Public Properties

		
		public virtual bool Enabled {
			get { return enabled; }
			set { enabled = value; }
		}

		
		public string ModelName {
			get { return modelName; }
			set { modelName = value; }
		}

		public virtual void Dispose()
		{
			selectAllStoredProcdureName = null;
			modelName = null;
		}

		#endregion Public Properties
	}

	
	
	public class TableGenericModel<T> : TableGenericModel
	{
		#region Protected Fields

		
		protected T primaryKey;

		#endregion Protected Fields

		#region Public Properties

		
		public T PrimaryKey {
			get { return primaryKey; }
			set { primaryKey = value; }
		}

		public override void Dispose()
		{
			base.Dispose();
			primaryKey = default(T);
		}

		#endregion Public Properties
	}
}