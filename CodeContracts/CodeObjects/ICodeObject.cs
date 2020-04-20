using System.Collections.Generic;

namespace CSharp.CodeUtils.CodeContracts.CodeObjects
{
    /// <summary>
    /// Code object contract
    /// </summary>
    public interface ICodeObject
    {
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
        /// Removes argument
        /// </summary>
        /// <param name="arg"></param>
        void RemoveArgument(ICodeArgument arg);

        /// <summary>
        /// Adds new argument
        /// </summary>
        /// <param name="typeName">Argument type</param>
        /// <param name="name">Argument name</param>
        void AddArgument(string typeName, string name);

        /// <summary>
        /// Removes argument by name
        /// </summary>
        /// <param name="name">Argument name</param>
        void RemoveArgument(string name);

        /// <summary>
        /// Remove all args
        /// </summary>
        void ClearArgs();
    }
}