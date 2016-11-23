using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Web_Forms_Helpers.System.Web.UI
{
	/// <summary>
	/// </summary>
	public class GMasterHelper : GMasterPage, IPageMasterHelper
	{
		#region Private Fields

		/// <summary>
		/// </summary>
		private Dictionary<string, SqlConnection> connectionList = null;

		#endregion Private Fields

		#region Public Constructors

		/// <summary>
		/// </summary>
		/// <param name="connectionStringKey">
		/// </param>
		/// <param name="connectionStringValue">
		/// </param>
		public GMasterHelper(string connectionStringKey, string connectionStringValue)
			: this(new Dictionary<string, string>() { { connectionStringKey, connectionStringValue } })
		{
		}

		/// <summary>
		/// </summary>
		/// <param name="keyValueList">
		/// </param>
		public GMasterHelper(ICollection<KeyValuePair<string, string>> keyValueList)
		{
			if (keyValueList != null)
			{
				connectionList = new Dictionary<string, SqlConnection>(keyValueList.Count);
				foreach (var keyValue in keyValueList)
				{
					connectionList.Add(
						keyValue.Key,
						new SqlConnection(keyValue.Value)
					);
				}
			}
		}

		#endregion Public Constructors

		#region Public Methods

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public bool AddToConnectionList(SqlConnection connection)
		{
			bool result = false;

			if (connection != null)
			{
				if (connectionList != null)
				{
					connectionList.Add(
						Guid.NewGuid().ToString(),
						connection
					);
					result = true;
				}
			}

			return result;
		}

		/// <summary>
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();

			if (connectionList != null)
			{
				foreach (var connValue in connectionList.Values)
				{
					if (connValue != null)
					{
						connValue.Dispose();
					}
				}
				connectionList.Clear();
				connectionList = null;
			}
		}

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public SqlConnection GetCurrentSqlConnection()
		{
			SqlConnection connection = null;
			if (connectionList != null)
			{
				foreach (var connValue in connectionList.Values)
				{
					if (connValue != null)
					{
						connection = connValue;
						if (connection.State != ConnectionState.Open)
						{
							connection.Open();
						}
						break;
					}
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
		public SqlConnection GetCurrentSqlConnection(string connectionStringKeyName)
		{
			SqlConnection connection = null;
			if (connectionList != null)
			{
				if (connectionList.ContainsKey(connectionStringKeyName))
				{
					connection = connectionList[connectionStringKeyName];
					if (connection != null)
					{
						if (connection.State != ConnectionState.Open)
						{
							connection.Open();
						}
					}
				}
			}
			return connection;
		}

		#endregion Public Methods
	}
}