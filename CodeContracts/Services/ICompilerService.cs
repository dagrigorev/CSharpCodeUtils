using System.IO;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using Microsoft.CodeAnalysis;

namespace CSharp.CodeUtils.CodeContracts.Services
{
    /// <summary>
    /// C# compiler service contract
    /// </summary>
    public interface ICompilerService
    {
        /// <summary>
        /// Building stream
        /// </summary>
        Stream BuildStream { get; set; }

        /// <summary>
        /// Source code generator
        /// </summary>
        ISourceCodeGenerator CodeGenerator { get; set; }

        /// <summary>
        /// Parses source code string and generates <see cref="SyntaxTree"/>
        /// </summary>
        /// <param name="src">Source code string</param>
        /// <param name="srcKind">Source code type</param>
        /// <returns></returns>
        SyntaxTree ParseSourceCode(string src, SourceCodeKind srcKind);

        /// <summary>
        /// Creates new compiler object.
        /// </summary>
        /// <param name="assemblyName">Generating assembly name</param>
        /// <param name="enableOptimization">Enables optimization </param>
        /// <returns>New <see cref="Compilation"/> instance</returns>
        Compilation CreateCompiler(string assemblyName, bool enableOptimization);

        /// <summary>
        /// Checks source code string for validity
        /// </summary>
        /// <returns>True - if string is correct, False - otherwise</returns>
        bool IsSourceCodeValid(string srcCode);

        /// <summary>
        /// Compiles <see cref="ICodeObject"/>
        /// </summary>
        /// <param name="sourceCodeObject"><see cref="ICodeObject"/> instance</param>
        /// <returns>True - if compilation was successful, False - otherwise</returns>
        bool Compile(ICodeObject sourceCodeObject);
    }
}
