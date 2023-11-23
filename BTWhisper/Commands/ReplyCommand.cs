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
    internal class ReplyCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "Reply";

        public string Help => "A Example Command";

        public string Syntax => "Reply";

        public List<string> Aliases => new List<string>() { "r"};

        public List<string> Permissions => new List<string>() { "BTWhisper.Reply" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            var whisperList = WhisperPlugin.Instance.WhisperLast;
            if (command.Length < 1)
            {
                TranslationHelper.SendMessageTranslation(player.CSteamID, "ProperUsage", "/Reply <Message>");
                return;
            }
            var message = string.Join(" ", command);
            if (!whisperList.ContainsKey(player.CSteamID.m_SteamID))
            {
                // No active Messages
                TranslationHelper.SendMessageTranslation(player.CSteamID, "Reply_NoActiveMessages");
                return;
            }
            var target = UnturnedPlayer.FromCSteamID((Steamworks.CSteamID)whisperList[player.CSteamID.m_SteamID]);
            if(target == null)
            {
                // Player is no longer online
                TranslationHelper.SendMessageTranslation(player.CSteamID, "Reply_NoActiveMessages");
                whisperList.Remove(player.CSteamID.m_SteamID);
                return;
            }

            if (WhisperPlugin.Instance.Configuration.Instance.showPersonalMessages)
                TranslationHelper.SendMessageTranslation(player.CSteamID, "Message", player.CharacterName, message);
            TranslationHelper.SendMessageTranslation(target.CSteamID, "Message", player.CharacterName, message);
            //
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
