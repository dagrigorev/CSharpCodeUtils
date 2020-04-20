using CSharp.CodeUtils.CodeRunner.CodeObjects;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests
{
    [TestFixture]
    public class TestsCodeArgument
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void TestDefaultCtor()
        {
            var codeArg = new CodeArgument();
            Assert.IsTrue(string.IsNullOrEmpty(codeArg.TypeName) && codeArg.Value == null);
        }
    }
}