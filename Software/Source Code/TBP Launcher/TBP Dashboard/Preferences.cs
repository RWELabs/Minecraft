using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TBP_Dashboard
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            CurrentVersion.Text = "Current Version: " + Properties.Settings.Default.Version;
            LauncherLocation.Text = Properties.Settings.Default.LaunchMinecraft;
            if(Properties.Settings.Default.CheckUpdates == "TRUE"){ CheckTBPUpdates.Checked = true;}
            if(Properties.Settings.Default.CheckUpdates == "FALSE") { CheckTBPUpdates.Checked = false; }
        }

        private void SetManually_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executable Files (*.exe)|*.exe";
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "Browse for your Minecraft Launcher Executable";
            ofd.CheckFileExists = true;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                LauncherLocation.Text = ofd.FileName;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (CheckTBPUpdates.Checked == true) { Properties.Settings.Default.CheckUpdates = "TRUE"; }
            if (CheckTBPUpdates.Checked == false) { Properties.Settings.Default.CheckUpdates = "FALSE"; }
            Properties.Settings.Default.LaunchMinecraft = LauncherLocation.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            LauncherLocation.Text = null;
        }

        private void SetMSLauncher_Click(object sender, EventArgs e)
        {
            LauncherLocation.Text = Properties.Settings.Default.MSStoreMinecraftLocation;
        }

        private void CheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdates.Text = "Checking for updates...";
            string CurrentUpdateVersion = "https://raw.githubusercontent.com/RWELabs/Minecraft/master/Web/launcheruc.xml";

            //View current stable version number
            XmlDocument document = new XmlDocument();
            document.Load(CurrentUpdateVersion);
            string CVER = document.InnerText;
            Properties.Settings.Default.CVER = CVER;
            Properties.Settings.Default.Save();

            if (!CVER.Contains(Properties.Settings.Default.Version))
            {
                CheckForUpdates.Text = "Updates available.";
                AvailableVersion.Text = "Updates available.";
                AvailableVersion.Visible = true;

                //Alert to available update
                DialogResult dr = MessageBox.Show("There are updates available for TBP Launcher. Would you like to download and install the latest version?", "Update | TBP Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //User clicks yes
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        //Process.Start(LatestRelease);
                        UpdateDownload download = new UpdateDownload();
                        download.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an issue updating..." + Environment.NewLine + Environment.NewLine + ex.Message);
                    }
                }
                else if (dr == DialogResult.No)
                {
                    //
                }
                else
                {
                    //
                }
            }
            else if (CVER.Contains(Properties.Settings.Default.Version))
            {
                CheckForUpdates.Text = "Up to date!";
                AvailableVersion.Text = "No updates available.";
                AvailableVersion.Visible = true;
            }
        }
    }
}
