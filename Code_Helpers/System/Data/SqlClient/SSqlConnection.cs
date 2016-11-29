using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Code_Helpers.System.Data.SqlClient
{
	public static class SSqlConnection
	{
		#region Public Methods

		public static bool Exec(this SqlConnection connection, CommandType commandType, string sqlText, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			SqlTransaction transaction = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, out errorMsg);
		}

		public static bool Exec(this SqlConnection connection, CommandType commandType, string sqlText, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			SqlTransaction transaction = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, out errorMsg);
		}

		public static bool Exec(this SqlConnection connection, SqlTransaction transaction, CommandType commandType, string sqlText, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, out errorMsg);
		}

		public static bool Exec(this SqlConnection connection, SqlTransaction transaction, CommandType commandType, string sqlText, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			errorMsg = string.Empty;
			if (IsOpened(connection, out errorMsg).IsNotTrue())
				return false;

			using (SqlCommand command = new SqlCommand(sqlText, connection))
			{
				try
				{
					command.CommandType = commandType;

					if (transaction.IsNotNull())
					{
						command.Transaction = transaction;
					}

					if (parmList.IsNotNull())
					{
						foreach (SqlParameter parm in parmList)
						{
							command.Parameters.Add(parm);
						}
					}

					command.ExecuteNonQuery();

					return true;
				}
				catch (Exception ex) { errorMsg = ex.ToString(); }
			}
			return false;
		}

		public static T ExecScalar<T>(this SqlConnection connection, SqlTransaction transaction, CommandType commandType, string sqlText, IEnumerable<SqlParameter> parmList, T defaultValue, out string errorMsg)
		{
			if (IsOpened(connection, out errorMsg).IsNotTrue())
				return defaultValue;

			using (SqlCommand command = new SqlCommand(sqlText, connection))
			{
				try
				{
					command.CommandType = commandType;

					if (transaction.IsNotNull())
					{
						command.Transaction = transaction;
					}

					if (parmList.IsNotNull())
					{
						foreach (SqlParameter parm in parmList)
						{
							command.Parameters.Add(parm);
						}
					}
					return SObject.DbValueAs<T>(command.ExecuteScalar(), defaultValue);
				}
				catch (Exception ex) { errorMsg = ex.ToString(); }
			}

			return defaultValue;
		}

		public static SqlDataReader Get(this SqlConnection connection, string sqlText, CommandType commandType, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return Get(connection, sqlText, commandType, CommandBehavior.Default, parmList, out errorMsg);
		}

		public static SqlDataReader Get(this SqlConnection connection, string sqlText, CommandType commandType, CommandBehavior commandBehavior, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			errorMsg = string.Empty;

			if (IsOpened(connection, out errorMsg).IsNotTrue())
				return null;

			using (SqlCommand command = new SqlCommand(sqlText, connection))
			{
				try
				{
					command.CommandType = commandType;

					if (parmList.IsNotNull())
					{
						foreach (SqlParameter parm in parmList)
						{
							command.Parameters.Add(parm);
						}
					}

					return command.ExecuteReader(commandBehavior);
				}
				catch (Exception ex)
				{
					errorMsg = ex.ToString();
				}
			}
			return null;
		}

		public static bool IsOpened(this SqlConnection connection, out string errorMsg)
		{
			errorMsg = string.Empty;
			if ((connection.State == ConnectionState.Open).IsNotTrue())
			{
				errorMsg = "Database connection object is not opened";
				return false;
			}
			return true;
		}

		public static bool IsReady(SqlConnection connection)
		{
			string errorMsg;
			using (SqlDataReader dataReader = Get(connection, "SELECT TOP 1 1", CommandType.Text, out errorMsg))
			{
				if (dataReader.IsNotNull())
					return true;
			}
			return false;
		}

		#endregion Public Methods
	}
}