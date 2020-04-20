using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.CodeUtils.CodeContracts;
using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner
{
    public class CSharpSourceCodeGenerator : ISourceCodeGenerator
    {
        public ISet<string> Usings { get; private set; }

        public CSharpSourceCodeGenerator()
        {
            Usings = new HashSet<string> { "System", "System.Linq", "System.Collections.Generic" };

        }

        private string GenerateMetodDeclaration(ICodeObject codeObject)
        {
            var sourceCodeBuilder = new StringBuilder();
            sourceCodeBuilder.AppendLine(
                $"public {codeObject.ReturnType} {codeObject.Name}({GetStringFromArgs(codeObject.Args.ToArray())}){{");
            sourceCodeBuilder.Append(codeObject.SourceCode);
            sourceCodeBuilder.AppendLine("}");
            return sourceCodeBuilder.ToString();
        }

        /// <inheritdoc />
        public string Generate(ICodeObject codeObject)
        {
            var sourceCodeBuilder = new StringBuilder(GetUsings());
            sourceCodeBuilder.AppendLine($"namespace {codeObject.Name}Namespace{{");

            sourceCodeBuilder.AppendLine($"public class {codeObject.Name}Block{{");
            if (codeObject is IExtendableCode extCode)
                foreach (var ext in extCode.Extensions)
                    sourceCodeBuilder.AppendLine(GenerateMetodDeclaration(ext));

            sourceCodeBuilder.AppendLine(GenerateMetodDeclaration(codeObject));
            sourceCodeBuilder.AppendLine("}");
            sourceCodeBuilder.AppendLine("}");

            return sourceCodeBuilder.ToString();
        }

        private string GetUsings()
        {
            var usingsStringBuilder = new StringBuilder();
            foreach (var usingItem in Usings)
                usingsStringBuilder.AppendLine($"using {usingItem};");
            return usingsStringBuilder.ToString();
        }

        private string GetStringFromArgs(params ICodeArgument[] args)
        {
            var argsStringBuilder = new StringBuilder();
            var revArgs = args.Reverse().ToArray();

            foreach (var arg in revArgs)
            {
                argsStringBuilder.Append($"{arg.TypeName} {arg.Name}");
                if (!revArgs.Last().Equals(arg))
                    argsStringBuilder.Append(", ");
            }

            return argsStringBuilder.ToString();
        }
    }
}