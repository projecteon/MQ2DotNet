namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// Provides access achievements, achievement categories, and other information surrounding the achievement system.
    /// https://docs.macroquest.org/reference/top-level-objects/tlo-achievement/#achievementmgr-type
    /// </summary>
    [MQ2Type("achievementmgr")]
    public class AchievementManagerType : MQ2DataType
    {
        public AchievementManagerType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
            Achievement = new IndexedMember<AchievementType, int, AchievementType, string>(this, "AchievementType");
            AchievementByIndex = new IndexedMember<AchievementType, int>(this, "AchievementByIndex");
            Category = new IndexedMember<AchievementCategoryType, int, AchievementCategoryType, string>(this, "Category");
            CategoryByIndex = new IndexedMember<AchievementCategoryType, int>(this, "CategoryByIndex");
        }

        /// <summary>
        /// Find an achievement by its ID or by its name.
        /// </summary>
        public IndexedMember<AchievementType, int, AchievementType, string> Achievement { get; }

        /// <summary>
        /// Find an achievement by its index.
        /// </summary>
        public IndexedMember<AchievementType, int> AchievementByIndex { get; }

        /// <summary>
        /// The number of achievements in the manager.
        /// </summary>
        public int? AchievementCount => GetMember<IntType>("AchievementCount");

        /// <summary>
        /// Find an achievement category by its id or by its name.Note: If searching by name, only top-level categories are returned from the achievement manager.
        /// </summary>
        public IndexedMember<AchievementCategoryType, int, AchievementCategoryType, string> Category { get; }

        /// <summary>
        /// Find an achievement category by its index.
        /// </summary>
        public IndexedMember<AchievementCategoryType, int> CategoryByIndex { get; }

        /// <summary>
        /// The number of achievement categories in the manager.
        /// </summary>
        public int? CategoryCount => GetMember<IntType>("CategoryCount");

        /// <summary>
        /// The total number of accumulated achievement points.
        /// </summary>
        public int? Points => GetMember<IntType>("Points");

        /// <summary>
        /// The number of completed achievements.
        /// </summary>
        public int? CompletedAchievement => GetMember<IntType>("CompletedAchievement");

        /// <summary>
        /// The number of available achievements.
        /// </summary>
        public int? TotalAchievement => GetMember<IntType>("TotalAchievement");

        /// <summary>
        /// Indicates that the manager has loaded all achievement data and is ready to be used.
        /// </summary>
        public bool Ready => GetMember<BoolType>("Ready");
    }
}
