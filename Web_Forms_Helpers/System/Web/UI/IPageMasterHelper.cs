using System.Data.SqlClient;

namespace WebFormsHelpers.System.Web.UI
{
	public interface IPageMasterHelper
	{
		#region Public Methods

		bool AddToConnectionList(SqlConnection connection);

		SqlConnection GetCurrentSqlConnection();

		SqlConnection GetCurrentSqlConnection(string connectionStringKeyName);

		#endregion Public Methods
	}
}