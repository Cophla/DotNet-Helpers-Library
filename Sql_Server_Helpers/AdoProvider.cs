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

		public static bool ApplyTransaction(SqlTransaction transaction, out string errorMsg)
		{
			string TRANSACTION_NAME = null;
			return ApplyTransaction(transaction, TRANSACTION_NAME, out errorMsg);
		}

		public static bool ApplyTransaction(SqlTransaction transaction, string TRANSACTION_NAME, out string errorMsg)
		{
			errorMsg = string.Empty;
			bool result = false;
			try
			{
				transaction.Commit();
				result = true;
			}
			catch (Exception ex)
			{
				errorMsg = ex.ToString();
				try
				{
					if (SString.IsNotNone(TRANSACTION_NAME))
					{
						transaction.Rollback(TRANSACTION_NAME);
					}
					else
					{
						transaction.Rollback();
					}
				}
				catch (Exception)
				{
					errorMsg = $"{errorMsg}{ex.ToString()}";
				}
			}
			return result;
		}

		public static bool ApplyTransaction(SqlConnection connection, out string transactionError, ApplySqlTransActionMethod myMethodCall)
		{
			bool result = false;
			string TRANSACTION_NAME = Guid.NewGuid().ToString().Substring(
				0, CstVars.MAX_SQL_TRANSACTION_NAME_LENGTH
			);
			using (SqlTransaction transaction = connection.BeginTransaction(TRANSACTION_NAME))
			{
				result = myMethodCall(transaction, out transactionError);
				if (SBool.IsTrue(result))
				{
					result = ApplyTransaction(transaction, TRANSACTION_NAME, out transactionError);
				}
				else
				{
					try
					{
						transaction.Rollback(TRANSACTION_NAME);
					}
					catch (Exception ex)
					{
						transactionError = $"{transactionError}{ex.ToString()}";
					}
				}
			}

			return result;
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return ExecuteNonQueryStoredProcedure(connection, storedPrcedure, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
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
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			IEnumerable<SqlParameter> outParmList;
			return ExecuteNonQueryStoredProcedure(connection, storedPrcedure, parmList, out outParmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out string errorMsg)
		{
			IEnumerable<SqlParameter> inOutParmList;
			return ExecuteNonQueryStoredProcedure(connection, storedPrcedure, parmList, out outParmList, out inOutParmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="inOutParmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out IEnumerable<SqlParameter> inOutParmList, out string errorMsg)
		{
			SqlParameter returnParm;
			return ExecuteNonQueryStoredProcedure(connection, storedPrcedure, parmList, out outParmList, out inOutParmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="inOutParmList">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out IEnumerable<SqlParameter> inOutParmList, out SqlParameter returnParm, out string errorMsg)
		{
			SqlTransaction transaction = null;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out outParmList, out inOutParmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, out SqlParameter returnParm, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return ExecuteNonQueryStoredProcedure(connection, storedPrcedure, parmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, out SqlParameter returnParm, out string errorMsg)
		{
			IEnumerable<SqlParameter> outParmList;
			return ExecuteNonQueryStoredProcedure(connection, storedPrcedure, parmList, out outParmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out SqlParameter returnParm, out string errorMsg)
		{
			IEnumerable<SqlParameter> inOutParmList;
			return ExecuteNonQueryStoredProcedure(connection, storedPrcedure, parmList, out outParmList, out inOutParmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
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
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
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
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			IEnumerable<SqlParameter> outParmList;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out outParmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out string errorMsg)
		{
			IEnumerable<SqlParameter> inOutParmList;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out outParmList, out inOutParmList, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="inOutParmList">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out IEnumerable<SqlParameter> inOutParmList, out string errorMsg)
		{
			SqlParameter returnParm;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out outParmList, out inOutParmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, out SqlParameter returnParm, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, out SqlParameter returnParm, out string errorMsg)
		{
			IEnumerable<SqlParameter> outParmList;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out outParmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out SqlParameter returnParm, out string errorMsg)
		{
			IEnumerable<SqlParameter> inOutParmList;
			return ExecuteNonQueryStoredProcedure(connection, transaction, storedPrcedure, parmList, out outParmList, out inOutParmList, out returnParm, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="storedPrcedure">
		/// </param>
		/// <param name="parmList">
		/// </param>
		/// <param name="outParmList">
		/// </param>
		/// <param name="inOutParmList">
		/// </param>
		/// <param name="returnParm">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool ExecuteNonQueryStoredProcedure(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, out IEnumerable<SqlParameter> outParmList, out IEnumerable<SqlParameter> inOutParmList, out SqlParameter returnParm, out string errorMsg)
		{
			outParmList = null;
			inOutParmList = null;
			returnParm = null;
			errorMsg = string.Empty;
			bool result = false;
			if (IsDbConnectionOpened(connection, out errorMsg))
			{
				using (SqlCommand command = new SqlCommand(storedPrcedure, connection))
				{
					try
					{
						command.CommandType = CommandType.StoredProcedure;

						if (transaction != null)
						{
							command.Transaction = transaction;
						}

						if (parmList != null)
						{
							foreach (SqlParameter parm in parmList)
							{
								command.Parameters.Add(parm);
							}
						}

						command.ExecuteNonQuery();

						outParmList = parmList.Where(outParm => outParm.Direction == ParameterDirection.Output);
						if (outParmList.Count() == 0)
							outParmList = null;

						inOutParmList = parmList.Where(inOutParm => inOutParm.Direction == ParameterDirection.InputOutput);
						if (inOutParmList.Count() == 0)
							inOutParmList = null;

						returnParm = parmList.SingleOrDefault(returnSqlParm => returnSqlParm.Direction == ParameterDirection.ReturnValue);

						result = true;
					}
					catch (Exception ex) { errorMsg = ex.ToString(); }
				}
			}

			return result;
		}

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
		public static T ExecuteScalarStoredProcedure<T>(SqlConnection connection, SqlTransaction transaction, string storedPrcedure, IEnumerable<SqlParameter> parmList, T defaultValue, out string errorMsg)
		{
			errorMsg = string.Empty;
			T result = defaultValue;
			if (IsDbConnectionOpened(connection, out errorMsg))
			{
				using (SqlCommand command = new SqlCommand(storedPrcedure, connection))
				{
					try
					{
						command.CommandType = CommandType.StoredProcedure;

						if (transaction != null)
						{
							command.Transaction = transaction;
						}

						if (parmList != null)
						{
							foreach (SqlParameter parm in parmList)
							{
								command.Parameters.Add(parm);
							}
						}
						result = SData.ValueAs<T>(command.ExecuteScalar());
					}
					catch (Exception ex) { errorMsg = ex.ToString(); }
				}
			}
			return result;
		}

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

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool IsDbConnectionOpened(SqlConnection connection, out string errorMsg)
		{
			errorMsg = string.Empty;
			bool result = false;
			if (!(result = (connection.State == ConnectionState.Open)))
			{
				errorMsg = "Database connection object is not opened";
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
		private static SqlDataReader GetDataReaderFromSQLNameOrText(SqlConnection connection, string sqlNameOrText, CommandType commandType, CommandBehavior commandBehavior, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			errorMsg = string.Empty;
			SqlDataReader dataReader = null;
			if (IsDbConnectionOpened(connection, out errorMsg))
			{
				using (SqlCommand command = new SqlCommand(sqlNameOrText, connection))
				{
					try
					{
						command.CommandType = commandType;

						if (parmList != null)
						{
							foreach (SqlParameter parm in parmList)
							{
								command.Parameters.Add(parm);
							}
						}

						dataReader = command.ExecuteReader(commandBehavior);
					}
					catch (Exception ex)
					{
						errorMsg = ex.ToString();
					}
				}
			}
			return dataReader;
		}

		private static T GetFromDataReaderUsingGeneric<T>(
					SqlDataReader dataReader
				) where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize, new()
		{
			T data = null;
			if (
				!SCode.IsTypeInList(
					data,
					typeof(DataSet), typeof(DataView), typeof(DataTable)
				)
			)
			{
				throw new Exception("You are not allowed to use this type of object. You are only allowed to use DataSet, DataView or DataTable");
			}
			DataTable dtbl = null;
			using (dataReader)
			{
				if (dataReader != null)
				{
					dtbl = new DataTable();
					dtbl.Load(dataReader);
				}
			}
			if (dtbl != null)
			{
				data = new T();

				if (data is DataSet)
				{
					(data as DataSet).Tables.Add(dtbl);
				}
				else if (data is DataView)
				{
					(data as DataView).Table = dtbl;
				}
				else if (data is DataTable)
				{
					data = SCode.CastAs<T>(dtbl);
				}
			}
			return data;
		}

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