using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeContracts
{
    /// <summary>
    /// Code runner contract
    /// </summary>
    public interface ICodeRunner
    {
        /// <summary>
        /// Runs source code
        /// </summary>
        /// <param name="name">Code snippet name</param>
        /// <param name="args">Code arguments</param>
        /// <returns>Execution result</returns>
        object Run(string name, params object[] args);

        /// <summary>
        /// Runs source code that implemented by <see cref="ICodeObject"/>
        /// </summary>
        /// <param name="codeObject">Runnable code object</param>
        /// <returns>Running result</returns>
        object Run(ICodeObject codeObject, params object[] args);
    }
}