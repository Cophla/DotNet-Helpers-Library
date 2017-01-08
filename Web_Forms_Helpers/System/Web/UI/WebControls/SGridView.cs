using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebFormsHelpers.System.Web.UI.WebControls
{
	public static class SGridView
	{
		#region Public Methods

		public static void Clear(this GridView gridView)
		{
			SControl.Clear(gridView);
		}

		public static void Fill(this GridView gridView, SqlDataReader dataReader)
		{
			SControl.Fill(gridView, dataReader);
		}

		public static void Fill(this GridView gridView, DataTable dataTable)
		{
			SControl.Fill(gridView, dataTable);
		}

		public static void Fill(this GridView gridView, DataSet dataSet)
		{
			SControl.Fill(gridView, dataSet);
		}

		public static void Fill(this GridView gridView, DataView dataView)
		{
			SControl.Fill(gridView, dataView);
		}

		public static void FillThenDispose(this GridView gridView, SqlDataReader dataReader)
		{
			SControl.FillThenDispose(gridView, dataReader);
		}

		public static void FillThenDispose(this GridView gridView, DataTable dataTable)
		{
			SControl.FillThenDispose(gridView, dataTable);
		}

		public static void FillThenDispose(this GridView gridView, DataSet dataSet)
		{
			SControl.FillThenDispose(gridView, dataSet);
		}

		public static void FillThenDispose(this GridView gridView, DataView dataView)
		{
			SControl.FillThenDispose(gridView, dataView);
		}

		#endregion Public Methods
	}
}