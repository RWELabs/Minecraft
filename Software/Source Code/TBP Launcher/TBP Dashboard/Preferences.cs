using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            CurrentVersion.Text = "Client Version: " + Properties.Settings.Default.Version;
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
            string CurrentUpdateVersion = "https://raw.githubusercontent.com/RWELabs/Minecraft/master/Web/launcheruc.txt";

            //View current stable version number
            //View current stable version number
            WebClient client = new WebClient();
            client.Proxy = null;
            Stream stream = client.OpenRead(CurrentUpdateVersion);
            StreamReader reader = new StreamReader(stream);
            String CVER = reader.ReadToEnd();

            if (!CVER.Contains(Properties.Settings.Default.Version))
            {
                CheckForUpdates.Text = "Updates available.";
                AvailableVersion.Text = "Update available: v" + CVER;
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

        private void FindLauncherStart_Click(object sender, EventArgs e)
        {
            //Check for Win32 Install
            string InstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            string InstallPath10 = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            string BackupInstallpath = @"C:\Program Files (x86)\Minecraft Launcher\MinecraftLauncher.exe";


            if (InstallPath != null)
            {
                if (File.Exists(InstallPath + @"MinecraftLauncher.exe"))
                {
                    LauncherLocation.Text = InstallPath + @"MinecraftLauncher.exe";
                }
                else if (File.Exists(InstallPath + "Minecraft Launcher" + @"MinecraftLauncher.exe"))
                {
                    LauncherLocation.Text = InstallPath + @"MinecraftLauncher.exe";
                }
            }
            else if (InstallPath10 != null)
            {
                if (File.Exists(InstallPath10 + @"MinecraftLauncher.exe"))
                {
                    LauncherLocation.Text = InstallPath + @"MinecraftLauncher.exe";
                }
                else if (File.Exists(InstallPath10 + "Minecraft Launcher" + @"MinecraftLauncher.exe"))
                {
                    LauncherLocation.Text = InstallPath + @"MinecraftLauncher.exe";
                }
            }
            else if (File.Exists(@"C:\Program Files (x86)\Minecraft Launcher\MinecraftLauncher.exe"))
            {
                LauncherLocation.Text = @"C:\Program Files (x86)\Minecraft Launcher\MinecraftLauncher.exe";
            }
            else
            {
                try
                {
                    string Directories = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\";
                    //Verify MS Launcher Installed

                    foreach (string dir in Directory.GetDirectories(Directories))
                    {
                        if (dir.EndsWith("Microsoft.4297127D64EC6_8wekyb3d8bbwe"))
                        {
                            LauncherLocation.Text = Properties.Settings.Default.MSStoreMinecraftLocation;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
                catch
                {
                    //No Microsoft Store Launcher or Local Install Launcher
                    MessageBox.Show("We weren't able to find the Minecraft Launcher on your PC. If you know where it's installed, please use the Find (Browse) button to locate the launcher manually.");
                }
            }
        }
    }
}
