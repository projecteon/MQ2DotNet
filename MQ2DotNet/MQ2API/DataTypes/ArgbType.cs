using System.Drawing;

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ArgbType : MQ2DataType
    {
        internal ArgbType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public static implicit operator Color(ArgbType typeVar)
        {
            return Color.FromArgb(typeVar.VarPtr.Int);
        }
    }
}