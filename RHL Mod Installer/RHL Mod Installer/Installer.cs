using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RHL_Mod_Installer_API;

namespace RHL_Mod_Installer
{
    public class Installer : InstallerBasic 
    {
        void InstallerBasic.Install() {
            InstallerAPI.functions.unpackZip(new List<string>() {InstallerAPI.functions.getModFolder() });
        }
    }
}
