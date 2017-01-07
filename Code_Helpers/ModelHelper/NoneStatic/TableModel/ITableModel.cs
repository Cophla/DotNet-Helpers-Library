using CodeHelpers.ObjectHelper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	
	public interface ITableModel
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



		void Fill(SqlDataReader dataReader);

		
		
		
		void Fill(SqlDataReader dataReader, out string errorMsg);

		
		
		void Fill(DataRow dataRow);

		
		
		
		void Fill(DataRow dataRow, out string errorMsg);

		
		
		
		void Fill(SqlConnection connection, SqlDataReader dataReader);

		
		
		
		
		void Fill(SqlConnection connection, SqlDataReader dataReader, out string errorMsg);

		
		
		
		void Fill(SqlConnection connection, DataRow dataRow);

		
		
		
		
		void Fill(SqlConnection connection, DataRow dataRow, out string errorMsg);

		
		
		bool Insert();

		
		
		
		bool Insert(out string errorMsg);

		
		
		
		bool Insert(SqlConnection connection);

		
		
		
		
		bool Insert(SqlConnection connection, out string errorMsg);

		
		
		
		
		bool Insert(SqlConnection connection, SqlTransaction transaction);

		
		
		
		
		
		bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		
		
		bool IsUsed();

		
		
		
		bool IsUsed(out string errorMsg);

		
		
		
		bool IsUsed(SqlConnection connection);

		
		
		
		
		bool IsUsed(SqlConnection connection, out string errorMsg);

		
		
		SqlDataReader SelectAll();

		
		
		
		SqlDataReader SelectAll(out string errorMsg);

		
		
		
		SqlDataReader SelectAll(SqlConnection connection);

		
		
		
		
		SqlDataReader SelectAll(SqlConnection connection, out string errorMsg);

		
		
		
		
		SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior);

		
		
		
		
		
		SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg);

		
		
		bool Update();

		
		
		
		bool Update(out string errorMsg);

		
		
		
		bool Update(SqlConnection connection);

		
		
		
		
		bool Update(SqlConnection connection, out string errorMsg);

		
		
		
		
		bool Update(SqlConnection connection, SqlTransaction transaction);

		
		
		
		
		
		bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		
		
		
		bool UpdateEnabilityStatus(string tableName);

		
		
		
		
		bool UpdateEnabilityStatus(string tableName, out string errorMsg);

		
		
		
		
		bool UpdateEnabilityStatus(SqlConnection connection, string tableName);

		
		
		
		
		
		bool UpdateEnabilityStatus(SqlConnection connection, string tableName, out string errorMsg);

		
		
		
		
		
		bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName);

		
		
		
		
		
		
		bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg);

		#endregion Public Methods
	}

	
	
	public interface ITableModel<T> : ITableModel
	{
		#region Public Methods

		
		
		void Fill(T primaryKey);

		
		
		
		void Fill(T primaryKey, out string errorMsg);

		
		
		
		void Fill(SqlConnection connection, T primaryKey);

		
		
		
		
		void Fill(SqlConnection connection, T primaryKey, out string errorMsg);

		#endregion Public Methods
	}
}