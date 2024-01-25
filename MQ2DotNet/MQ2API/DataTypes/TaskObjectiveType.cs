using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a task objective
    /// </summary>
    [PublicAPI]
    [MQ2Type("taskobjectivemember")]
    public class TaskObjectiveType : MQ2DataType
    {
        internal TaskObjectiveType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Index of this objective in the list (0 based)
        /// Confusingly, ${Task[taskname].Objective[1].Index} == 0
        /// </summary>
        public int? Index => GetMember<IntType>("Index");

        /// <summary>
        /// Instruction text for this objective, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public string Instruction => GetMember<StringType>("Instruction");

        /// <summary>
        /// Status text for the objective, e.g. 0/1 or Done, as seen in the Quest Journal window
        /// Note that accessing this member will select the task
        /// </summary>
        public string Status => GetMember<StringType>("Status");

        /// <summary>
        /// Zone for the objective, as seen in the Quest Journal window
        /// Note that accessing this member will select the task.
        /// TODO: this needs to be tested. It is a special case where a member can return different data types which makes this tricky.
        /// </summary>
        public bool AllZones
        {
            get
            {
                try
                {
                    return GetMember<StringType>("Zone") == "ALL";
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Zone for the objective, as seen in the Quest Journal window
        /// Note that accessing this member will select the task.
        /// TODO: this needs to be tested. It is a special case where a member can return different data types which makes this tricky.
        /// </summary>
        public ZoneType Zone
        {
            get
            {
                try
                {
                    return GetMember<ZoneType>("Zone");
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Unknown, None, Deliver, Kill, Loot, Hail, Explore, Tradeskill, Fishing, Foraging, Cast, UseSkill, DZSwitch, DestroyObject, Collect, Dialogue, NULL
        /// </summary>
        public string Type => GetMember<StringType>("Type");

        /// <summary>
        /// Returns the current count of the .Type needed to complete a objective
        /// </summary>
        public int? CurrentCount => GetMember<IntType>("CurrentCount");

        /// <summary>
        /// Returns the required count of the .Type needed to complete a objective
        /// </summary>
        public int? RequiredCount => GetMember<IntType>("RequiredCount");

        /// <summary>
        /// Returns true or false if a objective is optional
        /// </summary>
        public bool Optional => GetMember<BoolType>("Optional");

        /// <summary>
        /// Returns a string of the required item to complete a objective.
        /// </summary>
        public string RequiredItem => GetMember<StringType>("RequiredItem");

        /// <summary>
        /// Returns a string of the required skill to complete a objective.
        /// </summary>
        public string RequiredSkill => GetMember<StringType>("RequiredSkill");

        /// <summary>
        /// Returns a string of the required spell to complete a objective.
        /// </summary>
        public string RequiredSpell => GetMember<StringType>("RequiredSpell");

        /// <summary>
        /// Returns an int of the switch used in a objective.
        /// </summary>
        public int? DZSwitchID => GetMember<IntType>("DZSwitchID");
    }
}