using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBP_Dashboard.ModManager
{
    public partial class ActivateModpack : Form
    {
        public ActivateModpack()
        {
            InitializeComponent();
        }

        private void ActivateModpack_Load(object sender, EventArgs e)
        {
            DisableMods.RunWorkerAsync();
        }

        private void DisableMods_DoWork(object sender, DoWorkEventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string modsPath = dataPath + @"\.minecraft\mods\";
            string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";

            if (!Directory.Exists(disabledmodsPath))
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    StatusLabel.Text = "Creating Directories...";
                }));
                Directory.CreateDirectory(disabledmodsPath);
            }

            foreach (string file in Directory.EnumerateFiles(modsPath))
            {
                string mod = Path.GetFullPath(file);
                string modname = Path.GetFileName(file);
                try
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        StatusLabel.Text = "Disabling " + modname + "...";
                    }));
                    File.Move(mod, disabledmodsPath + modname);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DisableMods_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //Cancelled
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                //MessageBox.Show("Mods have been disabled");
                EnableMods.RunWorkerAsync();
            }
        }

        private void EnableMods_DoWork(object sender, DoWorkEventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string modsPath = dataPath + @"\.minecraft\mods\";
            string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";
            string Pack = Properties.Settings.Default.CurrentModpack;

            switch (Pack as string)
            {
                case "No Modpack (Vanilla Minecraft)":
                    //do nothing
                    break;
                case "TBP Origins (Season 1)":
                    this.Invoke(new MethodInvoker(delegate
                    {
                        ProcessingList.LoadFile(Application.ExecutablePath.Replace("TBP Dashboard.exe", "origins_season1_modlist.txt"), RichTextBoxStreamType.PlainText);
                    }));
                    break;
                case "Custom Modpack":
                    //do nothing
                    break;
            }
        }

        private void EnableMods_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string modsPath = dataPath + @"\.minecraft\mods\";
            string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";
            string Pack = Properties.Settings.Default.CurrentModpack;

            foreach (string line in ProcessingList.Lines)
            {
                try
                {
                    StatusLabel.Text = "Enabling " + line;

                    try
                    {
                        File.Move(disabledmodsPath + line, modsPath + line);
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Skipping " + line;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("Active modpack has been switched to " + Pack + " successfully.");
            this.Close();
        }
    }
}
