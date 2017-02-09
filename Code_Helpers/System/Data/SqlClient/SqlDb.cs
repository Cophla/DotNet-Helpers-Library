using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.System.Data.SqlClient
{
	public class SqlDb : IDisposable
	{
		#region Private Fields

		private CommandBehavior _commandBehavior;

		private CommandType _commandType = CommandType.StoredProcedure;

		private bool _isFullDispose;

		private SqlConnection _sqlConnection;

		private IDictionary<string, SqlParameter> _sqlParmDictionary;

		private string _sqlString;

		private SqlTransaction _sqlTransaction;

		#endregion Private Fields

		#region Public Constructors

		public SqlDb(int capacity) : this(capacity, false)
		{
		}

		public SqlDb(int capacity, SqlConnection connection) : this(capacity, connection, (SqlTransaction)null)
		{
		}

		public SqlDb(int capacity, SqlConnection connection, SqlTransaction transaction)
			: this(capacity, connection, transaction, (string)null)
		{
		}

		public SqlDb(int capacity, SqlConnection connection, SqlTransaction transaction, string sqlString)
			: this(capacity, false)
		{
			_sqlConnection = connection;
			_sqlTransaction = transaction;
			_sqlString = sqlString;
		}

		public SqlDb(int capacity, bool fullDispose)
		{
			_sqlParmDictionary = new Dictionary<string, SqlParameter>(capacity);
			_isFullDispose = fullDispose;
			if (_isFullDispose)
				_commandBehavior = CommandBehavior.CloseConnection;
			else
				_commandBehavior = CommandBehavior.Default;
		}

		#endregion Public Constructors

		#region Public Properties

		public CommandType SQLCommandType
		{
			get { return _commandType; }
			set { _commandType = value; }
		}

		public SqlConnection SQLConnection
		{
			get
			{
				return _sqlConnection;
			}

			set
			{
				_sqlConnection = value;
				if (_sqlConnection.State != ConnectionState.Open)
					_sqlConnection.Open();
			}
		}

		public string SQLString
		{
			get { return _sqlString; }
			set { _sqlString = value; }
		}

		public SqlTransaction SQLTransaction
		{
			get { return _sqlTransaction; }
			set { _sqlTransaction = value; }
		}

		#endregion Public Properties

		#region Public Indexers

		public object this[string parameterName]
		{
			get { return GetObjValue(parameterName); }

			set { AddParm(parameterName, value); }
		}

		#endregion Public Indexers

		#region Public Methods

		public SqlParameter AddOutParm(string parameterName, SqlDbType dbType)
		{
			SqlParameter outParm = SSqlParameter.CreateOut(parameterName, dbType);
			return AddSqlParm(parameterName, outParm);
		}

		public SqlParameter AddOutParm(string parameterName, SqlDbType dbType, int size)
		{
			SqlParameter outParm = SSqlParameter.CreateOut(parameterName, dbType, size);
			return AddSqlParm(parameterName, outParm);
		}

		public SqlParameter AddParm(string parameterName, object value)
		{
			SqlParameter inputParm = SSqlParameter.Create(parameterName, value);
			return AddSqlParm(parameterName, inputParm);
		}

		public SqlParameter AddSqlParm(string parameterName, SqlParameter param)
		{
			if (_sqlParmDictionary.ContainsKey(parameterName))
				_sqlParmDictionary[parameterName] = param;
			else
				_sqlParmDictionary.Add(parameterName, param);
			return param;
		}

		public void Dispose()
		{
			_sqlString = null;
			_sqlParmDictionary.Clear();
			_sqlParmDictionary = null;
			if (_isFullDispose)
			{
				using (_sqlTransaction)
				using (_sqlConnection)
				{ }
			}
			_sqlTransaction = null;
			_sqlConnection = null;
		}

		public int Exec(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Exec(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public int Exec(MessageString errorMsg)
		{
			return _sqlConnection.Exec(
				_sqlTransaction, _commandType, _sqlString, _sqlParmDictionary.Values, errorMsg);
		}

		public int Exec()
		{
			return _sqlConnection.Exec(
				_sqlTransaction, _commandType, _sqlString, _sqlParmDictionary.Values);
		}

		public T ExecScalar<T>(out string errorMsg)
		{
			return ExecScalar<T>(out errorMsg, default(T));
		}

		public T ExecScalar<T>(MessageString errorMsg)
		{
			return ExecScalar<T>(errorMsg, default(T));
		}

		public T ExecScalar<T>()
		{
			return ExecScalar<T>(default(T));
		}

		public T ExecScalar<T>(out string errorMsg, T defaultValue)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return ExecScalar<T>(_errorMsg, defaultValue);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public T ExecScalar<T>(MessageString errorMsg, T defaultValue)
		{
			return _sqlConnection.ExecScalar<T>(
				_sqlTransaction, _commandType, _sqlString, _sqlParmDictionary.Values, defaultValue,
				errorMsg);
		}

		public T ExecScalar<T>(T defaultValue)
		{
			return _sqlConnection.ExecScalar<T>(
				_sqlTransaction, _commandType, _sqlString, _sqlParmDictionary.Values, defaultValue);
		}

		public SqlDataReader Get(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Get(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public SqlDataReader Get()
		{
			return _sqlConnection.Get(
				_sqlString, _commandType, _commandBehavior, _sqlParmDictionary.Values);
		}

		public SqlDataReader Get(MessageString errorMsg)
		{
			return _sqlConnection.Get(
				_sqlString, _commandType, _commandBehavior, _sqlParmDictionary.Values, errorMsg);
		}

		public DataSet GetDataSet(out string errorMsg)
		{
			return Get(out errorMsg).GetDataSet();
		}

		public DataSet GetDataSet()
		{
			return Get().GetDataSet();
		}

		public DataSet GetDataSet(MessageString errorMsg)
		{
			return Get(errorMsg).GetDataSet();
		}

		public DataTable GetDataTable(out string errorMsg)
		{
			return Get(out errorMsg).GetDataTable();
		}

		public DataTable GetDataTable()
		{
			return Get().GetDataTable();
		}

		public DataTable GetDataTable(MessageString errorMsg)
		{
			return Get(errorMsg).GetDataTable();
		}

		public DataView GetDataView(out string errorMsg)
		{
			return Get(out errorMsg).GetDataView();
		}

		public DataView GetDataView()
		{
			return Get().GetDataView();
		}

		public DataView GetDataView(MessageString errorMsg)
		{
			return Get(errorMsg).GetDataView();
		}

		public object GetObjValue(string parameterName)
		{
			if (_sqlParmDictionary.ContainsKey(parameterName))
				return _sqlParmDictionary[parameterName].Value;

			throw new Exception("Parameter Name not found");
		}

		public SqlDataReader GetSingleRow(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetSingleRow(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public SqlDataReader GetSingleRow()
		{
			return _sqlConnection.Get(
				_sqlString, _commandType, CommandBehavior.SingleRow, _sqlParmDictionary.Values);
		}

		public SqlDataReader GetSingleRow(MessageString errorMsg)
		{
			return _sqlConnection.Get(
				_sqlString, _commandType, CommandBehavior.SingleRow, _sqlParmDictionary.Values, errorMsg);
		}

		public T GetValue<T>(string parameterName)
		{
			return GetObjValue(parameterName).DbValueAs<T>();
		}

		#endregion Public Methods
	}
}