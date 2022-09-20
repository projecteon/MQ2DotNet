using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MQ2DotNet;
using MQ2DotNet.EQ;
using MQ2DotNet.MQ2API;
using MQ2DotNet.Plugin;
using MQ2DotNet.Services;
using Newtonsoft.Json;

namespace Toolbox
{
    /// <summary>
    /// Example plugin that adds two commands:
    /// 
    ///     /removespa [spa]
    /// Removes any spells that have an effect with the specified SPA
    /// 
    ///     /blockspa [spa]
    /// "Blocks" any spell that has an effect with the specified SPA
    /// This is done by removing the spells rather than with the blocked spells window
    /// </summary>
    public class Toolbox : IPlugin
    {
        private readonly MQ2 _mq2;
        private readonly Chat _chat;
        private readonly Commands _commands;
        private readonly Events _events;
        private readonly Spawns _spawns;
        private readonly TLO _tlo;

        public Toolbox(MQ2 mq2, Chat chat, Commands commands, Events events, Spawns spawns, TLO tlo)
        {
            _mq2 = mq2;
            _chat = chat;
            _commands = commands;
            _events = events;
            _spawns = spawns;
            _tlo = tlo;
        }

        #region Plugin API
        public void InitializePlugin()
        {
            LoadSettings();

            // Note the commands don't need to be removed, MQ2DotNet handles this when the plugin is unloaded
            _commands.AddCommand("/removespa", RemoveSPACommand);
            _commands.AddCommand("/blockspa", BlockSPACommand);
        }

        public void OnPulse()
        {
            if (_tlo.EverQuest.GameState != "INGAME")
                return;

            if (++_frame % 30 == 0)
            {
                _frame = 0;
                foreach (var spa in _blocked)
                    RemoveSPA(spa);
            }
        }

        public void ShutdownPlugin()
        {
        }

        public void SetGameState(GameState gameState)
        {
            if (gameState == GameState.InGame)
                LoadSettings();

        }
        #endregion

        #region Commands
        private void BlockSPACommand(string[] args)
        {
            if (args.Length != 1 || !int.TryParse(args[0], out var spa))
            {
                _mq2.WriteChat("Usage: /blockspa <spa>");
                if (_blocked.Count > 0)
                    _mq2.WriteChat("Currently blocking: " + string.Join(", ", _blocked));
                else
                    _mq2.WriteChat("No SPAs are currently blocked");
                return;
            }

            if (_blocked.Contains(spa))
            {
                _mq2.WriteChat($"No longer blocking SPA {spa}");
                _blocked.Remove(spa);
            }
            else
            {
                _mq2.WriteChat($"Now blocking SPA {spa}");
                _blocked.Add(spa);
            }

            SaveSettings();
        }

        private void RemoveSPACommand(string[] args)
        {
            if (args.Length != 1 || !int.TryParse(args[0], out var spa))
            {
                _mq2.WriteChat("Usage: /removespa <spa>");
                return;
            }

            var removedCount = RemoveSPA(spa);

            _mq2.WriteChat(removedCount > 0
                ? $"Removed {removedCount} buffs with SPA {spa}"
                : $"No buffs found with SPA {spa}");
        }
        #endregion

        private string _settingsFilePath => _mq2.ConfigPath + "\\Toolbox.json";

        private int _frame = 0;
        private List<int> _blocked;

        private void LoadSettings()
        {
            if (_tlo.EverQuest.GameState != "INGAME")
                return;

            try
            {
                var settings = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(
                        File.ReadAllText(_settingsFilePath));

                _blocked = settings[_tlo.EverQuest.Server + "_" + _tlo.Me.Name];

            }
            catch (Exception)
            {
                _mq2.WriteChat("Toolbox failed to load settings");
                _blocked = new List<int>();
            }
        }

        private void SaveSettings()
        {
            if (_tlo.EverQuest.GameState != "INGAME")
                return;

            try
            {
                Dictionary<string, List<int>> settings;
                try
                {
                    settings = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(File.ReadAllText(_settingsFilePath));
                }
                catch (Exception)
                {
                    settings = new Dictionary<string, List<int>>();
                }

                settings[_tlo.EverQuest.Server + "_" + _tlo.Me.Name] = _blocked;

                File.WriteAllText(_settingsFilePath, JsonConvert.SerializeObject(settings, Formatting.Indented));

                _mq2.WriteChat("Toolbox settings saved");

            }
            catch (Exception e)
            {
                _mq2.WriteChat("Toolbox failed to save settings");
            }
        }

        private int RemoveSPA(int spa)
        {
            var buffs = Enumerable.Range(1, _tlo.Me.MaxBuffSlots ?? 1)
                .Select(index => _tlo.Me.Buff[index])
                .Where(buff => buff != null && buff.Spell.HasSPA[spa])
                .ToList();

            foreach (var buff in buffs)
            {
                _mq2.WriteChat($"Removing buff with SPA {spa}: {buff}");
                buff.Remove();
            }

            return buffs.Count;
        }
    }
}
