using System.Collections.Generic;
using System.Linq;
using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner.CodeObjects
{
    public class CodeObject : ICodeObject, IExtendableCode
    {
        private int _argCounter;
        private ISet<ICodeObject> _extensions;
        
        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public Stack<ICodeArgument> Args { get; }

        /// <inheritdoc />
        public string SourceCode { get; set; }

        /// <inheritdoc />
        public string ReturnType { get; set; }

        /// <inheritdoc />
        public ICodeObject[] Extensions => _extensions.ToArray();

        public CodeObject(Stack<ICodeArgument> args)
        {
            Args = args;
            _argCounter = 0;
            _extensions = new HashSet<ICodeObject>();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CodeObject()
        {
            Args = new Stack<ICodeArgument>();
            _argCounter = 0;
            _extensions = new HashSet<ICodeObject>();
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
        public void AddArgument<T>()
        {
            AddArgument(new CodeArgument()
            {
                TypeName = typeof(T).FullName,
                Name = $"arg{_argCounter}",
                Value = default(T)
            });
            _argCounter++;
        }

        /// <inheritdoc />
        public void ClearArgs()
        {
            if(Args.Count > 0)
                Args.Clear();

            _argCounter = 0;
        }

        /// <inheritdoc />
        public void AddExtension(ICodeObject codeObject)
        {
            if (!_extensions.Contains(codeObject))
                _extensions.Add(codeObject);
        }

        /// <inheritdoc />
        public void RemoveExtension(ICodeObject removeObject)
        {
            if (_extensions.Contains(removeObject))
                _extensions.Remove(removeObject);
        }
    }
}