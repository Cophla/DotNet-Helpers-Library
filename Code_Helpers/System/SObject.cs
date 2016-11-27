using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Code_Helpers.System
{
	public static class SObject
	{
		#region Public Methods
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
		public static bool Equals<T>(this T value, T otherValue)
		{
			if (value is string)
				return (value as string).Equals(otherValue as string, StringComparison.InvariantCultureIgnoreCase);

			return value.Equals(otherValue);
		}

		public static bool IsBetween<T>(this T value, T startValue, T endValue)
		{
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

		public static bool IsNotBetween<T>(this T value, T startValue, T endValue)
		{
			return !IsBetween(value, startValue, endValue);
		}

		public static bool IsNotBetween<T>(this T value, object startValue, object endValue)
		{
			return !IsBetween(value, startValue, endValue);
		}

		public static bool IsTypeInList<T>(params Type[] checkList)
		{
			if (checkList.IsNull()) return false;

			Type valueType = typeof(T);
			return checkList.First(
				(item) => valueType.IsAssignableFrom(item)).IsNotNull();
		}

		public static bool IsTypeInList<T>(IEnumerable<Type> checkList)
		{
			if (checkList.IsNull()) return false;

			Type valueType = typeof(T);
			return checkList.First(
				(item) => valueType.IsAssignableFrom(item)).IsNotNull();
		}

		public static bool IsTypeInListParallel<T>(params Type[] checkList)
		{
			if (checkList.IsNull()) return false;

			Type valueType = typeof(T);
			return checkList.AsParallel().First(
				(item) => valueType.IsAssignableFrom(item)).IsNotNull();
		}

		public static bool IsTypeInListParallel<T>(IEnumerable<Type> checkList)
		{
			if (checkList.IsNull()) return false;

			Type valueType = typeof(T);
			return checkList.AsParallel().First(
				(item) => valueType.IsAssignableFrom(item)).IsNotNull();
		}

		public static bool IsTypeNotInList<T>(params Type[] checkList)
		{
			return !IsTypeInList<T>(checkList);
		}

		public static bool IsTypeNotInList<T>(IEnumerable<Type> checkList)
		{
			return !IsTypeInList<T>(checkList);
		}

		public static bool IsTypeNotInListParallel<T>(params Type[] checkList)
		{
			return !IsTypeInListParallel<T>(checkList);
		}

		public static bool IsTypeNotInListParallel<T>(IEnumerable<Type> checkList)
		{
			return !IsTypeInListParallel<T>(checkList);
		}

		public static bool IsValueInAllEqual<T>(this T value, params T[] checkList)
		{
			return IsValueInAllEqual(value, checkList.AsEnumerable());
		}

		public static bool IsValueInAllEqual<T>(this T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (IsNotNull(value) && IsNotNull(checkList))
			{
				if (value is string)
				{
					string valueTest = value as string;
					IEnumerable<string> checkListTest = checkList as IEnumerable<string>;
					result = checkListTest.All(
						(checkListItem) => valueTest.Equals(
							checkListItem, StringComparison.InvariantCultureIgnoreCase
						)
					);
				}
				else
				{
					result = checkList.All((checkListItem) => value.Equals(checkListItem));
				}
			}
			return result;
		}

		public static bool IsValueInAllEqual<T>(this T value, params object[] checkList)
		{
			return IsValueInAllEqual(value, checkList.Cast<T>());
		}

		public static bool IsValueInAllEqualParallel<T>(this T value, params T[] checkList)
		{
			return IsValueInListParallel(value, checkList.AsEnumerable());
		}

		public static bool IsValueInAllEqualParallel<T>(this T value, params object[] checkList)
		{
			return IsValueInListParallel(value, checkList.Cast<T>());
		}

		public static bool IsValueInAllEqualParallel<T>(this T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (IsNotNull(value) && IsNotNull(checkList))
			{
				if (value is string)
				{
					string valueTest = value as string;
					IEnumerable<string> checkListTest = checkList as IEnumerable<string>;
					result = checkListTest.AsParallel().All(
						(checkListItem) => valueTest.Equals(
							checkListItem, StringComparison.InvariantCultureIgnoreCase
						)
					);
				}
				else
				{
					result = checkList.AsParallel().All(
						(checkListItem) => value.Equals(checkListItem)
					);
				}
			}
			return result;
		}

		public static bool IsValueInList<T>(this T value, params T[] checkList)
		{
			return IsValueInList(value, checkList.AsEnumerable());
		}

		public static bool IsNullInList(params object[] checkList)
		{
			foreach (object obj in checkList)
				if (obj.IsNull())
					return true;
			return false;
		}

		public static bool IsValueInList<T>(this T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (IsNotNull(value) && IsNotNull(checkList))
			{
				if (value is string)
				{
					string valueTest = value as string;
					IEnumerable<string> checkListTest = checkList as IEnumerable<string>;
					result = checkListTest.Contains(valueTest, StringComparer.InvariantCultureIgnoreCase);
				}
				else
				{
					result = checkList.Contains(value);
				}
			}
			return result;
		}

		public static bool IsValueInList<T>(this T value, params object[] checkList)
		{
			return IsValueInList(value, checkList.Cast<T>());
		}

		public static bool IsValueInListParallel<T>(this T value, params T[] checkList)
		{
			return IsValueInListParallel(value, checkList.AsEnumerable());
		}

		public static bool IsValueInListParallel<T>(this T value, params object[] checkList)
		{
			return IsValueInListParallel(value, checkList.Cast<T>());
		}

		public static bool IsValueInListParallel<T>(this T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (IsNotNull(value) && IsNotNull(checkList))
			{
				if (value is string)
				{
					string valueTest = value as string;
					IEnumerable<string> checkListTest = checkList as IEnumerable<string>;
					result = checkListTest.AsParallel().Contains(
						valueTest,
						StringComparer.InvariantCultureIgnoreCase
					);
				}
				else
				{
					result = checkList.AsParallel().Contains(value);
				}
			}
			return result;
		}

		public static bool IsValueNotInAllEqual<T>(this T value, params T[] checkList)
		{
			return !IsValueInAllEqual(value, checkList);
		}

		public static bool IsValueNotInAllEqual<T>(this T value, IEnumerable<T> checkList)
		{
			return !IsValueInAllEqual(value, checkList);
		}

		public static bool IsValueNotInAllEqual<T>(this T value, params object[] checkList)
		{
			return !IsValueInAllEqual(value, checkList);
		}

		public static bool IsValueNotInAllEqualParallel<T>(this T value, params T[] checkList)
		{
			return !IsValueInAllEqualParallel(value, checkList);
		}

		public static bool IsValueNotInAllEqualParallel<T>(this T value, IEnumerable<T> checkList)
		{
			return !IsValueInAllEqualParallel(value, checkList);
		}

		public static bool IsValueNotInList<T>(this T value, params T[] checkList)
		{
			return !IsValueInList(value, checkList);
		}

		public static bool IsValueNotInList<T>(this T value, params object[] checkList)
		{
			return !IsValueInList(value, checkList);
		}

		public static bool IsValueNotInListParallel<T>(this T value, params T[] checkList)
		{
			return !IsValueInListParallel(value, checkList);
		}

		public static bool IsValueNotInListParallel<T>(this T value, params object[] checkList)
		{
			return !IsValueInListParallel(value, checkList);
		}

		public static bool IsValueNotInListParallel<T>(this T value, IEnumerable<T> checkList)
		{
			return !IsValueInListParallel(value, checkList);
		}

		public static bool NotEquals<T>(this T value, T otherValue)
		{
			return !Equals(value, otherValue);
		}

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
			return Equals<T>(ConvertAs<T>(obj), ConvertAs<T>(otherObj));
		}

		public static bool IsDBNull(this object obj)
		{
			return Convert.IsDBNull(obj);
		}

		public static bool IsNotDBNull(this object obj)
		{
			return !IsDBNull(obj);
		}

		public static bool IsNotNull(this object obj)
		{
			return obj != null;
		}

		public static bool IsNotNullOrDBNull(this object obj)
		{
			return !IsNullOrDBNull(obj);
		}

		public static bool IsNull(this object obj)
		{
			return obj == null;
		}

		public static bool IsNullOrDBNull(this object obj)
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