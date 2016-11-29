using System;
using System.ComponentModel;
using System.Data;

namespace Code_Helpers.System.Data
{
	public static class SDataRow
	{
		#region Public Methods

		public static DataRow GetFirstRow<T>(T data)
							where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize
		{
			if (data.IsNull())
				return null;

			if (
				SObject.IsTypeNotInList<T>(
					typeof(DataSet), typeof(DataTable), typeof(DataView)
				)
			)
				throw new InvalidCastException("Data parameter is not valid, you are only alowed to use: DataTable, DataSet and DataView");

			if (data is DataSet)
			{
				DataSet dataSet = data as DataSet;
				if (dataSet.Tables.Count < 1)
					return null;

				if (dataSet.Tables[0].Rows.Count < 1)
					return null;

				return dataSet.Tables[0].Rows[0];
			}

			if (data is DataTable)
			{
				DataTable dataTable = data as DataTable;
				if (dataTable.Rows.Count < 1)
					return null;

				return dataTable.Rows[0];
			}

			if (data is DataView)
			{
				DataView dataView = data as DataView;
				if (dataView.Table.IsNull())
					return null;

				if (dataView.Table.Rows.Count < 1)
					return null;

				return dataView.Table.Rows[0];
			}

			return null;
		}

		public static bool HasRows<T>(T data)
			where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize
		{
			return GetFirstRow(data).IsNotNull();
		}

		#endregion Public Methods
	}
}