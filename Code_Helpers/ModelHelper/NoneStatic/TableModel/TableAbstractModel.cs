using CodeHelpers.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public abstract class TableAbstractModel<T> : TableGenericModel<T>, ITableModel<T>
	{

		#region Protected Constructors

		protected TableAbstractModel(Type type) : base(type)
		{
		}

		public virtual bool Delete()
		{
			using (MessageString errorMsg = new MessageString())
				return Delete(errorMsg);
		}
		public virtual bool Delete(SqlConnection connection)
		{
			using (MessageString _errorMsg = new MessageString())
				return Delete(connection, _errorMsg);
		}
		public abstract bool Delete(MessageString errorMsg);
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
			using (MessageString _errorMsg = new MessageString())
				try
				{
					return Delete(connection, _errorMsg);
				}
				finally
				{
					errorMsg = _errorMsg.ToString();
				}
		}
		public abstract bool Delete(
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
		public abstract bool Exists();
		public abstract bool Exists(SqlConnection connection);
		public abstract bool Exists(MessageString errorMsg);
		public abstract bool Exists(out string errorMsg);
		public abstract bool Exists(SqlConnection connection, MessageString errorMsg);
		public abstract bool Exists(SqlConnection connection, out string errorMsg);
		public abstract void Fill(DataRow dataRow);
		public abstract void Fill(SqlDataReader dataReader);
		public abstract void Fill(T primaryKey);
		public abstract void Fill(DataRow dataRow, out string errorMsg);
		public abstract void Fill(DataRow dataRow, MessageString errorMsg);
		public abstract void Fill(SqlConnection connection, T primaryKey);
		public abstract void Fill(T primaryKey, MessageString errorMsg);
		public abstract void Fill(SqlDataReader dataReader, MessageString errorMsg);
		public abstract void Fill(SqlDataReader dataReader, out string errorMsg);
		public abstract void Fill(T primaryKey, out string errorMsg);
		public abstract void Fill(SqlConnection connection, T primaryKey, MessageString errorMsg);
		public abstract void Fill(SqlConnection connection, T primaryKey, out string errorMsg);
		public abstract new SqlDataReader GetAll();
		public abstract new SqlDataReader GetAll(MessageString errorMsg);
		public abstract new SqlDataReader GetAll(SqlConnection connection);
		public abstract new SqlDataReader GetAll(out string errorMsg);
		public abstract new SqlDataReader GetAll(SqlConnection connection, CommandBehavior commandBehavior);
		public abstract new SqlDataReader GetAll(SqlConnection connection, MessageString errorMsg);
		public abstract new SqlDataReader GetAll(SqlConnection connection, out string errorMsg);
		public abstract new SqlDataReader GetAll(SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg);
		public abstract new SqlDataReader GetAll(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg);
		public abstract new IEnumerable<TblModel> GetAll<TblModel>() where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection) where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(MessageString errorMsg) where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(out string errorMsg) where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior) where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, out string errorMsg) where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg) where TblModel : ITableModel, new();
		public abstract new IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) where TblModel : ITableModel, new();
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