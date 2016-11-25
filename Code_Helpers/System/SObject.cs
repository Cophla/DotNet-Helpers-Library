using System;

namespace Code_Helpers.System
{
	public static class SObject
	{
		#region Public Methods

		public static T CastAs<T>(this object obj)
		{
			if (IsDBNull(obj))
			{
				obj = null;
				return (T)obj;
			}
			return (T)obj;
		}

		public static T ConvertAs<T>(this object obj)
		{
			return ConvertAs(obj, default(T));
		}

		public static T ConvertAs<T>(this object obj, T defaultValue)
		{
			T result = defaultValue;

			if (IsNotNullOrDBNull(obj))
			{
				Type normalType = typeof(T);
				Type nullableType = Nullable.GetUnderlyingType(normalType);

				result = CastAs<T>(
					(IsNotNull(nullableType)) ?
					Convert.ChangeType(obj, nullableType) :
					Convert.ChangeType(obj, normalType)
				);
			}

			return result;
		}

		public static T DbValueAs<T>(this object obj, T defaultValue)
		{
			T result = defaultValue;
			if (IsNotNullOrDBNull(obj))
			{
				if (result is string)
				{
					result = CastAs<T>(ConvertAs<string>(obj).Trim());
				}
				else
				{
					result = ConvertAs<T>(obj);
				}
			}
			return result;
		}

		public static T DbValueAs<T>(this object obj)
		{
			return DbValueAs(obj, default(T));
		}

		public static bool Equals<T>(this object obj, object otherObj)
		{
			return SCode.Equals<T>(ConvertAs<T>(obj), ConvertAs<T>(otherObj));
		}

		public static bool IsDBNull(this object obj)
		{
			return Convert.IsDBNull(obj);
		}

		public static bool IsNotDBNull(object obj)
		{
			return !IsDBNull(obj);
		}

		public static bool IsNotNull(object obj)
		{
			return obj != null;
		}

		public static bool IsNotNullOrDBNull(object obj)
		{
			return !IsNullOrDBNull(obj);
		}

		public static bool IsNull(object obj)
		{
			return obj == null;
		}

		public static bool IsNullOrDBNull(object obj)
		{
			return IsNull(obj) || IsDBNull(obj);
		}

		public static bool NotEquals<T>(this object obj, object otherObj)
		{
			return !Equals<T>(obj, otherObj);
		}

		#endregion Public Methods
	}
}