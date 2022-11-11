using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Program;
using MQ2DotNet.Services;

namespace Program
{
    [PublicAPI]
    public class Program : IProgram
    {
        private readonly MQ2 _mq2;
        private readonly Chat _chat;
        private readonly Commands _commands;
        private readonly Events _events;
        private readonly Spawns _spawns;
        private readonly TLO _tlo;

        public Program(MQ2 mq2, Chat chat, Commands commands, Events events, Spawns spawns, TLO tlo)
        {
            _mq2 = mq2;
            _chat = chat;
            _commands = commands;
            _events = events;
            _spawns = spawns;
            _tlo = tlo;
        }

        public async Task Main(CancellationToken token, string[] args)
        {
        }
    }
}
