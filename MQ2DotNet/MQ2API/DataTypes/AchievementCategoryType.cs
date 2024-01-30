namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// Provides access to achievement categories. Achievements are organized hierarchically in the achievements window by categories.
    /// While not required to access achievements, categories may be useful for enumerating lists of achievements.
    /// https://docs.macroquest.org/reference/data-types/datatype-achievementcat/
    /// </summary>
    [MQ2Type("achievementcat")]
    public class AchievementCategoryType : MQ2DataType
    {
        public AchievementCategoryType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
            Achievement = new IndexedMember<AchievementType, int, AchievementType, string>(this, "AchievementType");
            AchievementByIndex = new IndexedMember<AchievementType, int>(this, "AchievementByIndex");
            Category = new IndexedMember<AchievementCategoryType, int, AchievementCategoryType, string>(this, "Category");
            CategoryByIndex = new IndexedMember<AchievementCategoryType, int>(this, "CategoryByIndex");
        }

        /// <summary>
        /// The unique ID for the category
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// The category's display name
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// The category's description
        /// </summary>
        public string Description => GetMember<StringType>("Description");

        /// <summary>
        /// Find an achievement in this category by its ID or name.
        /// </summary>
        public IndexedMember<AchievementType, int, AchievementType, string> Achievement { get; }

        /// <summary>
        /// Find an achievement by its index in this category.
        /// </summary>
        public IndexedMember<AchievementType, int> AchievementByIndex { get; }

        /// <summary>
        /// The number of achievements in this category.
        /// </summary>
        public int? AchievementCount => GetMember<IntType>("AchievementCount");

        /// <summary>
        /// Find a child category in this category by its ID or name.
        /// </summary>
        public IndexedMember<AchievementCategoryType, int, AchievementCategoryType, string> Category { get; }

        /// <summary>
        /// Find a child category by its index in this category.
        /// </summary>
        public IndexedMember<AchievementCategoryType, int> CategoryByIndex { get; }

        /// <summary>
        /// The number of child categories in this category.
        /// </summary>
        public int? CategoryCount => GetMember<IntType>("CategoryCount");

        /// <summary>
        /// The total earned points of achievements in this category.
        /// </summary>
        public int? Points => GetMember<IntType>("Points");

        /// <summary>
        /// The number of achievements earned in this category and its subcategories
        /// </summary>
        public int? CompletedAchievements => GetMember<IntType>("CompletedAchievements");

        /// <summary>
        /// The total number of achievements in this category and its subcategories.
        /// </summary>
        public int? TotalAchievements => GetMember<IntType>("TotalAchievements");

        /// <summary>
        /// Name of the image texture that is used to represent this category in the Achievements Window.
        /// </summary>
        public string ImageTextureName => GetMember<StringType>("ImageTextureName");

        /// <summary>
        /// The index of the category in the achievement manager.
        /// For more information see https://docs.macroquest.org/reference/top-level-objects/tlo-achievement/#note-about-achievement-indices
        /// </summary>
        public int? Index => GetMember<IntType>("Index");
    }
}
