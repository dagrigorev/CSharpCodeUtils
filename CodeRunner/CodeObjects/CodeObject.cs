using System.Collections.Generic;
using System.Linq;
using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner.CodeObjects
{
    public class CodeObject : ICodeObject
    {
        /// <inheritdoc />
        public Stack<ICodeArgument> Args { get; }

        /// <inheritdoc />
        public string SourceCode { get; set; }

        /// <inheritdoc />
        public string ReturnType { get; set; }

        public CodeObject(Stack<ICodeArgument> args)
        {
            Args = args;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CodeObject()
        {
            Args = new Stack<ICodeArgument>();
        }

        /// <inheritdoc />
        public void AddArgument(ICodeArgument arg)
        {
            //arg.Name += $"_{Args.Count}";
            if(!Args.Contains(arg))
                Args.Push(arg);
        }

        /// <inheritdoc />
        public void RemoveArgument()
        {
            if (Args.Count > 0)
                Args.Pop();
        }

        /// <inheritdoc />
        public void AddArgument(string typeName, string name)
        {
            if(!Args.Any(arg => arg.Name.Equals(name)))
                Args.Push(new CodeArgument()
                {
                    TypeName = typeName,
                    Name = name
                });
        }

        /// <inheritdoc />
        public void ClearArgs()
        {
            if(Args.Count > 0)
                Args.Clear();
        }
    }
}