using CodeHelpers.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.System.Data.SqlClient
{
	public static class SSqlConnection
	{
		#region Public Methods

		public static bool ApplyTransaction(
			this SqlConnection connection, out string transactionError,
			SSqlTransaction.BoolMethod myMethodCall)
		{
			string TRANSACTION_NAME = Guid.NewGuid().ToString().Substring(
				0, CstVars.MAX_SQL_TRANSACTION_NAME_LENGTH
			);
			using (SqlTransaction transaction = connection.BeginTransaction(TRANSACTION_NAME))
			{
				if (myMethodCall(transaction, out transactionError).IsTrue())
					return SSqlTransaction.Apply(transaction, TRANSACTION_NAME, out transactionError);

				try
				{
					transaction.Rollback(TRANSACTION_NAME);
				}
				catch (Exception ex)
				{
					transactionError = $"{transactionError}{ex.ToString()}";
				}
			}

			return false;
		}

		public static bool ApplyTransaction(
			this SqlConnection connection, MessageString transactionError,
			Func<SqlTransaction, MessageString, bool> myMethodCall)
		{
			string TRANSACTION_NAME = Guid.NewGuid().ToString().Substring(
				0, CstVars.MAX_SQL_TRANSACTION_NAME_LENGTH
			);
			using (SqlTransaction transaction = connection.BeginTransaction(TRANSACTION_NAME))
			{
				if (myMethodCall(transaction, transactionError).IsTrue())
					return SSqlTransaction.Apply(transaction, TRANSACTION_NAME, transactionError);

				try
				{
					transaction.Rollback(TRANSACTION_NAME);
				}
				catch (Exception ex)
				{
					transactionError.Append(ex.ToString());
				}
			}

			return false;
		}

		public static int Exec(
			this SqlConnection connection, CommandType commandType, string sqlText, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			SqlTransaction transaction = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, out errorMsg);
		}

		public static int Exec(
			this SqlConnection connection, CommandType commandType, string sqlText, IEnumerable<SqlParameter> parmList,
			out string errorMsg)
		{
			SqlTransaction transaction = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, out errorMsg);
		}

		public static int Exec(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType, string sqlText,
			out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, out errorMsg);
		}

		public static int Exec(
			this SqlConnection connection, CommandType commandType, string sqlText, MessageString errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			SqlTransaction transaction = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, errorMsg);
		}

		public static int Exec(
			this SqlConnection connection, CommandType commandType, string sqlText, IEnumerable<SqlParameter> parmList,
			MessageString errorMsg)
		{
			SqlTransaction transaction = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, errorMsg);
		}

		public static int Exec(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType, string sqlText,
			MessageString errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return Exec(connection, transaction, commandType, sqlText, parmList, errorMsg);
		}

		public static int Exec(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType,
			string sqlText, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			if (IsOpened(connection, out errorMsg).IsNotTrue())
				return -1;

			try
			{
				return Exec(connection, transaction, commandType, sqlText, parmList);
			}
			catch (Exception ex) { errorMsg = ex.ToString(); }

			return -1;
		}

		public static int Exec(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType,
			string sqlText, IEnumerable<SqlParameter> parmList, MessageString errorMsg)
		{
			if (IsOpened(connection, errorMsg).IsNotTrue())
				return -1;

			try
			{
				return Exec(connection, transaction, commandType, sqlText, parmList);
			}
			catch (Exception ex) { errorMsg.Append(ex.ToString()); }

			return -1;
		}

		public static int Exec(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType,
			string sqlText, IEnumerable<SqlParameter> parmList)
		{
			using (SqlCommand command = new SqlCommand(sqlText, connection))
			{
				command.CommandType = commandType;

				if (transaction.IsNotNull())
					command.Transaction = transaction;

				if (parmList.IsNotNull())
					foreach (SqlParameter parm in parmList)
						command.Parameters.Add(parm);

				int returnValue = command.ExecuteNonQuery();
				command.Parameters.Clear();
				return returnValue;
			}
		}

		public static T ExecScalar<T>(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType,
			string sqlText, IEnumerable<SqlParameter> parmList, T defaultValue, out string errorMsg)
		{
			if (IsOpened(connection, out errorMsg).IsNotTrue())
				return defaultValue;

			try
			{
				return ExecScalar<T>(connection, transaction, commandType, sqlText, parmList,
					defaultValue);
			}
			catch (Exception ex) { errorMsg = ex.ToString(); }

			return defaultValue;
		}

		public static T ExecScalar<T>(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType,
			string sqlText, IEnumerable<SqlParameter> parmList, T defaultValue, MessageString errorMsg)
		{
			if (IsOpened(connection, errorMsg).IsNotTrue())
				return defaultValue;

			try
			{
				return ExecScalar<T>(connection, transaction, commandType, sqlText, parmList,
					defaultValue);
			}
			catch (Exception ex) { errorMsg.Append(ex.ToString()); }

			return defaultValue;
		}

		public static T ExecScalar<T>(
			this SqlConnection connection, SqlTransaction transaction, CommandType commandType,
			string sqlText, IEnumerable<SqlParameter> parmList, T defaultValue)
		{
			using (SqlCommand command = new SqlCommand(sqlText, connection))
			{
				command.CommandType = commandType;

				if (transaction.IsNotNull())
					command.Transaction = transaction;

				if (parmList.IsNotNull())
					foreach (SqlParameter parm in parmList)
						command.Parameters.Add(parm);

				T returnValue = SObject.DbValueAs<T>(command.ExecuteScalar(), defaultValue);
				command.Parameters.Clear();
				return returnValue;
			}
		}

		public static SqlDataReader Get(
			this SqlConnection connection, string sqlText, CommandType commandType, out string errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return Get(connection, sqlText, commandType, CommandBehavior.Default, parmList, out errorMsg);
		}

		public static SqlDataReader Get(
			this SqlConnection connection, string sqlText, CommandType commandType, MessageString errorMsg)
		{
			IEnumerable<SqlParameter> parmList = null;
			return Get(connection, sqlText, commandType, CommandBehavior.Default, parmList, errorMsg);
		}

		public static SqlDataReader Get(
			this SqlConnection connection, string sqlText, CommandType commandType,
			CommandBehavior commandBehavior, IEnumerable<SqlParameter> parmList, out string errorMsg)
		{
			if (IsOpened(connection, out errorMsg).IsNotTrue())
				return null;

			try
			{
				return Get(connection, sqlText, commandType, commandBehavior, parmList);
			}
			catch (Exception ex)
			{
				errorMsg = ex.ToString();
			}

			return null;
		}

		public static SqlDataReader Get(
			this SqlConnection connection, string sqlText, CommandType commandType,
			CommandBehavior commandBehavior, IEnumerable<SqlParameter> parmList, MessageString errorMsg)
		{
			if (IsOpened(connection, errorMsg).IsNotTrue())
				return null;

			try
			{
				return Get(connection, sqlText, commandType, commandBehavior, parmList);
			}
			catch (Exception ex)
			{
				errorMsg.Append(ex.ToString());
			}

			return null;
		}

		public static SqlDataReader Get(
			this SqlConnection connection, string sqlText, CommandType commandType,
			CommandBehavior commandBehavior, IEnumerable<SqlParameter> parmList)
		{
			using (SqlCommand command = new SqlCommand(sqlText, connection))
			{
				command.CommandType = commandType;

				if (parmList.IsNotNull())
					foreach (SqlParameter parm in parmList)
						command.Parameters.Add(parm);

				SqlDataReader dataReader = command.ExecuteReader(commandBehavior);
				command.Parameters.Clear();
				return dataReader;
			}
		}

		public static bool IsNotReady(this SqlConnection connection)
		{
			return IsReady(connection).Not();
		}

		public static bool IsOpened(this SqlConnection connection, MessageString errorMsg)
		{
			if ((connection.State == ConnectionState.Open).IsNotTrue())
			{
				errorMsg.Append("Database connection object is not opened");
				return false;
			}
			return true;
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

		public static bool IsReady(this SqlConnection connection)
		{
			string errorMsg;
			SqlDataReader dataReader = Get(connection, "SELECT TOP 1 1", CommandType.Text, out errorMsg);
			return SObject.Dispose(ref dataReader, delegate ()
			{ return true; });
		}

		#endregion Public Methods
	}
}