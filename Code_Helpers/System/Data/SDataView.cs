using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Helpers.System.Data
{
	public static class SDataView
	{
		public static bool HasRows(this DataView dataTable)
		{
			return SDataRow.HasRows<DataView>(dataTable);
		}

		public static DataRow GetFirstRow(this DataView dataView)
		{
			return SDataRow.GetFirstRow<DataView>(dataView);
		}
	}
}
