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
            ConfiguratorAPI.GUI.addBoolBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "GooseSpeedTiers.txt"), "Walk", "Goose Slow Speed");
            ConfiguratorAPI.GUI.addBoolBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "GooseSpeedTiers.txt"), "Run", "Goose Normal Speed");
            ConfiguratorAPI.GUI.addBoolBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "GooseSpeedTiers.txt"), "Charge", "Goose Fast Speed");
            ConfiguratorAPI.GUI.addComment("Options below will show up after first time of using goose with this mod active!");
            ConfiguratorAPI.GUI.addBoolBoxForAll(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "GooseTasks.txt"));
        }
    }
}
