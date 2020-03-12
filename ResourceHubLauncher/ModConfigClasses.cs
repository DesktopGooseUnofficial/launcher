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
            fileLocationPath = fileLocation;
            StreamReader file = new StreamReader(fileLocation);
            string[] lines = file.ReadToEnd().Split('\n');
            file.Close();
            foreach (string line in lines) {
                int equal = line.IndexOf('=');
                string key = line.Substring(0, equal);
                string value = line.Substring(equal + 1);
                options.Add(new KeyValuePair<string, string>(key, value));
            }
        }

        public string getOption(string optionName) {
            return options.Find((p) => { return p.Key == optionName; }).Value;
        }

        public void ChangeOption(string optionName,string toWhat) {

            KeyValuePair<string, string> optionPair= options.Find(( p) => { return p.Key == optionName; });
            options.Remove(optionPair);
            options.Add(new KeyValuePair<string, string>(optionName, toWhat));

        }

        public void SaveChanges() {
            FileStream stream = new FileStream(fileLocationPath, FileMode.Truncate);
            stream.Close();
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

        string fileLocationPath;
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

        }
        public class StringBox : MetroTextBox, ModConfigBox
        {
            public StringBox(string fileWithConfig, string configOptionName, string showedName) {
                Controls.Add(BoxName);
                BoxName.Text = showedName + ':';
                Size = new Size(388, 23);
                BoxName.Text = showedName;
                configOption = configOptionName;
                configFilePath = fileWithConfig;
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                Text = configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption);
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                BoxName.Location = newLocation;
                Location = new Point(newLocation.X, newLocation.Y + BoxName.Size.Height + 3);
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }
            
            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                configFiles.Find((p) => { return p.Key == configFilePath; }).Value.ChangeOption(configOption, Text);
            }

            MetroLabel BoxName = new MetroLabel();
            string configFilePath;
            string configOption;
        }

        public class Comment : MetroLabel, ModConfigBox {
            public Comment(string comment) {
                MaximumSize = new Size(388, 9999999);
                WrapToLine = true;
                Text = comment;
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

        public class IntBox : MetroTextBox, ModConfigBox
        {
            public IntBox(string fileWithConfig, string configOptionName, string showedName) {
                Controls.Add(BoxName);
                BoxName.Text = showedName + ':';
                Size = new Size(388, 23);
                BoxName.Text = showedName;
                configOption = configOptionName;
                configFilePath = fileWithConfig;
                MaxLength = 10;
                KeyPress += IntBox_KeyPress;
                ShortcutsEnabled = false;
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                Text = configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption);
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                BoxName.Location = newLocation;
                Location = new Point(newLocation.X, newLocation.Y + BoxName.Size.Height + 3);
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                configFiles.Find((p) => { return p.Key == configFilePath; }).Value.ChangeOption(configOption, Text);
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

            MetroLabel BoxName = new MetroLabel();
            string configFilePath;
            string configOption;
        }

        public class FloatBox : MetroTextBox, ModConfigBox
        {
            public FloatBox(string fileWithConfig, string configOptionName, string showedName) {
                Controls.Add(BoxName);
                BoxName.Text = showedName + ':';
                Size = new Size(388, 23);
                BoxName.Text = showedName;
                configOption = configOptionName;
                configFilePath = fileWithConfig;
                MaxLength = 20;
                KeyPress += FloatBox_KeyPress;
                ShortcutsEnabled = false;
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                Text = configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption);
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                BoxName.Location = newLocation;
                Location = new Point(newLocation.X, newLocation.Y + BoxName.Size.Height + 3);
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                configFiles.Find((p) => { return p.Key == configFilePath; }).Value.ChangeOption(configOption, Text);
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

            MetroLabel BoxName = new MetroLabel();
            string configFilePath;
            string configOption;
        }

        public class BoolBox : MetroCheckBox, ModConfigBox
        {
            public BoolBox(string fileWithConfig, string configOptionName, string showedName) {
                Text = showedName;
                configOption = configOptionName;
                configFilePath = fileWithConfig;
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {

                Checked = configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption).ToLower()=="true";
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
                Controls.Add(BoxName);
                Controls.Add(fileDialogButton);
                fileDialogButton.Size = new Size(23, 23);
                fileDialogButton.Text = "\\/";
                fileDialogButton.FontWeight = MetroButtonWeight.Regular;

                BoxName.Text = showedName + ':';
                Size = new Size(365, 23);
                BoxName.Text = showedName;
                applyAction = howToUsePath;
                fileDialog = FileDialog;
                fileDialogButton.Click += FileDialogButtonClick;
                modFilePath = toFilePath;
            }

            void ModConfigBox.ApplyValue(List<KeyValuePair<string, ConfigFile>> configFiles) {
                //Text = configFiles.Find((p) => { return p.Key == configFilePath; }).Value.getOption(configOption);
                string ModsFilesPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles");
                if ( configFiles.First().Key.StartsWith(ModsFilesPath)) {
                    Text = Path.Combine(ModsFilesPath, Path.GetDirectoryName(modFilePath),"Default",Path.GetFileName(modFilePath));
                }
            }

            void ModConfigBox.SetLocation(Point newLocation) {
                BoxName.Location = newLocation;
                Location = new Point(newLocation.X, newLocation.Y + BoxName.Size.Height + 3);
            }

            Point ModConfigBox.GetNextBoxLocation() {
                return new Point(Location.X, Location.Y + Size.Height + 6);
            }

            void ModConfigBox.Apply(List<KeyValuePair<string, ConfigFile>> configFiles) {
                if(File.Exists(Text)) {
                    applyAction(Text);
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
