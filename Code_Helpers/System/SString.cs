using System;

namespace Code_Helpers.System
{
	public static class SString
	{
		#region Public Methods

		public static bool ContainsInsensitive(this string text, string value)
		{
			return (text.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0);
		}

		public static string ConvertStarToPercent(string text)
		{
			return (
				IsNotNullOrWhiteSpace(text) ? text.Replace('*', '%') : text
			);
		}

		public static bool IsNone(string value)
		{
			if (SCode.IsNull(value))
				return true;
			if (value == string.Empty)
				return true;
			return IsNullOrWhiteSpace(value);
		}

		public static bool IsNotNone(string value)
		{
			return !IsNone(value);
		}

		public static bool IsNotNullOrEmpty(string value)
		{
			return !string.IsNullOrEmpty(value);
		}

		public static bool IsNotNullOrWhiteSpace(string value)
		{
			return !string.IsNullOrWhiteSpace(value);
		}

		public static bool IsNullOrEmpty(string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static bool IsNullOrWhiteSpace(string value)
		{
			return string.IsNullOrWhiteSpace(value);
		}

		public static bool NotContains(this string text, string value)
		{
			return !text.Contains(value);
		}

		public static bool NotContainsInsensitive(this string text, string value)
		{
			return !text.ContainsInsensitive(value);
		}

		#endregion Public Methods
	}
}