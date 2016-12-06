using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Forms_Helpers.System.Web.UI.WebControls
{
	public static class SDropDownList
	{
		public static void Fill(this DropDownList dropDownList, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(dropDownList, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this DropDownList dropDownList, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(dropDownList, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this DropDownList dropDownList, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(dropDownList, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this DropDownList dropDownList, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(dropDownList, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this DropDownList dropDownList, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(dropDownList, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this DropDownList dropDownList, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(dropDownList, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static bool SetByValue(this DropDownList dropDownList, object value)
		{
			return SListControl.SetByValue(dropDownList, value);
		}

		public static bool SetByText(this DropDownList dropDownList, object text)
		{
			return SListControl.SetByText(dropDownList, text);
		}

		public static void Clear(this DropDownList dropDownList)
		{
			SListControl.Clear(dropDownList);
		}
	}
}