using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHL_Mod_Configurator_API
{
    public interface ConfiguratorBasic
    {
        void Initialize();
    }

    public class GUIStorage
    {
        static public string modConfigComment;
        static public List<ConfiguratorAPI.ConfStringBox> confStringBoxes;
        static public List<ConfiguratorAPI.ConfIntBox> confIntBoxes;
        static public List<ConfiguratorAPI.ConfFloatBox> confFloatBoxes;
        static public List<ConfiguratorAPI.ConfBoolBox> confBoolBoxes;
        static public List<ConfiguratorAPI.ConfFileBox> confFileBoxes;
        static public List<ConfiguratorAPI.ConfColorBox> confColorBoxes;
    }
    public static class ConfiguratorAPI
    {
        public class Functions
        {
            //returns path to folder with a goose executable
            public delegate string GetGooseFolderFunction();
            public GetGooseFolderFunction getGooseFolder;

            //returns path to folder with a mod
            public delegate string GetModFolderFunction();
            public GetModFolderFunction getModFolder;

        }
        public static Functions functions;

        //option - file with: OptionName=OptionState (just like in goose config.ini)

        
        public  class ConfStringBox
        {
            //makes textbox for specified option in file
            public delegate ConfStringBox Init(string fileWithConfig,string configOptionName, string showedName);
            public static Init init;

            //makes textbox for every option in file
            public delegate List<ConfStringBox> InitForAll(string fileWithConfig);
            public static Init initForAll;
        }

        //Makes TextBox number only
        public class ConfIntBox
        {
            //makes textbox for specified option in file
            public delegate ConfIntBox Init(string fileWithConfig, string configOptionName, string showedName);
            public static Init init;

            //makes textbox for every option in file
            public delegate List<ConfIntBox> InitForAll(string fileWithConfig);
            public static Init initForAll;
        }

        //Makes TextBox float numbers only
        public class ConfFloatBox
        {
            //makes textbox for specified option in file
            public delegate ConfFloatBox Init(string fileWithConfig, string configOptionName, string showedName);
            public static Init init;

            //makes textbox for every option in file
            public delegate List<ConfFloatBox> InitForAll(string fileWithConfig);
            public static Init initForAll;
        }

        //Makes RadioButton
        public class ConfBoolBox
        {
            //makes textbox for specified option in file
            public delegate ConfBoolBox Init(string fileWithConfig, string configOptionName, string showedName);
            public static Init init;

            //makes textbox for every option in file
            public delegate List<ConfBoolBox> InitForAll(string fileWithConfig);
            public static Init initForAll;
        }

        //Makes TextBox with changeFile button
        public class ConfFileBox
        {
            //makes textbox with option to browse files
            public delegate ConfFileBox Init(string showedName, OpenFileDialog FileDialog, Action<string>howToUsePath);
            public static Init init;
        }

        //Makes Button with Color in it
        public class ConfColorBox
        {
            //makes textbox for specified option in file
            public delegate ConfColorBox Init(string fileWithConfig, string configOptionName, string showedName);
            public static Init init;

            //makes textbox for every option in file
            public delegate List<ConfColorBox> InitForAll(string fileWithConfig);
            public static Init initForAll;
        }
    }

}
