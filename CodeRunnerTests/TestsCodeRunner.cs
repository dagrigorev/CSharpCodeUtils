using System;
using CSharp.CodeUtils.CodeContracts;
using CSharp.CodeUtils.CodeContracts.Factories;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using CSharp.CodeUtils.CodeRunner.Factories;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests
{
    [TestFixture]
    public class TestsCodeRunner
    {
        private ICodeRunner _runner;
        private ICodeFactory _factory;

        [SetUp]
        public void Setup()
        {
            _runner = new CSharpCodeManager().Initialize();
            _factory = new CodeFactory();
        }

        [Test]
        public void TestRunEmptyCodeObject()
        {
            Assert.IsNull(_runner.Run(new CodeObject()));
        }

        [Test]
        public void TestRunArithmeticalSumCodeObject()
        {
            Assert.AreEqual(_runner.Run(_factory.CreateArithmeticalSumCodeObject(), 5, 10), 15);
        }

        [Test]
        public void TestRunArithmeticalSubCodeObject()
        {
            Assert.AreEqual(_runner.Run(_factory.CreateArithmeticalSubCodeObject(), 5, 10), -5);
        }

        [Test]
        public void TestRunArithmeticalMulCodeObject()
        {
            Assert.AreEqual(_runner.Run(_factory.CreateArithmeticalMulCodeObject(), 5, 10), 50);
        }

        [Test]
        public void TestRunArithmeticalDivCodeObject()
        {
            Assert.AreEqual(_runner.Run(_factory.CreateArithmeticalDivCodeObject(), 10, 5), 2);
        }
    }
}