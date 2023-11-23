using Rocket.API.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhisperPlugin
{
    public partial class WhisperPlugin
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
            {
                "ProperUsage", "[color=#FF0000]{{Whisper}} [/color] [color=#F3F3F3]Proper Usage |[/color] [color=#3E65FF]{0}[/color]"
            },
            {
                "TargetNotFound", "[color=#FF0000]{{Whisper}} [/color][color=#F3F3F3]Target Not Found![/color]"
            },
            {
                "Message", "[i][color=#FF0000]{{Whisper}} [/color] [color=#F3F3F3]From: [/color][color=#3E65FF]{0}[/color] [color=#F3F3F3]| {1}[/color][/i]"
            },
            {
                "Reply_NoActiveMessages", "[color=#FF0000]{{Whisper}} [/color][color=#F3F3F3]No active messages to reply back to![/color]"
            },
            {
                "ToggleMessage", "[color=#F3F3F3]You have Turned[/color] [color=#3E65FF]{0}[/color] [color=#F3F3F3]Toggle Messages[/color]"
            }
        };
    }
}