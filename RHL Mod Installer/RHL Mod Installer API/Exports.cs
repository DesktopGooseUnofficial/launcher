using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHL_Mod_Installer_API
{

    public interface InstallerBasic
    {
        void Install();
    }
    public static class InstallerAPI
    {
        public class Functions
        {
            //returns path to folder with a goose executable
            public delegate string GetGooseFolderFunction();
            public GetGooseFolderFunction getGooseFolder;

            //returns path to folder with a mod
            public delegate string GetModFolderFunction();
            public GetModFolderFunction getModFolder;


            //add location (there this file will be placed) for every file in your zip with your mod!
            //every item in locationsForFiles is needed to end with a name (and extension) of a file from .zip of your mod
            public delegate void UnpackZipFunction(List<string> locationsForFiles);
            public UnpackZipFunction unpackZip;

        }
        public static Functions functions;


    }
}
