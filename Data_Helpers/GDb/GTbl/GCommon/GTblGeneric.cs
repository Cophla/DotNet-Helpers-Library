namespace Data_Helpers.GDb.GTbl.GCommon
{
	/// <summary>
	/// </summary>
	public class GTblGeneric
	{
		#region Protected Fields

		/// <summary>
		/// </summary>
		protected bool enabled;

		/// <summary>
		/// </summary>
		protected string selectAllStoredProcdureName;

		#endregion Protected Fields

		#region Private Fields

		/// <summary>
		/// </summary>
		private string modelName;

		#endregion Private Fields

		#region Public Properties

		/// <summary>
		/// </summary>
		public virtual bool Enabled {
			get { return enabled; }
			set { enabled = value; }
		}

		/// <summary>
		/// </summary>
		public string ModelName {
			get { return modelName; }
			set { modelName = value; }
		}

		#endregion Public Properties
	}

	/// <summary>
	/// </summary>
	/// <typeparam name="T">
	/// </typeparam>
	public class GTblGeneric<T> : GTblGeneric
	{
		#region Protected Fields

		/// <summary>
		/// </summary>
		protected T primaryKey;

		#endregion Protected Fields

		#region Public Properties

		/// <summary>
		/// </summary>
		public T PrimaryKey {
			get { return primaryKey; }
			set { primaryKey = value; }
		}

		#endregion Public Properties
	}
}