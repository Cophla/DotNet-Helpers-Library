namespace CodeHelpers.System
{
	public static class SBool
	{
		#region Public Methods

		public static bool IsNotTrue(this bool value)
		{
			return IsFalse(value);
		}

		public static bool IsFalse(this bool value)
		{
			return value == false;
		}

		public static bool IsTrue(this bool value)
		{
			return value == true;
		}

		public static bool Not(this bool value)
		{
			return !value;
		}

		#endregion Public Methods
	}
}