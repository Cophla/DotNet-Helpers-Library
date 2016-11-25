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
			bool result = false;
			if (IsOpened(connection, out errorMsg))
			{
				using (SqlCommand command = new SqlCommand(sqlText, connection))
				{
					try
					{
						command.CommandType = commandType;

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

						result = true;
					}
					catch (Exception ex) { errorMsg = ex.ToString(); }
				}
			}

			return result;
		}

		public static T ExecScalar<T>(this SqlConnection connection, SqlTransaction transaction, CommandType commandType, string sqlText, IEnumerable<SqlParameter> parmList, T defaultValue, out string errorMsg)
		{
			errorMsg = string.Empty;
			T result = defaultValue;
			if (IsOpened(connection, out errorMsg))
			{
				using (SqlCommand command = new SqlCommand(sqlText, connection))
				{
					try
					{
						command.CommandType = commandType;

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
						result = SObject.DbValueAs<T>(command.ExecuteScalar());
					}
					catch (Exception ex) { errorMsg = ex.ToString(); }
				}
			}
			return result;
		}

		public static SqlDataReader Get(this SqlConnection connection, string sqlText, CommandType commandType, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return Get(connection, sqlText, commandType, CommandBehavior.Default, parmList, out errorMsg);
		}

		public static SqlDataReader Get(this SqlConnection connection, string sqlText, CommandType commandType, CommandBehavior commandBehavior, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			errorMsg = string.Empty;
			SqlDataReader dataReader = null;
			if (IsOpened(connection, out errorMsg))
			{
				using (SqlCommand command = new SqlCommand(sqlText, connection))
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

		public static bool IsOpened(this SqlConnection connection, out string errorMsg)
		{
			errorMsg = string.Empty;
			bool result = false;
			if (!(result = (connection.State == ConnectionState.Open)))
			{
				errorMsg = "Database connection object is not opened";
			}
			return result;
		}

		public static bool IsReady(SqlConnection connection)
		{
			bool result = false;
			string errorMsg;
			using (SqlDataReader dataReader = Get(connection, "SELECT TOP 1 1", CommandType.Text, out errorMsg))
			{
				if (dataReader != null)
				{
					result = true;
				}
			}
			return result;
		}

		#endregion Public Methods
	}
}