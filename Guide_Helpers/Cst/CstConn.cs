using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace GuideHelpers.CstConn
{
	public static class ApplicationName
	{
		#region Public Constructors

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

		#endregion Public Constructors

		#region Public Properties

		public static IReadOnlyDictionary<string, string> ConnectionKeyValueList
		{
			get { return connectionKeyValueList; }
		}

		#endregion Public Properties

		#region Public Classes

		public static class ConnName
		{
			#region Public Fields

			public const string DEFAULT_CONNECTION = "DefaultDbConnection";

			public const string SECOND_CONNECTION = "SecondDbConnection";

			#endregion Public Fields
		}

		#endregion Public Classes

		#region Private Fields

		private static readonly IReadOnlyDictionary<string, string> connectionKeyValueList;

		#endregion Private Fields
	}
}