using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;


namespace RHL_Mod_Installer_API
{

    public interface InstallerBasic
    {
        void Install();
    }
    public static class API
    {
        public class Functions {

            public static string modFolder;
            public static string gooseFolder;
            public static string modZipFilePath;
            public static string launcherModPath;

            //returns path to folder with a goose executable
            public string GetGooseFolderFunction() {
                return gooseFolder;
            }


            //returns path to folder with a mod
            public  string GetModFolderFunction() {
                return modFolder;
            }



            //add location (there this file will be placed) for every file in your zip with your mod!
            //every item in locationsForFiles is needed to end with a name (and extension) of a file from .zip of your mod
            public  void UnpackZipFunction(List<string> locationsForFiles){
                ZipFile.ExtractToDirectory(modZipFilePath, Path.Combine(launcherModPath, "Zip"));
                foreach(string path in locationsForFiles) {
                    bool file = File.Exists(Path.Combine(launcherModPath, "Zip", Path.GetFileName(path)));
                    
                    if(file) {
                        if (File.Exists(path)) {
                            File.Delete(path);
                        }
                        File.Move(Path.Combine(launcherModPath, "Zip", Path.GetFileName(path)), path);
                    } else {
                        if(Directory.Exists(path)) {
                            Directory.Delete(path, true);
                        }
                        Directory.Move(Path.Combine(launcherModPath, "Zip", Path.GetDirectoryName(path)), path);
                    }
                   
                }
                
            }
        }
        public static Functions functions;


    }
}
