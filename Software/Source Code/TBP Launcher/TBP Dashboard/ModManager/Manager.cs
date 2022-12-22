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

            Status.Text = "Ready";
        }

        private void PauseItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Do absolutely nothing!
        }
    }
}
