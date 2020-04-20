using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using CSharp.CodeUtils.CodeContracts;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Services;
using CSharp.CodeUtils.CodeRunner.CodeObjects;
using CSharp.CodeUtils.CodeRunner.Services;
using Microsoft.CodeAnalysis.Emit;

namespace CSharp.CodeUtils.CodeRunner
{
    public class CSharpCodeManager : ICodeManager
    {
        private EmitResult _lastResult;

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

        private object[] GetArgs(ICodeObject codeObject)
        {
            var instaces = new List<object>();
            foreach (var arg in codeObject.Args.Reverse())
            {
                var type = AppDomain.CurrentDomain.GetAssemblies()
                        .FirstOrDefault(assembly => assembly.GetType(arg.TypeName) != null)
                        ?.GetType(arg.TypeName);
                object val = Activator.CreateInstance(type);
                val = arg.Value;
                instaces.Add(val);
            }

            return instaces.ToArray();
        }

        /// <inheritdoc />
        public object Run(ICodeObject codeObject)
        {
            if (!CompilationService.Compile(codeObject))
            {
                return default;
            }
            else
            {
                var type = ResolveTypeFromMemory(CompilationService.BuildStream as MemoryStream, codeObject);
                return type.InvokeMember(codeObject.Name,
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    Activator.CreateInstance(type), GetArgs(codeObject));
            }
        }

        /// <inheritdoc />
        public object Run(ICodeObject codeObject, params object[] args)
        {
            if (!IsValid(codeObject)) return default;
            codeObject.AddArguments(args);

            return Run(codeObject);
        }

        private Type ResolveTypeFromMemory(MemoryStream ms, ICodeObject component)
        {
            if (component == null) return default;

            // reset stream
            ms.Seek(0, SeekOrigin.Begin);

            // load this 'virtual' DLL so that we can use
            // and create instance of the desired class and call the desired function.
            // P.S. Cannot cache it, cause we can't predict that same signature functions will not exist in one type container.  
            return Assembly.Load(ms.ToArray()).GetType($"{component.Name}Namespace.{component.Name}Block");
        }

        /// <inheritdoc />
        public CSharpCodeManager Initialize()
        {
            CompilationService.CodeGenerator = new CSharpSourceCodeGenerator();

            return this;
        }

        /// <inheritdoc />
        public bool IsValid(ICodeObject codeObject)
        {
            return codeObject != null && !codeObject.IsEmpty();
        }

        void ICodeManager.Initialize()
        {
            Initialize();
        }
    }
}