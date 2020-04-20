using System;
using System.Collections;
using System.Collections.Generic;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Services;

namespace CSharp.CodeUtils.CodeRunner.Services
{
    /// <summary>
    /// Code caching service implementation
    /// </summary>
    public class CodeCachingService : ICachingService<string, ICodeObject>
    {
        private IDictionary<string, ICodeObject> _cache;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CodeCachingService()
        {
            _cache = new Dictionary<string, ICodeObject>();
        }

        /// <inheritdoc />
        public void Cache(string key, ICodeObject value)
        {
            if(string.IsNullOrEmpty(key)) throw new NullReferenceException("Empty key");

            if (_cache.ContainsKey(key))
                _cache[key] = value;
            else
                _cache.Add(key, value);
        }

        /// <inheritdoc />
        public ICodeObject Get(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new NullReferenceException("Empty key");

            return _cache.ContainsKey(key) ? _cache[key] : default;
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new NullReferenceException("Empty key");

            if (_cache.ContainsKey(key))
                _cache.Remove(key);
        }
    }
}
