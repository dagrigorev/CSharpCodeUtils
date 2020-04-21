using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeContracts
{
    /// <summary>
    /// Source code generator
    /// </summary>
    public interface ISourceCodeGenerator
    {
        /// <summary>
        /// Generates source code from code object
        /// </summary>
        /// <param name="codeObject"></param>
        /// <returns></returns>
        string Generate(ICodeObject codeObject);
    }
}