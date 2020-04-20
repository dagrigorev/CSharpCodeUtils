using Microsoft.CodeAnalysis;

namespace CSharp.CodeUtils.CodeContracts.Services
{
    /// <summary>
    /// C# compiler service contract
    /// </summary>
    public interface ICompilerService
    {
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
    }
}
