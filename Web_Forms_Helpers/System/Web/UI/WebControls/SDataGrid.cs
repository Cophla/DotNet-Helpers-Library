using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebFormsHelpers.System.Web.UI.WebControls
{
	public static class SDataGrid
	{
		#region Public Methods

		public static void Fill(this DataGrid dataGrid, SqlDataReader dataReader)
		{
			SControl.Fill(dataGrid, dataReader);
		}

		public static void Fill(this DataGrid dataGrid, DataTable dataTable)
		{
			SControl.Fill(dataGrid, dataTable);
		}

		public static void Fill(this DataGrid dataGrid, DataSet dataSet)
		{
			SControl.Fill(dataGrid, dataSet);
		}

		public static void Fill(this DataGrid dataGrid, DataView dataView)
		{
			SControl.Fill(dataGrid, dataView);
		}

		public static void FillThenDispose(this DataGrid dataGrid, SqlDataReader dataReader)
		{
			SControl.FillThenDispose(dataGrid, dataReader);
		}

		public static void FillThenDispose(this DataGrid dataGrid, DataTable dataTable)
		{
			SControl.FillThenDispose(dataGrid, dataTable);
		}

		public static void FillThenDispose(this DataGrid dataGrid, DataSet dataSet)
		{
			SControl.FillThenDispose(dataGrid, dataSet);
		}

		public static void FillThenDispose(this DataGrid dataGrid, DataView dataView)
		{
			SControl.FillThenDispose(dataGrid, dataView);
		}

		#endregion Public Methods
	}
}