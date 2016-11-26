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

		private static void Fill<T>(this ListControl listControl, T data, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
			where T : class
		{
			if (listControl != null)
			{
				listControl.Items.Clear();

				bool isEmptyData = false;

				if (data != null)
				{
					bool isValidParameters = false;

					if (
						SObject.IsTypeInList(
							data,
							typeof(IEnumerable), typeof(IListSource), typeof(IDataSource)
						)
					)
					{
						isValidParameters = true;
					}
					else
					{
						throw new InvalidCastException("Data parameter is not valid, you are only alowed to use: DataTable and SqlDataReader");
					}
					if (isValidParameters)
					{
						listControl.Items.Clear();
						if (
							(data is DbDataReader && (!(data as DbDataReader).HasRows)) ||
							(data is DataSet && SDataSet.GetFirstRow(data as DataSet) == null) ||
							(data is DataTable && SDataTable.GetFirstRow(data as DataTable) == null) ||
							(data is IList && (data as IList).Count == 0)
						)
						{
							isEmptyData = true;
						}

						if (!isEmptyData)
						{
							if (
								!(data is MarshalByValueComponent) &&
								data is IList)
							{
								IList dataList = (data as IList);
								foreach (var t in dataList)
								{
									ListItem listItem = new ListItem();
									listItem.Value = t.GetType().GetProperty(valueField).GetValue(t, null).ToString();
									listItem.Text = t.GetType().GetProperty(textField).GetValue(t, null).ToString();
									listControl.Items.Add(listItem);
								}
							}
							else
							{
								listControl.DataSource = data;
								listControl.DataValueField = valueField;
								listControl.DataTextField = textField;
								listControl.DataBind();

								if (data is DbDataReader)
								{
									data.GetType().GetMethod("Close").Invoke(data, null);
								}
							}
						}
					}
				}
				else
				{
					isEmptyData = true;
				}
				if (positionZeroItem != null)
				{
					listControl.Items.Insert(0, positionZeroItem);
					isEmptyData = false;
				}
				if (isEmptyData)
				{
					if (emptyCaseItem != null)
					{
						listControl.Items.Add(emptyCaseItem);
					}
					else
					{
						listControl.Items.Add(new ListItem("< فارغة >", ""));
					}
				}
			}
			else
			{
				throw new NullReferenceException("List Control can not be null value");
			}
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

		private static void FillThenDispose<T>(this ListControl listControl, T data, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
			where T : class
		{
			IDisposable disposableData = data as IDisposable;
			if (disposableData == null) return;

			using (disposableData)
			{
				Fill(listControl, data, valueField, textField, positionZeroItem, emptyCaseItem);
			}
		}

		public static bool SetByValue(this ListControl listControl, object value)
		{
			if (listControl == null) return false;
			listControl.ClearSelection();
			string valueToSelect = SObject.ConvertAs<string>(value);
			if (listControl.Items.FindByValue(valueToSelect) != null)
			{
				listControl.SelectedValue = valueToSelect;
				return true;
			}
			return false;
		}

		public static bool SetByText(this ListControl listControl, object text)
		{
			if (listControl == null) return false;
			listControl.ClearSelection();
			string textToSelect = SObject.ConvertAs<string>(text);
			ListItem textItem = listControl.Items.FindByText(textToSelect);
			if (textItem != null)
			{
				textItem.Selected = true;
				return true;
			}
			return false;
		}
	}
}