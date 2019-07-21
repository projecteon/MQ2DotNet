using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MQ2DotNet;
using MQ2DotNet.EQ;
using MQ2DotNet.MQ2API;
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
    public class Toolbox : Plugin
    {
        #region Plugin API
        public override void InitializePlugin()
        {
            LoadSettings();

            // Note the commands don't need to be removed, MQ2DotNet handles this when the plugin is unloaded
            Commands.AddCommand("/removespa", RemoveSPACommand);
            Commands.AddCommand("/blockspa", BlockSPACommand);
        }

        public override void OnPulse()
        {
            if (TLO.EverQuest.GameState != "INGAME")
                return;

            if (++_frame % 30 == 0)
            {
                _frame = 0;
                foreach (var spa in _blocked)
                    RemoveSPA(spa);
            }
        }

        public override void SetGameState(GameState gameState)
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
                MQ2.WriteChat("Usage: /blockspa <spa>");
                if (_blocked.Count > 0)
                    MQ2.WriteChat("Currently blocking: " + string.Join(", ", _blocked));
                else
                    MQ2.WriteChat("No SPAs are currently blocked");
                return;
            }

            if (_blocked.Contains(spa))
            {
                MQ2.WriteChat($"No longer blocking SPA {spa}");
                _blocked.Remove(spa);
            }
            else
            {
                MQ2.WriteChat($"Now blocking SPA {spa}");
                _blocked.Add(spa);
            }

            SaveSettings();
        }

        private void RemoveSPACommand(string[] args)
        {
            if (args.Length != 1 || !int.TryParse(args[0], out var spa))
            {
                MQ2.WriteChat("Usage: /removespa <spa>");
                return;
            }

            var removedCount = RemoveSPA(spa);

            MQ2.WriteChat(removedCount > 0
                ? $"Removed {removedCount} buffs with SPA {spa}"
                : $"No buffs found with SPA {spa}");
        }
        #endregion

        private string _settingsFilePath => MQ2.INIPath + "\\Toolbox.json";

        private int _frame = 0;
        private List<int> _blocked;

        private void LoadSettings()
        {
            if (TLO.EverQuest.GameState != "INGAME")
                return;

            try
            {
                var settings = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(
                        File.ReadAllText(_settingsFilePath));

                _blocked = settings[TLO.EverQuest.Server + "_" + TLO.Me.Name];

            }
            catch (Exception)
            {
                MQ2.WriteChat("Toolbox failed to load settings");
                _blocked = new List<int>();
            }
        }

        private void SaveSettings()
        {
            if (TLO.EverQuest.GameState != "INGAME")
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

                settings[TLO.EverQuest.Server + "_" + TLO.Me.Name] = _blocked;

                File.WriteAllText(_settingsFilePath, JsonConvert.SerializeObject(settings, Formatting.Indented));

                MQ2.WriteChat("Toolbox settings saved");

            }
            catch (Exception e)
            {
                MQ2.WriteChat("Toolbox failed to save settings");
            }
        }

        private static int RemoveSPA(int spa)
        {
            var buffs = Enumerable.Range(1, TLO.Me.MaxBuffSlots ?? 1)
                .Select(index => TLO.Me.Buff[index])
                .Where(buff => buff != null && buff.Spell.HasSPA[spa])
                .ToList();

            foreach (var buff in buffs)
            {
                MQ2.WriteChat($"Removing buff with SPA {spa}: {buff}");
                buff.Remove();
            }

            return buffs.Count;
        }
    }
}
