using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsHelpers.System.Web.UI.WebControls
{
	public static class SCheckBoxList
	{
		#region Public Methods

		public static void Clear(this CheckBoxList checkBoxList)
		{
			SListControl.Clear(checkBoxList);
		}

		public static void Fill(this CheckBoxList checkBoxList, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(checkBoxList, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this CheckBoxList checkBoxList, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(checkBoxList, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this CheckBoxList checkBoxList, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(checkBoxList, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this CheckBoxList checkBoxList, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(checkBoxList, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this CheckBoxList checkBoxList, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(checkBoxList, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this CheckBoxList checkBoxList, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(checkBoxList, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static bool SetByText(this CheckBoxList checkBoxList, object text)
		{
			return SListControl.SetByText(checkBoxList, text);
		}

		public static bool SetByValue(this CheckBoxList checkBoxList, object value)
		{
			return SListControl.SetByValue(checkBoxList, value);
		}

		#endregion Public Methods
	}
}