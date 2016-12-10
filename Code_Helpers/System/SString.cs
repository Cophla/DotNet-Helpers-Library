using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Code_Helpers.System
{
	public static class SString
	{
		#region Public Methods

		public static bool Contains(this string text, string value, bool ignoreCase)
		{
			if (ignoreCase.IsNotTrue())
				return (text.IndexOf(value, StringComparison.InvariantCulture) >= 0);

			return (text.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0);
		}

		public static string ConvertStarToPercent(this string text)
		{
			return (
				IsNotNullOrWhiteSpace(text) ? text.Replace('*', '%') : text
			);
		}

		public static bool Equals(this string text, string otherText)
		{
			if (SObject.IsNullInList(text, otherText))
				return false;
			return text.Equals(otherText, StringComparison.InvariantCultureIgnoreCase);
		}

		public static string Format(string format, params object[] args)
		{
			return string.Format(CultureInfo.InvariantCulture, format, args);
		}

		public static string Format(this string value, string format)
		{
			return string.Format(CultureInfo.InvariantCulture, format, value);
		}

		public static bool IsNone(this string value)
		{
			if (value.IsNull())
				return true;
			if (value == string.Empty)
				return true;
			return IsNullOrWhiteSpace(value);
		}

		public static bool IsNotNone(this string value)
		{
			return IsNone(value).Not();
		}

		public static bool IsNotNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value).Not();
		}

		public static bool IsNotNullOrWhiteSpace(this string value)
		{
			return string.IsNullOrWhiteSpace(value).Not();
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static bool IsNullOrWhiteSpace(this string value)
		{
			return string.IsNullOrWhiteSpace(value);
		}

		public static bool IsStringInAllEqual(this string value, IEnumerable<string> checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			foreach (string item in checkList)
				if (Equals(value, item).IsNotTrue())
					return false;

			return true;
		}

		public static bool IsStringInAllEqual(this string value, params string[] checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			foreach (string item in checkList)
				if (Equals(value, item).IsNotTrue())
					return false;

			return true;
		}

		public static bool IsStringInAllEqualParallel(this string value, IEnumerable<string> checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().All((checkListItem) => Equals(value, checkListItem));
		}

		public static bool IsStringInAllEqualParallel(this string value, params string[] checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().All((checkListItem) => Equals(value, checkListItem));
		}

		public static bool IsStringInList(this string value, IEnumerable<string> checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			foreach (string item in checkList)
				if (Equals(value, item))
					return true;

			return false;
		}

		public static bool IsStringInList(this string value, params string[] checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			foreach (string item in checkList)
				if (Equals(value, item))
					return true;

			return false;
		}

		public static bool IsStringInListParallel(this string value, IEnumerable<string> checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().Contains(value, StringComparer.InvariantCultureIgnoreCase);
		}

		public static bool IsStringInListParallel(this string value, params string[] checkList)
		{
			if (SObject.IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().Contains(value, StringComparer.InvariantCultureIgnoreCase);
		}

		public static bool NotContains(this string text, string value)
		{
			return text.Contains(value).Not();
		}

		public static bool NotContains(this string text, string value, bool ignoreCase)
		{
			return Contains(text, value, ignoreCase).Not();
		}

		public static bool NotEquals(this string text, string otherText)
		{
			return Equals(text, otherText).Not();
		}

		public static string ToTitleCase(this string value)
		{
			if (IsNone(value))
				return string.Empty;

			TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
			return textInfo.ToTitleCase(value);
		}

		#endregion Public Methods
	}
}