using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CodeHelpers.System;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public abstract class ATableModel<T> : TableModel<T>, ITableModel<T>
	{
		#region Protected Constructors

		protected ATableModel(Type type) : base(type)
		{
		}

		#endregion Protected Constructors

		#region Public Methods

		public virtual bool Delete()
		{
			using (MessageString _errorMsg = new MessageString())
				return Delete(_errorMsg);
		}

		public virtual bool Delete(SqlConnection connection)
		{
			using (MessageString _errorMsg = new MessageString())
				return Delete(connection, _errorMsg);
		}

		public virtual bool Delete(MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnDelete(errorMsg);
		}

		public virtual bool Delete(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Delete(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Delete(SqlConnection connection, MessageString errorMsg)
		{
			SqlTransaction transaction = null;
			return Delete(connection, transaction, errorMsg);
		}

		public virtual bool Delete(SqlConnection connection, SqlTransaction transaction)
		{
			using (MessageString _errorMsg = new MessageString())
				return Delete(connection, transaction, _errorMsg);
		}

		public virtual bool Delete(SqlConnection connection, out string errorMsg)
		{
			SqlTransaction transaction = null;
			return Delete(connection, transaction, out errorMsg);
		}

		public virtual bool Delete(
			SqlConnection connection, SqlTransaction transaction, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnDelete(connection, transaction, errorMsg);
		}

		public virtual bool Delete(
			SqlConnection connection, SqlTransaction transaction, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Delete(connection, transaction, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Exists()
		{
			using (MessageString _errorMsg = new MessageString())
				return Exists(_errorMsg);
		}

		public virtual bool Exists(SqlConnection connection)
		{
			using (MessageString _errorMsg = new MessageString())
				return Exists(connection, _errorMsg);
		}

		public virtual bool Exists(MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnExists(errorMsg);
		}
		protected abstract bool OnExists(MessageString errorMsg);

		public virtual bool Exists(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Exists(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Exists(SqlConnection connection, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnExists(connection, errorMsg);
		}

		public virtual bool Exists(SqlConnection connection, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Exists(connection, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Fill(DataRow dataRow)
		{
			using (MessageString _errorMsg = new MessageString())
				return Fill(dataRow, _errorMsg);
		}

		public virtual bool Fill(SqlDataReader dataReader)
		{
			using (MessageString _errorMsg = new MessageString())
				return Fill(dataReader, _errorMsg);
		}

		public virtual bool Fill(T primaryKey)
		{
			using (MessageString _errorMsg = new MessageString())
				return Fill(primaryKey, _errorMsg);
		}

		public virtual bool Fill(DataRow dataRow, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Fill(dataRow, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Fill(DataRow dataRow, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnFill(dataRow, errorMsg);
		}

		public virtual bool Fill(SqlConnection connection, T primaryKey)
		{
			using (MessageString _errorMsg = new MessageString())
				return Fill(connection, primaryKey, _errorMsg);
		}

		public virtual bool Fill(T primaryKey, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnFill(primaryKey, errorMsg);
		}

		public virtual bool Fill(SqlDataReader dataReader, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			if (dataReader.IsNull())
			{
				errorMsg.AppendLine($"SqlDataReader is null.");
				errorMsg.AppendLine($"Filling model object {_modelType.FullName} is broken.");
				return false;
			}
			if (dataReader.HasRows.IsFalse())
			{
				errorMsg.AppendLine($"SqlDataReader is empty or has no rows");
				errorMsg.AppendLine($"Filling model object {_modelType.FullName} is broken.");
				return false;
			}
			return OnFill(dataReader, errorMsg);
		}

		public virtual bool Fill(SqlDataReader dataReader, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Fill(dataReader, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Fill(T primaryKey, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Fill(primaryKey, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Fill(SqlConnection connection, T primaryKey, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnFill(connection, primaryKey, errorMsg);
		}

		public virtual bool Fill(SqlConnection connection, T primaryKey, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Fill(connection, primaryKey, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual SqlDataReader GetAll()
		{
			using (MessageString _errorMsg = new MessageString())
				return GetAll(_errorMsg);
		}

		public virtual SqlDataReader GetAll(MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnGetAll(errorMsg);
		}

		public virtual SqlDataReader GetAll(SqlConnection connection)
		{
			using (MessageString _errorMsg = new MessageString())
				return GetAll(connection, _errorMsg);
		}

		public virtual SqlDataReader GetAll(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAll(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual SqlDataReader GetAll(SqlConnection connection, CommandBehavior commandBehavior)
		{
			using (MessageString _errorMsg = new MessageString())
				return GetAll(connection, commandBehavior, _errorMsg);
		}

		public virtual SqlDataReader GetAll(SqlConnection connection, MessageString errorMsg)
		{
			return GetAll(connection, CommandBehavior.Default, errorMsg);
		}

		public virtual SqlDataReader GetAll(SqlConnection connection, out string errorMsg)
		{
			return GetAll(connection, CommandBehavior.Default, out errorMsg);
		}

		public virtual SqlDataReader GetAll(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnGetAll(connection, commandBehavior, errorMsg);
		}

		public virtual SqlDataReader GetAll(
			SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAll(connection, commandBehavior, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>() where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				return GetAll<TblModel>(_errorMsg);
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection)
			where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				return GetAll<TblModel>(connection, _errorMsg);
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(MessageString errorMsg)
			where TblModel : ITableModel, new()
		{
			CheckMessageString(errorMsg);
			return OnGetAll<TblModel>(errorMsg);
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(out string errorMsg) where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAll<TblModel>(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior)
			where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				return GetAll<TblModel>(connection, commandBehavior, _errorMsg);
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, MessageString errorMsg)
			where TblModel : ITableModel, new()
		{
			return GetAll<TblModel>(connection, CommandBehavior.Default, errorMsg);
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, out string errorMsg)
			where TblModel : ITableModel, new()
		{
			return GetAll<TblModel>(connection, CommandBehavior.Default, out errorMsg);
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg)
			where TblModel : ITableModel, new()
		{
			CheckMessageString(errorMsg);
			return OnGetAll<TblModel>(connection, commandBehavior, errorMsg);
		}

		public virtual IEnumerable<TblModel> GetAll<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg)
			where TblModel : ITableModel, new()
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return GetAll<TblModel>(connection, commandBehavior, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Insert()
		{
			using (MessageString _errorMsg = new MessageString())
				return Insert(_errorMsg);
		}

		public virtual bool Insert(SqlConnection connection)
		{
			using (MessageString _errorMsg = new MessageString())
				return Insert(connection, _errorMsg);
		}

		public virtual bool Insert(MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnInsert(errorMsg);
		}

		public virtual bool Insert(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Insert(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Insert(SqlConnection connection, SqlTransaction transaction)
		{
			using (MessageString _errorMsg = new MessageString())
				return Insert(connection, transaction, _errorMsg);
		}

		public virtual bool Insert(SqlConnection connection, MessageString errorMsg)
		{
			SqlTransaction transaction = null;
			return Insert(connection, transaction, errorMsg);
		}

		public virtual bool Insert(SqlConnection connection, out string errorMsg)
		{
			SqlTransaction transaction = null;
			return Insert(connection, transaction, out errorMsg);
		}

		public virtual bool Insert(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnInsert(connection, transaction, errorMsg);
		}

		public virtual bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Insert(connection, transaction, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool IsUsed()
		{
			using (MessageString _errorMsg = new MessageString())
				return IsUsed(_errorMsg);
		}

		public virtual bool IsUsed(SqlConnection connection)
		{
			using (MessageString _errorMsg = new MessageString())
				return IsUsed(connection, _errorMsg);
		}

		public virtual bool IsUsed(MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnIsUsed(errorMsg);
		}

		public virtual bool IsUsed(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return IsUsed(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool IsUsed(SqlConnection connection, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnIsUsed(connection, errorMsg);
		}

		public virtual bool IsUsed(SqlConnection connection, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return IsUsed(connection, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool SetEnabled(string tableName)
		{
			using (MessageString _errorMsg = new MessageString())
				return SetEnabled(tableName, _errorMsg);
		}

		public virtual bool SetEnabled(SqlConnection connection, string tableName)
		{
			using (MessageString _errorMsg = new MessageString())
				return SetEnabled(connection, tableName, _errorMsg);
		}

		public virtual bool SetEnabled(string tableName, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnSetEnabled(tableName, errorMsg);
		}

		public virtual bool SetEnabled(string tableName, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return SetEnabled(tableName, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName)
		{
			using (MessageString _errorMsg = new MessageString())
				return SetEnabled(connection, transaction, tableName, _errorMsg);
		}

		public virtual bool SetEnabled(SqlConnection connection, string tableName, MessageString errorMsg)
		{
			SqlTransaction transaction = null;
			return SetEnabled(connection, transaction, tableName, errorMsg);
		}

		public virtual bool SetEnabled(SqlConnection connection, string tableName, out string errorMsg)
		{
			SqlTransaction transaction = null;
			return SetEnabled(connection, transaction, tableName, out errorMsg);
		}

		public virtual bool SetEnabled(
			SqlConnection connection, SqlTransaction transaction, string tableName, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnSetEnabled(connection, transaction, tableName, errorMsg);
		}

		public virtual bool SetEnabled(
			SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return SetEnabled(connection, transaction, tableName, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Update()
		{
			using (MessageString _errorMsg = new MessageString())
				return Update(_errorMsg);
		}

		public virtual bool Update(SqlConnection connection)
		{
			using (MessageString _errorMsg = new MessageString())
				return Update(connection, _errorMsg);
		}

		public virtual bool Update(MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnUpdate(errorMsg);
		}

		public virtual bool Update(out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Update(_errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		public virtual bool Update(SqlConnection connection, SqlTransaction transaction)
		{
			using (MessageString _errorMsg = new MessageString())
				return Update(connection, transaction, _errorMsg);
		}

		public virtual bool Update(SqlConnection connection, MessageString errorMsg)
		{
			SqlTransaction transaction = null;
			return Update(connection, transaction, errorMsg);
		}

		public virtual bool Update(SqlConnection connection, out string errorMsg)
		{
			SqlTransaction transaction = null;
			return Update(connection, transaction, out errorMsg);
		}

		public virtual bool Update(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg)
		{
			CheckMessageString(errorMsg);
			return OnUpdate(connection, transaction, errorMsg);
		}

		public virtual bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg)
		{
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Update(connection, transaction, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}

		#endregion Public Methods

		#region Protected Methods

		protected void CheckMessageString(MessageString errorMsg)
		{
			if (errorMsg.IsNull())
				throw new NullReferenceException("MessageString object is empty");
		}

		protected abstract bool OnDelete(MessageString errorMsg);

		protected abstract bool OnDelete(
			SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		protected abstract bool OnExists(SqlConnection connection, MessageString errorMsg);

		protected abstract bool OnFill(DataRow dataRow, MessageString errorMsg);

		protected abstract bool OnFill(T primaryKey, MessageString errorMsg);

		protected abstract bool OnFill(SqlDataReader dataReader, MessageString errorMsg);

		protected abstract bool OnFill(SqlConnection connection, T primaryKey, MessageString errorMsg);

		protected abstract SqlDataReader OnGetAll(MessageString errorMsg);

		protected abstract SqlDataReader OnGetAll(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg);

		protected abstract IEnumerable<TblModel> OnGetAll<TblModel>(MessageString errorMsg)
			where TblModel : ITableModel, new();

		protected abstract IEnumerable<TblModel> OnGetAll<TblModel>(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg)
			where TblModel : ITableModel, new();

		protected abstract bool OnInsert(MessageString errorMsg);

		protected abstract bool OnInsert(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		protected abstract bool OnIsUsed(MessageString errorMsg);

		protected abstract bool OnIsUsed(SqlConnection connection, MessageString errorMsg);

		protected abstract bool OnSetEnabled(string tableName, MessageString errorMsg);

		protected abstract bool OnSetEnabled(
			SqlConnection connection, SqlTransaction transaction, string tableName, MessageString errorMsg);

		protected abstract bool OnUpdate(MessageString errorMsg);

		protected abstract bool OnUpdate(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		#endregion Protected Methods
	}
}