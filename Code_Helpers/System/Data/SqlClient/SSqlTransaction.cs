using Guide_Helpers.Cst;
using System;
using System.Data.SqlClient;

namespace Code_Helpers.System.Data.SqlClient
{
	public static class SSqlTransaction
	{
		#region Public Delegates

		public delegate bool ApplyMethod(SqlTransaction transaction, out string errorMsg);

		#endregion Public Delegates

		#region Public Methods

		public static bool ApplyTransaction(this SqlTransaction transaction, out string errorMsg)
		{
			string TRANSACTION_NAME = null;
			return ApplyTransaction(transaction, TRANSACTION_NAME, out errorMsg);
		}

		public static bool ApplyTransaction(this SqlTransaction transaction, string TRANSACTION_NAME, out string errorMsg)
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

		public static bool ApplyTransaction(SqlConnection connection, out string transactionError, ApplyMethod myMethodCall)
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

		#endregion Public Methods
	}
}