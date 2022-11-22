using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Program;
using MQ2DotNet.Services;

namespace MQ2DotNet_Plugin
{
    public class MQ2DotNet_Plugin : IPlugin
    {
        private readonly MQ2 _mq2;
        private readonly Chat _chat;
        private readonly Commands _commands;
        private readonly Events _events;
        private readonly Spawns _spawns;
        private readonly TLO _tlo;

        public MQ2DotNet_Plugin(MQ2 mq2, Chat chat, Commands commands, Events events, Spawns spawns, TLO tlo)
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
            _mq2.WriteChat("\ag[MQ2DotNet_Plugin]\aw InitializePlugin()");

            _events.OnChatMQ2 += (s, e) =>
            {
                if (e == "[MQ2] Hello")
                    _mq2.WriteChat("Hello yourself");
            };

            _commands.AddCommand("/test", args => { _mq2.WriteChat("Hello there"); });
        }

        public void ShutdownPlugin()
        {
            _mq2.WriteChat("\ag[MQ2DotNet_Plugin]\aw ShutdownPlugin()");
        }

        public void OnPulse()
        {
        }
    }
}

