using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQ2DotNet;
using MQ2DotNet.MQ2API;
using MQ2DotNet.MQ2API.DataTypes;

namespace AddDataType
{
    public class AddDataType : Plugin
    {
        public override void InitializePlugin()
        {
            // To use a type, it needs to be registered
            // This takes the name of the type (as per constructor to the MQ2Type C++ class)
            // And a function to create the type, given an MQ2TypeVar
            MQ2TypeFactory.Register("bazaar", typeVar => new BazaarType(typeVar));
            MQ2TypeFactory.Register("bazaaritem", typeVar => new BazaarItemType(typeVar));

            // Registering the type like this only affects this AppDomain (each plugin/program is loaded to its own AppDomain)
            // So there is no need to unregister it - the whole AppDomain is unloaded when the plugin is unloaded, and nothing unmanaged is modified

            Commands.AddAsyncCommand("/datatypetest", DataTypeTest);

            // Commands do need unregistering because they do stuff in the unmanaged world and MQ2 doesn't keep track of what plugin owns them
            // But MQ2DotNet is nice enough to clean up after you if you forget
        }

        private async Task DataTypeTest(string[] args)
        {
            // Open bazaar window and wait one frame
            TLO.Window["BazaarSearchWnd"].DoOpen();
            await Task.Yield();

            // To get a top level object:
            var bazaarTLO = TLO.GetTLO<BazaarType>("Bazaar");

            // Search and wait for it to finish
            MQ2.DoCommand("/bzsrch silk");
            while (!bazaarTLO.Done)
                await Task.Yield();

            await Task.Delay(1000);
            
            var firstItem = bazaarTLO.Item[1]; // This one uses 1 based indexing

            if (Debugger.IsAttached)
                Debugger.Break();

            // Now you can look at stuff. If nothing was found, firstItem will be null
        }
    }

    public class BazaarType : MQ2DataType
    {
        // Constructor typically needs to call the base with the typeVar, and create any IndexedMember helpers
        public BazaarType(MQ2TypeVar typeVar) : base(typeVar)
        {
            Item = new IndexedMember<BazaarItemType, int>(this, "Item");
        }
        
        // For each member the type has, create a property that calls GetMember
        public IntType Count => GetMember<IntType>("Count");
        public BoolType Done => GetMember<BoolType>("Done");
        public BoolType Pricecheckdone => GetMember<BoolType>("Pricecheckdone");
        public IntType Pricecheck => GetMember<IntType>("Pricecheck");

        // For members that take an index, you can use the helper class IndexedMember
        // e.g. this one takes an int as the index, and returns a BazaarItemType
        public IndexedMember<BazaarItemType, int> Item { get; }
    }

    public class BazaarItemType : MQ2DataType
    {
        public BazaarItemType(MQ2TypeVar typeVar) : base(typeVar)
        {
        }

        public IntType Price => GetMember<IntType>("Price");
        public IntType Quantity => GetMember<IntType>("Quantity");
        public IntType ItemID => GetMember<IntType>("ItemID");
        public SpawnType Trader => GetMember<SpawnType>("Trader");
        public StringType Name => GetMember<StringType>("Name");
    }
}
