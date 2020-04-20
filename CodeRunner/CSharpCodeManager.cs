using System.Collections.Generic;
using System.ComponentModel;
using CSharp.CodeUtils.CodeContracts;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Services;
using CSharp.CodeUtils.CodeRunner.Services;

namespace CSharp.CodeUtils.CodeRunner
{
    public class CSharpCodeManager : ICodeManager
    {

        /// <inheritdoc />
        public IEnumerable<ICodeObject> CodeObjects { get; set; }

        /// <inheritdoc />
        public ICompilerService CompilationService { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CSharpCodeManager()
        {
            CompilationService = new CSharpCompilationService(); 
        }

        /// <inheritdoc />
        public object Run(string name, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public object Run(ICodeObject codeObject)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void Initialize()
        {
            CompilationService.CodeGenerator = new CSharpSourceCodeGenerator();
        }

        /// <inheritdoc />
        public bool IsValid(ICodeObject codeObject)
        {
            return codeObject != null && !string.IsNullOrEmpty(codeObject.ReturnType) &&
                   codeObject.SourceCode.Length > 0;
        }
    }
}