using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQ2DotNet;
using MQ2DotNet.MQ2API;
using MQ2DotNet.MQ2API.DataTypes;
using MQ2DotNet.Plugin;
using MQ2DotNet.Services;

namespace AddDataType
{
    public class AddDataType : IPlugin
    {
        private readonly MQ2 _mq2;
        private readonly Chat _chat;
        private readonly Commands _commands;
        private readonly Events _events;
        private readonly Spawns _spawns;
        private readonly TLO _tlo;

        public AddDataType(MQ2 mq2, Chat chat, Commands commands, Events events, Spawns spawns, TLO tlo)
        {
            _mq2 = mq2;
            _chat = chat;
            _commands = commands;
            _events = events;
            _spawns = spawns;
            _tlo = tlo;
        }

        public void InitializePlugin()
        {
            _commands.AddAsyncCommand("/datatypetest", DataTypeTest);

            // Commands do need unregistering because they do stuff in the unmanaged world and MQ2 doesn't keep track of what plugin owns them
            // But MQ2DotNet is nice enough to clean up after you if you forget
        }

        public void OnPulse()
        {
        }

        public void ShutdownPlugin()
        {
        }

        private async Task DataTypeTest(string[] args)
        {
            // Open bazaar window and wait one frame
            _tlo.Window["BazaarSearchWnd"].DoOpen();
            await Task.Yield();

            // To get a top level object:
            var bazaarTLO = _tlo.GetTLO<BazaarType>("Bazaar");

            // Search and wait for it to finish
            _mq2.DoCommand("/bzsrch silk");
            while (!bazaarTLO.Done)
                await Task.Yield();

            await Task.Delay(1000);
            
            var firstItem = bazaarTLO.Item[1]; // This one uses 1 based indexing

            if (Debugger.IsAttached)
                Debugger.Break();

            // Now you can look at stuff. If nothing was found, firstItem will be null
        }
    }

    // Adding the MQ2Type attribute to a class that derives from MQ2DataType registers it for use with the type by the supplied name
    [MQ2Type("bazaar")]
    public class BazaarType : MQ2DataType
    {
        // Constructor typically needs to call the base with the typeVar, and create any IndexedMember helpers
        public BazaarType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
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

    [MQ2Type("bazaaritem")]
    public class BazaarItemType : MQ2DataType
    {
        public BazaarItemType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        public IntType Price => GetMember<IntType>("Price");
        public IntType Quantity => GetMember<IntType>("Quantity");
        public IntType ItemID => GetMember<IntType>("ItemID");
        public SpawnType Trader => GetMember<SpawnType>("Trader");
        public StringType Name => GetMember<StringType>("Name");
    }
}
