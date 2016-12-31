using System.Data.SqlClient;

namespace Code_Helpers.System.Web
{
	public interface IWSHelper
	{
		#region Public Methods

		bool addToConnectionList(SqlConnection connection);

		SqlConnection getCurrentSqlConnection();

		SqlConnection getCurrentSqlConnection(string connectionStringKeyName);

		#endregion Public Methods
	}
}