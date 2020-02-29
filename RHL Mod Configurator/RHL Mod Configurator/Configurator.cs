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
            GUIStorage.modConfigComment = "List Of Key Codes: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=netframework-4.8";
            GUIStorage.confStringBoxes.Add(API.ConfStringBox.init(Path.Combine( API.functions.getModFolder(),"Config.txt"),"KeyName", "Spawn Food Key"));
            GUIStorage.confIntBoxes.Add(API.ConfIntBox.init(Path.Combine(API.functions.getModFolder(), "Config.txt"), "ImageSize", "Food Image Size"));
            OpenFileDialog fileDialog=new OpenFileDialog();
            fileDialog.InitialDirectory = API.functions.getModFolder();
            fileDialog.Filter = "png files (*.png)|*.png";
            GUIStorage.confFileBoxes.Add(API.ConfFileBox.init("Food Image", fileDialog, (string dir) => { File.Copy(dir, Path.Combine(API.functions.getModFolder(), "crumbs.png"), true); }));
            OpenFileDialog fileDialog2 = new OpenFileDialog();
            fileDialog2.InitialDirectory = API.functions.getModFolder();
            fileDialog2.Filter = "wav files (*.wav)|*.wav";
            GUIStorage.confFileBoxes.Add(API.ConfFileBox.init("Eating Food Sound", fileDialog2, (string dir) => { File.Copy(dir, Path.Combine(API.functions.getModFolder(), "nom.wav"), true); }));
        }
    }
}
