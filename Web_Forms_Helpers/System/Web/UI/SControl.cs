﻿using Code_Helpers.System;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Forms_Helpers.System.Web.UI
{
	public static class SControl
	{
		public static void Fill(this BaseDataList dataList, IDataSource dataSource)
		{
			Fill<BaseDataList, IDataSource>(dataList, dataSource);
		}

		public static void Fill(this BaseDataList dataList, IEnumerable enumerable)
		{
			Fill<BaseDataList, IEnumerable>(dataList, enumerable);
		}

		public static void Fill(this BaseDataList dataList, IListSource listSource)
		{
			Fill<BaseDataList, IListSource>(dataList, listSource);
		}

		public static void Fill(this Repeater repeater, IDataSource dataSource)
		{
			Fill<Repeater, IDataSource>(repeater, dataSource);
		}

		public static void Fill(this Repeater repeater, IEnumerable enumerable)
		{
			Fill<Repeater, IEnumerable>(repeater, enumerable);
		}

		public static void Fill(this Repeater repeater, IListSource listSource)
		{
			Fill<Repeater, IListSource>(repeater, listSource);
		}

		public static void Fill(this BaseDataBoundControl dataBoundControl, IDataSource dataSource)
		{
			Fill<BaseDataBoundControl, IDataSource>(dataBoundControl, dataSource);
		}

		public static void Fill(this BaseDataBoundControl dataBoundControl, IEnumerable enumerable)
		{
			Fill<BaseDataBoundControl, IEnumerable>(dataBoundControl, enumerable);
		}

		public static void Fill(this BaseDataBoundControl dataBoundControl, IListSource listSource)
		{
			Fill<BaseDataBoundControl, IListSource>(dataBoundControl, listSource);
		}

		private static void Fill<U, T>(U dataControl, T data)
			where U : class
			where T : class
		{
			if (dataControl.IsNull()) return;

				bool isValidParameters = false;

				if (
					SObject.IsTypeInList<U>(
						typeof(BaseDataList), typeof(Repeater), typeof(BaseDataBoundControl)
					)
				)
				{
					if (
						(data == null) ||
						SObject.IsTypeInList<T>(
							typeof(IListSource), typeof(IEnumerable), typeof(IDataSource)
						)
					)
					{
						isValidParameters = true;
					}
					else
					{
						throw new InvalidCastException("Data parameter is not valid, you are only alowed to use: SqlDataReader, IDataSource, IEnumerable and IListSource");
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
						if (dataControl is BaseDataList)
						{
							BaseDataList dl = dataControl as BaseDataList;
							dl.DataSource = data;
							dl.DataBind();
						}
						else if (dataControl is Repeater)
						{
							Repeater rptr = dataControl as Repeater;
							rptr.DataSource = data;
							rptr.DataBind();
						}
						else if (dataControl is BaseDataBoundControl)
						{
							BaseDataBoundControl grv = dataControl as BaseDataBoundControl;
							grv.DataSource = data;
							grv.DataBind();
						}
					}

					if ((data != null) && (data is DbDataReader))
					{
						data.GetType().GetMethod("Close").Invoke(data, null);
					}
				}
			
		}

		public static void FillThenDispose(this BaseDataList dataList, IDataSource dataSource)
		{
			FillThenDispose<BaseDataList, IDataSource>(dataList, dataSource);
		}

		public static void FillThenDispose(this BaseDataList dataList, IEnumerable enumerable)
		{
			FillThenDispose<BaseDataList, IEnumerable>(dataList, enumerable);
		}

		public static void FillThenDispose(this BaseDataList dataList, IListSource listSource)
		{
			FillThenDispose<BaseDataList, IListSource>(dataList, listSource);
		}

		public static void FillThenDispose(this Repeater repeater, IDataSource dataSource)
		{
			FillThenDispose<Repeater, IDataSource>(repeater, dataSource);
		}

		public static void FillThenDispose(this Repeater repeater, IEnumerable enumerable)
		{
			FillThenDispose<Repeater, IEnumerable>(repeater, enumerable);
		}

		public static void FillThenDispose(this Repeater repeater, IListSource listSource)
		{
			FillThenDispose<Repeater, IListSource>(repeater, listSource);
		}

		public static void FillThenDispose(this BaseDataBoundControl dataBoundControl, IDataSource dataSource)
		{
			FillThenDispose<BaseDataBoundControl, IDataSource>(dataBoundControl, dataSource);
		}

		public static void FillThenDispose(this BaseDataBoundControl dataBoundControl, IEnumerable enumerable)
		{
			FillThenDispose<BaseDataBoundControl, IEnumerable>(dataBoundControl, enumerable);
		}

		public static void FillThenDispose(this BaseDataBoundControl dataBoundControl, IListSource listSource)
		{
			FillThenDispose<BaseDataBoundControl, IListSource>(dataBoundControl, listSource);
		}

		private static void FillThenDispose<U, T>(U dataControl, T data)
			where U : class
			where T : class
		{
			IDisposable disposableData = data as IDisposable;
			if (disposableData == null) return;

			using (disposableData)
			{
				Fill<U, T>(dataControl, data);
			}
		}
	}
}