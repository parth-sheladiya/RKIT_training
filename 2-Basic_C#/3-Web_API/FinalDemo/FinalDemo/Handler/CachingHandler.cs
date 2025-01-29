using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace FinalDemo.Handler
{
    public class CachingHandler
    {
        /// <summary>
        /// Retrieves an item from the cache by its key.
        /// </summary>
        /// <param name="key">The key of the cached item to retrieve.</param>
        /// <returns>The cached object, or null if not found.</returns>
        public static object Get(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        /// <summary>
        /// Inserts an item into the cache with a specified key, value, and duration.
        /// </summary>
        /// <param name="key">The key used to store and retrieve the cached item.</param>
        /// <param name="value">The value to store in the cache.</param>
        /// <param name="duration">The duration for which the cache item will be valid.</param>
        public static void Set(string key, object value, TimeSpan duration)
        {
            HttpContext.Current.Cache.Insert(
                key,
                value,
                null,
                DateTime.Now.Add(duration),
                Cache.NoSlidingExpiration
            );
        }

        /// <summary>
        /// Removes an item from the cache by its key.
        /// </summary>
        /// <param name="key">The key of the cached item to remove.</param>
        public static void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }
}