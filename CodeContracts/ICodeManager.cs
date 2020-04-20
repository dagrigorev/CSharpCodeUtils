using System.Collections.Generic;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Services;

namespace CSharp.CodeUtils.CodeContracts
{
    /// <summary>
    /// Source code manager
    /// </summary>
    public interface ICodeManager : ICodeRunner
    {
        /// <summary>
        /// Code objects collection
        /// </summary>
        IEnumerable<ICodeObject> CodeObjects { get; set; }

        /// <summary>
        /// Source code compilation service
        /// </summary>
        ICompilerService CompilationService { get; set; }

        /// <summary>
        /// Initializes code manager
        /// </summary>
        void Initialize();

        /// <summary>
        /// Checks <see cref="ICodeObject"/> for validity
        /// </summary>
        /// <param name="codeObject">Code object</param>
        /// <returns>True - if object is valid, False - otherwise</returns>
        bool IsValid(ICodeObject codeObject);
    }
}