namespace MQ2DotNet.MQ2API.DataTypes
{
    public class TypeType : MQ2DataType
    {
        public TypeType()
        {
            MemberByNumber = new IndexedMember<StringType>(this, "Member");
            MemberByName = new IndexedMember<IntType>(this, "Member");
        }

        public StringType Name => GetMember<StringType>("Name");
        public IndexedMember<StringType> MemberByNumber { get; }
        public IndexedMember<IntType> MemberByName { get; }
    }
}