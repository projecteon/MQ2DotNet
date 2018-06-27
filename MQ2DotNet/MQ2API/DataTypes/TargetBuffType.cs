namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TargetBuffType : SpellType
    {
        public new IntType Address => GetMember<IntType>("Address");
        public IntType xIndex => GetMember<IntType>("xIndex");
        public new TimeStampType Duration => GetMember<TimeStampType>("Duration");
    }
}