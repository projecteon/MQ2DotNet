using System;

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class AltAbilityType : MQ2DataType
    {
        /// <summary>
        /// Name of the ability
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");
        
        /// <summary>
        /// Short name of the ability
        /// </summary>
        public StringType ShortName => GetMember<StringType>("ShortName");

        /// <summary>
        /// Description as it appears in the AA window
        /// </summary>
        public StringType Description => GetMember<StringType>("Description");

        /// <summary>
        /// ID of the ability, for use with /alt activate
        /// </summary>
        public IntType ID => GetMember<IntType>("ID");

        /// <summary>
        /// Reuse time in seconds
        /// </summary>
        public IntType ReuseTime => GetMember<IntType>("ReuseTime");

        /// <summary>
        /// Reuse time in seconds after modifiers have been applied
        /// </summary>
        public IntType MyReuseTime => GetMember<IntType>("MyReuseTime");

        /// <summary>
        /// Minimum level to train
        /// </summary>
        public IntType MinLevel => GetMember<IntType>("MinLevel");

        /// <summary>
        /// Base cost to train
        /// </summary>
        public IntType Cost => GetMember<IntType>("Cost");

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
        public IntType RequiresAbilityPoints => GetMember<IntType>("RequiresAbilityPoints");

        /// <summary>
        /// Max rank available in this ability
        /// </summary>
        public IntType MaxRank => GetMember<IntType>("MaxRank");

        /// <summary>
        /// Current rank in this ability
        /// </summary>
        public IntType Rank => GetMember<IntType>("Rank");

        /// <summary>
        /// Deprecated, use <see cref="Rank"/>
        /// </summary>
        [Obsolete]
        public IntType AARankRequired => Rank;

        /// <summary>
        /// Type (1-6) TODO: Document properly
        /// </summary>
        public IntType Type => GetMember<IntType>("Type");

        /// <summary>
        /// TODO: Document properly
        /// </summary>
        public IntType Flags => GetMember<IntType>("Flags");

        /// <summary>
        /// TODO: Document properly
        /// </summary>
        public IntType Expansion => GetMember<IntType>("Expansion");

        /// <summary>
        /// True if the ability does not require activation
        /// </summary>
        public BoolType Passive => GetMember<BoolType>("Passive");

        /// <summary>
        /// Returns the amount of points spent on an AA
        /// </summary>
        public IntType PointsSpent => GetMember<IntType>("PointsSpent");

        [Obsolete]
        public IntType xIndex => GetMember<IntType>("xIndex");

        /// <summary>
        /// Returns true/false on if the Alternative Ability can be trained
        /// </summary>
        public BoolType CanTrain => GetMember<BoolType>("CanTrain");

        /// <summary>
        /// Returns the next index number of the Alternative Ability
        /// </summary>
        public IntType NextIndex => GetMember<IntType>("NextIndex");

    }
}