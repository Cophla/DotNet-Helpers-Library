using Code_Helpers.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code_Helpers
{
	public static class SCode
	{
		#region Public Methods

		

		

		

		public static bool Equals<T>(T value, T otherValue)
		{
			if (value is string)
				return (value as string).Equals(otherValue as string, StringComparison.InvariantCultureIgnoreCase);
			else
				return value.Equals(otherValue);
		}

		public static bool IsBetween<T>(T value, T startValue, T endValue)
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

		public static bool IsBetween<T>(T value, object startValue, object endValue)
		{
			return IsBetween(value, SObject.ConvertAs<T>(startValue), SObject.ConvertAs<T>(endValue));
		}

		

		public static bool IsNotBetween<T>(T value, T startValue, T endValue)
		{
			return !IsBetween(value, startValue, endValue);
		}

		public static bool IsNotBetween<T>(T value, object startValue, object endValue)
		{
			return !IsBetween(value, startValue, endValue);
		}

		

		public static bool IsTypeInList<T>(T value, params Type[] checkList)
		{
			return IsTypeInList(value, checkList.AsEnumerable());
		}

		public static bool IsTypeInList<T>(T value, IEnumerable<Type> checkList)
		{
			if (SObject.IsNull(checkList))
				return false;
			if (SObject.IsNull(value))
				return IsTypeInList<T>(checkList);

			bool result = false;
			Type valueType = value.GetType();
			result = (
				SObject.IsNotNull(
					checkList.First((item) => valueType.IsAssignableFrom(item))
				)
			);
			return result;
		}

		public static bool IsTypeInList<T>(IEnumerable<Type> checkList)
		{
			bool result = false;
			if (SObject.IsNotNull(checkList))
			{
				Type valueType = typeof(T);
				result = (
					SObject.IsNotNull(
						checkList.First((item) => valueType.IsAssignableFrom(item))
					)
				);
			}
			return result;
		}

		public static bool IsTypeInListParallel<T>(T value, params Type[] checkList)
		{
			return IsTypeInListParallel(value, checkList.AsEnumerable());
		}

		public static bool IsTypeInListParallel<T>(T value, IEnumerable<Type> checkList)
		{
			bool result = false;
			if (SObject.IsNotNull(value) && SObject.IsNotNull(checkList))
			{
				Type valueType = value.GetType();
				result = (
					SObject.IsNotNull(
						checkList.AsParallel().First((item) => valueType.IsAssignableFrom(item))
					)
				);
			}
			return result;
		}

		public static bool IsTypeNotInList<T>(T value, params Type[] checkList)
		{
			return !IsTypeInList(value, checkList);
		}

		public static bool IsTypeNotInList<T>(T value, IEnumerable<Type> checkList)
		{
			return !IsTypeInList(value, checkList);
		}

		public static bool IsTypeNotInListParallel<T>(T value, params Type[] checkList)
		{
			return !IsTypeInListParallel(value, checkList);
		}

		public static bool IsTypeNotInListParallel<T>(T value, IEnumerable<Type> checkList)
		{
			return !IsTypeInListParallel(value, checkList);
		}

		public static bool IsValueInAllEqual<T>(T value, params T[] checkList)
		{
			return IsValueInAllEqual(value, checkList.AsEnumerable());
		}

		public static bool IsValueInAllEqual<T>(T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (SObject.IsNotNull(value) && SObject.IsNotNull(checkList))
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

		public static bool IsValueInAllEqual<T>(T value, params object[] checkList)
		{
			return IsValueInAllEqual(value, checkList.Cast<T>());
		}

		public static bool IsValueInAllEqualParallel<T>(T value, params T[] checkList)
		{
			return IsValueInListParallel(value, checkList.AsEnumerable());
		}

		public static bool IsValueInAllEqualParallel<T>(T value, params object[] checkList)
		{
			return IsValueInListParallel(value, checkList.Cast<T>());
		}

		public static bool IsValueInAllEqualParallel<T>(T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (SObject.IsNotNull(value) && SObject.IsNotNull(checkList))
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

		public static bool IsValueInList<T>(T value, params T[] checkList)
		{
			return IsValueInList(value, checkList.AsEnumerable());
		}

		public static bool IsValueInList<T>(T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (SObject.IsNotNull(value) && SObject.IsNotNull(checkList))
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

		public static bool IsValueInList<T>(T value, params object[] checkList)
		{
			return IsValueInList(value, checkList.Cast<T>());
		}

		public static bool IsValueInListParallel<T>(T value, params T[] checkList)
		{
			return IsValueInListParallel(value, checkList.AsEnumerable());
		}

		public static bool IsValueInListParallel<T>(T value, params object[] checkList)
		{
			return IsValueInListParallel(value, checkList.Cast<T>());
		}

		public static bool IsValueInListParallel<T>(T value, IEnumerable<T> checkList)
		{
			bool result = false;
			if (SObject.IsNotNull(value) && SObject.IsNotNull(checkList))
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

		public static bool IsValueNotInAllEqual<T>(T value, params T[] checkList)
		{
			return !IsValueInAllEqual(value, checkList);
		}

		public static bool IsValueNotInAllEqual<T>(T value, IEnumerable<T> checkList)
		{
			return !IsValueInAllEqual(value, checkList);
		}

		public static bool IsValueNotInAllEqual<T>(T value, params object[] checkList)
		{
			return !IsValueInAllEqual(value, checkList);
		}

		public static bool IsValueNotInAllEqualParallel<T>(T value, params T[] checkList)
		{
			return !IsValueInAllEqualParallel(value, checkList);
		}

		public static bool IsValueNotInAllEqualParallel<T>(T value, IEnumerable<T> checkList)
		{
			return !IsValueInAllEqualParallel(value, checkList);
		}

		public static bool IsValueNotInList<T>(T value, params T[] checkList)
		{
			return !IsValueInList(value, checkList);
		}

		public static bool IsValueNotInList<T>(T value, params object[] checkList)
		{
			return !IsValueInList(value, checkList);
		}

		public static bool IsValueNotInListParallel<T>(T value, params T[] checkList)
		{
			return !IsValueInListParallel(value, checkList);
		}

		public static bool IsValueNotInListParallel<T>(T value, params object[] checkList)
		{
			return !IsValueInListParallel(value, checkList);
		}

		public static bool IsValueNotInListParallel<T>(T value, IEnumerable<T> checkList)
		{
			return !IsValueInListParallel(value, checkList);
		}

		

		public static bool NotEquals<T>(T value, T otherValue)
		{
			return !Equals(value, otherValue);
		}

		#endregion Public Methods
	}
}