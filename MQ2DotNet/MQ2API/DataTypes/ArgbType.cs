using System.Drawing;
using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a colour
    /// </summary>
    [PublicAPI]
    public class ArgbType : MQ2DataType
    {
        internal ArgbType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Implicit conversion to a .NET colour type
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        public static implicit operator Color(ArgbType typeVar)
        {
            return Color.FromArgb(typeVar.VarPtr.Int);
        }
    }
}