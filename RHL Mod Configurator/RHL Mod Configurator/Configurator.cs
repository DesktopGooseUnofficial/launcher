using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RHL_Mod_Configurator_API;
using System.IO;
using System.Windows.Forms;

namespace RHL_Mod_Configurator
{
    public class Configurator : ConfiguratorBasic
    {
        void ConfiguratorBasic.Initialize() {

            ConfiguratorAPI.GUI.addComment("Change hat mode to " + '"' + "Custom" + '"' + " for using custom hat");
            ConfiguratorAPI.GUI.addBoolBox(Path.Combine(ConfiguratorAPI.functions.getGooseFolder(), "config.toml"), "HatMode", "Hat Mode");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getGooseFolder(), "config.toml"), "CustomHatPath", "Custom Hat");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getGooseFolder(), "config.toml"), "HorizontalSize", "Horizontal Size");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getGooseFolder(), "config.toml"), "HatPosition", "Hat Position");
            
        }
    }
}
