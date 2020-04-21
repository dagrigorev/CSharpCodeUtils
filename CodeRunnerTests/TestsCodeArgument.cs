using System;
using CSharp.CodeUtils.CodeContracts.Factories;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using CSharp.CodeUtils.CodeRunner.Factories;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests
{
    [TestFixture]
    public class TestsCodeArgument
    {
        private ICodeFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new CodeFactory();
        }

        [Test]
        public void TestDefaultCtor()
        {
            var codeArg = new CodeArgument();
            Assert.IsTrue(string.IsNullOrEmpty(codeArg.TypeName) && codeArg.Value == null);
        }

        [Test]
        public void TestCreateInt8Argument()
        {
            var byteArg = _factory.CreateInt8Argument("byteArg");
            Assert.IsTrue(byteArg.Value.Equals(default(byte)) &&
                          byteArg.TypeName.Equals(nameof(Byte)) &&
                          byteArg.Name.Equals("byteArg"));
        }

        [Test]
        public void TestCreateInt16Argument()
        {
            var int16Arg = _factory.CreateInt16Argument("int16Arg");
            Assert.IsTrue(int16Arg.Value.Equals(default(Int16)) &&
                          int16Arg.TypeName.Equals(nameof(Int16)) &&
                          int16Arg.Name.Equals("int16Arg"));
        }

        [Test]
        public void TestCreateInt32Argument()
        {
            var int32Arg = _factory.CreateInt32Argument("int32Arg");
            Assert.IsTrue(int32Arg.Value.Equals(default(Int32)) &&
                          int32Arg.TypeName.Equals(nameof(Int32)) &&
                          int32Arg.Name.Equals("int32Arg"));
        }

        [Test]
        public void TestCreateInt64Argument()
        {
            var int64Arg = _factory.CreateInt64Argument("int64Arg");
            Assert.IsTrue(int64Arg.Value.Equals(default(Int64)) &&
                          int64Arg.TypeName.Equals(nameof(Int64)) &&
                          int64Arg.Name.Equals("int64Arg"));
        }

        [Test]
        public void TestCreateFloatArgument()
        {
            var floatArg = _factory.CreateFloatArgument("floatArg");
            Assert.IsTrue(floatArg.Value.Equals(default(float)) &&
                          floatArg.TypeName.Equals(nameof(Single)) &&
                          floatArg.Name.Equals("floatArg"));
        }

        [Test]
        public void TestCreateDoubleArgument()
        {
            var doubleArg = _factory.CreateDoubleArgument("doubleArg");
            Assert.IsTrue(doubleArg.Value.Equals(default(double)) &&
                          doubleArg.TypeName.Equals(nameof(Double)) &&
                          doubleArg.Name.Equals("doubleArg"));
        }
    }
}