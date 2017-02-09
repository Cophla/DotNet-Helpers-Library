using System;
using CodeHelpers.System;

namespace CodeHelpers.ModelHelper.NoneStatic
{
	public class GlobalModel : IDisposable
	{
		#region Protected Fields

		protected bool _enabled;
		protected Type _modelType;
		protected int _userExecuterId;

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

		public Type ModelType
		{
			get { return _modelType; }
			set { _modelType = value; }
		}

		public virtual int UserExecuterId
		{
			get { return _userExecuterId; }
			set { _userExecuterId = value; }
		}

		#endregion Public Properties

		#region Public Methods

		public virtual void Dispose()
		{
			_modelType = null;
		}

		#endregion Public Methods

		#region Private Methods

		private void _SetModelFullName(Type type)
		{
			if (type.IsNull())
				return;
			_modelType = type;
		}

		#endregion Private Methods
	}
}