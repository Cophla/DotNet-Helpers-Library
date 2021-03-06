﻿using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebFormsHelpers.System.Web.UI.WebControls
{
	public static class SRepeater
	{
		#region Public Methods

		public static void Clear(this Repeater repeater)
		{
			SControl.Clear(repeater);
		}

		public static void Fill(this Repeater repeater, SqlDataReader dataReader)
		{
			SControl.Fill(repeater, dataReader);
		}

		public static void Fill(this Repeater repeater, DataTable dataTable)
		{
			SControl.Fill(repeater, dataTable);
		}

		public static void Fill(this Repeater repeater, DataSet dataSet)
		{
			SControl.Fill(repeater, dataSet);
		}

		public static void Fill(this Repeater repeater, DataView dataView)
		{
			SControl.Fill(repeater, dataView);
		}

		public static void FillThenDispose(this Repeater repeater, SqlDataReader dataReader)
		{
			SControl.FillThenDispose(repeater, dataReader);
		}

		public static void FillThenDispose(this Repeater repeater, DataTable dataTable)
		{
			SControl.FillThenDispose(repeater, dataTable);
		}

		public static void FillThenDispose(this Repeater repeater, DataSet dataSet)
		{
			SControl.FillThenDispose(repeater, dataSet);
		}

		public static void FillThenDispose(this Repeater repeater, DataView dataView)
		{
			SControl.FillThenDispose(repeater, dataView);
		}

		#endregion Public Methods
	}
}