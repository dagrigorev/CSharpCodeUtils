using System;
using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner.CodeObjects
{
    /// <summary>
    /// <see cref="ICodeObject"/> extensions
    /// </summary>
    public static class CodeObjectExtension
    {
        /// <summary>
        /// Extends <see cref="ICodeObject"/> argument adding methods.
        /// </summary>
        /// <param name="codeObj"></param>
        /// <param name="args"></param>
        public static void AddArguments(this ICodeObject codeObj, params object[] args)
        {
            int argCounter = 0;
            foreach (var arg in args)
            {
                var codeArg = new CodeArgument()
                {
                    TypeName = arg.GetType().Name,
                    Name = $"arg{arg.GetType().Name}{argCounter++}",
                    Value = Activator.CreateInstance(arg.GetType())
                };

                codeObj.AddArgument(codeArg);
            }
        }

        public static bool IsEmpty(this ICodeObject codeObject)
        {
            return codeObject != null && string.IsNullOrEmpty(codeObject.Name) &&
                   string.IsNullOrEmpty(codeObject.ReturnType);
        }
    }
}