using Code_Helpers.System;
using Code_Helpers.System.Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Web_Forms_Helpers.System.Web.UI
{
	public static class SControl
	{
		public static void Fill(this DataList dataList, SqlDataReader dataReader)
		{
			Fill<DataList, SqlDataReader>(dataList, dataReader);
		}

		public static void Fill(this DataList dataList, DataTable dataTable)
		{
			Fill<DataList, DataTable>(dataList, dataTable);
		}

		public static void Fill(this DataList dataList, DataSet dataSet)
		{
			Fill<DataList, DataSet>(dataList, dataSet);
		}

		public static void Fill(this DataList dataList, DataView dataView)
		{
			Fill<DataList, DataView>(dataList, dataView);
		}

		public static void Fill(this Repeater repeater, SqlDataReader dataReader)
		{
			Fill<Repeater, SqlDataReader>(repeater, dataReader);
		}

		public static void Fill(this Repeater repeater, DataTable dataTable)
		{
			Fill<Repeater, DataTable>(repeater, dataTable);
		}

		public static void Fill(this Repeater repeater, DataSet dataSet)
		{
			Fill<Repeater, DataSet>(repeater, dataSet);
		}

		public static void Fill(this Repeater repeater, DataView dataView)
		{
			Fill<Repeater, DataView>(repeater, dataView);
		}

		public static void Fill(this GridView gridView, SqlDataReader dataReader)
		{
			Fill<GridView, SqlDataReader>(gridView, dataReader);
		}

		public static void Fill(this GridView gridView, DataTable dataTable)
		{
			Fill<GridView, DataTable>(gridView, dataTable);
		}

		public static void Fill(this GridView gridView, DataSet dataSet)
		{
			Fill<GridView, DataSet>(gridView, dataSet);
		}

		public static void Fill(this GridView gridView, DataView dataView)
		{
			Fill<GridView, DataView>(gridView, dataView);
		}

		private static void Fill<U, T>(U dataControl, T data)
		{
			if (dataControl != null)
			{
				bool isValidParameters = false;

				if (
					SObject.IsTypeInList(
						dataControl,
						typeof(DataList), typeof(Repeater), typeof(GridView)
					)
				)
				{
					if (
						(data == null) ||
						SObject.IsTypeInList(
							data,
							typeof(SqlDataReader), typeof(DataTable), typeof(DataSet), typeof(DataView)
						)
					)
					{
						isValidParameters = true;
					}
					else
					{
						throw new InvalidCastException("Data parameter is not valid, you are only alowed to use: SqlDataReader, DataTable, DataSet and DataView");
					}
				}
				else
				{
					throw new InvalidCastException("Control parameter is not valid, you are only alowed to use: DataList, Repeater and GridView");
				}

				if (isValidParameters)
				{
					try
					{
						dataControl.GetType().GetProperty("DataSource").SetValue(dataControl, data);
						dataControl.GetType().GetMethod("DataBind").Invoke(dataControl, null);
					}
					catch (Exception)
					{
						if (dataControl is DataList)
						{
							DataList dl = dataControl as DataList;
							dl.DataSource = data;
							dl.DataBind();
						}
						else if (dataControl is Repeater)
						{
							Repeater rptr = dataControl as Repeater;
							rptr.DataSource = data;
							rptr.DataBind();
						}
						else if (dataControl is GridView)
						{
							GridView grv = dataControl as GridView;
							grv.DataSource = data;
							grv.DataBind();
						}
					}

					if ((data != null) && (data is SqlDataReader))
					{
						data.GetType().GetMethod("Close").Invoke(data, null);
					}
				}
			}
		}

		public static void FillThenDispose(this DataList dataList, SqlDataReader dataReader)
		{
			FillThenDispose<DataList, SqlDataReader>(dataList, dataReader);
		}

		public static void FillThenDispose(this DataList dataList, DataTable dataTable)
		{
			FillThenDispose<DataList, DataTable>(dataList, dataTable);
		}

		public static void FillThenDispose(this DataList dataList, DataSet dataSet)
		{
			FillThenDispose<DataList, DataSet>(dataList, dataSet);
		}

		public static void FillThenDispose(this DataList dataList, DataView dataView)
		{
			FillThenDispose<DataList, DataView>(dataList, dataView);
		}

		public static void FillThenDispose(this Repeater repeater, SqlDataReader dataReader)
		{
			FillThenDispose<Repeater, SqlDataReader>(repeater, dataReader);
		}

		public static void FillThenDispose(this Repeater repeater, DataTable dataTable)
		{
			FillThenDispose<Repeater, DataTable>(repeater, dataTable);
		}

		public static void FillThenDispose(this Repeater repeater, DataSet dataSet)
		{
			FillThenDispose<Repeater, DataSet>(repeater, dataSet);
		}

		public static void FillThenDispose(this Repeater repeater, DataView dataView)
		{
			FillThenDispose<Repeater, DataView>(repeater, dataView);
		}

		public static void FillThenDispose(this GridView gridView, SqlDataReader dataReader)
		{
			FillThenDispose<GridView, SqlDataReader>(gridView, dataReader);
		}

		public static void FillThenDispose(this GridView gridView, DataTable dataTable)
		{
			FillThenDispose<GridView, DataTable>(gridView, dataTable);
		}

		public static void FillThenDispose(this GridView gridView, DataSet dataSet)
		{
			FillThenDispose<GridView, DataSet>(gridView, dataSet);
		}

		public static void FillThenDispose(this GridView gridView, DataView dataView)
		{
			FillThenDispose<GridView, DataView>(gridView, dataView);
		}

		private static void FillThenDispose<U, T>(U dataControl, T data) where T : IDisposable
		{
			using (data)
			{
				Fill<U, T>(dataControl, data);
			}
		}

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

		private static void FillThenDispose<T>(this ListControl listControl, T data, string valueField, string textField, ListItem positionZeroItem, ListItem emptyCaseItem) where T : IDisposable
		{
			using (data)
			{
				Fill(listControl, data, valueField, textField, positionZeroItem, emptyCaseItem);
			}
		}
	}
}