// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class MenuType : MQ2DataType
    {
        internal MenuType(MQ2TypeVar typeVar) : base(typeVar)
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

        public int? NumVisibleMenus => GetMember<IntType>("NumVisibleMenus");

        public int? CurrMenu => GetMember<IntType>("CurrMenu");

        public string Name => GetMember<StringType>("Name");

        public int? NumItems => GetMember<IntType>("NumItems");

        public IndexedMember<StringType, int> Items { get; }
    }
}