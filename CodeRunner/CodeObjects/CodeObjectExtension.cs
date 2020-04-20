using System;
using System.Linq;
using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner.CodeObjects
{
    /// <summary>
    /// <see cref="ICodeObject"/> extensions
    /// </summary>
    public static class CodeObjectExtension
    {
        /// <summary>
        /// Extensions <see cref="ICodeObject"/> argument adding methods.
        /// </summary>
        /// <param name="codeObj"></param>
        /// <param name="args"></param>
        public static void AddArguments(this ICodeObject codeObj, params object[] args)
        {
            int argCounter = 0;
            var codeObjectArgs = codeObj.Args.ToArray();
            codeObj.ClearArgs();
            
            foreach (var arg in args)
            {
                var argument = codeObjectArgs.FirstOrDefault(arg0 => arg0.Name.Equals($"arg{argCounter}"));
                if (argument != null)
                {
                    argument.Value = arg;
                    codeObj.AddArgument(argument);
                }
                else
                {
                    var codeArg = new CodeArgument()
                    {
                        TypeName = arg.GetType().FullName,
                        Name = $"arg{argCounter}",
                        Value = arg
                    };

                    codeObj.AddArgument(codeArg);
                }

                argCounter++;
            }
        }

        public static bool HasArgument(this ICodeObject codeObject, string argumentName)
        {
            return codeObject.Args.Any(arg => arg.Name.Equals(argumentName));
        }

        public static bool IsEmpty(this ICodeObject codeObject)
        {
            return codeObject != null && string.IsNullOrEmpty(codeObject.Name) &&
                   string.IsNullOrEmpty(codeObject.ReturnType);
        }
    }
}