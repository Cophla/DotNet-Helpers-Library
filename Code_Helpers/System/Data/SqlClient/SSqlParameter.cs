using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.System.Data.SqlClient
{
	public static class SSqlParameter
	{
		#region Public Methods

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

		#endregion Public Methods
	}
}