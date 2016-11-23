using Code_Helpers;
using System;
using System.ComponentModel;
using System.Data;

namespace Data_Helpers
{
	public static class SData
	{
		#region Public Methods

		public static DataRow GetFirstRow(DataSet dataSet)
		{
			return GetFirstRow<DataSet>(dataSet);
		}

		public static DataRow GetFirstRow(DataTable dataTable)
		{
			return GetFirstRow<DataTable>(dataTable);
		}

		public static DataRow GetFirstRow(DataView dataView)
		{
			return GetFirstRow<DataView>(dataView);
		}

		public static bool HasRows(DataView dataView)
		{
			return HasRows<DataView>(dataView);
		}

		public static bool HasRows(DataTable dataTable)
		{
			return HasRows<DataTable>(dataTable);
		}

		public static bool HasRows(DataSet dataSet)
		{
			return HasRows<DataSet>(dataSet);
		}

		public static T ValueAs<T>(object obj)
		{
			return ValueAs(obj, default(T));
		}

		public static T ValueAs<T>(object obj, T defaultValue)
		{
			T result = defaultValue;
			if (SCode.IsNotNullOrDBNull(obj))
			{
				if (result is string)
				{
					result = SCode.CastAs<T>(SCode.ConvertAs<string>(obj).Trim());
				}
				else
				{
					result = SCode.ConvertAs<T>(obj);
				}
			}
			return result;
		}

		#endregion Public Methods

		#region Private Methods

		private static DataRow GetFirstRow<T>(T data)
							where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize
		{
			DataRow dataRow = null;
			if (SCode.IsNotNull(data))
			{
				if (
					SCode.IsTypeInList(
						data,
						typeof(DataSet), typeof(DataTable), typeof(DataView)
					)
				)
				{
					if (data is DataSet)
					{
						DataSet dataSet = data as DataSet;
						if (dataSet.Tables.Count > 0)
						{
							if (dataSet.Tables[0].Rows.Count > 0)
							{
								dataRow = dataSet.Tables[0].Rows[0];
							}
						}
					}
					else if (data is DataTable)
					{
						DataTable dataTable = data as DataTable;
						if (dataTable.Rows.Count > 0)
						{
							dataRow = dataTable.Rows[0];
						}
					}
					else if (data is DataView)
					{
						DataView dataView = data as DataView;
						if (SCode.IsNotNull(dataView.Table))
						{
							if (dataView.Table.Rows.Count > 0)
							{
								dataRow = dataView.Table.Rows[0];
							}
						}
					}
				}
				else
				{
					throw new InvalidCastException("Data parameter is not valid, you are only alowed to use: DataTable, DataSet and DataView");
				}
			}
			return dataRow;
		}

		private static bool HasRows<T>(T data)
			where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize
		{
			return SCode.IsNotNull(GetFirstRow(data));
		}

		#endregion Private Methods
	}
}