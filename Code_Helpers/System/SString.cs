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

		public static string ConvertStarToPercent(this string text)
		{
			return (
				IsNotNullOrWhiteSpace(text) ? text.Replace('*', '%') : text
			);
		}

		public static bool IsNone(this string value)
		{
			if (SObject.IsNull(value))
				return true;
			if (value == string.Empty)
				return true;
			return IsNullOrWhiteSpace(value);
		}

		public static bool IsNotNone(this string value)
		{
			return !IsNone(value);
		}

		public static bool IsNotNullOrEmpty(this string value)
		{
			return !string.IsNullOrEmpty(value);
		}

		public static bool IsNotNullOrWhiteSpace(this string value)
		{
			return !string.IsNullOrWhiteSpace(value);
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static bool IsNullOrWhiteSpace(this string value)
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

		public static bool Equals(this string text, string otherText)
		{
			return SCode.Equals(text, otherText);
		}

		public static bool NotEquals(this string text, string otherText)
		{
			return SBool.Not(Equals(text, otherText));
		}

		#endregion Public Methods
	}
}