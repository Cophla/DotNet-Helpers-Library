using Code_Helpers.System;
using Code_Helpers.System.Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Forms_Helpers.System.Web.UI.WebControls
{
	public static class SListControl
	{
		#region Public Methods

		public static void Clear(this ListControl listControl)
		{
			SControl.Clear(listControl);
		}

		public static void Fill(this ListControl listControl, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			Fill<IDataSource>(listControl, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this ListControl listControl, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			Fill<IListSource>(listControl, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this ListControl listControl, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			Fill<IEnumerable>(listControl, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListControl listControl, IEnumerable enumerable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			FillThenDispose<IEnumerable>(listControl, enumerable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListControl listControl, IListSource listSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			FillThenDispose<IListSource>(listControl, listSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListControl listControl, IDataSource dataSource, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			FillThenDispose<IDataSource>(listControl, dataSource, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static bool SetByText(this ListControl listControl, object text)
		{
			if (listControl == null)
				return false;

			listControl.ClearSelection();
			string textToSelect = SObject.ConvertAs<string>(text);
			ListItem textItem = listControl.Items.FindByText(textToSelect);
			if (textItem.IsNull())
				return false;

			textItem.Selected = true;
			return true;
		}

		public static bool SetByValue(this ListControl listControl, object value)
		{
			if (listControl == null)
				return false;

			listControl.ClearSelection();
			string valueToSelect = SObject.ConvertAs<string>(value);
			if (listControl.Items.FindByValue(valueToSelect).IsNull())
				return false;

			listControl.SelectedValue = valueToSelect;
			return true;
		}

		#endregion Public Methods

		#region Private Methods

		private static void Fill<T>(this ListControl listControl, T data, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
													where T : class
		{
			if (listControl.IsNull())
				throw new NullReferenceException("List Control can not be null value");

			if (SObject.IsTypeNotInList<T>(typeof(IEnumerable), typeof(IListSource), typeof(IDataSource)))
				throw new InvalidCastException("Data parameter is not valid, you are only alowed to use: IEnumerable, IListSource and IDataSource");

			listControl.Items.Clear();

			if (data.IsNull())
			{
				Clear(listControl);
				return;
			}

			if (
				(data is DbDataReader && (!(data as DbDataReader).HasRows)) ||
				(data is DataSet && SDataSet.GetFirstRow(data as DataSet) == null) ||
				(data is DataTable && SDataTable.GetFirstRow(data as DataTable) == null) ||
				(data is IList && (data as IList).Count == 0)
			)
			{
				if (emptyCaseItem.IsNull())
					emptyCaseItem = (new ListItem("< Empty Data >", string.Empty));

				listControl.Items.Add(emptyCaseItem);
				return;
			}

			listControl.DataSource = data;
			listControl.DataValueField = valueField;
			listControl.DataTextField = textField;
			listControl.DataBind();

			if (data is DbDataReader)
				data.GetType().GetMethod("Close").Invoke(data, null);

			if (positionZeroItem.IsNotNull())
				listControl.Items.Insert(0, positionZeroItem);
		}

		private static void FillThenDispose<T>(this ListControl listControl, T data, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
			where T : class
		{
			IDisposable disposableData = data as IDisposable;
			if (disposableData == null)
				Fill(listControl, data, valueField, textField, positionZeroItem, emptyCaseItem);

			using (disposableData)
			{
				Fill(listControl, data, valueField, textField, positionZeroItem, emptyCaseItem);
			}
		}

		#endregion Private Methods
	}
}