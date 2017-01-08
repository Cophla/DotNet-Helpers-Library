using CodeHelpers.ModelHelper.NoneStatic.TableModel;
using CodeHelpers.ObjectHelper;
using CodeHelpers.System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CodeHelpers.ModelHelper.Static
{
	public static class STableModel
	{
		#region Public Methods

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