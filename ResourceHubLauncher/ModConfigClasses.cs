using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace ResourceHubLauncher
{
    class ConfigFile
    {
        public ConfigFile(string fileLocation) {
            options = new List<KeyValuePair<string, string>>();
            fileLocationPath = fileLocation;
            if(File.Exists(fileLocationPath)) {
                StreamReader file = new StreamReader(fileLocationPath);
                string[] lines = file.ReadToEnd().Split('\n');
                file.Close();
                foreach (string line in lines) {
                    int equal = line.IndexOf('=');
                    if (equal != -1) {
                        string key = line.Substring(0, equal);
                        string value = line.Substring(equal + 1);
                        value= value.Replace("\r", "");
                        options.Add(new KeyValuePair<string, string>(key, value));
                    }

                }
            }
            
        }

        public void Reload() {
            options.Clear();
            if (File.Exists(fileLocationPath)) {
                StreamReader file = new StreamReader(fileLocationPath);
                string[] lines = file.ReadToEnd().Split('\n');
                file.Close();
                foreach (string line in lines) {
                    int equal = line.IndexOf('=');
                    if (equal != -1) {
                        string key = line.Substring(0, equal);
                        string value = line.Substring(equal + 1);
                        value=value.Replace("\r", "");
                        options.Add(new KeyValuePair<string, string>(key, value));
                    }

                }
            }
        }
        public string getOption(string optionName) {
            int index = options.FindIndex((p) => { return p.Key == optionName; });
            if(index!=-1) {
                return options.Find((p) => { return p.Key == optionName; }).Value;
            } else {
                return "";
            }
        }

        public void ChangeOption(string optionName,string toWhat) {
            int index= options.FindIndex((p) => { return p.Key == optionName; });
            if(index!=-1) {
                KeyValuePair<string, string> optionPair = options[index];
                options.Remove(optionPair);
            }
            
            
            options.Add(new KeyValuePair<string, string>(optionName, toWhat));

        }

        public void SaveChanges() {
            if(File.Exists(fileLocationPath)) {
                FileStream stream = new FileStream(fileLocationPath, FileMode.Truncate);
                stream.Close();
            }
            
            StreamWriter file = new StreamWriter(fileLocationPath);
            string toWrite = "";
            foreach(KeyValuePair<string, string> pair in options) {
                if(pair.Value.EndsWith("\r")) {
                    toWrite += pair.Key + '=' + pair.Value + "\n";
                } else {
                    toWrite += pair.Key + '=' + pair.Value + "\r\n";
                }
            }
            file.Write(toWrite);
            file.Close();
        }

        public void ApplyFrom(string what) {
            options = new List<KeyValuePair<string, string>>();
            if(File.Exists(what)) {
                StreamReader file = new StreamReader(what);
                string[] lines = file.ReadToEnd().Split('\n');
                file.Close();
                foreach (string line in lines) {
                    int equal = line.IndexOf('=');
                    if (equal != -1) {
                        string key = line.Substring(0, equal);
                        string value = line.Substring(equal + 1);
                        if (options.FindIndex((p) => { return p.Key == key; }) == -1) {
                            options.Add(new KeyValuePair<string, string>(key, value));
                        }

                    }

                }
            }
            
        }

        public string fileLocationPath;
        public List<KeyValuePair<string, string>> options;
    }
    class ModConfigClasses
    {
        
        public interface ModConfigBox
        {
            void Apply(List<KeyValuePair<string, ConfigFile>> configFiles);
            Point GetNextBoxLocation();
            void SetLocation(Point newLocation);
            void ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles);

            void addControlsToControl(Control c);

        }

        /*
         *             private void MouseDown_(object sender, MouseEventArgs e) {
                ContextMenuStrip.Items.Find("DiscardChangesToolStripMenuItem",false)[0].Click += DiscardChanges;
                ContextMenuStrip.Items.Find("SetToDefaultToolStripMenuItem", false)[0].Click += ToDefault;
                MouseDown -= MouseDown_;
                ContextMenuStrip.Closed += ContextMenu_Closed;
            }

            private void ContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
                ContextMenuStrip.Items.Find("DiscardChangesToolStripMenuItem", false)[0].Click -= DiscardChanges;
                ContextMenuStrip.Items.Find("SetToDefaultToolStripMenuItem", false)[0].Click -= ToDefault;
                MouseDown += MouseDown_;
                ContextMenuStrip.Closed -= ContextMenu_Closed;
            }

            private void ToDefault(object sender, EventArgs e) {
                ((ModConfigBox)this).ApplyValue(ModConfigForm.actualModConfig.defaultConfigFiles);
            }

            private void DiscardChanges(object sender, EventArgs e) {
                ((ModConfigBox)this).ApplyValue(ModConfigForm.actualModConfig.configFiles);
            }
        */


        public class StringBox : MetroTextBox, ModConfigBox
        {
            public StringBox(string fileWithConfig, string configOptionName, string showedName) {
                BoxName.Text = showedName + ':';
                BoxName.AutoSize = true;
                Size = new Size(388, 23);
                configOption = configOptionName;
                configFilePath = fileWithConfig;
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                Text = configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption);
                for (int i = 0; i < Text.Length; i++) {
                    if (Text[i] == '\n' || Text[i] == '\r') {
                        Text = Text.Remove(i, 1);
                    }
                }
            }

            void ModConfigBox.addControlsToControl(Control c) {
                c.Controls.Add(BoxName);
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                BoxName.Location = newLocation;
                Location = new Point(newLocation.X, newLocation.Y + BoxName.Size.Height + 3);
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }
            
            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                for(int i=0;i< Text.Length;i++) {
                    if(Text[i]=='\n'|| Text[i] == '\r') {
                        Text= Text.Remove(i, 1);
                    }
                }
                configFiles.Find((p) => { return p.Key == configFilePath; }).Value.ChangeOption(configOption, Text);
            }

            protected MetroLabel BoxName = new MetroLabel();
            protected string configFilePath;
            protected string configOption;
        }

        public class Comment : MetroLabel, ModConfigBox {
            public Comment(string comment) {
                
                MaximumSize = new Size(388, 9999999);
                Graphics g = CreateGraphics();
                Font f = new Font("Segoe UI", 9f);
                string measured = "";
                string measuredBefore = "";
                string readyT = "";
                AutoSize = true;
                foreach (string word in comment.Split(' ')) {
                    if (measured != "") {
                        measured += ' ' + word;
                    } else {
                        measured += word;
                    }

                    if (g.MeasureString(measured, f).Width > 388) {
                        if (readyT == "") {
                            readyT += measuredBefore;
                        } else {
                            readyT += "\r\n" + measuredBefore;
                        }

                        measured = word;
                    }

                    measuredBefore = measured;
                }
                if (measured != "") {
                    if (readyT == "") {
                        readyT += measured;
                    } else {
                        readyT += "\r\n" + measured;
                    }
                }
                Text = readyT;








            }

            void ModConfigBox.addControlsToControl(Control c) {
                
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                Location = newLocation;
            }
            
            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {

            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {

            }
        }

        public class IntBox : StringBox
        {
            public IntBox(string fileWithConfig, string configOptionName, string showedName) : base(fileWithConfig, configOptionName, showedName) {
                MaxLength = 10;
                KeyPress += IntBox_KeyPress;
                ShortcutsEnabled = false;
            }

            private void IntBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {

                if ((sender as MetroTextBox).Text == "0" && char.IsDigit(e.KeyChar)) {
                    if ((sender as MetroTextBox).SelectionLength != 1) {
                        e.Handled = true;
                    }

                }
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }

            }

        }

        public class FloatBox : StringBox
        {
            public FloatBox(string fileWithConfig, string configOptionName, string showedName) : base(fileWithConfig, configOptionName, showedName) {
                MaxLength = 20;
                KeyPress += FloatBox_KeyPress;
                ShortcutsEnabled = false;
            }

            /*private bool isNumber(string s,bool point,bool pointAndZeroOnStart) {
            uint pointN = 0;
            foreach(char c in s) {
                if(c=='.') {
                    pointN++;
                }
               if(!( char.IsDigit(c) || c=='.')) {
                    return false;
               }
            }
            if(!point&& pointN>0) {
                return false;
            }
            if(pointN > 1) {
                return false;
            }
            if(!pointAndZeroOnStart) {
                if(s.StartsWith(".")|| ((s.StartsWith("0")&& !(s.StartsWith("0.") && point)))) {
                    return false;
                }
            }
            return true;
        }*/

            private void FloatBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {

                //Ctrl+V cover
                /*if ( e.KeyChar == (char)22) {

                    bool selectedMiddle = (sender as MetroTextBox).SelectionStart > 0;
                    if (!isNumber(Clipboard.GetText(),true, selectedMiddle)) {
                        e.Handled = true;
                    }
                    bool selectedPoint = (sender as MetroTextBox).SelectedText.IndexOf('.') > -1;
                    bool pointInText= (sender as MetroTextBox).Text.IndexOf('.') > -1;
                    bool pointInClipboard= Clipboard.GetText().IndexOf('.') > -1;

                    if(pointInText&& pointInClipboard) {
                        if(!selectedPoint) {
                            e.Handled = true;
                        }
                    }

                }*/
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && (((sender as MetroTextBox).Text.IndexOf('.') > -1) || (sender as MetroTextBox).Text.Length == 0 || (sender as MetroTextBox).Text.Length == 19)) {
                    e.Handled = true;
                }

                if ((sender as MetroTextBox).Text == "0" && char.IsDigit(e.KeyChar)) {
                    if ((sender as MetroTextBox).SelectionLength != 1) {
                        e.Handled = true;
                    }
                }
            }

        }

        public class BoolBox : MetroCheckBox, ModConfigBox
        {
            public BoolBox(string fileWithConfig, string configOptionName, string showedName) {
                Text = showedName;
                configOption = configOptionName;
                configFilePath = fileWithConfig;
                AutoSize = true;
            }

            void ModConfigBox.addControlsToControl(Control c) {
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                int index = configFiles.FindIndex((p) => { return p.Key == configFilePath; });
                if(index!=-1) {
                    Checked = configFiles[index].Value.getOption(configOption).ToLower() == "true";
                }
                
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                Location = newLocation;
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                string newValue = Checked ? "True" : "False";
                configFiles.Find((p) => { return p.Key == configFilePath; }).Value.ChangeOption(configOption, newValue);
            }

            string configFilePath;
            string configOption;
        }

        public class FileBox : MetroTextBox, ModConfigBox
        {
            public FileBox(string showedName, OpenFileDialog FileDialog, Action<string> howToUsePath, string toFilePath) {
                fileDialogButton.Size = new Size(23, 23);
                fileDialogButton.Text = "\\/";
                fileDialogButton.FontWeight = MetroButtonWeight.Regular;

                BoxName.Text = showedName + ':';
                BoxName.AutoSize = true;
                Size = new Size(365, 23);
                applyAction = howToUsePath;
                fileDialog = FileDialog;
                fileDialogButton.Click += FileDialogButtonClick;
                modFilePath = toFilePath;

                string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string forDefaultPath = ModConfigForm.getInGooseFilePath(modFilePath);
                string defaultPath = Path.Combine(exePath, "ModsFiles", MainForm.modName, "Default", forDefaultPath);
                if(!Directory.Exists(Path.GetDirectoryName(defaultPath))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(defaultPath));
                }
                try {
                    File.Copy(toFilePath, defaultPath, false);
                } catch(IOException) {

                }
            }

            void ModConfigBox.addControlsToControl(Control c) {
                c.Controls.Add(BoxName);
                c.Controls.Add(fileDialogButton);
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                //Text = configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption);
                string ModsFilesPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles",MainForm.modName,"Default");
                if ( configFiles.First().Value.fileLocationPath.StartsWith(ModsFilesPath)) {
                    string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    string forDefaultPath = ModConfigForm.getInGooseFilePath( modFilePath);
                    string defaultPath = Path.Combine(exePath, "ModsFiles", MainForm.modName, "Default", forDefaultPath);

                    Text = defaultPath;
                    return;
                }
                
                if (configFiles.First().Value.fileLocationPath.StartsWith(Path.GetDirectoryName((string)Config.Options["gpath"]))) {
                    Text = modFilePath;
                    return;
                }
                    /*ModsFilesPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", MainForm.modName, "Used Before");
                    if (configFiles.First().Value.fileLocationPath.StartsWith(ModsFilesPath)) {
                        string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        string forDefaultPath = ModConfigForm.getInGooseFilePath(modFilePath);
                        string defaultPath = Path.Combine(exePath, "ModsFiles", MainForm.modName, "Used Before", forDefaultPath);

                        Text = defaultPath;
                    }*/
                }

            void ModConfigBox.SetLocation(Point newLocation) {
                BoxName.Location = newLocation;
                
                Location = new Point(newLocation.X, newLocation.Y + BoxName.Size.Height + 3);
                fileDialogButton.Location = new Point(Location.X+Size.Width, Location.Y);
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                if(Text!= modFilePath) {
                    if (File.Exists(Text)) {
                        applyAction(Text);


                        string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        string forDefaultPath = ModConfigForm.getInGooseFilePath(modFilePath);
                        string defaultPath = Path.Combine(exePath, "ModsFiles", MainForm.modName, "Used Before", forDefaultPath);
                        try {
                            File.Copy(modFilePath, defaultPath, true);
                        } catch (IOException) {

                        }
                    }
                }
                
            }
            void FileDialogButtonClick(object sender, EventArgs e) {
                fileDialog.InitialDirectory = Text;
                if (fileDialog.ShowDialog() == DialogResult.OK) {
                    Text = fileDialog.FileName;
                }
            }

            MetroLabel BoxName = new MetroLabel();
            MetroButton fileDialogButton = new MetroButton();
            Action<string> applyAction;
            OpenFileDialog fileDialog;
            public string modFilePath;
        }

        public class ColorBox : MetroButton, ModConfigBox
        {
            public ColorBox(string fileWithConfig, string configOptionName, string showedName) {
                Text = showedName;
                Size=new Size(388, 23);
                UseCustomBackColor = true;
                UseCustomForeColor = true;
                configOption = configOptionName;
                configFilePath = fileWithConfig;
                Click += OnClick;
                colorDialog.ShowHelp = true;
            }

            void ModConfigBox.addControlsToControl(Control c) {
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                
                SetButtonColor(ColorTranslator.FromHtml(configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption)));
            }

            public void SetButtonColor(Color newColor) {
                BackColor = newColor;
                ForeColor = Color.FromArgb(255- newColor.R, 255 - newColor.G, 255 - newColor.B);
                colorDialog.Color = newColor;
            }

            void OnClick(object sender, EventArgs e) {
                if (colorDialog.ShowDialog() == DialogResult.OK) {
                    SetButtonColor(colorDialog.Color);
                }
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                Location = newLocation;
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                string newValue = "#" + BackColor.R.ToString("X2") + BackColor.G.ToString("X2") + BackColor.B.ToString("X2");
                configFiles.Find((p) => { return p.Key == configFilePath; }).Value.ChangeOption(configOption, newValue);
                
            }

            ColorDialog colorDialog = new ColorDialog();
            string configFilePath;
            string configOption;
        }

        public class LinkButton : MetroButton, ModConfigBox
        {
            public LinkButton(string buttonText, string buttonLink,Func<object, string, MessageBoxButtons, MessageBoxIcon, MessageBoxDefaultButton, DialogResult> MsgBox_) {
                Text = buttonText;
                Size = new Size(388, 23);
                Click += OnClick;
                link = buttonLink;
                MsgBox = MsgBox_;
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
               
            }

            void ModConfigBox.addControlsToControl(Control c) {
            }

            void OnClick(object sender, EventArgs e) {
                if (MsgBox("This will open a link: "+'"' + link + '"' + ". Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                    Process.Start(link);
                }
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                Location = newLocation;
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                
            }
            string link;
            Func<object, string, MessageBoxButtons, MessageBoxIcon, MessageBoxDefaultButton, DialogResult> MsgBox;
        }
    }
}
