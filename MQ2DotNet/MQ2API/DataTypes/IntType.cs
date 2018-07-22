namespace MQ2DotNet.MQ2API.DataTypes
{
    public class IntType : MQ2DataType
    {
        internal IntType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        // MQ2 type has a bunch of members, but it hardly seems worth implementing them here
        public static implicit operator int(IntType typeVar)
        {
            return typeVar.VarPtr.Int;
        }

        public static implicit operator Class(IntType typeVar)
        {
            return (Class) typeVar.VarPtr.Int;
        }

        public static implicit operator Int64Type(IntType typeVar)
        {
            return new Int64Type(typeVar.VarPtr.Int);
        }
    }
}