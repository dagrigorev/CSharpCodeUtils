namespace CSharp.CodeUtils.CodeContracts.Services
{
    /// <summary>
    /// Caching service contract
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    public interface ICachingService<in TKey, TValue>
    {
        /// <summary>
        /// Caches item. If item already in cache it'll be updated
        /// </summary>
        /// <param name="key">Item key</param>
        /// <param name="value">Item value</param>
        void Cache(TKey key, TValue value);

        /// <summary>
        /// Gets item from cache
        /// </summary>
        /// <param name="key">Item key</param>
        /// <returns>Value if exists and default otherwise</returns>
        TValue Get(TKey key);

        /// <summary>
        /// Removes item from cache
        /// </summary>
        /// <param name="key"></param>
        void Remove(TKey key);
    }
}