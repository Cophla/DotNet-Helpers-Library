using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsHelpers.System.Web.UI.WebControls
{
	public static class SRadioButtonList
	{
		#region Public Methods

		public static void Clear(this RadioButtonList radioButtonList)
		{
			SListControl.Clear(radioButtonList);
		}

		public static void Fill(this RadioButtonList radioButtonList, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(radioButtonList, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this RadioButtonList radioButtonList, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(radioButtonList, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this RadioButtonList radioButtonList, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.Fill(radioButtonList, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this RadioButtonList radioButtonList, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(radioButtonList, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this RadioButtonList radioButtonList, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(radioButtonList, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this RadioButtonList radioButtonList, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			SListControl.FillThenDispose(radioButtonList, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static bool SetByText(this RadioButtonList radioButtonList, object text)
		{
			return SListControl.SetByText(radioButtonList, text);
		}

		public static bool SetByValue(this RadioButtonList radioButtonList, object value)
		{
			return SListControl.SetByValue(radioButtonList, value);
		}

		#endregion Public Methods
	}
}