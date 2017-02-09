using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeHelpers.System
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
			if (IsNoneInList(obj))
				return defaultValue;

			Type normalType = typeof(T);
			Type nullableType = Nullable.GetUnderlyingType(normalType);

			return CastAs<T>(
				nullableType.IsNotNull() ?
				Convert.ChangeType(obj, nullableType) :
				Convert.ChangeType(obj, normalType)
			);
		}

		public static T DbValueAs<T>(this object obj, T defaultValue)
		{
			if (typeof(T) == typeof(string))
			{
				string convertedValue = ConvertAs<string>(obj, defaultValue as string);
				if (convertedValue.IsNull())
					return CastAs<T>(convertedValue);
				return CastAs<T>(convertedValue.Trim());
			}

			return ConvertAs<T>(obj, defaultValue);
		}

		public static T DbValueAs<T>(this object obj)
		{
			return DbValueAs(obj, default(T));
		}

		public static bool Dispose<T>(ref T disposableObject, Func<bool> boolMethod)
			where T : IDisposable
		{
			if (disposableObject.IsNull())
				return false;

			bool result = false;
			using (disposableObject)
			{
				result = boolMethod();
			}
			disposableObject = default(T);

			return result;
		}

		public static bool Dispose<T>(this T disposableObject, Func<bool> boolMethod)
			where T : IDisposable
		{
			return Dispose(ref disposableObject, boolMethod);
		}

		public static bool Equals<T>(this T value, T otherValue)
		{
			if (value is string)
				return SString.Equals(value as string, otherValue as string);

			if (IsNullInList(value, otherValue))
				return false;

			return value.Equals(otherValue);
		}

		public static bool Equals<T>(this object obj, object otherObj)
		{
			return Equals<T>(ConvertAs<T>(obj), ConvertAs<T>(otherObj));
		}

		public static string Format<T>(this object obj, string format)
		{
			string result = string.Empty;
			if (obj != null && !Convert.IsDBNull(obj))
			{
				result = SString.Format(
					$"{{0:{format}}}",
					(obj is T ? obj : ConvertAs<T>(obj))
				);
			}
			return result;
		}

		public static bool IsBetween<T>(this T value, T startValue, T endValue)
		{
			if (IsNullInList(value, startValue, endValue))
				return false;

			return (
				(
					Comparer<T>.Default.Compare(value, startValue) == 0 ||
					Comparer<T>.Default.Compare(value, startValue) > 0
				)
				&&
				(
					Comparer<T>.Default.Compare(value, endValue) == 0 ||
					Comparer<T>.Default.Compare(value, endValue) < 0
				)
			);
		}

		public static bool IsBetween<T>(this T value, object startValue, object endValue)
		{
			return IsBetween(value, ConvertAs<T>(startValue), ConvertAs<T>(endValue));
		}

		public static bool IsDBNull(this object obj)
		{
			return Convert.IsDBNull(obj);
		}

		public static bool IsDBNullInList(params object[] checkList)
		{
			foreach (object obj in checkList)
				if (obj.IsDBNull())
					return true;
			return false;
		}

		public static bool IsNoneInList(params object[] checkList)
		{
			foreach (object obj in checkList)
				if (obj.IsNullOrDBNull())
					return true;
			return false;
		}

		public static bool IsNotBetween<T>(this T value, T startValue, T endValue)
		{
			return IsBetween(value, startValue, endValue).Not();
		}

		public static bool IsNotBetween<T>(this T value, object startValue, object endValue)
		{
			return IsBetween(value, startValue, endValue).Not();
		}

		public static bool IsNotDBNull(this object obj)
		{
			return IsDBNull(obj).Not();
		}

		public static bool IsNotNull(this object obj)
		{
			return obj != null;
		}

		public static bool IsNotNullOrDBNull(this object obj)
		{
			return IsNullOrDBNull(obj).Not();
		}

		public static bool IsNotType<T>(this Type myType)
		{
			return IsType<T>(myType).Not();
		}

		public static bool IsNull(this object obj)
		{
			return obj == null;
		}

		public static bool IsNullInList(params object[] checkList)
		{
			foreach (object obj in checkList)
				if (obj.IsNull())
					return true;
			return false;
		}

		public static bool IsNullOrDBNull(this object obj)
		{
			return obj.IsNull() || obj.IsDBNull();
		}

		public static bool IsType<T>(this Type myType)
		{
			if (myType.IsNull())
				return false;

			Type valueType = typeof(T);
			if (valueType.IsAssignableFrom(myType))
				return true;

			valueType = null;

			return false;
		}

		public static bool IsTypeInList<T>(params Type[] checkList)
		{
			if (checkList.IsNull())
				return false;

			Type valueType = typeof(T);
			foreach (Type item in checkList)
				if (valueType.IsAssignableFrom(item))
					return true;

			valueType = null;

			return false;
		}

		public static bool IsTypeInList<T>(IEnumerable<Type> checkList)
		{
			if (checkList.IsNull())
				return false;

			Type valueType = typeof(T);
			foreach (Type item in checkList)
				if (valueType.IsAssignableFrom(item))
					return true;

			valueType = null;

			return false;
		}

		public static bool IsTypeInListParallel<T>(params Type[] checkList)
		{
			if (checkList.IsNull())
				return false;

			Type valueType = typeof(T);
			return checkList.AsParallel().First(
				(item) => valueType.IsAssignableFrom(item)).IsNotNull();
		}

		public static bool IsTypeInListParallel<T>(IEnumerable<Type> checkList)
		{
			if (checkList.IsNull())
				return false;

			Type valueType = typeof(T);
			return checkList.AsParallel().First(
				(item) => valueType.IsAssignableFrom(item)).IsNotNull();
		}

		public static bool IsTypeNotInList<T>(params Type[] checkList)
		{
			return IsTypeInList<T>(checkList).Not();
		}

		public static bool IsTypeNotInList<T>(IEnumerable<Type> checkList)
		{
			return IsTypeInList<T>(checkList).Not();
		}

		public static bool IsTypeNotInListParallel<T>(params Type[] checkList)
		{
			return IsTypeInListParallel<T>(checkList).Not();
		}

		public static bool IsTypeNotInListParallel<T>(IEnumerable<Type> checkList)
		{
			return IsTypeInListParallel<T>(checkList).Not();
		}

		public static bool IsValueInAllEqual<T>(this T value, params T[] checkList)
		{
			return IsValueInAllEqual(value, checkList.AsEnumerable());
		}

		public static bool IsValueInAllEqual<T>(this T value, IEnumerable<T> checkList)
		{
			if (IsNullInList(value, checkList))
				return false;

			if (value is string)
				return SString.IsStringInAllEqual(value as string, checkList as IEnumerable<string>);

			foreach (T item in checkList)
				if (Equals(value, item).IsNotTrue())
					return false;

			return true;
		}

		public static bool IsValueInAllEqual<T>(this T value, params object[] checkList)
		{
			return IsValueInAllEqual(value, checkList.Cast<T>());
		}

		public static bool IsValueInAllEqualParallel<T>(this T value, params T[] checkList)
		{
			if (value is string)
				return SString.IsStringInAllEqualParallel(value as string, checkList as string[]);

			if (IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().All((checkListItem) => Equals<T>(value, checkListItem));
		}

		public static bool IsValueInAllEqualParallel<T>(this T value, params object[] checkList)
		{
			return IsValueInListParallel(value, checkList.Cast<T>());
		}

		public static bool IsValueInAllEqualParallel<T>(this T value, IEnumerable<T> checkList)
		{
			if (value is string)
				return SString.IsStringInAllEqualParallel(value as string, checkList as IEnumerable<string>);

			if (IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().All((checkListItem) => Equals<T>(value, checkListItem));
		}

		public static bool IsValueInList<T>(this T value, params T[] checkList)
		{
			if (value is string)
				return SString.IsStringInList(value as string, checkList as string[]);

			if (IsNullInList(value, checkList))
				return false;

			foreach (T item in checkList)
				if (Equals(value, item))
					return true;

			return false;
		}

		public static bool IsValueInList<T>(this T value, IEnumerable<T> checkList)
		{
			if (value is string)
				return SString.IsStringInList(value as string, checkList as IEnumerable<string>);

			if (IsNullInList(value, checkList))
				return false;

			foreach (T item in checkList)
				if (Equals(value, item))
					return true;

			return false;
		}

		public static bool IsValueInList<T>(this T value, params object[] checkList)
		{
			return IsValueInList(value, checkList.Cast<T>());
		}

		public static bool IsValueInListParallel<T>(this T value, params T[] checkList)
		{
			if (value is string)
				return SString.IsStringInListParallel(value as string, checkList as string[]);

			if (IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().Contains(value);
		}

		public static bool IsValueInListParallel<T>(this T value, params object[] checkList)
		{
			return IsValueInListParallel(value, checkList.Cast<T>());
		}

		public static bool IsValueInListParallel<T>(this T value, IEnumerable<T> checkList)
		{
			if (value is string)
				return SString.IsStringInListParallel(value as string, checkList as IEnumerable<string>);

			if (IsNullInList(value, checkList))
				return false;

			return checkList.AsParallel().Contains(value);
		}

		public static bool IsValueNotInAllEqual<T>(this T value, params T[] checkList)
		{
			return IsValueInAllEqual(value, checkList).Not();
		}

		public static bool IsValueNotInAllEqual<T>(this T value, IEnumerable<T> checkList)
		{
			return IsValueInAllEqual(value, checkList).Not();
		}

		public static bool IsValueNotInAllEqual<T>(this T value, params object[] checkList)
		{
			return IsValueInAllEqual(value, checkList).Not();
		}

		public static bool IsValueNotInAllEqualParallel<T>(this T value, params T[] checkList)
		{
			return IsValueInAllEqualParallel(value, checkList).Not();
		}

		public static bool IsValueNotInAllEqualParallel<T>(this T value, IEnumerable<T> checkList)
		{
			return IsValueInAllEqualParallel(value, checkList).Not();
		}

		public static bool IsValueNotInList<T>(this T value, params T[] checkList)
		{
			return IsValueInList(value, checkList).Not();
		}

		public static bool IsValueNotInList<T>(this T value, params object[] checkList)
		{
			return IsValueInList(value, checkList).Not();
		}

		public static bool IsValueNotInListParallel<T>(this T value, params T[] checkList)
		{
			return IsValueInListParallel(value, checkList).Not();
		}

		public static bool IsValueNotInListParallel<T>(this T value, params object[] checkList)
		{
			return IsValueInListParallel(value, checkList).Not();
		}

		public static bool IsValueNotInListParallel<T>(this T value, IEnumerable<T> checkList)
		{
			return IsValueInListParallel(value, checkList).Not();
		}

		public static bool NotEquals<T>(this T value, T otherValue)
		{
			return Equals(value, otherValue).Not();
		}

		public static bool NotEquals<T>(this object obj, object otherObj)
		{
			return Equals<T>(obj, otherObj).Not();
		}

		#endregion Public Methods
	}
}