using CSharp.CodeUtils.CodeContracts;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Factories;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using CSharp.CodeUtils.CodeRunner.Factories;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests
{
    [TestFixture]
    public class TestCodeObject
    {
        private ICodeFactory _factory;
        private ICodeManager _manager;

        [SetUp]
        public void Setup()
        {
            _factory = new CodeFactory();
            _manager = new CSharpCodeManager();
        }

        [Test]
        public void TestCodeObjectDefaultCtor()
        {
            Assert.DoesNotThrow(() => new CodeObject());
        }

        [Test]
        public void TestCreateArithmeticalSumCode()
        {
            var sum = _factory.CreateArithmeticalSumCodeObject();

            Assert.IsTrue(sum.Args.Count > 1 && sum.SourceCode.Length > 0 && 
                          sum.ReturnType.Length > 0 && !sum.ReturnType.Equals("void"));
        }

        [Test]
        public void TestCreateArithmeticalSubCode()
        {
            var sum = _factory.CreateArithmeticalSubCodeObject();

            Assert.IsTrue(sum.Args.Count > 1 && sum.SourceCode.Length > 0 &&
                          sum.ReturnType.Length > 0 && !sum.ReturnType.Equals("void"));
        }

        [Test]
        public void TestCreateArithmeticalMulCode()
        {
            var sum = _factory.CreateArithmeticalMulCodeObject();

            Assert.IsTrue(sum.Args.Count > 1 && sum.SourceCode.Length > 0 &&
                          sum.ReturnType.Length > 0 && !sum.ReturnType.Equals("void"));
        }

        [Test]
        public void TestCreateArithmeticalDivCode()
        {
            var sum = _factory.CreateArithmeticalDivCodeObject();

            Assert.IsTrue(sum.Args.Count > 1 && sum.SourceCode.Length > 0 &&
                          sum.ReturnType.Length > 0 && !sum.ReturnType.Equals("void"));
        }
    }
}