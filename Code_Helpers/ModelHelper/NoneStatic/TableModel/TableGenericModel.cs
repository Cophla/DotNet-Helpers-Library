using System;
using CodeHelpers.System;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public class TableGenericModel : IDisposable
	{
		#region Public Constructors

		public TableGenericModel()
		{
			_SetModelFullName(typeof(TableGenericModel));
		}

		#endregion Public Constructors

		#region Protected Constructors

		protected TableGenericModel(Type type)
		{
			_SetModelFullName(type);
		}

		#endregion Protected Constructors

		#region Private Methods

		private void _SetModelFullName(Type type)
		{
			if (type.IsNull()) return;
			_modelName = type.FullName;
		}

		#endregion Private Methods

		#region Protected Fields

		protected string _deleteStoredProcdureName;
		protected bool _enabled;

		protected string _insertStoredProcdureName;
		protected string _selectAllStoredProcdureName;
		protected string _updateStoredProcdureName;

		#endregion Protected Fields

		#region Private Fields

		protected string _modelName;

		#endregion Private Fields

		#region Public Properties

		public virtual bool Enabled
		{
			get { return _enabled; }
			set { _enabled = value; }
		}

		public string ModelName
		{
			get { return _modelName; }
			set { _modelName = value; }
		}

		#endregion Public Properties

		#region Public Methods

		public virtual void Dispose()
		{
			_selectAllStoredProcdureName = null;
			_modelName = null;
		}

		#endregion Public Methods
	}

	public class TableGenericModel<T> : TableGenericModel
	{
		#region Public Constructors

		public TableGenericModel() : base(typeof(TableGenericModel<T>))
		{
		}

		#endregion Public Constructors

		#region Protected Constructors

		protected TableGenericModel(Type type) : base(type)
		{
		}

		#endregion Protected Constructors

		#region Protected Fields

		protected T _primaryKey;

		#endregion Protected Fields

		#region Public Properties

		public T PrimaryKey
		{
			get { return _primaryKey; }
			set { _primaryKey = value; }
		}

		#endregion Public Properties

		#region Public Methods

		public override void Dispose()
		{
			base.Dispose();
			_primaryKey = default(T);
		}

		#endregion Public Methods
	}
}