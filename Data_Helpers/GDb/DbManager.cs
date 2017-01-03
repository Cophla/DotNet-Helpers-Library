using System.Configuration;
using System.Data.SqlClient;

namespace Data_Helpers.GDb
{
	/// <summary></summary>
	public class GDbManager
	{
		#region Private Properties

		/// <summary></summary>
		private static string DbConnection { get { return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; } }

		#endregion Private Properties

		#region Public Methods

		/// <summary></summary>
		/// <returns></returns>
		public static SqlConnection GetSqlInstance()
		{
			return new SqlConnection(DbConnection);
		}

		#endregion Public Methods
	}
}