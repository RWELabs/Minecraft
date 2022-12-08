using CmlLib.Core.Downloader;
using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Ionic.Zip;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Cryptography;
using ZipFile = System.IO.Compression.ZipFile;
using System.Runtime.Remoting.Contexts;

namespace TBP_Dashboard.Get
{
    public partial class DownloadContent : Form
    {
        public DownloadContent()
        {
            InitializeComponent();

            StatusText.Text = "Please Wait...";
            DownloadProgress.Text = "Retrieiving download information...";

            string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string MinecraftDir = Appdata + @"\.minecraft\";
            string LauncherProfiles = MinecraftDir + @"launcher_profiles.json";

            FileDestination.Text = Properties.Settings.Default.DownloadItem;
            
            //Query URL for Download Type
            Uri DownloadURL = new Uri(Properties.Settings.Default.DownloadItem);
            // Grabs the query string from the URL:
            string query = DownloadURL.Query;
            // Parses the query string as a NameValueCollection:
            var queryParams = HttpUtility.ParseQueryString(query);

            foreach (string param in queryParams)
            {
                if (param == "type") { string DownloadType = queryParams["type"]; Properties.Settings.Default.DownloadType = DownloadType.ToLower(); }
                if (param == "version") { string GameVersion = queryParams["version"]; Properties.Settings.Default.DownloadVersion = GameVersion.ToString(); }
                if (param == "name") { string Name = queryParams["name"]; Properties.Settings.Default.DownloadName = Name.ToString(); }
            }
            
            //MessageBox.Show(DownloadType + " " + GameVersion);
            
            Properties.Settings.Default.Save();

            try
            {
                FileRead.LoadFile(LauncherProfiles, RichTextBoxStreamType.PlainText);
            }
            catch
            {
                //
            }

            if(Properties.Settings.Default.DownloadType == "modpack")
            {
                DoModpackDownload();
            }
            else if (Properties.Settings.Default.DownloadType == "resourcepack")
            {
                DoResourcePackDownload();
            }
            else if (Properties.Settings.Default.DownloadType == "world")
            {
                DoWorldDownload();
            }

        }

        private void DoWorldDownload()
        {
            string Minecraft = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\";

            MessageBox.Show("TBP World Saves can be up to 10gb in size. Please take this into consideration when selecting a location to save them. You may also need additional space if you're planning on downloading and installing the world to your saves folder.", "Just a heads up!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Where would you like to save this world?";
            sfd.AddExtension = true;
            sfd.Filter = "Minecraft Worlds (.zip)|*.zip";
            sfd.InitialDirectory = Minecraft + @"saves\";
            sfd.FileName = Properties.Settings.Default.DownloadName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string SaveLocation = sfd.FileName;
                Properties.Settings.Default.TmpString = SaveLocation;
                Properties.Settings.Default.Save();

                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                        string updatelocation = Path.Combine(SaveLocation);

                        wc.DownloadProgressChanged += wc_DownloadProgressChanged3;
                        wc.DownloadFileCompleted += wc_DownloadFileCompleted3;

                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri(Properties.Settings.Default.DownloadItem),
                            // Param2 = Path to save
                            updatelocation
                        );

                        this.BringToFront();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                this.Close();
            }
        }

        private void FileDestination_TextChanged(object sender, EventArgs e)
        {
            //
        }


        private void DoModpackDownload()
        {
            if (Properties.Settings.Default.DownloadVersion.StartsWith("fabric"))
            {
                if (!FileRead.Text.Contains(Properties.Settings.Default.DownloadVersion))
                {
                    //DialogResult dr = MessageBox.Show("This modpack requires a version of the Fabric mod loader to be installed. We'll download and launch the Fabric Installer for you to complete the setup. This modpack requires the latest version of " + Properties.Settings.Default.DownloadVersion + Environment.NewLine + Environment.NewLine + "We'll download the modpack and install it while you complete the Fabric installation.", "TBP Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //download fabric
                    //string FabricInstaller = "https://raw.githubusercontent.com/RWELabs/Minecraft/master/Web/Launcher/fabric-installer.exe";
                    StartFabricInstaller.Start();
                    StatusText.Text = "Launching Fabric Installer";
                    DownloadProgress.Text = "Please wait...";
                }

                else if (FileRead.Text.Contains(Properties.Settings.Default.DownloadVersion))
                {
                    //Skip fabric install
                    DoModpackInstall();
                }
            }
        }

        private void DoResourcePackDownload()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    StatusText.Text = "Downloading Resource Pack";
                    DownloadProgress.Text = "Calculating...";

                    string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string updatelocation = Path.Combine(dataPath, Properties.Settings.Default.DownloadName + ".zip");

                    wc.DownloadProgressChanged += wc3_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc3_DownloadFileCompleted;

                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(Properties.Settings.Default.DownloadItem),
                        // Param2 = Path to save
                        updatelocation
                    );

                    this.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartFabricInstaller_Tick(object sender, EventArgs e)
        {
            string dataPath = Path.GetDirectoryName(Application.ExecutablePath).Replace("TBP Dashboard.exe", null);
            string updatelocation = Path.Combine(dataPath, "fabric-installer.exe");

            StartFabricInstaller.Stop();

            Process.Start(updatelocation);

            DoModpackInstall();
        }

        private void DoModpackInstall()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    StatusText.Text = "Downloading Modpack";
                    DownloadProgress.Text = "Calculating...";

                    string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string updatelocation = Path.Combine(dataPath, "tbp-modpack.zip");

                    wc.DownloadProgressChanged += wc2_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc2_DownloadFileCompleted;

                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(Properties.Settings.Default.DownloadItem),
                        // Param2 = Path to save
                        updatelocation
                    );

                    this.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wc2_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // First check for Cancelled and then for other exceptions
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
            }
            if (e.Error != null)
            {
                // handle error scenario
                throw e.Error;
            }
        }

        void wc2_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            long FileSize = e.TotalBytesToReceive / 1024;
            long FileSizeMB = FileSize / 1000;
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";

            DownloadProgress.Text = "Downloading " + e.ProgressPercentage.ToString() + "% of " + FileSizeMB.ToString() + "mb (" + FileSize + "kb)";


            if (DownloadProgress.Text.Contains("100%") && ProgressBar.Value == 100)
            {
                StartModpackUnzip.Start();
                StatusText.Text = "Installing Modpack...";
                DownloadProgress.Text = "Installing mods to Minecraft directory...";
            }
        }

        private void StartModpackUnzip_Tick(object sender, EventArgs e)
        {
            StartModpackUnzip.Stop();
            DoModpackUnzip();
        }

        private void DoModpackUnzip()
        {
            string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string MinecraftDir = Appdata + @"\.minecraft\mods\";
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string updatelocation = Path.Combine(dataPath, "tbp-modpack.zip");

            if (!Directory.Exists(MinecraftDir)) { Directory.CreateDirectory(MinecraftDir); }
            
            StatusText.Text = "Installing Modpack...";
            DownloadProgress.Text = "This may take a few minutes.";
            ProgressBar.Style = ProgressBarStyle.Marquee;
            //ZipFile.ExtractToDirectory(updatelocation, MinecraftDir);

            string zipToUnpack = updatelocation;
            string unpackDirectory = MinecraftDir;
            using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(zipToUnpack))
            {
               foreach (ZipEntry e in zip1)
                {
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            StatusText.Text = "Cleaning up...";
            DownloadProgress.Text = "Finishing installation...";
            MessageBox.Show("We have successfully installed a modpack. Please note that this modpack requires the use of " + Properties.Settings.Default.DownloadVersion + ". Please ensure you select this profile when launching Minecraft.");
            this.Close();
        }

        private void DownloadContent_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string fabriclocation = Path.Combine(dataPath, "fabric-installer.exe");

            Properties.Settings.Default.DownloadItem = null;
            Properties.Settings.Default.DownloadType = null;
            Properties.Settings.Default.DownloadVersion = null;
            Properties.Settings.Default.Save();

            if (File.Exists(fabriclocation))
            {
                File.Delete(fabriclocation);
            }
        }

        private void wc3_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // First check for Cancelled and then for other exceptions
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
            }
            if (e.Error != null)
            {
                // handle error scenario
                throw e.Error;
            }
        }

        void wc3_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            long FileSize = e.TotalBytesToReceive / 1024;
            long FileSizeMB = FileSize / 1000;
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";

            DownloadProgress.Text = "Downloading " + e.ProgressPercentage.ToString() + "% of " + FileSizeMB.ToString() + "mb (" + FileSize + "kb)";


            if (DownloadProgress.Text.Contains("100%") && ProgressBar.Value == 100)
            {
                StatusText.Text = "Installing Resource Pack...";
                DownloadProgress.Text = "Installing Resource Pack to Minecraft directory...";
                ResourcePackInstallTimer.Start();
            }
        }

        private void DoResourcePackInstall()
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string updatelocation = Path.Combine(dataPath, Properties.Settings.Default.DownloadName + ".zip");

            string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string MinecraftDir = Appdata + @"\.minecraft\resourcepacks\";

            if(File.Exists(MinecraftDir + Properties.Settings.Default.DownloadName + ".zip"))
            {
                MessageBox.Show("There's already a copy of this resource pack installed on your machine. To use it, enable it within your game settings.");
                this.Close();
            }
            else
            {
                File.Move(updatelocation, MinecraftDir + Properties.Settings.Default.DownloadName + ".zip");

                MessageBox.Show("We have successfully installed a resource pack. To use this resource pack, please enable it within your game settings.");
                this.Close();
            }
        }

        private void ResourcePackInstallTimer_Tick(object sender, EventArgs e)
        {
            ResourcePackInstallTimer.Stop();
            DoResourcePackInstall();
        }

        private void wc_DownloadFileCompleted3(object sender, AsyncCompletedEventArgs e)
        {
            // First check for Cancelled and then for other exceptions
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
            }
            if (e.Error != null)
            {
                // handle error scenario
                throw e.Error;
            }
        }

        void wc_DownloadProgressChanged3(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            long FileSize = e.TotalBytesToReceive / 1024;
            long FileSizeMB = FileSize / 1000;
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";

            DownloadProgress.Text = "Downloading " + e.ProgressPercentage.ToString() + "% of " + FileSizeMB.ToString() + "mb (" + FileSize + "kb)";


            if (DownloadProgress.Text.Contains("100%") && ProgressBar.Value == 100)
            {
                StartWorldHandling.Start();
                StatusText.Text = "Finishing up...";
                DownloadProgress.Text = "Please wait...";
            }
        }

        private void StartWorldHandling_Tick(object sender, EventArgs e)
        {
            StartWorldHandling.Stop();

            if(MessageBox.Show("The world has been downloaded successfully. Would you like us to automatically extract and install it for you, in your Minecraft Saves folder?", "World Saver | TBP Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string SavesFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\";
                    ZipFile.ExtractToDirectory(Properties.Settings.Default.TmpString, SavesFolder);
                    MessageBox.Show("Your world has been installed and is now ready to be played in Minecraft!", "TBP Launcher", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("There was an issue installing the world. You can still do this manually, by extracting the ZIP file to your Saves directory. Error Message:" + Environment.NewLine + Environment.NewLine + ex.Message, "TBP Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}
