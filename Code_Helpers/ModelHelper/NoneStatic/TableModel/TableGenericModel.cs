using CodeHelpers.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public class TableGenericModel : GlobalModel
	{
		#region Public Constructors

		public TableGenericModel() : this(typeof(TableGenericModel))
		{
		}

		#endregion Public Constructors

		#region Public Methods

		public override void Dispose()
		{
			_spnDelete = null;
			_spnInsert = null;
			_spnGetAll = null;
			_spnUpdate = null;
			_spnExists = null;
			_spnIsUsed = null;
			_spnSetEnabled = null;
	}

		#endregion Public Methods

		#region Protected Fields

		protected string _spnDelete;

		protected string _spnInsert;

		protected string _spnGetAll;

		protected string _spnUpdate;
		protected string _spnExists;
		protected string _spnIsUsed;
		protected string _spnSetEnabled;

		#endregion Protected Fields

		#region Protected Constructors

		protected TableGenericModel(Type type) : base(type)
		{
		}

		#endregion Protected Constructors

		public static SqlDataReader GetAllDataReader<TblModel>()
			where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAllDataReader<TblModel>(errorMsg);
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>() where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAllObjList<TblModel>(errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(out string errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAllDataReader<TblModel>(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
			
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(out string errorMsg)
			where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAllObjList<TblModel>(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public static SqlDataReader GetAllDataReader<TblModel>(MessageString errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (TblModel model = new TblModel())
				return model.GetAll(errorMsg);
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(MessageString errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (SqlDataReader dataReader = GetAllDataReader<TblModel>(errorMsg))
			{
				if (dataReader.IsNull())
					return null;

				ICollection<TblModel> objList = new List<TblModel>(40);
				while (dataReader.Read())
				{
					TblModel model = new TblModel();
					model.Fill(dataReader);
					objList.Add(model);
				}
				return objList;
			}
		}

		public static SqlDataReader GetAllDataReader<TblModel>(SqlConnection connection) 
			where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAllDataReader<TblModel>(connection, errorMsg);
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(SqlConnection connection) 
			where TblModel : ITableModel, new()
		{
			using(MessageString errorMsg = new MessageString())
				return GetAllObjList<TblModel>(connection, errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, out string errorMsg) where TblModel : ITableModel, new()
		{
			return GetAllDataReader<TblModel>(connection, CommandBehavior.Default, out errorMsg);
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(
			SqlConnection connection, out string errorMsg) where TblModel : ITableModel, new()
		{
			return GetAllObjList<TblModel>(connection, CommandBehavior.Default, out errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel, new()
		{
			return GetAllDataReader<TblModel>(connection, CommandBehavior.Default, errorMsg);
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(
			SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel, new()
		{
			return GetAllObjList<TblModel>(connection, CommandBehavior.Default, errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior) 
			where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAllDataReader<TblModel>(connection, commandBehavior, errorMsg);
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior) 
			where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAllObjList<TblModel>(connection, commandBehavior, errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAllDataReader<TblModel>(connection, commandBehavior, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAllObjList<TblModel>(connection, commandBehavior, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (TblModel model = new TblModel())
				return model.GetAll(connection, commandBehavior, errorMsg);
		}

		public static IEnumerable<TblModel> GetAllObjList<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (SqlDataReader dataReader = GetAllDataReader<TblModel>(
				connection, commandBehavior, errorMsg))
			{
				if (dataReader.IsNull())
					return null;

				ICollection<TblModel> objList = new List<TblModel>(40);
				while (dataReader.Read())
				{
					TblModel model = new TblModel();
					model.Fill(dataReader);
					objList.Add(model);
				}
				return objList;
			}
		}
	}

	public class TableGenericModel<T> : TableGenericModel
	{
		#region Public Constructors

		public TableGenericModel() : this(typeof(TableGenericModel<T>))
		{
		}

		#endregion Public Constructors

		#region Public Properties

		public T PrimaryKey {
			get { return _primaryKey; }
			set { _primaryKey = value; }
		}

		#endregion Public Properties

		#region Public Methods

		public override void Dispose()
		{
			base.Dispose();

			if (_primaryKey is IDisposable)
				(_primaryKey as IDisposable).Dispose();

			_primaryKey = default(T);
		}

		#endregion Public Methods

		#region Protected Fields

		protected T _primaryKey;

		#endregion Protected Fields

		#region Protected Constructors

		protected TableGenericModel(Type type) : base(type)
		{
		}

		#endregion Protected Constructors
	}
}