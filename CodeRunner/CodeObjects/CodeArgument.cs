using CSharp.CodeUtils.CodeContracts.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner.CodeObjects
{
    /// <summary>
    /// Code argument implementation
    /// </summary>
    public class CodeArgument : ICodeArgument
    {
        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public string TypeName { get; set; }

        /// <inheritdoc />
        public object Value { get; set; }

        public CodeArgument()
        {
            Name = string.Empty;
            TypeName = string.Empty;
            Value = default;
        }
    }
}