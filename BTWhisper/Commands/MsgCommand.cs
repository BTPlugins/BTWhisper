using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhisperPlugin.Helpers.BaseHelpers;

namespace WhisperPlugin.Commands
{
    internal class MsgCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "msg";

        public string Help => "A Example Command";

        public string Syntax => "msg";

        public List<string> Aliases => new List<string>() { "m", "tell"};

        public List<string> Permissions => new List<string>() { "BTWhisper.Msg" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if(command.Length < 2)
            {
                TranslationHelper.SendMessageTranslation(player.CSteamID, "ProperUsage", "/Msg <Player> <Message>");
                return;
            }
            var target = UnturnedPlayer.FromName(command[0]);
            if(target == null)
            {
                TranslationHelper.SendMessageTranslation(player.CSteamID, "TargetNotFound");
                return;
            }
            var message = string.Join(" ", command.Skip(1));
            if (WhisperPlugin.Instance.Configuration.Instance.showPersonalMessages)
                TranslationHelper.SendMessageTranslation(player.CSteamID, "Message", player.CharacterName, message);
            TranslationHelper.SendMessageTranslation(target.CSteamID, "Message", player.CharacterName, message);
            //
            foreach(SteamPlayer play in Provider.clients)
            {
                var playr = UnturnedPlayer.FromSteamPlayer(play);
                if (WhisperPlugin.Instance.StaffLogEnabled.Contains(playr.CSteamID.m_SteamID))
                {
                    TranslationHelper.SendMessageTranslation(player.CSteamID, "Message", player.CharacterName, message);
                }
            }
            //
            var whisperList = WhisperPlugin.Instance.WhisperLast;
            if (whisperList.ContainsKey(player.CSteamID.m_SteamID))
                whisperList.Remove(player.CSteamID.m_SteamID);
            if (whisperList.ContainsKey(target.CSteamID.m_SteamID)) 
                whisperList.Remove(target.CSteamID.m_SteamID);
            //
            WhisperPlugin.Instance.WhisperLast.Add(player.CSteamID.m_SteamID, target.CSteamID.m_SteamID);
            WhisperPlugin.Instance.WhisperLast.Add(target.CSteamID.m_SteamID, player.CSteamID.m_SteamID);
        }
    }
}
