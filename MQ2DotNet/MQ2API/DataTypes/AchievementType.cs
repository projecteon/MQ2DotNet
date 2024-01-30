using System;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// Provides the details about a single achievement and allows access to an achievement's objective.
    /// https://docs.macroquest.org/reference/data-types/datatype-achievement/
    /// </summary>
    [MQ2Type("achievement")]
    public class AchievementType : MQ2DataType
    {
        public AchievementType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
            Objective = new IndexedMember<AchievementObjectiveType, int, AchievementObjectiveType, string>(this, "Objective");
            ObjectiveByIndex = new IndexedMember<AchievementObjectiveType, int>(this, "ObjectiveByIndex");
            Link = new IndexedStringMember<StringType>(this, "Link");
        }

        /// <summary>
        /// The achievement's unique ID.
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// The achievement's name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// The achievement's description
        /// </summary>
        public string Description => GetMember<StringType>("Description");

        /// <summary>
        /// The point value for the achievement
        /// </summary>
        public int? Points => GetMember<IntType>("Points");

        /// <summary>
        /// Find an objective by its objective ID or Description.
        /// </summary>
        public IndexedMember<AchievementObjectiveType, int, AchievementObjectiveType, string> Objective { get; }

        /// <summary>
        /// Find an objective by its visual ordering as displayed in the achievements window.
        /// </summary>
        public IndexedMember<AchievementObjectiveType, int> ObjectiveByIndex { get; }

        /// <summary>
        /// The number of objectives in this achievement.
        /// </summary>
        public int? ObjectiveCount => GetMember<IntType>("ObjectiveCount");

        /// <summary>
        /// Generate an achievement link. An optional name can be provided to display in the achievement, otherwise the current character's name will be used.
        /// </summary>
        public IndexedStringMember<StringType> Link { get; }

        /// <summary>
        /// The index of the achievement. 
        /// See https://docs.macroquest.org/reference/top-level-objects/tlo-achievement/#note-about-achievement-indices for more information.
        /// </summary>
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// ID of the Achievement's Icon. 
        /// See https://docs.macroquest.org/reference/data-types/datatype-achievement/#achievement-icon
        /// </summary>
        public int? IconID => GetMember<IntType>("IconID");

        /// <summary>
        /// The achievement state. 
        /// See https://docs.macroquest.org/reference/data-types/datatype-achievement/#achievement-state
        /// </summary>
        public string State => GetMember<StringType>("State");

        /// <summary>
        /// True if the achievement has been completed
        /// </summary>
        public bool Completed => GetMember<BoolType>("Completed");

        /// <summary>
        /// True if the achievement is open
        /// </summary>
        public bool Open => GetMember<BoolType>("Open");

        /// <summary>
        /// True if the achievement is locked
        /// </summary>
        public bool Locked => GetMember<BoolType>("Locked");

        /// <summary>
        /// True if the achievement is hidden
        /// </summary>
        public bool Hidden => GetMember<BoolType>("Hidden");

        /// <summary>
        /// Calendar time when the achievement was completed.
        /// </summary>
        public DateTime? CompletedTime => GetMember<TimeType>("CompletedTime");
    }
}
