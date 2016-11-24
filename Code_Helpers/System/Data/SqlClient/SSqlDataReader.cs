using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Helpers.System.Data.SqlClient
{
	public static class SSqlDataReader
	{
		private static T Get<T>(
					this SqlDataReader dataReader
				) where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize, new()
		{
			T data = null;
			if (
				!SCode.IsTypeInList(
					data,
					typeof(DataSet), typeof(DataView), typeof(DataTable)
				)
			)
			{
				throw new Exception("You are not allowed to use this type of object. You are only allowed to use DataSet, DataView or DataTable");
			}
			DataTable dtbl = null;
			using (dataReader)
			{
				if (dataReader != null)
				{
					dtbl = new DataTable();
					dtbl.Load(dataReader);
				}
			}
			if (dtbl != null)
			{
				data = new T();

				if (data is DataSet)
				{
					(data as DataSet).Tables.Add(dtbl);
				}
				else if (data is DataView)
				{
					(data as DataView).Table = dtbl;
				}
				else if (data is DataTable)
				{
					data = SObject.ConvertAs<T>(dtbl);
				}
			}
			return data;
		}
	}
}
