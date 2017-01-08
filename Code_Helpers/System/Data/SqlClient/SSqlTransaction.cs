using System;
using System.Data.SqlClient;

namespace CodeHelpers.System.Data.SqlClient
{
	public static class SSqlTransaction
	{
		#region Public Delegates

		public delegate bool BoolMethod(SqlTransaction transaction, out string errorMsg);

		#endregion Public Delegates

		#region Public Methods

		public static bool Apply(this SqlTransaction transaction, out string errorMsg)
		{
			string TRANSACTION_NAME = null;
			return Apply(transaction, TRANSACTION_NAME, out errorMsg);
		}

		public static bool Apply(
			this SqlTransaction transaction, string TRANSACTION_NAME, out string errorMsg)
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
						transaction.Rollback(TRANSACTION_NAME);
					else
						transaction.Rollback();
				}
				catch (Exception)
				{
					errorMsg = $"{errorMsg}{ex.ToString()}";
				}
			}
			return result;
		}

		public static bool Apply(this SqlTransaction transaction, MessageString errorMsg)
		{
			string TRANSACTION_NAME = null;
			return Apply(transaction, TRANSACTION_NAME, errorMsg);
		}

		public static bool Apply(
			this SqlTransaction transaction, string TRANSACTION_NAME, MessageString errorMsg)
		{
			bool result = false;
			try
			{
				transaction.Commit();
				result = true;
			}
			catch (Exception ex)
			{
				errorMsg.Append(ex.ToString());
				try
				{
					if (SString.IsNotNone(TRANSACTION_NAME))
						transaction.Rollback(TRANSACTION_NAME);
					else
						transaction.Rollback();
				}
				catch (Exception)
				{
					errorMsg.Append(ex.ToString());
				}
			}
			return result;
		}

		#endregion Public Methods
	}
}