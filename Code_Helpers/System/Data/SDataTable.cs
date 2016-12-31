using System.Data;

namespace Code_Helpers.System.Data
{
	public static class SDataTable
	{
		#region Public Methods

		public static DataRow GetFirstRow(this DataTable dataTable)
		{
			return SDataRow.GetFirstRow<DataTable>(dataTable);
		}

		public static bool HasNoRows(this DataTable dataTable)
		{
			return HasRows(dataTable).Not();
		}

		public static bool HasRows(this DataTable dataTable)
		{
			return SDataRow.HasRows<DataTable>(dataTable);
		}

		#endregion Public Methods
	}
}