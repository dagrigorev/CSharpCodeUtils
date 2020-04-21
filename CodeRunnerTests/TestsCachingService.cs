using System;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Services;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using CSharp.CodeUtils.CodeRunner.Services;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests
{
    /// <summary>
    /// <see cref="ICachingService{TKey,TValue}"/> tests
    /// </summary>
    public class TestsCachingService
    {
        private ICachingService<string, ICodeObject> _globalCache;

        [SetUp]
        public void Setup()
        {
            _globalCache = new CodeCachingService();
            _globalCache.Cache("SampleObject", new CodeObject());
        }

        [Test]
        public void TestCacheNull()
        {
            Assert.DoesNotThrow(() => _globalCache.Cache("sample", null));
        }

        [Test]
        public void TestCacheNotNull()
        {
            Assert.DoesNotThrow(() => _globalCache.Cache("sample", new CodeObject()));
        }

        [Test]
        public void TestCacheEmptyKey()
        {
            Assert.Throws<NullReferenceException>(() => _globalCache.Cache(string.Empty, null));
        }

        [Test]
        public void TestRemove()
        {
            Assert.DoesNotThrow(() => _globalCache.Remove("sample"));
        }

        [Test]
        public void TestRemoveEmptyKey()
        {
            Assert.Throws<NullReferenceException>(() => _globalCache.Remove(string.Empty));
        }

        [Test]
        public void TestGetExisting()
        {
            Assert.IsNotNull(_globalCache.Get("SampleObject"));
        }

        [Test]
        public void TestGetEmptyCache()
        {
            var emptyCache = new CodeCachingService();
            Assert.AreEqual(emptyCache.Get("Sample"), default(ICodeObject));
        }

        [Test]
        public void TestGetEmptyKey()
        {
            Assert.Throws<NullReferenceException>(() => _globalCache.Get(string.Empty));
        }
    }
}