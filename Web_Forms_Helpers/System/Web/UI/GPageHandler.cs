using Code_Helpers.System.Data.SqlClient;
using Sql_Server_Helpers;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Web_Forms_Helpers.System.Web.UI
{
	/// <summary>
	/// </summary>
	public static class GPageHandler
	{
		#region Public Methods

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public static SqlConnection GetCurrentHandlerSqlConnection()
		{
			SqlConnection connection = null;

			if (HttpContext.Current != null)
			{
				IPageMasterHelper currentHandler = HttpContext.Current.Handler as IPageMasterHelper;
				if (currentHandler != null)
				{
					connection = currentHandler.GetCurrentSqlConnection();

					if (connection != null)
					{
						if (!SSqlConnection.IsReady(connection))
						{
							if (currentHandler != null)
							{
								connection = new SqlConnection(connection.ConnectionString);
								connection.Open();
								currentHandler.AddToConnectionList(connection);
							}
						}
					}
				}
			}

			if (connection != null)
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}
			}

			return connection;
		}

		/// <summary>
		/// </summary>
		/// <param name="connectionStringKeyName">
		/// </param>
		/// <returns>
		/// </returns>
		public static SqlConnection GetCurrentHandlerSqlConnection(string connectionStringKeyName)
		{
			SqlConnection connection = null;

			if (HttpContext.Current != null)
			{
				IPageMasterHelper currentHandler = HttpContext.Current.Handler as IPageMasterHelper;
				if (currentHandler != null)
				{
					connection = currentHandler.GetCurrentSqlConnection(connectionStringKeyName);

					if (connection != null)
					{
						if (!SSqlConnection.IsReady(connection))
						{
							if (currentHandler != null)
							{
								connection = new SqlConnection(connection.ConnectionString);
								connection.Open();
								currentHandler.AddToConnectionList(connection);
							}
						}
					}
				}
			}

			if (connection != null)
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}
			}

			return connection;
		}

		#endregion Public Methods
	}
}