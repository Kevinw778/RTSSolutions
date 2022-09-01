using System;

namespace RtsSolutions.Problems
{
    /// <summary>
    /// A key-value cache with a size limit.
    /// </summary>
    public interface ICache<T>
    {
        /// <summary>
        /// Gets the value stored by the key.
        /// </summary>
        /// <param name="key">The key from which to get a value.</param>
        /// <returns>The value, or <code>null</code> if no value is cached for the given key.</returns>
        T Get(String key);

        /// <summary>
        /// Puts the value into the cache by the key. Only one key of the same value can be cached such that the value
        /// with the most recently put key is kept.
        /// If putting the value would extend the cache past the maximum size limit defined by <code>SetMaxSize()</code>
        /// </summary>
        /// <param name="key">key The key for which to cache the value.</param>
        /// <param name="value">The cached value.</param>
        void Put(String key, T value);

        /// <summary>
        /// Gets the allowed maximum size of the cache.
        /// </summary>
        /// <returns>The current maximum size of the cache.</returns>
        int GetMaxSize();

        /// <summary>
        /// Adjusts the maximum size of the cache. If the cache is resized to hold less values that are currently cached
        /// then values must be ejected until the current size is equal to the maximum size.
        /// </summary>
        /// <param name="maxSize">The new maximum size of the cache.</param>
        /// <exception name="IllegalArgumentException">If maxSize is less than or equal to 0</exception>
        void SetMaxSize(int maxSize);

        /// <summary>
        /// Gets the number of currently cached items.
        /// </summary>
        /// <returns>The cached item count.</returns>
        int GetCurrentCacheSize();
    }
}