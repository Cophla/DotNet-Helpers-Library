using System.Data;

namespace Code_Helpers.System.Data
{
	public static class SDataSet
	{
		#region Public Methods

		public static DataRow GetFirstRow(this DataSet dataSet)
		{
			return SDataRow.GetFirstRow<DataSet>(dataSet);
		}

		public static bool HasNoRows(this DataSet dataSet)
		{
			return HasRows(dataSet).Not();
		}

		public static bool HasRows(this DataSet dataSet)
		{
			return SDataRow.HasRows<DataSet>(dataSet);
		}

		#endregion Public Methods
	}
}