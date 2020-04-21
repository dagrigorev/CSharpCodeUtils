using System;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Factories;
using CSharp.CodeUtils.CodeContracts.Services;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using CSharp.CodeUtils.CodeRunner.Factories;
using CSharp.CodeUtils.CodeRunner.Services;
using NUnit.Framework;

namespace CSharp.CodeUtils.CodeRunner.Tests
{
    [TestFixture]
    public class TestsCodeCompilerService
    {
        private ICodeFactory _factory;
        private ICompilerService _compiler;

        [SetUp]
        public void Setup()
        {
            _factory = new CodeFactory();
            _compiler = new CSharpCompilationService {CodeGenerator = new CSharpSourceCodeGenerator()};
        }

        [Test]
        public void TestBuildArithmeticalSumObject()
        {
            Assert.DoesNotThrow(() =>
            {
                if(!_compiler.Compile(_factory.CreateArithmeticalSumCodeObject()))
                    throw new Exception("Compiler error");
            });
        }

        [Test]
        public void TestBuildArithmeticalSubObject()
        {
            Assert.DoesNotThrow(() =>
            {
                if (!_compiler.Compile(_factory.CreateArithmeticalSubCodeObject()))
                    throw new Exception("Compiler error");
            });
        }

        [Test]
        public void TestBuildArithmeticalMulObject()
        {
            Assert.DoesNotThrow(() =>
            {
                if (!_compiler.Compile(_factory.CreateArithmeticalMulCodeObject()))
                    throw new Exception("Compiler error");
            });
        }

        [Test]
        public void TestBuildArithmeticalDivObject()
        {
            Assert.DoesNotThrow(() =>
            {
                if (!_compiler.Compile(_factory.CreateArithmeticalDivCodeObject()))
                    throw new Exception("Compiler error");
            });
        }

        [Test]
        public void TestBuildEmptyObject()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                if (!_compiler.Compile(new CodeObject()))
                    throw new Exception("Compiler error");
            });
        }

        [Test]
        public void TestBuildErrorSourceCodeObject()
        {
            Assert.IsFalse(_compiler.Compile(new CodeObject()
            {
                Name = "InvalidCode",
                SourceCode = "a;sdkjshfa;kjsdf"
            }));
        }

        [Test]
        public void TestBuildExternalTypeIncludingSourceCode()
        {
            var sumCode = _factory.CreateArithmeticalSumCodeObject();
            if(sumCode is IExtendableCode ext)
                ext.AddExtension(_factory.CreateArithmeticalMulCodeObject());

            Assert.IsTrue(_compiler.Compile(sumCode));
        }

        [Test]
        public void TestCompilerDefaultInitialization()
        {
            Assert.DoesNotThrow(() =>
            {
                new CSharpCodeManager().Initialize();
            });
        }
    }
}