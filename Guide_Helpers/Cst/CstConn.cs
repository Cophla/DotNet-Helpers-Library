using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace Guide_Helpers.CstConn
{
	/// <summary>
	/// </summary>
	public static class ApplicationName
	{
		#region Private Fields

		private static readonly IReadOnlyDictionary<string, string> connectionKeyValueList;

		#endregion Private Fields

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

		/// <summary>
		/// </summary>
		public static IReadOnlyDictionary<string, string> ConnectionKeyValueList {
			get { return connectionKeyValueList; }
		}

		#endregion Public Properties

		#region Public Classes

		/// <summary>
		/// </summary>
		public static class ConnName
		{
			#region Public Fields

			/// <summary>
			/// </summary>
			public const string DEFAULT_CONNECTION = "DefaultDbConnection";

			/// <summary>
			/// </summary>
			public const string SECOND_CONNECTION = "SecondDbConnection";

			#endregion Public Fields
		}

		#endregion Public Classes
	}
}