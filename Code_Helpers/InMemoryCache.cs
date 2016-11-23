using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Code_Helpers
{
	public static class InMemoryCache
	{
		private static readonly int PROFILE_DURATION_IN_MINUTES = 60;
		private static Cache casheList = HttpRuntime.Cache;

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
	}
}
