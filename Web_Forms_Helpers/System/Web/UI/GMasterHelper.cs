using CodeHelpers.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Web_Forms_Helpers.System.Web.UI
{
	/// <summary></summary>
	public class GMasterHelper : GMasterPage, IPageMasterHelper
	{
		#region Private Fields

		/// <summary></summary>
		private Dictionary<string, SqlConnection> connectionList = null;

		#endregion Private Fields

		#region Public Constructors

		/// <summary></summary>
		/// <param name="connectionStringKey"></param>
		/// <param name="connectionStringValue"></param>
		public GMasterHelper(string connectionStringKey, string connectionStringValue)
			: this(new Dictionary<string, string>() { { connectionStringKey, connectionStringValue } })
		{
		}

		/// <summary></summary>
		/// <param name="keyValueList"></param>
		public GMasterHelper(ICollection<KeyValuePair<string, string>> keyValueList)
		{
			if (keyValueList.IsNull())
				return;

			connectionList = new Dictionary<string, SqlConnection>(keyValueList.Count);
			foreach (var keyValue in keyValueList)
				connectionList.Add(keyValue.Key, new SqlConnection(keyValue.Value));
		}

		#endregion Public Constructors

		#region Public Methods

		/// <summary></summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		public bool AddToConnectionList(SqlConnection connection)
		{
			if (connection.IsNull())
				return false;

			if (connectionList.IsNull())
				return false;

			connectionList.Add($"{Guid.NewGuid()}", connection);
			return true;
		}

		/// <summary></summary>
		public override void Dispose()
		{
			base.Dispose();

			if (connectionList.IsNull())
				return;

			foreach (var connValue in connectionList.Values)
				if (connValue.IsNotNull())
					connValue.Dispose();

			connectionList.Clear();
			connectionList = null;
		}

		/// <summary></summary>
		/// <returns></returns>
		public SqlConnection GetCurrentSqlConnection()
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

		/// <summary></summary>
		/// <param name="connectionStringKeyName"></param>
		/// <returns></returns>
		public SqlConnection GetCurrentSqlConnection(string connectionStringKeyName)
		{
			if (connectionList.IsNull())
				return null;

			if (connectionList.ContainsKey(connectionStringKeyName).IsNotTrue())
				return null;

			SqlConnection connection = connectionList[connectionStringKeyName];
			if (connection.IsNull())
				return null;

			if (connection.State != ConnectionState.Open)
				connection.Open();

			return connection;
		}

		#endregion Public Methods
	}
}