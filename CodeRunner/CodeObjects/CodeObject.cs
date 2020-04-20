using System.Collections.Generic;
using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner.CodeObjects
{
    public class CodeObject : ICodeObject
    {
        /// <inheritdoc />
        public Stack<ICodeArgument> Args { get; private set; }

        /// <inheritdoc />
        public string SourceCode { get; set; }

        /// <inheritdoc />
        public string ReturnType { get; set; }

        public CodeObject(Stack<ICodeArgument> args)
        {
            Args = args;
        }

        public CodeObject()
        {
            Args = new Stack<ICodeArgument>();
        }

        /// <inheritdoc />
        public void AddArgument(ICodeArgument arg)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveArgument(ICodeArgument arg)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void AddArgument(string typeName, string name)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveArgument(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void ClearArgs()
        {
            throw new System.NotImplementedException();
        }
    }
}