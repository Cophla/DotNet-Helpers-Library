using Code_Helpers;
using Code_Helpers.System;
using Data_Helpers;
using Data_Helpers.GDb.GTbl.GCommon;
using Guide_Helpers.Cst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Sql_Server_Helpers
{
	/// <summary>
	/// </summary>
	public static class AdoProvider
	{
		#region Public Delegates


		#endregion Public Delegates

		#region Public Methods

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, string storedPrcedure, out string errorMsg)
		{
			return ExecuteScalarStoredProcedure(connection, storedPrcedure, default(T), out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="defaultValue">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, string storedPrcedure, T defaultValue, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return ExecuteScalarStoredProcedure(connection, storedPrcedure, parmList, defaultValue, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, out string errorMsg)
		{
			return ExecuteScalarStoredProcedure(connection, transaction, storedPrcedure, default(T), out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="defaultValue">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, T defaultValue, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return ExecuteScalarStoredProcedure(connection, transaction, storedPrcedure, parmList, defaultValue, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			return ExecuteScalarStoredProcedure(connection, storedPrcedure, parmList, default(T), out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="defaultValue">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, T defaultValue, out string errorMsg)
		{
			SqlTransaction transaction = null;
			return ExecuteScalarStoredProcedure(connection, transaction, storedPrcedure, parmList, defaultValue, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			return ExecuteScalarStoredProcedure(connection, transaction, storedPrcedure, parmList, default(T), out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="defaultValue">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="sqlText">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static SqlDataReader GetDataReaderFromSQLText(SqlConnection connection, string sqlText, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			return GetDataReaderFromSQLNameOrText(connection, sqlText, CommandType.Text, CommandBehavior.Default, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="sqlText">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static SqlDataReader GetDataReaderFromSQLText(SqlConnection connection, string sqlText, out string errorMsg)
		{
			return GetDataReaderFromSQLNameOrText(connection, sqlText, CommandType.Text, CommandBehavior.Default, null, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="sqlText">
		/// </param>
		/// <param name="commandBehavior">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static SqlDataReader GetDataReaderFromSQLText(SqlConnection connection, string sqlText, CommandBehavior commandBehavior, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return GetDataReaderFromSQLNameOrText(connection, sqlText, CommandType.Text, commandBehavior, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedProcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static SqlDataReader GetDataReaderFromStoredProcedure(SqlConnection connection, string storedProcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			return GetDataReaderFromSQLNameOrText(connection, storedProcedure, CommandType.StoredProcedure, CommandBehavior.Default, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedProcedure">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static SqlDataReader GetDataReaderFromStoredProcedure(SqlConnection connection, string storedProcedure, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return GetDataReaderFromSQLNameOrText(connection, storedProcedure, CommandType.StoredProcedure, CommandBehavior.Default, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedProcedure">
		/// </param>
		/// <param name="commandBehavior">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static SqlDataReader GetDataReaderFromStoredProcedure(SqlConnection connection, string storedProcedure, CommandBehavior commandBehavior, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return GetDataReaderFromSQLNameOrText(connection, storedProcedure, CommandType.StoredProcedure, commandBehavior, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedProcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static DataSet GetDataSetFromStoredProcedure(SqlConnection connection, string storedProcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			return GetFromStoredProcedureUsingGeneric<DataSet>(connection, storedProcedure, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedProcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static DataTable GetDataTableFromStoredProcedure(SqlConnection connection, string storedProcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			return GetFromStoredProcedureUsingGeneric<DataTable>(connection, storedProcedure, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedProcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static DataView GetDataViewFromStoredProcedure(SqlConnection connection, string storedProcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			return GetFromStoredProcedureUsingGeneric<DataView>(connection, storedProcedure, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <returns>
		/// </returns>
		public static IEnumerable<T> GetObjList<T>() where T : IGTbl, new()
		{
			string errorMsg;
			return GetObjList<T>(out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static IEnumerable<T> GetObjList<T>(SqlConnection connection, out string errorMsg) where T : IGTbl, new()
		{
			return GetObjList<T>(new T().SelectAll(connection, out errorMsg));
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="commandBehavior">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static IEnumerable<T> GetObjList<T>(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg) where T : IGTbl, new()
		{
			return GetObjList<T>(new T().SelectAll(connection, commandBehavior, out errorMsg));
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static IEnumerable<T> GetObjList<T>(out string errorMsg) where T : IGTbl, new()
		{
			return GetObjList<T>(new T().SelectAll(out errorMsg));
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="dataReader">
		/// </param>
		/// <returns>
		/// </returns>
		public static IEnumerable<T> GetObjList<T>(SqlDataReader dataReader) where T : IGTbl, new()
		{
			string errorMsg;
			return GetObjList<T>(dataReader, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="dataReader">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static IEnumerable<T> GetObjList<T>(SqlDataReader dataReader, out string errorMsg) where T : IGTbl, new()
		{
			errorMsg = string.Empty;
			ICollection<T> objList = null;
			using (dataReader)
			{
				if (dataReader != null)
				{
					try
					{
						objList = new List<T>(40);
						while (dataReader.Read())
						{
							T obj = new T();
							obj.Fill(dataReader);
							objList.Add(obj);
						}
					}
					catch (Exception ex) { errorMsg = ex.ToString(); }
				}
			}
			return objList;
		}

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public static IEnumerable<T> GetObjList<T>(SqlConnection connection) where T : IGTbl, new()
		{
			string errorMsg;
			return GetObjList<T>(connection, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool IsConnectionReady(SqlConnection connection)
		{
			bool result = false;
			string errorMsg;
			using (SqlDataReader dataReader = GetDataReaderFromSQLText(connection, "SELECT 1", out errorMsg))
			{
				if (dataReader != null)
				{
					result = true;
				}
			}
			return result;
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="sqlNameOrText">
		/// </param>
		/// <param name="commandType">
		/// </param>
		/// <param name="commandBehavior">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		

		/// <summary>
		/// </summary>
		/// <typeparam name="T">
		/// </typeparam>
		/// <param name="connection">
		/// </param>
		/// <param name="storedProcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		private static T GetFromStoredProcedureUsingGeneric<T>(
			SqlConnection connection, string storedProcedure, IEnumerable<SqlParameter> parmList, out string errorMsg
		) where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize, new()
		{
			return GetFromDataReaderUsingGeneric<T>(
				GetDataReaderFromStoredProcedure(
					connection, storedProcedure, parmList, out errorMsg
				)
			);
		}

		#endregion Private Methods
	}
}