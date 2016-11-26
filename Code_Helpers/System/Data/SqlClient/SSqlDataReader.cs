using Data_Helpers.GDb.GTbl.GCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Code_Helpers.System.Data.SqlClient
{
	public static class SSqlDataReader
	{
		#region Public Methods

		public static DataSet GetDataSet(this SqlDataReader dataReader)
		{
			return Get<DataSet>(dataReader);
		}

		public static DataTable GetDataTable(this SqlDataReader dataReader)
		{
			return Get<DataTable>(dataReader);
		}

		public static DataView GetDataView(this SqlDataReader dataReader)
		{
			return Get<DataView>(dataReader);
		}

		#endregion Public Methods

		#region Private Methods

		private static T Get<T>(this SqlDataReader dataReader)
			where T : MarshalByValueComponent, ISupportInitializeNotification, ISupportInitialize, new()
		{
			T data = null;
			if (
				!SObject.IsTypeInList<T>(
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

		#endregion Private Methods

		public static IEnumerable<T> GetObjList<T>(this SqlDataReader dataReader, out string errorMsg) where T : IGTbl, new()
		{
			errorMsg = string.Empty;
			ICollection<T> objList = null;
			using (dataReader)
			{
				if (dataReader != null)
				{
					try
					{
						objList = new List<T>(40);
						while (dataReader.Read())
						{
							T obj = new T();
							obj.Fill(dataReader);
							objList.Add(obj);
						}
					}
					catch (Exception ex) { errorMsg = ex.ToString(); }
				}
			}
			return objList;
		}

		public static IEnumerable<T> GetObjList<T>(this SqlDataReader dataReader) where T : IGTbl, new()
		{
			string errorMsg;
			return GetObjList<T>(dataReader, out errorMsg);
		}
	}
}