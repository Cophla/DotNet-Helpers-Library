using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Forms_Helpers.System.Web.UI.WebControls
{
	public static class SListBox
	{
		public static void Fill(this ListBox listBox, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(listBox, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this ListBox listBox, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(listBox, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this ListBox listBox, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(listBox, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListBox listBox, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(listBox, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListBox listBox, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(listBox, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListBox listBox, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(listBox, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static bool SetByValue(this ListBox listBox, object value)
		{
			return SListControl.SetByValue(listBox, value);
		}

		public static bool SetByText(this ListBox listBox, object text)
		{
			return SListControl.SetByText(listBox, text);
		}

		public static void Clear(this ListBox listBox)
		{
			SListControl.Clear(listBox);
		}
	}
}