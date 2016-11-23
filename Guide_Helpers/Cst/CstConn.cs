using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace Guide_Helpers.CstConn
{
	/// <summary>
	/// </summary>
	public static class ApplicationName
	{
		static ApplicationName()
		{
			const int CONNECTIONS_COUNT = 2;
			Dictionary<string, string> connectionKeyValueDictionary = new Dictionary<string, string>(CONNECTIONS_COUNT);

			connectionKeyValueDictionary.Add(
				ConnName.DEFAULT_CONNECTION,
				ConfigurationManager.ConnectionStrings[
					ConnName.DEFAULT_CONNECTION
				].ConnectionString
			);

			connectionKeyValueDictionary.Add(
				ConnName.SECOND_CONNECTION,
				ConfigurationManager.ConnectionStrings[
					ConnName.SECOND_CONNECTION
				].ConnectionString
			);

			connectionKeyValueList = new ReadOnlyDictionary<string, string>(connectionKeyValueDictionary);
		}

		/// <summary>
		/// </summary>
		public static IReadOnlyDictionary<string, string> ConnectionKeyValueList {
			get { return connectionKeyValueList; }
		}

		/// <summary>
		/// </summary>
		public static class ConnName
		{
			/// <summary>
			/// </summary>
			public const string DEFAULT_CONNECTION = "DefaultDbConnection";

			/// <summary>
			/// </summary>
			public const string SECOND_CONNECTION = "SecondDbConnection";
		}

		private static readonly IReadOnlyDictionary<string, string> connectionKeyValueList;
	}
}