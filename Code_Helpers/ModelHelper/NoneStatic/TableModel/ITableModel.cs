using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CodeHelpers.System;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public interface ITableModel : IDisposable
	{
		#region Public Methods

		bool Delete();

		bool Delete(out string errorMsg);

		bool Delete(MessageString errorMsg);

		bool Delete(SqlConnection connection);

		bool Delete(SqlConnection connection, out string errorMsg);

		bool Delete(SqlConnection connection, MessageString errorMsg);

		bool Delete(SqlConnection connection, SqlTransaction transaction);

		bool Delete(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		bool Delete(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		bool Exists();

		bool Exists(out string errorMsg);

		bool Exists(MessageString errorMsg);

		bool Exists(SqlConnection connection);

		bool Exists(SqlConnection connection, out string errorMsg);

		bool Exists(SqlConnection connection, MessageString errorMsg);

		bool Fill(SqlDataReader dataReader);

		bool Fill(SqlDataReader dataReader, out string errorMsg);

		bool Fill(SqlDataReader dataReader, MessageString errorMsg);

		bool Fill(DataRow dataRow);

		bool Fill(DataRow dataRow, out string errorMsg);

		bool Fill(DataRow dataRow, MessageString errorMsg);

		SqlDataReader GetAll();

		IEnumerable<TblModel> GetAll<TblModel>() where TblModel : ITableModel, new();

		SqlDataReader GetAll(out string errorMsg);

		IEnumerable<TblModel> GetAll<TblModel>(out string errorMsg) where TblModel : ITableModel, new();

		SqlDataReader GetAll(MessageString errorMsg);

		IEnumerable<TblModel> GetAll<TblModel>(MessageString errorMsg) where TblModel : ITableModel, new();

		SqlDataReader GetAll(SqlConnection connection);

		IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection) where TblModel : ITableModel, new();

		SqlDataReader GetAll(SqlConnection connection, out string errorMsg);

		IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, out string errorMsg) where TblModel : ITableModel, new();

		SqlDataReader GetAll(SqlConnection connection, MessageString errorMsg);

		IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, MessageString errorMsg) where TblModel : ITableModel, new();

		SqlDataReader GetAll(SqlConnection connection, CommandBehavior commandBehavior);

		IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior) where TblModel : ITableModel, new();

		SqlDataReader GetAll(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg);

		IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) where TblModel : ITableModel, new();

		SqlDataReader GetAll(SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg);

		IEnumerable<TblModel> GetAll<TblModel>(SqlConnection connection, CommandBehavior commandBehavior, MessageString errorMsg) where TblModel : ITableModel, new();

		bool Insert();

		bool Insert(out string errorMsg);

		bool Insert(MessageString errorMsg);

		bool Insert(SqlConnection connection);

		bool Insert(SqlConnection connection, out string errorMsg);

		bool Insert(SqlConnection connection, MessageString errorMsg);

		bool Insert(SqlConnection connection, SqlTransaction transaction);

		bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		bool Insert(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		bool IsUsed();

		bool IsUsed(out string errorMsg);

		bool IsUsed(MessageString errorMsg);

		bool IsUsed(SqlConnection connection);

		bool IsUsed(SqlConnection connection, out string errorMsg);

		bool IsUsed(SqlConnection connection, MessageString errorMsg);

		bool SetEnabled(string tableName);

		bool SetEnabled(string tableName, out string errorMsg);

		bool SetEnabled(string tableName, MessageString errorMsg);

		bool SetEnabled(SqlConnection connection, string tableName);

		bool SetEnabled(SqlConnection connection, string tableName, out string errorMsg);

		bool SetEnabled(SqlConnection connection, string tableName, MessageString errorMsg);

		bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName);

		bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg);

		bool SetEnabled(SqlConnection connection, SqlTransaction transaction, string tableName, MessageString errorMsg);

		bool Update();

		bool Update(out string errorMsg);

		bool Update(MessageString errorMsg);

		bool Update(SqlConnection connection);

		bool Update(SqlConnection connection, out string errorMsg);

		bool Update(SqlConnection connection, MessageString errorMsg);

		bool Update(SqlConnection connection, SqlTransaction transaction);

		bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		bool Update(SqlConnection connection, SqlTransaction transaction, MessageString errorMsg);

		#endregion Public Methods
	}

	public interface ITableModel<T> : ITableModel
	{
		#region Public Methods

		bool Fill(T primaryKey);

		bool Fill(T primaryKey, out string errorMsg);

		bool Fill(T primaryKey, MessageString errorMsg);

		bool Fill(SqlConnection connection, T primaryKey);

		bool Fill(SqlConnection connection, T primaryKey, out string errorMsg);

		bool Fill(SqlConnection connection, T primaryKey, MessageString errorMsg);

		#endregion Public Methods
	}
}