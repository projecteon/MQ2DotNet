using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Plugin;
using MQ2DotNet.Services;

namespace TestPlugin
{
    [PublicAPI]
    public class TestPlugin : IPlugin
    {
        private readonly MQ2 _mq2;
        private readonly Chat _chat;
        private readonly Commands _commands;
        private readonly Events _events;
        private readonly Spawns _spawns;
        private readonly TLO _tlo;

        public TestPlugin(MQ2 mq2, Chat chat, Commands commands, Events events, Spawns spawns, TLO tlo)
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
            _mq2.WriteChat("\ag[TestPlugin]\aw InitializePlugin()");

            _events.OnChatMQ2 += (s, e) =>
            {
                if (e == "[MQ2] Hello")
                    _mq2.WriteChat("Hello yourself");
            };

            _commands.AddCommand("/test", args => { _mq2.WriteChat("Hello there"); });
        }

        public void ShutdownPlugin()
        {
            _mq2.WriteChat("\ag[TestPlugin]\aw ShutdownPlugin()");
        }

        public void OnPulse()
        {
        }
    }
}
