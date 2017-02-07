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
			_deleteStoredProcdureName = null;
			_insertStoredProcdureName = null;
			_selectAllStoredProcdureName = null;
			_updateStoredProcdureName = null;
		}

		#endregion Public Methods

		#region Protected Fields

		protected string _deleteStoredProcdureName;

		protected string _insertStoredProcdureName;

		protected string _selectAllStoredProcdureName;

		protected string _updateStoredProcdureName;

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

		public static IEnumerable<TblModel> GetAll<TblModel>() where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAll<TblModel>(errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(out string errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (TblModel model = new TblModel())
				return model.GetAll(out errorMsg);
		}

		public static IEnumerable<TblModel> GetAll<TblModel>(out string errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (SqlDataReader dataReader = GetAllDataReader<TblModel>(out errorMsg))
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

		public static SqlDataReader GetAllDataReader<TblModel>(MessageString errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (TblModel model = new TblModel())
				return model.GetAll(errorMsg);
		}

		public static IEnumerable<TblModel> GetAll<TblModel>(MessageString errorMsg) 
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

		public static IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection) 
			where TblModel : ITableModel, new()
		{
			using(MessageString errorMsg = new MessageString())
				return GetAll<TblModel>(connection, errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, out string errorMsg) where TblModel : ITableModel, new()
		{
			return GetAllDataReader<TblModel>(connection, CommandBehavior.Default, out errorMsg);
		}

		public static IEnumerable<TblModel> GetAll<TblModel>(
			SqlConnection connection, out string errorMsg) where TblModel : ITableModel, new()
		{
			return GetAll<TblModel>(connection, CommandBehavior.Default, out errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel, new()
		{
			return GetAllDataReader<TblModel>(connection, CommandBehavior.Default, errorMsg);
		}

		public static IEnumerable<TblModel> GetAll<TblModel>(
			SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel, new()
		{
			return GetAll<TblModel>(connection, CommandBehavior.Default, errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior) 
			where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAllDataReader<TblModel>(connection, commandBehavior, errorMsg);
		}

		public static IEnumerable<TblModel> GetAll<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior) 
			where TblModel : ITableModel, new()
		{
			using (MessageString errorMsg = new MessageString())
				return GetAll<TblModel>(connection, commandBehavior, errorMsg);
		}

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (TblModel model = new TblModel())
				return model.GetAll(connection, commandBehavior, out errorMsg);
		}

		public static IEnumerable<TblModel> GetAll<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (SqlDataReader dataReader = GetAllDataReader<TblModel>(
				connection, commandBehavior, out errorMsg))
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

		public static SqlDataReader GetAllDataReader<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg) 
			where TblModel : ITableModel, new()
		{
			using (TblModel model = new TblModel())
				return model.GetAll(connection, commandBehavior, errorMsg);
		}

		public static IEnumerable<TblModel> GetAll<TblModel>(
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