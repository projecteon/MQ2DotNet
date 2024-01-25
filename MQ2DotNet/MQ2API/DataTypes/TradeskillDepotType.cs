using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// This contains information related to a tradeskill depot.
    /// Last Verified: 2023-07-02
    /// https://docs.macroquest.org/reference/data-types/datatype-tradeskilldepot/
    /// </summary>
    [MQ2Type("tradeskilldepot")]
    public class TradeskillDepotType : MQ2DataType
    {
        public TradeskillDepotType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
            _findItem = new IndexedMember<ItemType, string, ItemType, int>(this, "FindItem");
            _findItemCount = new IndexedMember<IntType, string, IntType, int>(this, "FindItemCount");
        }

        /// <summary>
        /// Select an item with the given name.
        /// </summary>
        /// <param name="name"></param>
        public void SelectItem(string name) => GetMember<MQ2DataType>("SelectItem", name);

        /// <summary>
        /// Withdraw a full stack of the selected item from the tradeskill depot.
        /// </summary>
        public void WithdrawStack() => GetMember<MQ2DataType>("SelectItem");

        /// <summary>
        /// Withdraw a full stack of the given item name from the tradeskill depot.
        /// </summary>
        /// <param name="name"></param>
        public void WithdrawStack(string name) => GetMember<MQ2DataType>("SelectItem", name);

        /// <summary>
        /// Withdraw the selected item from the tradeskill depot.
        /// Will create a quantity window if there is more than one item in the stack.
        /// </summary>
        public void WithdrawItem() => WithdrawStack();

        /// <summary>
        /// Withdraw the given item name from the tradeskill depot.
        /// Will create a quantity window if there is more than one item in the stack.
        /// </summary>
        /// <param name="name"></param>
        public void WithdrawItem(string name) => WithdrawStack(name);

        /// <summary>
        /// Returns the number of item stacks in the tradeskill depot.
        /// </summary>
        public int? Count => GetMember<IntType>("Count");

        /// <summary>
        /// Returns the total capacity of the tradeskill depot.
        /// </summary>
        public int? Capacity => GetMember<IntType>("Capacity");

        /// <summary>
        /// Returns whether the tradeskill depot is enabled or not.
        /// It requires the Night of Shadows expansion.
        /// </summary>
        public bool Enabled => GetMember<BoolType>("Enabled");

        /// <summary>
        /// Returns whether the tradeskill depot has been populated with items.
        /// The window must be opened at least once for the depot to be populated with items.
        /// </summary>
        public bool ItemsReceived => GetMember<BoolType>("ItemsReceived");

        /// <summary>
        /// Find an item with the given item ID in the tradeskill depot.
        /// FindItem[ # ]
        /// 
        /// Find an item by partial name in the tradeskill depot. Prefix with "=" for an exact match.
        /// FindItem[name]
        /// </summary>
        private readonly IndexedMember<ItemType, string, ItemType, int> _findItem;

        /// <summary>
        /// Find an item with the given item ID in the tradeskill depot.
        /// FindItem[ # ]
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ItemType FindItem(int itemID) => _findItem[itemID];

        /// <summary>
        /// Find an item by partial name in the tradeskill depot. Prefix with "=" for an exact match.
        /// FindItem[name]
        /// </summary>
        /// <param name="itemName">The name to match. No need to prefix with "=" for exact match, set the partialMatch param to false.</param>
        /// <param name="partialMatch">Optional partial match parameter. Default is true. If false an exact case insensitive match is required.</param>
        /// <returns></returns>
        public ItemType FindItem(string itemName, bool partialMatch = true) => _findItem[partialMatch ? itemName : $"={itemName}"];

        /// <summary>
        /// Find the number of items with the given item ID in the tradeskill depot.
        /// FindItemCount[ # ]
        /// 
        /// Find the number of items by partial name in the tradeskill depot. Prefix with "=" for an exact match.
        /// FindItemCount[name]
        /// </summary>
        private readonly IndexedMember<IntType, string, IntType, int> _findItemCount;

        /// <summary>
        /// Find the number of items with the given item ID in the tradeskill depot.
        /// FindItemCount[ # ]
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public int? FindItemCount(int itemID) => (int?)_findItemCount[itemID];

        /// <summary>
        /// Find the number of items by partial name in the tradeskill depot. Prefix with "=" for an exact match.
        /// FindItemCount[name]
        /// </summary>
        /// <param name="itemName">The name to match. No need to prefix with "=" for exact match, set the partialMatch param to false.</param>
        /// <param name="partialMatch">Optional partial match parameter. Default is true. If false an exact case insensitive match is required.</param>
        /// <returns></returns>
        public int? FindItemCount(string itemName, bool partialMatch = true) => (int?)_findItemCount[partialMatch ? itemName : $"={itemName}"];

        /// <summary>
        /// Returns the currently selected item in the tradeskill depot window.
        /// </summary>
        public ItemType SelectedItem => GetMember<ItemType>("SelectedItem");
    }
}
