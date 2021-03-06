﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using CodeHelpers.ModelHelper.NoneStatic.TableModel;
using CodeHelpers.ModelHelper.Static;
using CodeHelpers.System;

namespace CodeHelpers
{
	public static class InMemoryCache
	{
		#region Private Fields

		private const int PROFILE_DURATION_IN_MINUTES = 60;

		private static Cache casheList = HttpRuntime.Cache;

		#endregion Private Fields

		#region Public Methods

		public static TValue Get<TValue>(string cacheKey, Func<TValue> getItemCallback) where TValue : class
		{
			return Get<TValue>(cacheKey, PROFILE_DURATION_IN_MINUTES, getItemCallback);
		}

		public static TValue Get<TValue>(string cacheKey, int durationInMinutes, Func<TValue> getItemCallback)
			where TValue : class
		{
			TValue item = casheList[cacheKey] as TValue;
			if (item.IsNotNull())
				return item;

			item = getItemCallback();

			if (item.IsNull()) return null;

			CacheDependency dependencies = null;
			DateTime expiryDateTime = DateTime.Now.AddMinutes(durationInMinutes);
			TimeSpan slidingExpiration = Cache.NoSlidingExpiration;
			CacheItemPriority cachePriority = CacheItemPriority.Normal;
			CacheItemRemovedCallback onRemoveCallback = null;
			casheList.Add(
				cacheKey, item, dependencies, expiryDateTime, slidingExpiration, cachePriority,
				onRemoveCallback);
			return item;
		}

		public static IEnumerable<T> SelectAllList<T>() where T : TableModel, ITableModel, new()
		{
			using (T model = new T())
				return Get(model.ModelType.FullName, () => { return STableModel.GetObjList<T>(); });
		}

		#endregion Public Methods
	}
}