using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Helpers.System.Data.SqlClient
{
	public static class SSqlParameter
	{
		public static SqlParameter Create(string parameterName, object value)
		{
			return new SqlParameter(parameterName, value);
		}

		public static SqlParameter CreateOut(string parameterName, SqlDbType sqlDbType)
		{
			SqlParameter newParm = new SqlParameter(parameterName, sqlDbType);
			newParm.Direction = ParameterDirection.Output;
			return newParm;
		}

		public static SqlParameter CreateOut(string parameterName, SqlDbType sqlDbType, int size)
		{
			SqlParameter newParm = new SqlParameter(parameterName, sqlDbType, size);
			newParm.Direction = ParameterDirection.Output;
			return newParm;
		}
	}
}
