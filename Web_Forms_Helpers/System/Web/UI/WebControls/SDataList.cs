using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebFormsHelpers.System.Web.UI.WebControls
{
	public static class SDataList
	{
		#region Public Methods

		public static void Fill(this DataList dataList, SqlDataReader dataReader)
		{
			SControl.Fill(dataList, dataReader);
		}

		public static void Fill(this DataList dataList, DataTable dataTable)
		{
			SControl.Fill(dataList, dataTable);
		}

		public static void Fill(this DataList dataList, DataSet dataSet)
		{
			SControl.Fill(dataList, dataSet);
		}

		public static void Fill(this DataList dataList, DataView dataView)
		{
			SControl.Fill(dataList, dataView);
		}

		public static void FillThenDispose(this DataList dataList, SqlDataReader dataReader)
		{
			SControl.FillThenDispose(dataList, dataReader);
		}

		public static void FillThenDispose(this DataList dataList, DataTable dataTable)
		{
			SControl.FillThenDispose(dataList, dataTable);
		}

		public static void FillThenDispose(this DataList dataList, DataSet dataSet)
		{
			SControl.FillThenDispose(dataList, dataSet);
		}

		public static void FillThenDispose(this DataList dataList, DataView dataView)
		{
			SControl.FillThenDispose(dataList, dataView);
		}

		#endregion Public Methods
	}
}