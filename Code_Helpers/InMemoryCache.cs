using System;
using System.Web;
using System.Web.Caching;

namespace CodeHelpers
{
	public static class InMemoryCache
	{
		#region Private Fields

		private static readonly int PROFILE_DURATION_IN_MINUTES = 60;
		private static Cache casheList = HttpRuntime.Cache;

		#endregion Private Fields

		#region Private Methods

		private static TValue Get<TValue>(string cacheKey, int durationInMinutes, Func<TValue> getItemCallback) where TValue : class
		{
			TValue item = casheList[cacheKey] as TValue;
			if (item == null)
			{
				item = getItemCallback();
				casheList.Add(cacheKey, item, null, DateTime.Now.AddMinutes(durationInMinutes), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
			}
			return item;
		}

		#endregion Private Methods
	}
}