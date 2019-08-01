using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MQ2DotNet.EQ;
using MQ2DotNet.MQ2API.DataTypes;

// Sorts inventory. Anything in the keep list gets put at the end.
// Everything else gets sorted by autoloot setting: Sell > Destroy > Barter > Quest > Deposit > Keep > Ignore > None
// If it can, it will leave the rest of the bag empty between categories, so you can sell the bag contents.
// Trade satchels are supported.

var keepItems = new List<string>(new[] { "Fellowship Registration Insignia", "Mirror Fragment of Anashti Sul", "Grapes", 
    "Water Flask", "Class XXI Augmentation Distiller", "Philter of Major Translocation" });

if (TLO.Me.Spawn.Class == Class.Shadowknight)
    keepItems.AddRange(new [] {"Steed of Souls", "Bone Chips", "Tiny Jade Inlaid Coffin", "Pearl", "Fire Beetle Eye", "Honed Wurmslayer"});
if (TLO.Me.Spawn.Class == Class.Mage)
    keepItems.AddRange(new [] {"Malachite", "Pearl"});
if (TLO.Me.Spawn.Class == Class.Cleric)
    keepItems.AddRange(new[] { "Emerald" });

var debug = Args.Contains("debug");
void WriteDebug(string text)
{
    if (debug) MQ2.WriteChat(text);
}

// Abstracted view of the inventory to make it a bit easier to work with
// Can be accessed by item number e.g. inventory[0] for the first item in the first bag,
// or by bag & item number e.g. inventory.Bag[0][1] for the second item in the first bag.
// Each "item" is just a string
public class InventoryView : IEnumerable<string>
{
    private string[] _items;
    private InventoryBag[] _bags;

    public InventoryView(int[] bagSizes)
    {
        if (bagSizes.Length != 10)
            throw new ArgumentException("Need 10 bags !");

        _items = new string[bagSizes.Sum()];

        _bags = new InventoryBag[10];

        var start = 0;
        for (var i = 0; i < 10; i++)
        {
            _bags[i] = new InventoryBag(this, start, bagSizes[i]);
            start += bagSizes[i];
        }

        Bags = new List<InventoryBag>(_bags).AsReadOnly();
    }

    public string this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    public void AddFront(string itemName)
    {
        for (var i = 0; i < Slots; i++)
            if (string.IsNullOrEmpty(this[i]))
            {
                this[i] = itemName;
                return;
            }
        
        throw new InvalidOperationException();
    }

    public void AddBack(string itemName)
    {
        for (var i = Slots - 1; i >= 0; i--)
            if (string.IsNullOrEmpty(this[i]))
            {
                this[i] = itemName;
                return;
            }
        
        throw new InvalidOperationException();
    }

    public (int, int) GetBagAndSlot(int index)
    {
        var initialIndex = index;
        var bag = 0;
        while (index >= 0)
        {
            if (index < Bags[bag].Slots)
                return (bag, index);
            index -= Bags[bag].Slots;
            bag++;
        }

        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public int Slots => _items.Length;

    public int FreeSlots => _items.Count(string.IsNullOrEmpty);

    public IReadOnlyList<InventoryBag> Bags { get; }

    public IEnumerator<string> GetEnumerator()
    {
        for (var i = 0; i < Slots; i++)
            yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    public class InventoryBag : IEnumerable<string>
    {
        private InventoryView _inventory;
        private int _start;

        public InventoryBag(InventoryView inventory, int start, int slots)
        {
            _inventory = inventory;
            _start = start;
            Slots = slots;
        }

        public string this[int index]
        {
            get => index < Slots ? _inventory._items[_start + index] : throw new IndexOutOfRangeException();
            set
            {
                if (index >= Slots)
                    throw new IndexOutOfRangeException();
                _inventory._items[_start + index] = value; 
            }
        }

        public void AddFront(string itemName)
        {
            for (var i = 0; i < Slots; i++)
                if (string.IsNullOrEmpty(this[i]))
                {
                    this[i] = itemName;
                    return;
                }
            
            throw new InvalidOperationException();
        }

        public void AddBack(string itemName)
        {
            for (var i = Slots - 1; i >= 0; i--)
                if (string.IsNullOrEmpty(this[i]))
                {
                    this[i] = itemName;
                    return;
                }
            
            throw new InvalidOperationException();
        }

        public int Slots { get; set; }

        public int FreeSlots => this.Count(string.IsNullOrEmpty);

        public int UsedSlots => Slots - FreeSlots;

        public int FirstSlot => _start;

        public int LastSlot => _start + Slots;

        public IEnumerator<string> GetEnumerator()
        {
            for (var i = 0; i < Slots; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

public class AutoLoot
{
    public enum Setting
    {
        Sell,
        Destroy,
        Barter,
        Quest,
        Deposit,
        Keep,
        Ignore,
        None
    }

    private string _iniFilePath;

    public AutoLoot(string iniFilePath)
    {
        _iniFilePath = iniFilePath;
    }

    public Setting GetSetting(string itemName)
    {
        StringBuilder retVal = new StringBuilder(256);
        if (GetPrivateProfileString(itemName.Substring(0, 1), itemName, "", retVal, retVal.Capacity, _iniFilePath) <= 0)
            return Setting.None;
        
        switch (retVal.ToString().ToLower())
        {
            case "sell":
                return Setting.Sell;
            case "destroy":
                return Setting.Destroy;
            case "keep":
                return Setting.Keep;
            case "deposit":
                return Setting.Deposit;
            case "ignore":
                return Setting.Ignore;
            case string s when s.StartsWith("quest"):
                return Setting.Quest;
            case string s when s.StartsWith("barter"):
                return Setting.Barter;
            default:
                throw new NotSupportedException($"Unrecognized autoloot setting: {retVal}");
        }
    }

    [DllImport("kernel32.dll")]
    private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
}

// Get bag sizes and create an inventory view
var bags = Enumerable.Range(1, 10).Select(i => TLO.InvSlot[$"pack{i}"]).ToList();
var inventory = new InventoryView(bags.Select(b => (int)b.Item.Container).ToArray());

// Dump current inventory contents into a list. Not worried about stacking, assume everything's optimally stacked.
var allItems = bags.SelectMany(b => Enumerable.Range(1, (int)b.Item.Container).Select(i => b.Item.Item[i])).Where(item => item?.Name != null).ToList();
var itemsToPlace = new List<ItemType>(allItems);

// Place keep items at the end
foreach (var keepItem in keepItems)
{
    while (itemsToPlace.Any(i => i.Name == keepItem))
    {
        inventory.AddBack(keepItem);
        itemsToPlace.RemoveAt(itemsToPlace.FindIndex(i => i.Name == keepItem));
    }
}

// Get autoloot settings for the rest
var autoLoot = new AutoLoot(MQ2.INIPath + "/Macros/loot.ini");
var autoLootSettings = itemsToPlace.Select(item => item.Name).Distinct().ToDictionary(name => name, name => autoLoot.GetSetting(name));

// Returns all items that were placed
IEnumerable<string> PlaceInBags(InventoryView inventory, IReadOnlyCollection<string> itemNames, IEnumerable<int> bags)
{
    var numItemsToPlace = itemNames.Count();
    var bag = bags.GetEnumerator();
    bag.MoveNext();

    // Group by autoloot setting & sort
    var groups = itemNames.GroupBy(name => autoLootSettings[name]).OrderBy(group => group.Key);
    foreach (var group in groups.ToList())
    {
        foreach (var itemName in group.OrderBy(name => name))
        {
            // Place item in bag and move along to the next slot
            inventory.Bags[bag.Current].AddFront(itemName);
            numItemsToPlace--;
            yield return itemName;

            // If this bag is full, try to move along to the next one
            if (inventory.Bags[bag.Current].FreeSlots == 0)
                if (!bag.MoveNext())
                    yield break;
        }

        // If there's enough free slots to leave the rest of the bag empty, do so
        if (inventory.Bags[bag.Current].UsedSlots != 0)
        {
            var remainingFreeSlots = bags.SkipWhile(b => b <= bag.Current).Sum(b => inventory.Bags[b].FreeSlots);
            if (remainingFreeSlots >= numItemsToPlace)
                bag.MoveNext();
        }
    }
}

// Find where we have tradeskill bags
var tradeskillBags = Enumerable.Range(0, 10).Where(n => TLO.InvSlot[$"pack{n+1}"].Item?.Name == "Extraplanar Trade Satchel").ToList();

// Place tradeskill items first
if (tradeskillBags.Any())
{
    var itemsPlaced = PlaceInBags(inventory, itemsToPlace.Where(item => item.Tradeskills).Select(item => item.Name).ToArray(), tradeskillBags);
    foreach (var itemName in itemsPlaced)
        itemsToPlace.RemoveAt(itemsToPlace.FindIndex(i => i.Name == itemName));
}

// Then the rest
var itemsPlaced = PlaceInBags(inventory, itemsToPlace.Select(item => item.Name).ToArray(), Enumerable.Range(0, 10).Except(tradeskillBags));
foreach (var itemName in itemsPlaced)
    itemsToPlace.RemoveAt(itemsToPlace.FindIndex(i => i.Name == itemName));

if (itemsToPlace.Any())
    MQ2.WriteChat($"Something went wrong, couldn't place: {string.Join(", ", itemsToPlace)}");
else
{
    for (var i = 0; i < 10; i++)
        WriteDebug($"bag{i+1} = {string.Join(",", inventory.Bags[i])}");

    // Rearrange items to make things how we want. Loop through bag slots from end to start.
    for (var slot = inventory.Slots - 1; slot >= 0; slot--)
    {
        var (bag, bagSlot) = inventory.GetBagAndSlot(slot);

        // What's currently there?
        var currentItem = TLO.Me.Inventory[$"pack{bag+1}"].Item[bagSlot+1];
        if (currentItem != null)
        {
            if (currentItem.Name == inventory[slot])
            {
                WriteDebug($"{slot} = {currentItem.Name}, this is good");
                continue;
            }
            else
            {
                WriteDebug($"Auto inving {currentItem.Name}");
                // Auto inv whatever's already there
                MQ2.DoCommand($"/nomodkey /shiftkey /itemnotify in pack{bag + 1} {bagSlot + 1} leftmouseup");
                await Task.Yield();
                MQ2.DoCommand("/autoinventory");
                await Task.Yield();
            }
        }

        // What should be there?
        var item = allItems.FirstOrDefault(i => i.Name == inventory[slot]);

        // If it should be empty, make sure it actually is
        if (item == null)
        {
            currentItem = TLO.Me.Inventory[$"pack{bag+1}"].Item[bagSlot+1];
            if (currentItem != null)
            {
                MQ2.WriteChat($"{slot} = {currentItem?.Name} but should be {inventory[slot]}");
                MQ2.WriteChat("Something went wrong, aborting");
                return;
            }
            else
                continue;
        }

        // Find the first stack of the item that should be there
        var itemBag = TLO.FindItem["=" + item.Name].ItemSlot - 22;
        var itemBagSlot = TLO.FindItem["=" + item.Name].ItemSlot2 + 1;

        WriteDebug($"{item.Name} ({itemBag}, {itemBagSlot}) => pack{bag+1}, {bagSlot}");

        // Pick it up
        MQ2.DoCommand($"/nomodkey /shiftkey /itemnotify in pack{itemBag} {itemBagSlot} leftmouseup");
        await Task.Yield();

        // And move it to this slot
        MQ2.DoCommand($"/nomodkey /shiftkey /itemnotify in pack{bag + 1} {bagSlot + 1} leftmouseup");
        await Task.Yield();

        // Auto inv whatever was there (should be nothing, but just in case)
        MQ2.DoCommand("/autoinventory");
        await Task.Yield();
    }
}