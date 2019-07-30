using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type from the MQ2Cast plugin
    /// TODO: Invalidate this and make member calls throw if MQ2Cast isn't loaded
    /// </summary>
    [PublicAPI]
    [MQ2Type("Cast")]
    public class CastType : MQ2DataType
    {
        internal CastType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public bool Active => GetMember<BoolType>("Active");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public SpellType Effect => GetMember<SpellType>("Effect");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public SpellType Stored => GetMember<SpellType>("Stored");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? Timing => GetMember<IntType>("Timing");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public string Status => GetMember<StringType>("Status");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public string Result => GetMember<StringType>("Result");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public string Return => GetMember<StringType>("Return");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public bool Ready => GetMember<BoolType>("Ready");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public bool Taken => GetMember<BoolType>("Taken");
    }
}