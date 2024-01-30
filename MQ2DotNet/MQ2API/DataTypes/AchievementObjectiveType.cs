namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// Represents a single objective of an achievement
    /// https://docs.macroquest.org/reference/data-types/datatype-achievementobj/
    /// </summary>
    [MQ2Type("achievementobj")]
    public class AchievementObjectiveType : MQ2DataType
    {
        public AchievementObjectiveType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
        }

        /// <summary>
        /// The objective's unique ID.
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Text describing this objective.
        /// </summary>
        public string Description => GetMember<StringType>("Description");

        /// <summary>
        /// The current count recorded by the objective.
        /// </summary>
        public int? Count => GetMember<IntType>("Count");

        /// <summary>
        /// The total count required to be complete the objective. For objectives that don't require a count, this will be zero.
        /// </summary>
        public int? RequiredCount => GetMember<IntType>("RequiredCount");

        /// <summary>
        /// True if the objective has been completed.
        /// </summary>
        public bool Completed => GetMember<BoolType>("Completed");

        /// <summary>
        /// Visual index of the objective as displayed in the achievement window. Can be used with Achievement.ObjectiveByIndex.
        /// </summary>
        public int? Index => GetMember<IntType>("Index");
    }
}
