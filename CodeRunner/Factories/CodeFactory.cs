using System;
using CSharp.CodeUtils.CodeContracts.CodeObjects;
using CSharp.CodeUtils.CodeContracts.Factories;
using CSharp.CodeUtils.CodeRunner.CodeObjects;

namespace CSharp.CodeUtils.CodeRunner.Factories
{
    /// <summary>
    /// Code object factory implementation
    /// </summary>
    public class CodeFactory : ICodeFactory
    {
        /// <inheritdoc />
        public ICodeArgument CreateInt8Argument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Byte),
                Name = string.IsNullOrEmpty(name) ? "byteArg" : name,
                Value = default(byte)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateInt16Argument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Int16),
                Name = string.IsNullOrEmpty(name) ? "int16Arg" : name,
                Value = default(short)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateInt32Argument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Int32),
                Name = string.IsNullOrEmpty(name) ? "int32Arg" : name,
                Value = default(int)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateInt64Argument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Int64),
                Name = string.IsNullOrEmpty(name) ? "int64Arg" : name,
                Value = default(long)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateFloatArgument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Single),
                Name = string.IsNullOrEmpty(name) ? "argFloat" : name,
                Value = default(float)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateDoubleArgument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Double),
                Name = string.IsNullOrEmpty(name) ? "argDouble" : name,
                Value = default(double)
            };
        }
    }
}
