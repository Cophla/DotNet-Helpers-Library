using Code_Helpers.System;
using Code_Helpers.System.Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Web_Forms_Helpers.System.Web.UI.WebControls
{
	public static class SListControl
	{
		public static void Fill(this ListControl listControl, SqlDataReader dataReader, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			Fill<SqlDataReader>(listControl, dataReader, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this ListControl listControl, DataTable dataTable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			Fill<DataTable>(listControl, dataTable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this ListControl listControl, DataView dataView, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			Fill<DataView>(listControl, dataView, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void Fill(this ListControl listControl, DataSet dataSet, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			Fill<DataSet>(listControl, dataSet, valueField, textField, positionZeroItem, emptyCaseItem);
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
							typeof(SqlDataReader), typeof(DataTable), typeof(DataSet), typeof(DataView), typeof(IList)
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
							(data is SqlDataReader && (!(data as SqlDataReader).HasRows)) ||
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

								if (data is SqlDataReader)
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

		public static void FillThenDispose(this ListControl listControl, SqlDataReader dataReader, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			FillThenDispose<SqlDataReader>(listControl, dataReader, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListControl listControl, DataTable dataTable, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			FillThenDispose<DataTable>(listControl, dataTable, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListControl listControl, DataView dataView, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			FillThenDispose<DataView>(listControl, dataView, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		public static void FillThenDispose(this ListControl listControl, DataSet dataSet, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
		{
			FillThenDispose<DataSet>(listControl, dataSet, valueField, textField, positionZeroItem, emptyCaseItem);
		}

		private static void FillThenDispose<T>(this ListControl listControl, T data, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem)
			where T : class, IDisposable
		{
			using (data)
			{
				Fill(listControl, data, valueField, textField, positionZeroItem, emptyCaseItem);
			}
		}
	}
}