using CSharp.CodeUtils.CodeRunner.CodeObjects;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests
{
    [TestFixture]
    public class TestCodeObject
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCodeObjectDefaultCtor()
        {
            Assert.DoesNotThrow(() => new CodeObject());
        }
    }
}