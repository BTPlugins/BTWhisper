using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhisperPlugin.Helpers.BaseHelpers;

namespace WhisperPlugin.Commands
{
    internal class ToggleMessages : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "ToggleMessages";

        public string Help => "A Example Command";

        public string Syntax => "ToggleMessages";

        public List<string> Aliases => new List<string>() { "ToggleMessage", "LogMessages"};

        public List<string> Permissions => new List<string>() { "BTWhisper.ToggleMessages" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (WhisperPlugin.Instance.StaffLogEnabled.Contains(player.CSteamID.m_SteamID))
            {
                // Turn it off
                TranslationHelper.SendMessageTranslation(player.CSteamID, "ToggleMessage", "Off");
                WhisperPlugin.Instance.StaffLogEnabled.Remove(player.CSteamID.m_SteamID);
                return;
            }
            // Turn it on
            TranslationHelper.SendMessageTranslation(player.CSteamID, "ToggleMessage", "On");
            WhisperPlugin.Instance.StaffLogEnabled.Add(player.CSteamID.m_SteamID);
        }
    }
}
