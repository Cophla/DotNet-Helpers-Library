using CodeHelpers.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public abstract class TableAbstractModel<T> : TableGenericModel<T>, ITableModel<T>
	{
		#region Public Methods

		public abstract bool Delete();

		public abstract bool Delete(SqlConnection connection);

		public abstract bool Delete(SqlConnection connection, SqlTransaction transaction);

		public abstract bool Delete(out string errorMsg);

		public abstract bool Delete(SqlConnection connection, out string errorMsg);

		public abstract bool Delete(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		public abstract bool Delete(MessageString errorMsg);

		public abstract bool Delete(SqlConnection connection, MessageString errorMsg);

		public abstract bool Delete(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		public abstract bool Exists();

		public abstract bool Exists(SqlConnection connection);

		public abstract bool Exists(out string errorMsg);

		public abstract bool Exists(SqlConnection connection, out string errorMsg);

		public abstract bool Exists(MessageString errorMsg);

		public abstract bool Exists(SqlConnection connection, MessageString errorMsg);

		public abstract void Fill(SqlDataReader dataReader);

		public abstract void Fill(DataRow dataRow);

		public abstract void Fill(T primaryKey);

		public abstract void Fill(SqlConnection connection, DataRow dataRow);

		public abstract void Fill(SqlConnection connection, SqlDataReader dataReader);

		public abstract void Fill(SqlConnection connection, T primaryKey);

		public abstract void Fill(T primaryKey, out string errorMsg);

		public abstract void Fill(SqlConnection connection, T primaryKey, out string errorMsg);

		public abstract void Fill(SqlDataReader dataReader, out string errorMsg);

		public abstract void Fill(DataRow dataRow, out string errorMsg);

		public abstract void Fill(SqlConnection connection, SqlDataReader dataReader, out string errorMsg);

		public abstract void Fill(SqlConnection connection, DataRow dataRow, out string errorMsg);

		public abstract void Fill(T primaryKey, MessageString errorMsg);

		public abstract void Fill(SqlConnection connection, T primaryKey, MessageString errorMsg);

		public abstract void Fill(SqlDataReader dataReader, MessageString errorMsg);

		public abstract void Fill(DataRow dataRow, MessageString errorMsg);

		public abstract void Fill(SqlConnection connection, SqlDataReader dataReader, MessageString errorMsg);

		public abstract void Fill(SqlConnection connection, DataRow dataRow, MessageString errorMsg);

		public abstract bool Insert();

		public abstract bool Insert(SqlConnection connection);

		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction);

		public abstract bool Insert(out string errorMsg);

		public abstract bool Insert(SqlConnection connection, out string errorMsg);

		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		public abstract bool Insert(MessageString errorMsg);

		public abstract bool Insert(SqlConnection connection, MessageString errorMsg);

		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		public abstract bool IsUsed();

		public abstract bool IsUsed(SqlConnection connection);

		public abstract bool IsUsed(out string errorMsg);

		public abstract bool IsUsed(SqlConnection connection, out string errorMsg);

		public abstract bool IsUsed(MessageString errorMsg);

		public abstract bool IsUsed(SqlConnection connection, MessageString errorMsg);

		public abstract SqlDataReader SelectAll();

		public abstract SqlDataReader SelectAll(out string errorMsg);

		public abstract SqlDataReader SelectAll(MessageString errorMsg);

		public abstract SqlDataReader SelectAll(SqlConnection connection);

		public abstract SqlDataReader SelectAll(SqlConnection connection, out string errorMsg);

		public abstract SqlDataReader SelectAll(SqlConnection connection, MessageString errorMsg);

		public abstract SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior);

		public abstract SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg);

		public abstract SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg);

		public abstract IEnumerable<TblModel> SelectAll<TblModel>() where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(out String errorMsg) where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(MessageString errorMsg) where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(SqlConnection connection) where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(SqlConnection connection, out String errorMsg) where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior) where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, out String errorMsg) where TblModel : ITableModel;

		public abstract IEnumerable<TblModel> SelectAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg) where TblModel : ITableModel;

		public abstract bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName);

		public abstract bool SetEnabled(string tableName);

		public abstract bool SetEnabled(SqlConnection connection, string tableName);

		public abstract bool SetEnabled(string tableName, out string errorMsg);

		public abstract bool SetEnabled(SqlConnection connection, string tableName, out string errorMsg);

		public abstract bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg);

		public abstract bool SetEnabled(string tableName, MessageString errorMsg);

		public abstract bool SetEnabled(SqlConnection connection, string tableName, MessageString errorMsg);

		public abstract bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName, MessageString errorMsg);

		public abstract bool Update();

		public abstract bool Update(SqlConnection connection);

		public abstract bool Update(SqlConnection connection, SqlTransaction transaction);

		public abstract bool Update(out string errorMsg);

		public abstract bool Update(SqlConnection connection, out string errorMsg);

		public abstract bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		public abstract bool Update(MessageString errorMsg);

		public abstract bool Update(SqlConnection connection, MessageString errorMsg);

		public abstract bool Update(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		#endregion Public Methods

		#region Protected Constructors

		protected TableAbstractModel(Type type) : base(type)
		{
		}

		#endregion Protected Constructors
	}
}