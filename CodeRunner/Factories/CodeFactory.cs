using System;
using System.Collections.Generic;
using System.Text;
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
                Name = "argByte",
                Value = default(byte)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateInt16Argument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Int16),
                Name = "argInt16",
                Value = default(short)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateInt32Argument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Int32),
                Name = "argInt32",
                Value = default(int)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateInt64Argument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Int64),
                Name = "argInt64",
                Value = default(long)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateFloatArgument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Single),
                Name = "argFloat",
                Value = default(float)
            };
        }

        /// <inheritdoc />
        public ICodeArgument CreateDoubleArgument(string name)
        {
            return new CodeArgument()
            {
                TypeName = nameof(Double),
                Name = "argDouble",
                Value = default(double)
            };
        }
    }
}
