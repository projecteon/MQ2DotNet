using System;
using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for an AA
    /// </summary>
    [PublicAPI]
    [MQ2Type("altability")]
    public class AltAbilityType : MQ2DataType
    {
        internal AltAbilityType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Name of the ability
        /// </summary>
        public string Name => GetMember<StringType>("Name");
        
        /// <summary>
        /// Short name of the ability
        /// </summary>
        public string ShortName => GetMember<StringType>("ShortName");

        /// <summary>
        /// Description as it appears in the AA window
        /// </summary>
        public string Description => GetMember<StringType>("Description");

        /// <summary>
        /// ID of the ability, for use with /alt activate
        /// </summary>
        public int? ID => GetMember<IntType>("ID");

        /// <summary>
        /// Reuse time in seconds
        /// </summary>
        public int? ReuseTime => GetMember<IntType>("ReuseTime");

        /// <summary>
        /// Reuse time in seconds after modifiers have been applied
        /// </summary>
        public int? MyReuseTime => GetMember<IntType>("MyReuseTime");

        /// <summary>
        /// Minimum level to train
        /// </summary>
        public int? MinLevel => GetMember<IntType>("MinLevel");

        /// <summary>
        /// Base cost to train
        /// </summary>
        public int? Cost => GetMember<IntType>("Cost");

        /// <summary>
        /// Spell used by the ability (if any)
        /// </summary>
        public SpellType Spell => GetMember<SpellType>("Spell");

        /// <summary>
        /// Required ability (if any)
        /// </summary>
        public AltAbilityType RequiresAbility => GetMember<AltAbilityType>("RequiresAbility");

        /// <summary>
        /// Points required in <see cref="RequiresAbility"/>
        /// </summary>
        public int? RequiresAbilityPoints => GetMember<IntType>("RequiresAbilityPoints");

        /// <summary>
        /// Max rank available in this ability
        /// </summary>
        public int? MaxRank => GetMember<IntType>("MaxRank");

        /// <summary>
        /// Current rank in this ability
        /// </summary>
        public int? Rank => GetMember<IntType>("Rank");

        /// <summary>
        /// Deprecated, use <see cref="Rank"/>
        /// </summary>
        [Obsolete]
        public int? AARankRequired => Rank;

        /// <summary>
        /// Type (1-6) TODO: Document properly
        /// </summary>
        public int? Type => GetMember<IntType>("Type");

        /// <summary>
        /// TODO: Document properly
        /// </summary>
        public int? Flags => GetMember<IntType>("Flags");

        /// <summary>
        /// TODO: Document properly
        /// </summary>
        public int? Expansion => GetMember<IntType>("Expansion");

        /// <summary>
        /// True if the ability does not require activation
        /// </summary>
        public bool Passive => GetMember<BoolType>("Passive");

        /// <summary>
        /// Returns the amount of points spent on an AA
        /// </summary>
        public int? PointsSpent => GetMember<IntType>("PointsSpent");
        
        /// <summary>
        /// TODO: What is AltAbilityType.Index
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// Returns true/false on if the Alternative Ability can be trained
        /// </summary>
        public bool CanTrain => GetMember<BoolType>("CanTrain");

        /// <summary>
        /// Returns the next index number of the Alternative Ability
        /// </summary>
        public int? NextIndex => GetMember<IntType>("NextIndex");

    }
}