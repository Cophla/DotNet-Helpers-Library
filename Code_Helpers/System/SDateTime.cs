using System;

namespace CodeHelpers.System
{
	public static class SDateTime
	{
		#region Public Methods

		public static DateTime ToClientTime(this DateTime dt, string timezoneOffset)
		{
			// if there is no offset return the datetime in server timezone
			if (timezoneOffset.IsNone())
				return dt.ToLocalTime();

			// if there is no offset return the datetime in server timezone
			int integerTimeZone;
			if (int.TryParse(timezoneOffset, out integerTimeZone).IsNotTrue())
				return dt.ToLocalTime();

			return ToClientTime(dt, integerTimeZone);
		}

		public static DateTime ToClientTime(this DateTime dt, int timezoneOffset)
		{
			return dt.AddMinutes(-1 * timezoneOffset);
		}

		public static DateTime ToServerTime(this DateTime dt, string timezoneOffset)
		{
			// if there is no offset return the datetime in server timezone
			if (timezoneOffset.IsNone())
				return dt.ToLocalTime();

			int integerTimeZone;
			// if there is no offset return the datetime in server timezone
			if (int.TryParse(timezoneOffset, out integerTimeZone).IsNotTrue())
				return dt.ToLocalTime();

			return ToServerTime(dt, integerTimeZone);
		}

		public static DateTime ToServerTime(this DateTime dt, int timezoneOffset)
		{
			return dt.AddMinutes(timezoneOffset);
		}

		#endregion Public Methods
	}
}