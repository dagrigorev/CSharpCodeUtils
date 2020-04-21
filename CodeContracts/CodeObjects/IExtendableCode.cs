namespace CSharp.CodeUtils.CodeContracts.CodeObjects
{
    /// <summary>
    /// Extendable code object contract
    /// </summary>
    public interface IExtendableCode
    {
        /// <summary>
        /// Source code extensions here
        /// </summary>
        ICodeObject[] Extensions { get; }

        /// <summary>
        /// Extensions source code object by another one
        /// </summary>
        /// <param name="codeObject"><see cref="ICodeObject"/> instance that used for extending current</param>
        void AddExtension(ICodeObject codeObject);

        /// <summary>
        /// Removes extension
        /// </summary>
        /// <param name="removeObject"></param>
        void RemoveExtension(ICodeObject removeObject);
    }
}