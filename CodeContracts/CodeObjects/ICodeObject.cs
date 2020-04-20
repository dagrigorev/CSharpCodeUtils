using System.Collections.Generic;

namespace CSharp.CodeUtils.CodeContracts.CodeObjects
{
    /// <summary>
    /// Code object contract
    /// </summary>
    public interface ICodeObject
    {
        /// <summary>
        /// Code object name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Arguments list
        /// </summary>
        Stack<ICodeArgument> Args { get; }

        /// <summary>
        /// Source code
        /// </summary>
        string SourceCode { get; set; }

        /// <summary>
        /// Return type name
        /// </summary>
        string ReturnType { get; set; }

        /// <summary>
        /// Adds new argument
        /// </summary>
        /// <param name="arg"></param>
        void AddArgument(ICodeArgument arg);

        /// <summary>
        /// Adds new argument
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        void AddArgument<T>();

        /// <summary>
        /// Adds new argument
        /// </summary>
        /// <param name="typeName">Argument type</param>
        /// <param name="name">Argument name</param>
        void AddArgument(string typeName, string name);

        /// <summary>
        /// Removes last argument (from top of the stack)
        /// </summary>
        void RemoveArgument();

        /// <summary>
        /// Remove all args
        /// </summary>
        void ClearArgs();
    }
}