using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeContracts.Factories
{
    /// <summary>
    /// Code objects factory contract
    /// </summary>
    public interface ICodeFactory
    {
        /// <summary>
        /// Creates new Int8 argument
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <returns>Int8 value</returns>
        ICodeArgument CreateInt8Argument(string name);

        /// <summary>
        /// Creates new Int16 argument
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <returns>Int16 value</returns>
        ICodeArgument CreateInt16Argument(string name);

        /// <summary>
        /// Creates new Int32 argument
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <returns>Int32 value</returns>
        ICodeArgument CreateInt32Argument(string name);

        /// <summary>
        /// Creates new Int64 argument
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <returns>Int64 value</returns>
        ICodeArgument CreateInt64Argument(string name);

        /// <summary>
        /// Creates new Float argument
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <returns>Float argument</returns>
        ICodeArgument CreateFloatArgument(string name);

        /// <summary>
        /// Creates new Double argument
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <returns>Double argument</returns>
        ICodeArgument CreateDoubleArgument(string name);

        /// <summary>
        /// Creates new code object
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="name">Code object name</param>
        /// <returns><see cref="ICodeObject"/> instance</returns>
        ICodeObject CreateCodeObject<T>(string name);

        /// <summary>
        /// Create code object that implements  arithmetical sum operation
        /// </summary>
        /// <returns><see cref="ICodeObject"/> instance</returns>
        ICodeObject CreateArithmeticalSumCodeObject();

        /// <summary>
        /// Create code object that implements arithmetical subtraction operation
        /// </summary>
        /// <returns><see cref="ICodeObject"/> instance</returns>
        ICodeObject CreateArithmeticalSubCodeObject();

        /// <summary>
        /// Create code object that implements arithmetical multiplication operation
        /// </summary>
        /// <returns><see cref="ICodeObject"/> instance</returns>
        ICodeObject CreateArithmeticalMulCodeObject();

        /// <summary>
        /// Create code object that implements arithmetical divide operation
        /// </summary>
        /// <returns><see cref="ICodeObject"/> instance</returns>
        ICodeObject CreateArithmeticalDivCodeObject();

    }
}