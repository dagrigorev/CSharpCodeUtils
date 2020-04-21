using System;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using CSharp.CodeUtils.CodeRunner.Factories;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests.IntegrationalTests
{
    [TestFixture]
    public class TestCSharpCodeManager
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void TestInitializeAndBuildEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var codeManager = new CSharpCodeManager();
                codeManager.Initialize();
                codeManager.CompilationService.Compile(new CodeObject());
            });
        }

        [Test]
        public void TestInitializeBuildInvalid()
        {
            var codeManager = new CSharpCodeManager();
            codeManager.Initialize();

            Assert.IsNotNull(codeManager.CompilationService);

            Assert.IsFalse(codeManager.CompilationService.Compile(new CodeObject()
            {
                Name="InvalidSample",
                ReturnType = "123123",
                SourceCode = "aksjdbnslaidufhbpasidfq;l2p[239"
            }));
        }

        [Test]
        public void TestInitializeBuildAndRunDefault()
        {
            var codeManager = new CSharpCodeManager();
            codeManager.Initialize();

            Assert.IsNotNull(codeManager.CompilationService);

            Assert.Throws<InvalidOperationException>(() => codeManager.Run(new CodeObject()));
        }

        [Test]
        public void TestInitializeBuildAndRunInvalid()
        {
            var codeManager = new CSharpCodeManager();
            codeManager.Initialize();

            Assert.IsNotNull(codeManager.CompilationService);

            Assert.IsNull(codeManager.Run(new CodeObject()
            {
                Name = "InvalidSample",
                ReturnType = "123123",
                SourceCode = "aksjdbnslaidufhbpasidfq;l2p[239"
            }));
        }

        [Test]
        public void TestInitializeBuildAndRunArithmetical()
        {
            var codeManager = new CSharpCodeManager();
            var factory = new CodeFactory();

            codeManager.Initialize();

            Assert.IsNotNull(codeManager.CompilationService);

            Assert.AreEqual(codeManager.Run(factory.CreateArithmeticalSumCodeObject(), 10, 15), 25);
        }

        [Test]
        public void TestInitializeBuildAndRunSequence()
        {
            var codeManager = new CSharpCodeManager();
            var factory = new CodeFactory();

            codeManager.Initialize();

            Assert.IsNotNull(codeManager.CompilationService);

            Assert.AreEqual(codeManager.Run(factory.CreateArithmeticalSumCodeObject(), 10, 15), 25);
            Assert.AreEqual(codeManager.Run(factory.CreateArithmeticalSubCodeObject(), 15, 10), 5);
            Assert.AreEqual(codeManager.Run(factory.CreateArithmeticalMulCodeObject(), 10, 15), 150);
        }
    }
}