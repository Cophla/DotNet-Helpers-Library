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
			if (dataReader.IsNull())
				return null;

			if (SObject.IsTypeNotInList<T>(typeof(DataSet), typeof(DataView), typeof(DataTable)))
			{
				throw new Exception("You are not allowed to use this type of object. You are only allowed to use DataSet, DataView or DataTable");
			}

			DataTable dtbl = null;
			using (dataReader)
			{
				dtbl = new DataTable();
				dtbl.Load(dataReader);
			}

			T data = new T();
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
				data = SObject.CastAs<T>(dtbl);
			}

			return data;
		}

		#endregion Private Methods

		public static IEnumerable<T> GetObjList<T>(this SqlDataReader dataReader, out string errorMsg)
			where T : IGTbl, new()
		{
			errorMsg = string.Empty;
			if (dataReader.IsNull())
				return null;

			ICollection<T> objList = null;
			using (dataReader)
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
			return objList;
		}

		public static IEnumerable<T> GetObjList<T>(this SqlDataReader dataReader) where T : IGTbl, new()
		{
			string errorMsg;
			return GetObjList<T>(dataReader, out errorMsg);
		}
	}
}