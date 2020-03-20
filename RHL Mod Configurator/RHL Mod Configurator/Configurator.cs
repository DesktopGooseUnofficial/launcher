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

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = ConfiguratorAPI.functions.getModFolder();
            fileDialog.Filter = "png files (*.png)|*.png";

            ConfiguratorAPI.GUI.addComment("Options Below will show up after first time of using goose with this mod active");
            ConfiguratorAPI.GUI.addComment("Change hat mode to "+'"'+"Custom" + '"' + " for using custom hat");
            ConfiguratorAPI.GUI.addStringBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "HatMode ", "Hat Mode");
            ConfiguratorAPI.GUI.addFileBox2(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "CustomHatPath ", "Custom Hat", fileDialog);
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "HorizontalSize ", "Horizontal Size");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "HatPosition ", "Hat Position");
            
        }
    }
}
