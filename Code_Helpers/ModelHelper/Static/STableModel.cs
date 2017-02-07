using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CodeHelpers.ModelHelper.NoneStatic.TableModel;
using CodeHelpers.System;

namespace CodeHelpers.ModelHelper.Static
{
	public static class STableModel
	{
		#region Public Methods

		public static IEnumerable<T> GetObjList<T>() where T : ITableModel, new()
		{
			using (T tblModel = new T())
			using (SqlDataReader dataReader = tblModel.GetAll())
			{
				if (dataReader.IsNull()) return null;

				ICollection<T> objList = new List<T>(40);
				while (dataReader.Read())
				{
					T obj = new T();
					obj.Fill(dataReader);
					objList.Add(obj);
				}
				return objList;
			}
		}

		public static IEnumerable<T> GetObjList<T>(this SqlDataReader dataReader, out string errorMsg)
			where T : ITableModel, new()
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

		public static IEnumerable<T> GetObjList<T>(this SqlDataReader dataReader, MessageString errorMsg)
			where T : ITableModel, new()
		{
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
				catch (Exception ex) { errorMsg.Append(ex.ToString()); }
			}
			return objList;
		}

		public static IEnumerable<T> GetObjList<T>(this SqlDataReader dataReader) where T : ITableModel, new()
		{
			string errorMsg;
			return GetObjList<T>(dataReader, out errorMsg);
		}

		#endregion Public Methods
	}
}