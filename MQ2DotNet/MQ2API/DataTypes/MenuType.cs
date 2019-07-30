using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for a context menu
    /// </summary>
    [PublicAPI]
    [MQ2Type("menu")]
    public class MenuType : MQ2DataType
    {
        internal MenuType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            Items = new IndexedMember<StringType, int>(this, "Items");
        }
        
        /// <summary>
        /// Select the first item in the context menu with text containg a given string
        /// </summary>
        /// <param name="containing">Text to search for</param>
        /// <returns>true if an item was found, otherwise false</returns>
        public bool Select(string containing) => GetMember<BoolType>("Select", containing);

        /// <summary>
        /// Memory address of the CContextMenu structure
        /// </summary>
        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? NumVisibleMenus => GetMember<IntType>("NumVisibleMenus");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? CurrMenu => GetMember<IntType>("CurrMenu");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public int? NumItems => GetMember<IntType>("NumItems");

        /// <summary>
        /// TODO: What is this?
        /// </summary>
        public IndexedMember<StringType, int> Items { get; }
    }
}