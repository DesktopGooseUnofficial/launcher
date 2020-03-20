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

            ConfiguratorAPI.GUI.addBoolBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "RandomizeStartColor ", "Randomize Start Color");
            ConfiguratorAPI.GUI.addBoolBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "SeparateOrangesFromWhites ", "Separate Oranges From Whites");
            ConfiguratorAPI.GUI.addIntBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "MaxLoops ", "Max Loops");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "ColorSpeed ", "Color Speed");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "FrequencyR ", "Frequency Red");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "FrequencyG ", "Frequency Green");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "FrequencyB ", "Frequency Blue");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "PhaseR ", "Phase Red");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "PhaseG ", "Phase Green");
            ConfiguratorAPI.GUI.addFloatBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "PhaseB ", "Phase Blue");
            ConfiguratorAPI.GUI.addComment("Changing these two can cause the goose to crash. If it happens, lower the values");
            ConfiguratorAPI.GUI.addIntBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "Center ", "Center");
            ConfiguratorAPI.GUI.addIntBox(Path.Combine(ConfiguratorAPI.functions.getModFolder(), "config.toml"), "Width ", "Width");
        }
    }
}
