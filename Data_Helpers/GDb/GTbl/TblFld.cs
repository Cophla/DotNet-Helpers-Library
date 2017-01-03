using System.Data;

namespace Data_Helpers.GDb.GTbl
{
	/// <summary></summary>
	public class TblField
	{
		#region Private Fields

		/// <summary></summary>
		private readonly SqlDbType dbType;

		/// <summary></summary>
		private readonly string fldName;

		/// <summary></summary>
		private readonly int size;

		/// <summary></summary>
		private readonly string strParm;

		#endregion Private Fields

		#region Public Constructors

		/// <summary></summary>
		/// <param name="strParm"></param>
		/// <param name="fldName"></param>
		/// <param name="dbType"></param>
		public TblField(string strParm, string fldName, SqlDbType dbType) : this(strParm, fldName, dbType, -1) { }

		/// <summary></summary>
		/// <param name="strParm"></param>
		/// <param name="fldName"></param>
		/// <param name="dbType"></param>
		/// <param name="size"></param>
		public TblField(string strParm, string fldName, SqlDbType dbType, int size)
		{
			this.strParm = strParm;
			this.fldName = fldName;
			this.dbType = dbType;
			this.size = size;
		}

		#endregion Public Constructors

		#region Public Properties

		/// <summary></summary>
		public SqlDbType DbType {
			get { return dbType; }
		}

		/// <summary></summary>
		public string FldName {
			get { return fldName; }
		}

		/// <summary></summary>
		public int Size {
			get { return size; }
		}

		/// <summary></summary>
		public string StrParm {
			get { return strParm; }
		}

		#endregion Public Properties
	}
}