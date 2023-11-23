using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WhisperPlugin
{
    public class WhisperPluginConfiguration : IRocketPluginConfiguration
    {
        public bool showPersonalMessages { get; set; }
        public bool DebugMode { get; set; }
        public void LoadDefaults()
        {
            showPersonalMessages = true;
            DebugMode = false;
        }
    }
}
