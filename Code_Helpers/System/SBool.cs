namespace Code_Helpers.System
{
	public struct SBool
	{
		#region Public Methods

		public static bool IsNotTrue(bool value)
		{
			return value == false;
		}

		public static bool IsTrue(bool value)
		{
			return value == true;
		}

		public static bool Not(bool value)
		{
			return !value;
		}

		#endregion Public Methods
	}
}