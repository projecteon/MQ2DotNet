using System;
using JetBrains.Annotations;
using MQ2DotNet.EQ;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a 32 bit integer
    /// </summary>
    [PublicAPI]
    [MQ2Type("int")]
    public class IntType : MQ2DataType
    {
        internal IntType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        // MQ2 type has a bunch of members, but it hardly seems worth implementing them here


        /// <summary>
        /// Implicit conversion to a nullable int
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        public static implicit operator int?(IntType typeVar)
        {
            return typeVar?.VarPtr.Int;
        }

        /// <summary>
        /// Implicit conversion to a nullable IntPtr
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        public static implicit operator IntPtr?(IntType typeVar)
        {
            return typeVar?.VarPtr.Ptr;
        }

        /// <summary>
        /// Implicit conversion to a Class enum
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        public static implicit operator Class?(IntType typeVar)
        {
            return (Class?) typeVar?.VarPtr.Int;
        }
    }
}