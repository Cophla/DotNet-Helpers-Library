using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace CodeHelpers.System.Web
{
	public class WebServiceHelper : GWebService, IWSHelper
	{
		#region Public Fields

		public const string CURRENT_HANDLER_WS = "CURRENTLY_EXCUTING_WEB_SERVICE_1D550C05D32E4798990E34E9EC43FF5F";

		#endregion Public Fields

		#region Private Fields

		private IDictionary<string, SqlConnection> connectionList = null;

		#endregion Private Fields

		#region Public Constructors

		public WebServiceHelper(string connectionStringKey, string connectionStringValue)
			: this(new Dictionary<string, string>() { { connectionStringKey, connectionStringValue } }) { }

		public WebServiceHelper(ICollection<KeyValuePair<string, string>> keyValueList)
		{
			HttpContext.Current.Items.Add(CURRENT_HANDLER_WS, this);

			if (keyValueList.IsNull())
				return;

			connectionList = new Dictionary<string, SqlConnection>(keyValueList.Count);
			foreach (var keyValue in keyValueList)
				connectionList.Add(keyValue.Key, new SqlConnection(keyValue.Value));
		}

		#endregion Public Constructors

		#region Public Methods

		public bool addToConnectionList(SqlConnection connection)
		{
			if (connection.IsNull())
				return false;

			if (connectionList.IsNull())
				return false;

			connectionList.Add($"{Guid.NewGuid()}", connection);
			return true;
		}

		public SqlConnection getCurrentSqlConnection()
		{
			if (connectionList.IsNull())
				return null;

			foreach (var connValue in connectionList.Values)
			{
				if (connValue.IsNull())
					continue;

				if (connValue.State != ConnectionState.Open)
					connValue.Open();

				return connValue;
			}

			return null;
		}

		public SqlConnection getCurrentSqlConnection(string connectionStringKeyName)
		{
			if (connectionList.IsNull())
				return null;

			if (connectionList.ContainsKey(connectionStringKeyName).IsNotTrue())
				return null;

			SqlConnection connection = connectionList[connectionStringKeyName];
			if (connectionList.IsNull())
				return null;

			if (connection.State != ConnectionState.Open)
				connection.Open();

			return connection;
		}

		#endregion Public Methods

		#region Protected Methods

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing.IsNotTrue())
				return;

			if (connectionList.IsNull())
				return;

			foreach (var connValue in connectionList.Values)
				if (connValue.IsNotNull())
					connValue.Dispose();

			connectionList.Clear();
			connectionList = null;
		}

		#endregion Protected Methods
	}
}