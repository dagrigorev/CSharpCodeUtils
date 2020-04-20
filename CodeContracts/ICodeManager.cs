using System.Collections.Generic;
using CSharp.CodeUtils.CodeContracts.CodeObjects;

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
    }
}