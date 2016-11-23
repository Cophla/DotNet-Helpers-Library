using System.Data.SqlClient;

namespace Web_Forms_Helpers.System.Web.UI
{
	/// <summary>
	/// </summary>
	public interface IPageMasterHelper
	{
		bool AddToConnectionList(SqlConnection connection);
		SqlConnection GetCurrentSqlConnection();
		SqlConnection GetCurrentSqlConnection(string connectionStringKeyName);
	}
}