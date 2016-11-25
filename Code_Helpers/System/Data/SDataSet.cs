using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Helpers.System.Data
{
	public static class SDataSet
	{
		public static bool HasRows(this DataSet dataSet)
		{
			return SDataRow.HasRows<DataSet>(dataSet);
		}

		public static DataRow GetFirstRow(this DataSet dataSet)
		{
			return SDataRow.GetFirstRow<DataSet>(dataSet);
		}
	}
}
