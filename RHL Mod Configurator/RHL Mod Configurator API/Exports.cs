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


    public static class ConfiguratorAPI
    {
        public class Functions
        {
            //returns path to folder with a goose executable
            public delegate string GetGooseFolderFunction();
            public GetGooseFolderFunction getGooseFolder;

            //returns path to folder with a mod (GooseFolder\Assets\Mods\%ModName%)
            public delegate string GetModFolderFunction();
            public GetModFolderFunction getModFolder;

        }
        public static Functions functions;

        public class GUIFunctions
        {
            //Makes comment at the top of configurator window
            public delegate void AddCommentFunction(string comment);
            public AddCommentFunction addComment;


            //option - in file: OptionName=OptionState (just like in goose config.ini)


            //makes textbox for specified option in file
            public delegate void AddStringBoxFunction(string fileWithConfigPath, string configOptionName, string showedName);
            public  AddStringBoxFunction addStringBox;

            //makes textbox for every option in file
            public delegate void AddStringBoxForAllFunction(string fileWithConfigPath);
            public AddStringBoxForAllFunction addStringBoxForAll;


            //Makes TextBox number only
            //makes textbox for specified option in file
            public delegate void AddIntBoxFunction(string fileWithConfigPath, string configOptionName, string showedName);
            public AddIntBoxFunction addIntBox;

            //Makes TextBoxes number only
            //makes textbox for every option in file
            public delegate void AddIntBoxForAllFunction(string fileWithConfigPath);
            public AddIntBoxForAllFunction addIntBoxForAll;


            //Makes TextBox float (and normal) numbers only
            //makes textbox for specified option in file
            public delegate void AddFloatBoxFunction(string fileWithConfigPath, string configOptionName, string showedName);
            public AddFloatBoxFunction addFloatBox;

            //Makes TextBoxes float (and normal) numbers only
            //makes textbox for every option in file
            public delegate void AddFloatBoxForAllFunction(string fileWithConfigPath);
            public AddFloatBoxForAllFunction addFloatBoxForAll;


            //Makes CheckBox
            //makes textbox for specified option in file
            public delegate void AddBoolBoxFunction(string fileWithConfigPath, string configOptionName, string showedName);
            public AddBoolBoxFunction addBoolBox;

            //Makes RadioButton
            //makes textbox for every option in file
            public delegate void AddBoolBoxForAllFunction(string fileWithConfigPath);
            public AddBoolBoxForAllFunction addBoolBoxForAll;


            //makes textbox with option to browse files and changeFile button
            public delegate void AddFileBoxFunction(string showedName, OpenFileDialog FileDialog, Action<string> howToUsePath,string toFilePath);
            public AddFileBoxFunction addFileBox;

            //makes textbox with option to browse files and changeFile button
            public delegate void AddFileBox2Function(string fileWithConfigPath, string configOptionName, string showedName, OpenFileDialog FileDialog);
            public AddFileBox2Function addFileBox2;


            //Makes Button with Color in it
            //makes textbox for specified option in file
            public delegate void AddColorBoxFunction(string fileWithConfigPath, string configOptionName, string showedName);
            public AddColorBoxFunction addColorBox;

            //Makes Button with Color in it
            //makes textbox for every option in file
            public delegate void AddColorBoxForAllFunction(string fileWithConfigPath);
            public AddColorBoxForAllFunction addColorBoxForAll;


            //Makes button that after click redirects user to website
            public delegate void AddLinkButtonFunction(string buttonText, string buttonLink);
            public AddLinkButtonFunction addLinkButton;
        }
        public static GUIFunctions GUI;
    }

}
