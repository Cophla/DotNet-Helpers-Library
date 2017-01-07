using CodeHelpers.System;
using CodeHelpers.System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Web_Forms_Helpers.System.Web.UI
{
	/// <summary></summary>
	public static class GPageMasterHandler
	{
		#region Public Methods

		/// <summary></summary>
		/// <returns></returns>
		public static SqlConnection GetCurrentHandlerSqlConnection()
		{
			if (HttpContext.Current.IsNull())
				return null;

			IPageMasterHelper currentHandler = HttpContext.Current.Handler as IPageMasterHelper;
			if (currentHandler.IsNull())
				return null;

			SqlConnection connection = currentHandler.GetCurrentSqlConnection();

			if (connection.IsNull())
				return null;

			if (connection.IsNotReady())
			{
				connection = new SqlConnection(connection.ConnectionString);
				currentHandler.AddToConnectionList(connection);
			}

			if (connection.State != ConnectionState.Open)
				connection.Open();

			return connection;
		}

		/// <summary></summary>
		/// <param name="connectionStringKeyName"></param>
		/// <returns></returns>
		public static SqlConnection GetCurrentHandlerSqlConnection(string connectionStringKeyName)
		{
			if (HttpContext.Current.IsNull())
				return null;

			IPageMasterHelper currentHandler = HttpContext.Current.Handler as IPageMasterHelper;
			if (currentHandler.IsNull())
				return null;

			SqlConnection connection = currentHandler.GetCurrentSqlConnection(connectionStringKeyName);
			if (connection.IsNull())
				return null;

			if (connection.IsNotReady())
			{
				connection = new SqlConnection(connection.ConnectionString);
				currentHandler.AddToConnectionList(connection);
			}

			if (connection.State != ConnectionState.Open)
				connection.Open();

			return connection;
		}

		#endregion Public Methods
	}
}