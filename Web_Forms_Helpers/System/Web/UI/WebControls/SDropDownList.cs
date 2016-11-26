using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Web_Forms_Helpers.System.Web.UI.WebControls
{
	public static class SDropDownList
	{
		public static void Fill(this DropDownList dropDownList, SqlDataReader dataReader, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(dropDownList, dataReader, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this DropDownList dropDownList, DataTable dataTable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(dropDownList, dataTable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this DropDownList dropDownList, DataView dataView, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(dropDownList, dataView, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this DropDownList dropDownList, DataSet dataSet, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(dropDownList, dataSet, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this DropDownList dropDownList, SqlDataReader dataReader, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(dropDownList, dataReader, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this DropDownList dropDownList, DataTable dataTable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(dropDownList, dataTable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this DropDownList dropDownList, DataView dataView, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(dropDownList, dataView, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this DropDownList dropDownList, DataSet dataSet, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(dropDownList, dataSet, valueField, textField, positionZeroItem, emptyCaseItem);
		}
	}
}