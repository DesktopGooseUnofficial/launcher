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

            OpenFileDialog fileDialog2 = new OpenFileDialog();
            fileDialog2.InitialDirectory = ConfiguratorAPI.functions.getModFolder();
            fileDialog2.Filter = "wav files (*.wav)|*.wav";

            ConfiguratorAPI.GUI.addLinkButton("Key Codes for Spawn Food Option", "https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=netframework-4.8");
            ConfiguratorAPI.GUI.addStringBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "Config.txt"), "KeyName", "Spawn Food Key");
            ConfiguratorAPI.GUI.addIntBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "Config.txt"), "ImageSize", "Food Image Size");
            ConfiguratorAPI.GUI.addFileBox("Food Image", fileDialog, (string dir) => { File.Copy(dir, Path.Combine(ConfiguratorAPI.functions.getModFolder(), "crumbs.png"), true); }, Path.Combine(ConfiguratorAPI.functions.getModFolder(), "crumbs.png"));
            ConfiguratorAPI.GUI.addFileBox("Eating Food Sound", fileDialog2, (string dir) => { File.Copy(dir, Path.Combine(ConfiguratorAPI.functions.getModFolder(), "nom.wav"), true); }, Path.Combine(ConfiguratorAPI.functions.getModFolder(), "crumbs.png"));
        }
    }
}
