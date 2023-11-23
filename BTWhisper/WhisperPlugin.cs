using Rocket.API;
using Rocket.Core.Plugins;
using System;
using Logger = Rocket.Core.Logging.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace WhisperPlugin
{
    public partial class WhisperPlugin : RocketPlugin<WhisperPluginConfiguration>
    {
        public static WhisperPlugin Instance;
        public IDictionary<ulong, ulong> WhisperLast = new Dictionary<ulong, ulong>();
        public HashSet<ulong> StaffLogEnabled = new HashSet<ulong>();
        protected override void Load()
        {
            Instance = this;
            Logger.Log("#############################################", ConsoleColor.Yellow);
            Logger.Log("###            BTWhisper Loaded           ###", ConsoleColor.Yellow);
            Logger.Log("###   Plugin Created By blazethrower320   ###", ConsoleColor.Yellow);
            Logger.Log("###            Join my Discord:           ###", ConsoleColor.Yellow);
            Logger.Log("###     https://discord.gg/YsaXwBSTSm     ###", ConsoleColor.Yellow);
            Logger.Log("#############################################", ConsoleColor.Yellow);
            U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
        }

        private void OnPlayerDisconnected(UnturnedPlayer player)
        {
            if (WhisperLast.ContainsKey(player.CSteamID.m_SteamID))
                WhisperLast.Remove(player.CSteamID.m_SteamID);
            if (StaffLogEnabled.Contains(player.CSteamID.m_SteamID))
                StaffLogEnabled.Remove(player.CSteamID.m_SteamID);
        }

        protected override void Unload()
        {
            Instance = null;
            WhisperLast = null;
            StaffLogEnabled = null;
            Logger.Log("BTWhisper Unloaded");
            base.Unload();
        }
    }
}
