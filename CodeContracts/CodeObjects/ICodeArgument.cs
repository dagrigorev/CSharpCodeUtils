namespace CSharp.CodeUtils.CodeContracts.CodeObjects
{
    /// <summary>
    /// Simple code argument contract
    /// </summary>
    public interface ICodeArgument
    {
        /// <summary>
        /// Argument name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Argument type name
        /// </summary>
        string TypeName { get; set; }

        /// <summary>
        /// Argument value
        /// </summary>
        object Value { get; set; }
    }
}