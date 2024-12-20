using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
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
using CmlLib.Core.Auth.Microsoft;
using System.Xml;
using TBP_Dashboard.Properties;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using WebView2 = Microsoft.Web.WebView2.WinForms.WebView2;
using TBP_Dashboard.Get;
using System.Web;
using System.Runtime.ConstrainedExecution;
using System.Net;
using TBP_Dashboard.ModManager;

namespace TBP_Dashboard
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            //Define WV2 User Data
            string userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\UserData\WV\";
            if (!Directory.Exists(userDataFolder))
            {
                Directory.CreateDirectory(userDataFolder);
            }

            //Define window
            InitializeComponent();
            this.Height = 723;
            this.Width = 676;

            //Load user preferences from settings INI file if exists.
            string SettingsINI = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\settings.ini";
            if (File.Exists(SettingsINI))
            {
                SettingsProcessing.LoadFile(SettingsINI, RichTextBoxStreamType.PlainText);

                foreach(string line in SettingsProcessing.Lines)
                {
                    if (line.StartsWith("$mcdir=")){Settings.Default.LaunchMinecraft = line.Replace("$mcdir=", null);}
                    if (line.StartsWith("$checkupdates=")) { Settings.Default.CheckUpdates = line.Replace("$checkupdates=", null); }
                    if (line.StartsWith("$currentmp=")) { Settings.Default.CurrentModpack = line.Replace("$currentmp=", null); }
                    Settings.Default.Save();
                }
            }
            else
            {
                //file not yet generated, generates on first close
            }

            //Set current modpack
            if(Settings.Default.CurrentModpack == "undefined")
            {
                string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string modsPath = dataPath + @"\.minecraft\mods\";
                string disabledmodsPath = dataPath + @"\.minecraft\mods.disabled\";
                string presetsPath = dataPath + @"\.minecraft\mods.presets\";

                //No mods found, Vanilla
                if (Directory.GetFiles(modsPath).Length == 0 && Directory.GetDirectories(modsPath).Length == 0)
                {
                    //mods directory is empty
                    Properties.Settings.Default.CurrentModpack = "No Modpack (Vanilla Minecraft)";
                    Properties.Settings.Default.Save();
                }
                //Mods have been found
                else
                {
                    //Check if Modpack is Origins
                    ModsProcessing.LoadFile(Application.ExecutablePath.Replace("TBP Dashboard.exe", "origins_season1_modlist.txt"),RichTextBoxStreamType.PlainText);
                    int Num = 0;
                    foreach(string filePath in Directory.GetFiles(modsPath))
                    {
                        string fn = Path.GetFileName(filePath);

                        if (ModsProcessing.Text.Contains(fn))
                        {
                            Num = Num +1;
                            if(Num > 30)
                            {
                                Properties.Settings.Default.CurrentModpack = "TBP Origins (Season 1)";
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Properties.Settings.Default.CurrentModpack = "Custom Modpack";
                                Properties.Settings.Default.Save();
                            }
                        }
                    }
                }
            }

            //Set active modpack
            switch(Properties.Settings.Default.CurrentModpack as string)
            {
                case "No Modpack (Vanilla Minecraft)":
                    MP_Vanilla.Checked = true;
                    break;
                case "TBP Origins (Season 1)":
                    MP_Origins1.Checked = true;
                    break;
                case "Custom Modpack":
                    MP_Custom.Checked = true;
                    break;
            }

            ShowLoadingPanel();
        }

        private void PreInitializeBrowser()
        {
            //Check WV
            if(WebView == null)
            {
                //
            }
            if(WebView2 == null)
            {
                //
            }

            InitializeBrowser();
        }

        private async Task InitializeBrowser()
        {
            //var env = await CoreWebView2Environment.CreateAsync(Application.ExecutablePath.Replace("TBP Dashboard.exe", null) + @"WV\", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\UserData\WV\");
            var env = await CoreWebView2Environment.CreateAsync(null,Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\UserData\WV\");
            await WebView.EnsureCoreWebView2Async(env);
            await WebView2.EnsureCoreWebView2Async(env);

            //MessageBox.Show(Application.ExecutablePath.Replace("TBP Dashboard.exe", null) + @"WV\");
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            WebView.CoreWebView2.Settings.IsStatusBarEnabled = false;

            WebView.Source = new Uri("https://crutionix.com/oauth/");
            StatusStrip.Text = "Starting Launcher...";
            UpdateHeader.Text = "Starting TBP Launcher...";
            this.Text = "Starting... | TBP Launcher";

            //Check for updates
            if (Properties.Settings.Default.CheckUpdates == "TRUE")
            {
                StatusStrip.Visible = true;
                UpdateHeader.Visible = true;
                StartTimer.Start();
            }
        }

        private void WebView_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            StatusLabel.Text = WebView.Source.ToString();
        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (WebView.Source.ToString().EndsWith("/dashboard/"))
            {
                HideWebBrowser();
                HideLoadingPanel();
                StatusStrip.Visible = false;
                this.Icon = Resources.MCGC;
                this.Text = "Dashboard - TBP Launcher (v" + Settings.Default.Version + ")";
                this.Width = 1064;
                this.Height = 723;
                WebView2.Visible = true;
            }
            else if (WebView.Source.ToString().StartsWith("https://discord.com/oauth2/"))
            {
                this.Text = "Sign in with Discord";
                this.Icon = Resources.DiscordLogo;
                DiscordSwitchAccounts.Visible = true;
                HideLoadingPanel();
                ShowWebBrowser();
            }
            else if (WebView.Source.ToString().EndsWith("crutionix.com/"))
            {
                WebView2.Source = new Uri("https://crutionix.com/tbpdashboard/newsfeed?ref=wingo");
                                StatusStrip.Visible = false;
                this.Icon = Resources.MCGC;
                this.Text = "Dashboard - TBP Launcher (v" + Settings.Default.Version + ")";
                this.Width = 1064;
                this.Height = 723;
                WebView2.Visible = true;
            }
            else
            {
                HideLoadingPanel();
                ShowWebBrowser();
            }
        }

        private void ShowWebBrowser()
        {
            WebView.Location = new Point(0, 0);
            WebView.Dock = DockStyle.Fill;
            WebView.Visible = true;
            WebView.BringToFront();
            StatusStrip.Visible = true;
        }
        private void HideWebBrowser()
        {
            WebView.Visible = false;
            WebView.SendToBack();
        }
        private void HideLoadingPanel()
        {
            LoadingPanel.Dock = DockStyle.None;
            LoadingPanel.Location = new Point(-1000, -1000);
            LoadingPanel.Visible = false;
            LoadingPanel.SendToBack();
            StatusStrip.Visible = true;
        }

        private void ShowLoadingPanel()
        {
            LoadingPanel.Location = new Point(0, 0);
            LoadingPanel.Dock = DockStyle.Fill;
            LoadingPanel.Visible = true;
            LoadingPanel.BringToFront();
            StatusStrip.Visible = false;
        }

        private void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            ShowLoadingPanel();
        }

        private void CheckUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
             this.Invoke(new MethodInvoker(delegate
            {
                this.Text = "Checking for updates... | TBP Launcher";
            }));
            StatusLabel.Text = "Checking for updates...";
            string CurrentUpdateVersion = "https://raw.githubusercontent.com/RWELabs/Minecraft/master/Web/launcheruc.txt";

            //View current stable version number
            WebClient client = new WebClient();
            client.Proxy = null;
            Stream stream = client.OpenRead(CurrentUpdateVersion);
            StreamReader reader = new StreamReader(stream);
            String CVER = reader.ReadToEnd();
            Properties.Settings.Default.CVER = CVER;
            Properties.Settings.Default.Save();
        }

        private void CheckUpdates_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.Text = "Dashboard - TBP Launcher (v" + Settings.Default.Version + ")" + " [Up-to-Date]";
            }
            else if (e.Error != null)
            {
                this.Text = "Dashboard - TBP Launcher (v" + Settings.Default.Version + ")" + " [Up-to-Date]";

            }
            else
            {
                //Compare current stable version against installed version
                if (Properties.Settings.Default.CVER.Contains(Properties.Settings.Default.Version))
                {
                    this.Text = "Dashboard - TBP Launcher (v" + Settings.Default.Version + ")" + " [Up-to-Date]";
                }
                else
                {
                    this.Text = "Dashboard - TBP Launcher (v" + Settings.Default.Version + ")" + " [Updates Available]";
                    //Updates are available
                    UpdateNotification.Visible = true;
                }
            }
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StartTimer.Stop();
            CheckUpdates.RunWorkerAsync();
        }

        private void TryUpdate()
        {
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
                catch
                {
                    //Issue updating
                }
            }
            else if (dr == DialogResult.No)
            {
                //Refused Update

            }
            else
            {
                //Issue updating
            }
        }

        private void WebView2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
             WebView2.CoreWebView2.Settings.IsStatusBarEnabled = false;
        }

        private void WebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                ((WebView2)sender).ExecuteScriptAsync("document.querySelector('body').style.overflow='scroll';var style=document.createElement('style');style.type='text/css';style.innerHTML='::-webkit-scrollbar{display:none}';document.getElementsByTagName('body')[0].appendChild(style)");
                HideWebBrowser();
                HideLoadingPanel();
                StatusStrip.Visible = false;
                MenuStrip.Visible = true;
            }
            
        }

        private void WebView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            //If user clicks Play
            if (WebView2.Source.ToString().EndsWith("#wingo?ref=play"))
            {
                string MinecraftLocation = Properties.Settings.Default.LaunchMinecraft;
                if (String.IsNullOrEmpty(MinecraftLocation))
                {
                    //Launcher Location is not specified
                    FindLauncher();
                }
                else if (String.IsNullOrWhiteSpace(MinecraftLocation))
                {
                    //Launcher Location is not specified.
                    FindLauncher();
                }
                else if (MinecraftLocation == Properties.Settings.Default.MSStoreMinecraftLocation)
                {
                    //Launcher Location is MS Store Launcher
                    LaunchLauncher();
                }
                else
                {
                    //Other Launcher Location Specified
                    LaunchLauncher();
                }
            }
            //If user clicks Worlds
            if (WebView2.Source.ToString().EndsWith("#wingo?ref=worlddownload"))
            {
                try
                {
                    string InstallLocation = Path.GetDirectoryName(Application.ExecutablePath).Replace("TBP Dashboard.exe", null);
                    Process.Start(InstallLocation + @"\TBP World Saver.exe");
                    WebView2.Source = new Uri(WebView2.Source.ToString().Replace("#wingo?ref=worlddownload", null));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an issue. " + ex.Message);
                }
            }
            //If user clicks "Install Modpack"
            if (WebView2.Source.ToString().Contains("#wingo?ref=mpdownload_"))
            {
                string Source = WebView2.Source.ToString().Replace("https://crutionix.com/tbpdashboard/newsfeed/#wingo?ref=mpdownload_", null); ;
                Properties.Settings.Default.DownloadItem = Source;
                Properties.Settings.Default.Save();

                DoContentInstall.Start();

                //Query URL for Download Type
                Uri QueryURL = new Uri(Source);
                // Grabs the query string from the URL:
                string query = QueryURL.Query;
                // Parses the query string as a NameValueCollection:
                var queryParams = HttpUtility.ParseQueryString(query);

                string GoURL = queryParams["fwd"];

                WebView2.Source = new Uri("https://crutionix.com/tbpdashboard/" + GoURL);
                MP_Custom.Checked = true;
                MP_Origins1.Checked = false;
                MP_Vanilla.Checked = false;
            }
            //If user clicks Download World
            if (WebView2.Source.ToString().Contains("#wingo?ref=worldsave_"))
            {
                string Source = WebView2.Source.ToString().Replace("https://crutionix.com/tbpdashboard/newsfeed/#wingo?ref=worldsave_", null); 
                Properties.Settings.Default.DownloadItem = Source;
                Properties.Settings.Default.Save();

                //Query URL for Download Type
                Uri QueryURL = new Uri(Source);
                // Grabs the query string from the URL:
                string query = QueryURL.Query;
                // Parses the query string as a NameValueCollection:
                var queryParams = HttpUtility.ParseQueryString(query);

                string GoURL = queryParams["fwd"];

                WebView2.Source = new Uri("https://crutionix.com/tbpdashboard/" + GoURL);

                DoContentInstall.Start();
            }
            //If user clicks a File Link
            if (WebView2.Source.ToString().Contains("#wingo?ref=installfabric"))
            {
                string dataPath = Path.GetDirectoryName(Application.ExecutablePath).Replace("TBP Dashboard.exe", null);
                string fabriclocation = Path.Combine(dataPath, "fabric-installer.exe");
                Process.Start(fabriclocation);
                WebView2.Source = new Uri(WebView2.Source.ToString().Replace("#wingo?ref=installfabric", null));
            }
        }

        private void FindLauncher()
        {
            //Check for Win32 Install
            string InstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            string InstallPath10 = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            string BackupInstallpath = @"C:\Program Files (x86)\Minecraft Launcher\MinecraftLauncher.exe";


            if (InstallPath != null)
            {
                if(File.Exists(InstallPath + @"MinecraftLauncher.exe"))
                {
                    Properties.Settings.Default.LaunchMinecraft = InstallPath + @"MinecraftLauncher.exe";
                    Properties.Settings.Default.Save();
                    LaunchLauncher();
                }
                else if (File.Exists(InstallPath + "Minecraft Launcher" + @"MinecraftLauncher.exe"))
                {
                    Properties.Settings.Default.LaunchMinecraft = InstallPath + @"MinecraftLauncher.exe";
                    Properties.Settings.Default.Save();
                    LaunchLauncher();
                }
            }
            else if (InstallPath10 != null)
                {
                    if (File.Exists(InstallPath10 + @"MinecraftLauncher.exe"))
                    {
                        Properties.Settings.Default.LaunchMinecraft = InstallPath + @"MinecraftLauncher.exe";
                        Properties.Settings.Default.Save();
                        LaunchLauncher();
                    }
                    else if (File.Exists(InstallPath10 + "Minecraft Launcher" + @"MinecraftLauncher.exe"))
                    {
                        Properties.Settings.Default.LaunchMinecraft = InstallPath + @"MinecraftLauncher.exe";
                        Properties.Settings.Default.Save();
                        LaunchLauncher();
                    }
            }
            else if (File.Exists(@"C:\Program Files (x86)\Minecraft Launcher\MinecraftLauncher.exe"))
            {
                Properties.Settings.Default.LaunchMinecraft = @"C:\Program Files (x86)\Minecraft Launcher\MinecraftLauncher.exe";
                Properties.Settings.Default.Save();
                LaunchLauncher();
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
                            Properties.Settings.Default.LaunchMinecraft = Properties.Settings.Default.MSStoreMinecraftLocation;
                            Properties.Settings.Default.Save();
                            LaunchLauncher();
                        }
                    }

                    ActivityForm af = new ActivityForm();
                    af.Show();
                }
                catch
                {
                    //No Microsoft Store Launcher or Local Install Launcher
                    MessageBox.Show("NO MS LAUNCHER");
                    LaunchLauncher();
                }
            }
        }

        private void LaunchLauncher()
        {
            WebView2.Source = new Uri(WebView2.Source.ToString().Replace("#wingo?ref=play", null));

            string LaunchProcedure = Properties.Settings.Default.LaunchMinecraft;

            if (LaunchProcedure == Properties.Settings.Default.MSStoreMinecraftLocation)
            {
                try
                {
                    Process.Start(
                    "explorer.exe",
                    @"shell:AppsFolder\Microsoft.4297127D64EC6_8wekyb3d8bbwe!Minecraft");
                }
                catch
                {
                    //
                }
            }
            else if (String.IsNullOrEmpty(LaunchProcedure)) { FindLauncher(); }
            else if (String.IsNullOrWhiteSpace(LaunchProcedure)) { FindLauncher(); }
            else
            {
                Process.Start(LaunchProcedure);
            }

            ActivityForm af = new ActivityForm();
            af.Show();
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string updatelocation = Path.Combine(dataPath, "tbp-modpack.zip");
            string SettingsINI = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\settings.ini";

            if (File.Exists(updatelocation))
            {
                try
                {
                    File.Delete(updatelocation);
                }
                catch
                {
                    //
                }
            }

            //Save user preferences to settings INI file
            SettingsProcessing.Clear();
            SettingsProcessing.AppendText("$mcdir=" + Settings.Default.LaunchMinecraft + Environment.NewLine);
            SettingsProcessing.AppendText("$checkupdates=" + Settings.Default.CheckUpdates + Environment.NewLine);
            SettingsProcessing.AppendText("$currentmp=" + Settings.Default.CurrentModpack + Environment.NewLine);
            SettingsProcessing.SaveFile(SettingsINI, RichTextBoxStreamType.PlainText);
            Application.Exit();
        }

        private void DoContentInstall_Tick(object sender, EventArgs e)
        {
            DoContentInstall.Stop();
            DownloadContent dc = new DownloadContent();
            dc.Show();
        }

        private void DiscordSwitchAccounts_Click(object sender, EventArgs e)
        {
            WebView.Source = new Uri("https://crutionix.com/oauth/?pd_discord_oauth_logout=1");
        }

        private void MainIcon_MouseEnter(object sender, EventArgs e)
        {
            FileMenu.Select();
        }

        private void MainIcon_MouseLeave(object sender, EventArgs e)
        {
            WebView2.Focus();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Maximise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Minimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (WebView2.CanGoBack) { WebView.GoBack(); }
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            if (WebView2.CanGoForward) { WebView.GoForward(); }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            WebView2.Reload();
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            Preferences settings = new Preferences();
            settings.ShowDialog();
        }

        private void MCATimer_Tick(object sender, EventArgs e)
        {

        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            PreInitializeBrowser();
        }

        private void OpenMinecraftDir_Click(object sender, EventArgs e)
        {
            try
            {
                string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Process.Start(dataPath + @"\.minecraft");
            }
            catch(Exception ex)
            {
                MessageBox.Show("We couldn't open your Minecraft directory. Have you installed Minecraft on this system? Have you got a custom Minecraft Directory location?" + ex.Message);
            }
        }

        private void MainIcon_DoubleClick(object sender, EventArgs e)
        {
            //Show Debug Options
            TestFeatures.Visible = true;
        }

        private void OpenModManager_Click(object sender, EventArgs e)
        {
            Manager modmanager = new Manager();
            modmanager.Show();
        }

        private void OpenSettings_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("!");
        }

        private void testDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Test URL
            //WebView2.Source = new Uri("https://crutionix.com/tbpdashboard/newsfeed/#wingo?ref=mpdownload_https://onedrive.live.com/download?cid=2843D66BB53B6198&resid=2843D66BB53B6198%211352660&authkey=AKUCVE7MZx-pWe8&type=modpack&name=Origins&version=fabric-loader-1.19.2&fwd=originschangelog1-1");
            MessageBox.Show("You can specify a target from the source code, before building.");
        }

        private void OpenPrivacyPolicy_Click(object sender, EventArgs e)
        {
            WebView2.Source = new Uri("https://crutionix.com/policies/");
        }

        private void InstallUpdate_Click(object sender, EventArgs e)
        {
            TryUpdate();
        }

        private void DismissUpdate_Click(object sender, EventArgs e)
        {
            UpdateNotification.Visible = false;
        }

        private void OriginsMPChosen(object sender, EventArgs e)
        {
            //Disable Other Packs
            MP_Custom.Checked = false;
            MP_Vanilla.Checked = false;

            Settings.Default.CurrentModpack = "TBP Origins (Season 1)";
            Settings.Default.Save();

            ActivateModpack amp = new ActivateModpack();
            amp.ShowDialog();
        }

        private void CustomMPChosen(object sender, EventArgs e)
        {
            //Disable Other Packs
            MP_Origins1.Checked = false;
            MP_Vanilla.Checked = false;

            Settings.Default.CurrentModpack = "Custom Modpack";
            Settings.Default.Save();

            MessageBox.Show("You've chosen to use a Custom Modpack. To select which mods you'd like to use, open 'Mod Manager' and check the specific mods you'd like to use as a part of your custom modpack.", "Getting Started | Custom Modpacks", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void VanillaMPChosen(object sender, EventArgs e)
        {
            //Disable Other Packs
            MP_Custom.Checked = false;
            MP_Origins1.Checked = false;

            Settings.Default.CurrentModpack = "No Modpack (Vanilla Minecraft)";
            Settings.Default.Save();

            ActivateModpack amp = new ActivateModpack();
            amp.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebView2.Reload();
        }
    }
}
