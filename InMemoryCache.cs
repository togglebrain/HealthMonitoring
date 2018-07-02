using System;
using System.Runtime.Caching;

namespace HealthMonitoring.Base
{
    public class InMemoryCache
    {
        private static ObjectCache cachedOjects = MemoryCache.Default;
        private static InMemoryCache instance;
        static object lockObj;

        /// <summary>
        /// Singleton...
        /// </summary>
        private InMemoryCache()
        {

        }

        public static InMemoryCache GetInstance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                        instance = new InMemoryCache();
                }
                return instance;
            }
        }
        /// <summary>
        /// Get current count of objects in the cache
        /// </summary>
        public long Count
        {
            get
            {
                return cachedOjects.GetCount();
            }
        }

        /// <summary>
        /// Add object to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool Add<T>(string key, T value)
        {
            cachedOjects.Add(key, value, new CacheItemPolicy());
            return true;
        }

        /// <summary>
        /// Add an object to cache with expiry
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration">Absolute time at which cache should expire</param>
        public bool Add<T>(string key, T value, DateTimeOffset expiration)
        {
            cachedOjects.Add(key, value, new CacheItemPolicy()
            {
                AbsoluteExpiration = expiration
            });

            return true;
        }



        /// <summary>
        /// Add an object to cache with expiry
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration">Sliding timeout at which the item expires</param>
        public bool Add<T>(string key, T value, TimeSpan expiration)
        {
            cachedOjects.Add(key, value, new CacheItemPolicy()
            {

                SlidingExpiration = expiration
            });

            return true;
        }

        /// <summary>
        /// Check if a given key already exists in the cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return cachedOjects.Contains(key);
        }


        /// <summary>
        /// Get value of a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetData<T>(string key)
        {
            return (T)cachedOjects[key];
        }


        /// <summary>
        /// Remove an item from cache
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            cachedOjects.Remove(key);
        }
    }

}
