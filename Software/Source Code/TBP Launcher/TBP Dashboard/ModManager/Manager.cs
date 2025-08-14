using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace TBP_Dashboard.ModManager
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();

            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string modsPath = dataPath + @"\.minecraft\mods\";
            string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";
            string presetsPath = dataPath + @"\.minecraft\mods.presets\";

            Status.Text = "Checking directories...";

            if (!Directory.Exists(modsPath))
            {
                try
                {
                   Directory.CreateDirectory(modsPath);
                   Status.Text = "Creating directories...";
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Something went wrong. Error:" + ex.Message);
                }
            }
            if (!Directory.Exists(presetsPath))
            {
                try
                {
                    Directory.CreateDirectory(presetsPath);
                    Status.Text = "Creating directories...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong. Error:" + ex.Message);
                }
            }
            if (!Directory.Exists(disabledmodsPath))
            {
                try
                {
                   Directory.CreateDirectory(disabledmodsPath);
                   Status.Text = "Creating directories...";
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Something went wrong. Error:" + ex.Message);
                }
            }

            //Try add enabled mods to the list
            try
            {
                Status.Text = "Finding enabled mods...";
                foreach (string mod in Directory.GetFiles(modsPath, "*", SearchOption.TopDirectoryOnly).Select(f => Path.GetFileName(f)))
                {
                    ModList.Items.Add(mod, true);
                }
            }
            catch
            {
                //Mods could not be found.
            }

            //Try add disabled mods to the list
            try
            {
                Status.Text = "Finding disabled mods...";
                foreach (string mod in Directory.GetFiles(disabledmodsPath, "*", SearchOption.TopDirectoryOnly).Select(f => Path.GetFileName(f)))
                {
                    ModList.Items.Add(mod, false);
                }
            }
            catch
            {
                //Disabled mods could not be found
            }

            ModList.ItemCheck += ModList_ItemCheck;
            Status.Text = "Ready";
        }

        private void ModList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string modsPath = dataPath + @"\.minecraft\mods\";
            string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";

            string TargetMod = ModList.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                try
                {
                    Status.Text = "Disabling mod: " + TargetMod;
                    string SourceFile = disabledmodsPath + TargetMod;
                    string DestinationFile = modsPath + TargetMod;

                    File.Move(SourceFile, DestinationFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("We couldn't process your request. Error:" + ex.Message);
                }
            }
            else
            {
                try
                {
                    Status.Text = "Enabling mod: " + TargetMod;
                    string SourceFile = modsPath + TargetMod;
                    string DestinationFile = disabledmodsPath + TargetMod;

                    File.Move(SourceFile, DestinationFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("We couldn't process your request. Error:" + ex.Message);
                }
            }

            Status.Text = "Ready";
        }

        private void DeleteMod_Click(object sender, EventArgs e)
        {
            try
            {
                string TargetMod = ModList.SelectedItem.ToString();
                string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string modsPath = dataPath + @"\.minecraft\mods\";
                string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";

                //ModList.ItemCheck += PauseItemCheck;

                try
                {
                    if (ModList.GetItemChecked(ModList.SelectedIndex) == true)
                    {
                        File.Delete(modsPath + TargetMod);
                        Status.Text = "Deleting enabled mod...";
                        ModList.Items.Remove(TargetMod);
                    }
                    else if (ModList.GetItemChecked(ModList.SelectedIndex) == false)
                    {
                        File.Delete(disabledmodsPath + TargetMod);
                        Status.Text = "Deleting disabled mod...";
                        ModList.Items.Remove(TargetMod);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("We couldn't process your request. Error:" + ex.Message);
                    Status.Text = "Issue deleting mod.";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("We couldn't process your request. Error:" + ex.Message);
                Status.Text = "Issue deleting mod.";
            }
            Status.Text = "Ready";
        }

        private void PauseItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Do absolutely nothing!
        }

        private void SetPreset_Click(object sender, EventArgs e)
        {
            string ModsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\mods\";

            foreach(string Files in Directory.GetFiles(ModsFolder))
            {
                string Mod = Path.GetFileName(Files);
                PresetManagement.AppendText(Mod + Environment.NewLine);
            }

            PresetManagement.SaveFile(ModsFolder + "TBPOriginsS1.txt", RichTextBoxStreamType.PlainText);
        }

        private void InstallMod_Click(object sender, EventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string modsPath = dataPath + @"\.minecraft\mods\";
            string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";
            string presetsPath = dataPath + @"\.minecraft\mods.presets\";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a JAR file";
            ofd.Filter = "JAR files (*.jar)|*.jar";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // The user selected a JAR file, so you can now use the file path
                // in openFileDialog.FileName to open the file and do whatever you need to do with it.
                if (File.Exists(ofd.FileName))
                {
                    try
                    {
                        File.Copy(ofd.FileName, modsPath + ofd.SafeFileName);
                        MessageBox.Show(ofd.SafeFileName + "was installed successfully.","Mod Management | TBP Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("There was an issue installing this mod. More information: " + Environment.NewLine + Environment.NewLine + ex.Message, "Mod Management | TBP Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }
    }
}
