using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Helpers.GDb.GTbl.GCommon
{
	/// <summary></summary>
	public interface IGTbl : IDisposable
	{
		#region Public Methods

		/// <summary></summary>
		/// <returns></returns>
		bool Delete();

		/// <summary></summary>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Delete(out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		bool Delete(SqlConnection connection);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Delete(SqlConnection connection, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <returns></returns>
		bool Delete(SqlConnection connection, SqlTransaction transaction);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Delete(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		/// <summary></summary>
		/// <returns></returns>
		bool Exists();

		/// <summary></summary>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Exists(out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		bool Exists(SqlConnection connection);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Exists(SqlConnection connection, out string errorMsg);

		/// <summary></summary>
		/// <param name="dataReader"></param>
		void Fill(SqlDataReader dataReader);

		/// <summary></summary>
		/// <param name="dataReader"></param>
		/// <param name="errorMsg"></param>
		void Fill(SqlDataReader dataReader, out string errorMsg);

		/// <summary></summary>
		/// <param name="dataRow"></param>
		void Fill(DataRow dataRow);

		/// <summary></summary>
		/// <param name="dataRow"></param>
		/// <param name="errorMsg"></param>
		void Fill(DataRow dataRow, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="dataReader"></param>
		void Fill(SqlConnection connection, SqlDataReader dataReader);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="dataReader"></param>
		/// <param name="errorMsg"></param>
		void Fill(SqlConnection connection, SqlDataReader dataReader, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="dataRow"></param>
		void Fill(SqlConnection connection, DataRow dataRow);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="dataRow"></param>
		/// <param name="errorMsg"></param>
		void Fill(SqlConnection connection, DataRow dataRow, out string errorMsg);

		/// <summary></summary>
		/// <returns></returns>
		bool Insert();

		/// <summary></summary>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Insert(out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		bool Insert(SqlConnection connection);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Insert(SqlConnection connection, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <returns></returns>
		bool Insert(SqlConnection connection, SqlTransaction transaction);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		/// <summary></summary>
		/// <returns></returns>
		bool IsUsed();

		/// <summary></summary>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool IsUsed(out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		bool IsUsed(SqlConnection connection);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool IsUsed(SqlConnection connection, out string errorMsg);

		/// <summary></summary>
		/// <returns></returns>
		SqlDataReader SelectAll();

		/// <summary></summary>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		SqlDataReader SelectAll(out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		SqlDataReader SelectAll(SqlConnection connection);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		SqlDataReader SelectAll(SqlConnection connection, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="commandBehavior"></param>
		/// <returns></returns>
		SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="commandBehavior"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg);

		/// <summary></summary>
		/// <returns></returns>
		bool Update();

		/// <summary></summary>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Update(out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		bool Update(SqlConnection connection);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Update(SqlConnection connection, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <returns></returns>
		bool Update(SqlConnection connection, SqlTransaction transaction);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		/// <summary></summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		bool UpdateEnabilityStatus(string tableName);

		/// <summary></summary>
		/// <param name="tableName"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool UpdateEnabilityStatus(string tableName, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		bool UpdateEnabilityStatus(SqlConnection connection, string tableName);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="tableName"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool UpdateEnabilityStatus(SqlConnection connection, string tableName, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <param name="tableName"></param>
		/// <param name="errorMsg"></param>
		/// <returns></returns>
		bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg);

		#endregion Public Methods
	}

	/// <summary></summary>
	/// <typeparam name="T"></typeparam>
	public interface IGTbl<T> : IGTbl
	{
		#region Public Methods

		/// <summary></summary>
		/// <param name="primaryKey"></param>
		void Fill(T primaryKey);

		/// <summary></summary>
		/// <param name="primaryKey"></param>
		/// <param name="errorMsg"></param>
		void Fill(T primaryKey, out string errorMsg);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="primaryKey"></param>
		void Fill(SqlConnection connection, T primaryKey);

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <param name="primaryKey"></param>
		/// <param name="errorMsg"></param>
		void Fill(SqlConnection connection, T primaryKey, out string errorMsg);

		#endregion Public Methods
	}
}