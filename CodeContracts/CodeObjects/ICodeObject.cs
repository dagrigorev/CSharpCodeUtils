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
        Stack<ICodeArgument> Args { get; set; }

        /// <summary>
        /// Source code
        /// </summary>
        string SourceCode { get; set; }

        /// <summary>
        /// Return type name
        /// </summary>
        string ReturnType { get; set; }
    }
}