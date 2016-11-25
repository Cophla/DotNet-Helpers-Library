using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Helpers.System.Data
{
	public static class SDataTable
	{
		public static bool HasRows(this DataTable dataTable)
		{
			return SDataRow.HasRows<DataTable>(dataTable);
		}

		public static DataRow GetFirstRow(this DataTable dataTable)
		{
			return SDataRow.GetFirstRow<DataTable>(dataTable);
		}
	}
}
