using CodeHelpers.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public abstract class ATableModel<T> : TableModel<T>, ITableModel<T>
	{

		#region Protected Constructors

		protected ATableModel(Type type) : base(type)
		{
		}

		protected void CheckMessageString(MessageString errorMsg)
		{
			if (errorMsg.IsNull())
				throw new NullReferenceException("MessageString object is empty");
		}

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

		protected abstract bool OnDelete(MessageString errorMsg);
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

		protected abstract bool OnDelete(
			SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);
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
		public abstract bool Exists(MessageString errorMsg);
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
		protected abstract bool OnExists(SqlConnection connection, MessageString errorMsg);
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
		protected abstract bool OnFill(DataRow dataRow, MessageString errorMsg);
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
		protected abstract bool OnFill(T primaryKey, MessageString errorMsg);
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
		protected abstract bool OnFill(SqlDataReader dataReader, MessageString errorMsg);
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
		protected abstract bool OnFill(SqlConnection connection, T primaryKey, MessageString errorMsg);
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
		protected abstract SqlDataReader OnGetAll(MessageString errorMsg);
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
		protected abstract SqlDataReader OnGetAll(
			SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg);
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
		public abstract IEnumerable<TblModel> GetAll<TblModel>() where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection) where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(MessageString errorMsg) where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(out string errorMsg) where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior) where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, out string errorMsg) where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg) where TblModel : ITableModel, new();
		public abstract IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) where TblModel : ITableModel, new();
		public abstract bool Insert();
		public abstract bool Insert(SqlConnection connection);
		public abstract bool Insert(MessageString errorMsg);
		public abstract bool Insert(out string errorMsg);
		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction);
		public abstract bool Insert(SqlConnection connection, MessageString errorMsg);
		public abstract bool Insert(SqlConnection connection, out string errorMsg);
		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);
		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg);
		public abstract bool IsUsed();
		public abstract bool IsUsed(SqlConnection connection);
		public abstract bool IsUsed(MessageString errorMsg);
		public abstract bool IsUsed(out string errorMsg);
		public abstract bool IsUsed(SqlConnection connection, MessageString errorMsg);
		public abstract bool IsUsed(SqlConnection connection, out string errorMsg);
		public abstract bool SetEnabled(string tableName);
		public abstract bool SetEnabled(SqlConnection connection, string tableName);
		public abstract bool SetEnabled(string tableName, MessageString errorMsg);
		public abstract bool SetEnabled(string tableName, out string errorMsg);
		public abstract bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName);
		public abstract bool SetEnabled(SqlConnection connection, string tableName, MessageString errorMsg);
		public abstract bool SetEnabled(SqlConnection connection, string tableName, out string errorMsg);
		public abstract bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName, MessageString errorMsg);
		public abstract bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg);
		public abstract bool Update();
		public abstract bool Update(SqlConnection connection);
		public abstract bool Update(MessageString errorMsg);
		public abstract bool Update(out string errorMsg);
		public abstract bool Update(SqlConnection connection, SqlTransaction transaction);
		public abstract bool Update(SqlConnection connection, MessageString errorMsg);
		public abstract bool Update(SqlConnection connection, out string errorMsg);
		public abstract bool Update(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);
		public abstract bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		#endregion Protected Constructors
	}
}