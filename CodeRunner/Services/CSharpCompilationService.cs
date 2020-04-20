using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CSharp.CodeUtils.CodeContracts;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Services;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace CSharp.CodeUtils.CodeRunner.Services
{
    /// <summary>
    /// <see cref="ICompilerService"/> implementation
    /// </summary>
    public class CSharpCompilationService : ICompilerService
    {
        /// <summary>
        /// C# language max version
        /// </summary>
        private readonly LanguageVersion _maxLanguageVersion = Enum
            .GetValues(typeof(LanguageVersion))
            .Cast<LanguageVersion>()
            .Max();

        private readonly IReadOnlyCollection<MetadataReference> _references = new[] {
            MetadataReference.CreateFromFile(typeof(int).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(IEnumerable).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Queryable).GetTypeInfo().Assembly.Location),
        };

        /// <inheritdoc />
        public ISourceCodeGenerator CodeGenerator { get; set; }

        /// <inheritdoc />
        public SyntaxTree ParseSourceCode(string sourceCode, SourceCodeKind srcKind)
        {
            return CSharpSyntaxTree.ParseText(sourceCode,
                new CSharpParseOptions(kind: srcKind,
                    languageVersion: _maxLanguageVersion));
        }

        /// <inheritdoc />
        public Compilation CreateCompiler(string assemblyName, bool enableOptimization)
        {
            return CSharpCompilation.Create(assemblyName, options: new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: enableOptimization ? OptimizationLevel.Release : OptimizationLevel.Debug,
                allowUnsafe: true), references: _references);
        }

        /// <summary>
        /// Compiles code object
        /// </summary>
        /// <param name="codeObject"></param>
        /// <param name="ms"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private EmitResult Compile(ICodeObject codeObject, MemoryStream ms)
        {
            return Compile(codeObject.Name, CodeGenerator.Generate(codeObject), ms);
        }

        /// <summary>
        /// Compiles code object
        /// </summary>
        /// <param name="codeObject"></param>
        /// <param name="ms"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private EmitResult Compile(string name, string sourceCode, MemoryStream ms)
        {
            return CreateCompiler(assemblyName: name, enableOptimization: false)
                .AddReferences(_references)
                .AddSyntaxTrees(ParseSourceCode(sourceCode, SourceCodeKind.Regular))
                .Emit(ms);
        }

        /// <inheritdoc />
        public bool IsSourceCodeValid(string srcCode)
        {
            return Compile("checkableSrc", srcCode, new MemoryStream()).Success;
        }

        /// <inheritdoc />
        public bool Compile(ICodeObject sourceCodeObject)
        {
            if (sourceCodeObject.IsEmpty()) throw new InvalidOperationException("CodeObject cannot be empty");

            return Compile(sourceCodeObject.Name, CodeGenerator.Generate(sourceCodeObject), new MemoryStream()).Success;
        }
    }
}