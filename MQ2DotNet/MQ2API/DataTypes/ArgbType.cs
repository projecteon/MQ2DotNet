using System.Drawing;

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class ArgbType : MQ2DataType
    {
        public static implicit operator Color(ArgbType typeVar)
        {
            return Color.FromArgb(typeVar.VarPtr.Int);
        }
    }
}