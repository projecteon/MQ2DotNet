// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class SkillType : MQ2DataType
    {
        internal SkillType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        /// <summary>
        /// Name of the skill
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// Skill number
        /// </summary>
        public int ID => GetMember<IntType>("ID");

        /// <summary>
        /// Reuse time for the ability in milliseconds (not time remaining)
        /// </summary>
        public int ReuseTime => GetMember<IntType>("ReuseTime");

        /// <summary>
        /// Minimum level for your class
        /// </summary>
        public int MinLevel => GetMember<IntType>("MinLevel");

        /// <summary>
        /// Skill cap based on your current level and class
        /// </summary>
        public int SkillCap => GetMember<IntType>("SkillCap");

        /// <summary>
        /// TODO: Is this the common timer number (shared by other skills, but not the same as AA timers)
        /// </summary>
        public int AltTimer => GetMember<IntType>("AltTimer");

        /// <summary>
        /// Returns TRUE if the skill has been activated
        /// </summary>
        public bool Activated => GetMember<BoolType>("Activated");

        /// <summary>
        /// Skill has /autoskill on?
        /// </summary>
        public bool Auto => GetMember<BoolType>("Auto");
    }
}