using System.Data;

namespace Code_Helpers.System.Data
{
	public static class SDataView
	{
		#region Public Methods

		public static DataRow GetFirstRow(this DataView dataView)
		{
			return SDataRow.GetFirstRow<DataView>(dataView);
		}

		public static bool HasNoRows(this DataView dataTable)
		{
			return HasRows(dataTable).Not();
		}

		public static bool HasRows(this DataView dataTable)
		{
			return SDataRow.HasRows<DataView>(dataTable);
		}

		#endregion Public Methods
	}
}