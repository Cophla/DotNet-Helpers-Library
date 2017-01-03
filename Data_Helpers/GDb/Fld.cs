using Data_Helpers.GDb.GTbl;
using System.Data;

namespace Fld
{
	namespace DataBaseName
	{
		/// <summary></summary>
		public static class FldTable1
		{
			#region Public Fields

			/// <summary></summary>
			public static readonly TblField FIELD_NAME = new TblField("@StrParm", "FldName", SqlDbType.NVarChar, 50);

			#endregion Public Fields
		}
	}
}