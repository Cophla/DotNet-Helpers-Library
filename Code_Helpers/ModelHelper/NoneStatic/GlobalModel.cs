using System;
using CodeHelpers.System;

namespace CodeHelpers.ModelHelper.NoneStatic
{
	public class GlobalModel : IDisposable
	{
		#region Protected Fields

		protected bool _enabled;
		protected string _modelName;

		#endregion Protected Fields

		#region Public Constructors

		public GlobalModel() : this(typeof(GlobalModel))
		{
		}

		#endregion Public Constructors

		#region Protected Constructors

		protected GlobalModel(Type type)
		{
			_SetModelFullName(type);
		}

		#endregion Protected Constructors

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
			_modelName = null;
		}

		#endregion Public Methods

		#region Private Methods

		private void _SetModelFullName(Type type)
		{
			if (type.IsNull()) return;
			_modelName = type.FullName;
		}

		#endregion Private Methods
	}
}