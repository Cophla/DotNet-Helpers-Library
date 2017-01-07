using CodeHelpers.System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace CodeHelpers.System.Web
{
	public static class WSHandler
	{
		#region Public Methods

		public static SqlConnection getCurrentHandlerSqlConnection()
		{
			if (HttpContext.Current.IsNull())
				return null;

			IWSHelper currentHandler = HttpContext.Current.Handler as IWSHelper;
			if (currentHandler.IsNull())
				currentHandler = HttpContext.Current.Items[WebServiceHelper.CURRENT_HANDLER_WS] as IWSHelper;

			if (currentHandler.IsNull())
				return null;

			SqlConnection connection = currentHandler.getCurrentSqlConnection();
			if (connection.IsNull())
				return null;

			if (connection.IsNotReady())
			{
				connection = new SqlConnection(connection.ConnectionString);
				currentHandler.addToConnectionList(connection);
			}

			if (connection.State != ConnectionState.Open)
				connection.Open();

			return connection;
		}

		public static SqlConnection getCurrentHandlerSqlConnection(string connectionStringKeyName)
		{
			if (HttpContext.Current.IsNull())
				return null;

			IWSHelper currentHandler = HttpContext.Current.Handler as IWSHelper;
			if (currentHandler.IsNull())
				currentHandler = HttpContext.Current.Items[WebServiceHelper.CURRENT_HANDLER_WS] as IWSHelper;

			if (currentHandler.IsNull())
				return null;

			SqlConnection connection = currentHandler.getCurrentSqlConnection(connectionStringKeyName);
			if (connection.IsNull())
				return null;

			if (connection.IsNotReady())
			{
				connection = new SqlConnection(connection.ConnectionString);
				currentHandler.addToConnectionList(connection);
			}

			if (connection.State != ConnectionState.Open)
				connection.Open();

			return connection;
		}

		#endregion Public Methods
	}
}