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
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Http;
using static TBP_Dashboard.SignIn;
using DiscordRPC;
using DiscordRPC.Message;
using Button = DiscordRPC.Button;
using MineStatLib;

namespace TBP_Dashboard
{
    public partial class SignIn : Form
    {
        // Windows 10/11 only
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        

        const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private DateTime? gameStartTime = null;
        private bool isMinecraftRunning = false;
        // Only show the WebView after the first play.tbp.zone page has finished loading
        private bool firstPlaySiteLoaded = false;

        // Centers the PlayLogo control within the form's client area
        private void CenterPlayLogo()
        {
            try
            {
                if (PlayLogo == null) return;

                // Ensure the control doesn't use anchoring which interferes with manual centering
                PlayLogo.Anchor = AnchorStyles.None;

                int x = Math.Max(0, (this.ClientSize.Width - PlayLogo.Width) / 2);
                int y = Math.Max(0, (this.ClientSize.Height - PlayLogo.Height) / 2);
                PlayLogo.Location = new Point(x, y);
                PlayLogo.BringToFront();
            }
            catch { }
        }

        public SignIn()
        {
            //Define WV2 User Data
            string userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\UserData\WV\";
            if (!Directory.Exists(userDataFolder))
            {
                Directory.CreateDirectory(userDataFolder);
            }
            Properties.Settings.Default.hasWVSetup = false;

            //Define window
            InitializeComponent();
            InitDiscord();
            EnableDarkTitleBar();

            if (Properties.Settings.Default.hasWVSetup == false) { WebView2.Visible = false; PlayLogo.Visible = true; }

            if (Properties.Settings.Default.isMaximised == "TRUE")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.Height = Properties.Settings.Default.windowHeight;
                this.Width = Properties.Settings.Default.windowWidth;
            }
                
            MenuStrip.Renderer = new DarkMenuRenderer();
            PinsContextMenu.Renderer = new DarkMenuRenderer();
            WebControlContextMenu.Renderer = new DarkMenuRenderer();
            ModsContextMenu.Renderer = new DarkMenuRenderer();

            //Load user preferences from settings INI file if exists.
            string SettingsINI = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\settings.ini";
            if (File.Exists(SettingsINI))
            {
                SettingsProcessing.LoadFile(SettingsINI, RichTextBoxStreamType.PlainText);

                foreach (string line in SettingsProcessing.Lines)
                {
                    if (line.StartsWith("$mcdir=")) { Settings.Default.LaunchMinecraft = line.Replace("$mcdir=", null); }
                    if (line.StartsWith("$checkupdates=")) { Settings.Default.CheckUpdates = line.Replace("$checkupdates=", null); }
                    if (line.StartsWith("$currentmp=")) { Settings.Default.CurrentModpack = line.Replace("$currentmp=", null); }
                    if (line.StartsWith("$wv2ignored=")) { Settings.Default.wv2ignored = line.Replace("$wv2ignored=", null); }
                    Settings.Default.Save();
                }
            }
            else
            {
                //file not yet generated, generates on first close
            }

            //Load user pins - if exists.
            string UserPins = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\pins.json";
            List<Pin> pins;

            if (!File.Exists(UserPins))
            {
                // Initialize default pins
                pins = new List<Pin>
                    {
                        new Pin { Name = "TBPlay Newsfeed", Url = "https://play.tbp.zone" },
                        new Pin { Name = "TBPlay World Map", Url = "http://play.crutionix.com:8100/" }
                    };

                // Save to file
                string json = System.Text.Json.JsonSerializer.Serialize(pins, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(UserPins, json);
            }
            else
            {
                // Load existing pins
                string json = File.ReadAllText(UserPins);
                pins = System.Text.Json.JsonSerializer.Deserialize<List<Pin>>(json) ?? new List<Pin>();
            }

            string faviconFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"RWE Labs\TBP\pins.imagelibrary"
                );
            if (!Directory.Exists(faviconFolder)){ Directory.CreateDirectory(faviconFolder); }


            PopulatePinsMenuAsync(pins);

            //Set current modpack
            if (Settings.Default.CurrentModpack == "undefined")
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
                    ModsProcessing.LoadFile(Application.ExecutablePath.Replace("TBP Dashboard.exe", "origins_season1_modlist.txt"), RichTextBoxStreamType.PlainText);
                    int Num = 0;
                    foreach (string filePath in Directory.GetFiles(modsPath))
                    {
                        string fn = Path.GetFileName(filePath);

                        if (ModsProcessing.Text.Contains(fn))
                        {
                            Num = Num + 1;
                            if (Num > 30)
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
            switch (Properties.Settings.Default.CurrentModpack as string)
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
        }
              
        public static DiscordRpcClient client;

        private void InitDiscord()
        {
            client = new DiscordRpcClient(Properties.discord.Default.DiscordAppID);

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine($"Connected to Discord as {e.User.Username}");
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Presence updated!");
            };

            // Connect
            client.Initialize();

            // Set rich presence
            client.SetPresence(new RichPresence()
            {
                Details = "In the launcher...",
                State = "Browsing News and Events",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "tbplay",
                    LargeImageText = "News and Events | TBP",
                    SmallImageKey = "tbplay",
                    SmallImageText = "via TBPlay"
                },
                Buttons = new Button[]
                {
                    new Button() { Label = "Open TBPlay", Url = "https://tbp.crutionix.com/play/?action=open" }
                }
            });

            Console.Write("Starting Java Detection on 30s Intervals.");
            checkforJavaRPC.Start();
        }

        public class Pin
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        private async Task PopulatePinsMenuAsync(List<Pin> pins)
        {
            PinsContextMenu.Items.Clear();

            foreach (var pin in pins)
            {
                ToolStripMenuItem item = await CreatePinMenuItemAsync(pin);
                PinsContextMenu.Items.Add(item);
            }
        }

        private async Task<ToolStripMenuItem> CreatePinMenuItemAsync(Pin pin)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(pin.Name);
            item.Click += (s, e) => WebView2.Source = new Uri(pin.Url);

            if (pin.Name != "TBPlay Newsfeed" && pin.Name != "TBPlay World Map")
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                contextMenu.Renderer = new DarkMenuRenderer();
                ToolStripMenuItem visitItem = new ToolStripMenuItem("Visit Pin");
                visitItem.Image = Resources.icons8_play_32; ;
                visitItem.Click += (s, e) => WebView2.Source = new Uri(pin.Url);
                ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Pin");
                deleteItem.Image = Resources.icons8_close_window_96__1_;
                deleteItem.Click += (s, e) => DeletePin(pin);
                contextMenu.Items.Add(visitItem);
                contextMenu.Items.Add(deleteItem);
                item.MouseUp += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        contextMenu.Show(Cursor.Position);
                    }
                };
            }

            if (pin.Name == "TBPlay Newsfeed")
            {
                item.Image = Resources.IconSpw; // Convert Icon to Bitmap
            }
            else if (pin.Name == "TBPlay World Map")
            {
                item.Image = Resources.icons8_map_28;
            }
            else if (!string.IsNullOrEmpty(pin.Url))
            {
                try
                {
                    string domain = new Uri(pin.Url).Host;
                    string faviconUrl = $"https://www.google.com/s2/favicons?sz=16&domain={domain}";

                    using (HttpClient client = new HttpClient())
                    {
                        byte[] bytes = await client.GetByteArrayAsync(faviconUrl);
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            Image icon = Image.FromStream(ms);
                            item.Image = new Bitmap(icon, new Size(16, 16));
                        }
                    }
                }
                catch
                {
                    item.Image = Resources.icons8_website_28; // fallback
                }
            }

            return item;
        }



        private async Task<string> GetFaviconBase64FromWebViewAsync(WebView2 webView)
        {
            try
            {
                string script = @"
                    (async function() {
                        let icons = document.querySelectorAll('link[rel*=""icon""]');
                        if (icons.length > 0) {
                            return await new Promise(resolve => {
                                let img = new Image();
                                img.crossOrigin = 'anonymous';
                                img.src = icons[0].href;
                                img.onload = () => {
                                    let canvas = document.createElement('canvas');
                                    canvas.width = img.width;
                                    canvas.height = img.height;
                                    canvas.getContext('2d').drawImage(img, 0, 0);
                                    resolve(canvas.toDataURL('image/png'));
                                };
                                img.onerror = () => resolve(null);
                            });
                        } else {
                            return null;
                        }
                    })();
                ";

                string result = await webView.ExecuteScriptAsync(script);

                if (string.IsNullOrEmpty(result) || result == "null")
                    return null;

                // Remove wrapping quotes from WebView2
                if (result.StartsWith("\"") && result.EndsWith("\""))
                    result = result.Substring(1, result.Length - 2);

                result = result.Replace("\\u0022", "\""); // unescape quotes
                result = result.Replace("\\/", "/");       // unescape slashes

                // Remove "data:image/png;base64," prefix
                int commaIndex = result.IndexOf(',');
                if (commaIndex < 0) return null;
                return result.Substring(commaIndex + 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Keep panel inside client area
            int newX = WebControlPanel.Location.X;
            int newY = WebControlPanel.Location.Y;

            if (newX + WebControlPanel.Width > this.ClientSize.Width)
                newX = this.ClientSize.Width - WebControlPanel.Width;
            if (newX < 0) newX = 0;

            if (newY + WebControlPanel.Height > this.ClientSize.Height)
                newY = this.ClientSize.Height - this.ClientSize.Height; // <-- keep existing logical structure
            if (newY < 0) newY = 0;

            WebControlPanel.Location = new Point(newX, newY);

            // Re-center the PlayLogo whenever the form resizes
            CenterPlayLogo();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void WebControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = WebControlPanel.Location;
        }

        private void WebControlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Point newLocation = Point.Add(dragFormPoint, new Size(diff));

                // clamp X
                if (newLocation.X < 0)
                    newLocation.X = 0;
                if (newLocation.X + WebControlPanel.Width > this.ClientSize.Width)
                    newLocation.X = this.ClientSize.Width - WebControlPanel.Width;

                // clamp Y
                if (newLocation.Y < 0)
                    newLocation.Y = 0;
                if (newLocation.Y + WebControlPanel.Height > this.ClientSize.Height)
                    newLocation.Y = this.ClientSize.Height - WebControlPanel.Height;

                WebControlPanel.Location = newLocation;
            }
        }


        private void WebControlPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        private void EnableDarkTitleBar()
        {
            if (Environment.OSVersion.Version.Major >= 10)
            {
                int useImmersiveDarkMode = 1;
                DwmSetWindowAttribute(this.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useImmersiveDarkMode, sizeof(int));
            }
        }

        private void PreInitializeBrowser()
        {
            if (WebView2 == null)
            {
                return;
            }

            try
            {
                // Ensure initialization completes before using CoreWebView2
                InitializeBrowser().GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                // swallow initialization issues here; downstream guards will handle null
            }
        }

        private async Task InitializeBrowser()
        {
            var userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\TBP\UserData\WV\";
            Directory.CreateDirectory(userDataFolder);

            CoreWebView2Environment env = null;
            try
            {
                env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);
            }
            catch
            {
                // If environment creation fails (e.g., runtime missing), leave env null; EnsureCoreWebView2Async will also fail
            }

            try
            {
                if (WebView2.CoreWebView2 == null)
                {
                    await WebView2.EnsureCoreWebView2Async(env);
                }
            }
            catch
            {
                // Initialization can fail if WebView2 runtime is absent; callers guard on CoreWebView2 null
            }
        }

        private void WebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            //debug box: MessageBox.Show("WebMessageReceived fired!");
            try
            {
                var json = e.WebMessageAsJson;
                dynamic msg = JsonConvert.DeserializeObject(json);

                string action = msg.action ?? "";

                switch (action)
                {
                    case "play":
                        HandlePlay(msg);
                        break;
                    case "download":
                        HandleDownload(msg);
                        break;
                    case "install_fabric":
                        HandleInstallFabric(msg);
                        break;
                    case "pinsmenu":
                        PinsContextMenu.Enabled = true;
                        PinsContextMenu.Show(this, this.PointToClient(Cursor.Position));
                        break;
                    case "settings":
                        Preferences settings = new Preferences();
                        settings.Show();
                        break;
                    case "mcdir":
                        OpenMinecraftDir.PerformClick();
                        break;
                    case "modmenu":
                        ModsContextMenu.Enabled = true;
                        ModsContextMenu.Show(this, this.PointToClient(Cursor.Position));
                        break;
                    case "click":
                        WebView2_MouseClick(sender, null);
                        break;
                    case "update":
                        UpdateDownload download = new UpdateDownload();
                        download.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oops. An issue occured: {ex.Message}");
            }
        }

        private void HandlePlay(dynamic msg)
        {
            string fwd = "";
            string version = "";

            if (msg is string msgString)
            {
                if (msgString == "fromURI")
                {
                    fwd = "https://play.tbp.zone/minecraft/play/";
                }
                // else fwd remains ""
            }
            else
            {
                // dynamic object from WebView
                fwd = msg.fwd ?? "";
                version = msg.version ?? "";
            }

            string MinecraftLocation = Properties.Settings.Default.LaunchMinecraft;
            if (String.IsNullOrEmpty(MinecraftLocation) || String.IsNullOrWhiteSpace(MinecraftLocation))
            {
                FindLauncher();
            }
            else if (MinecraftLocation == Properties.Settings.Default.MSStoreMinecraftLocation)
            {
                LaunchLauncher();
            }
            else
            {
                LaunchLauncher();
            }

            if (!string.IsNullOrEmpty(fwd))
            {
                if (msg.ToString() == "fromURI")
                {
                    string urifwd = "https://play.tbp.zone/minecraft/play/";
                    WebView2.Source = new Uri(urifwd);
                }
                else
                {
                    WebView2.Source = new Uri(fwd);
                }
            }

            try
            {
                if (msg.ToString() == "fromURI")
                {
                    //don't check.
                }
                else
                {
                    CheckMinecraftVersion(version);
                }
            }
            catch
            {
                //
            }

            NaviTimer.Start();
            gameStartTime = DateTime.UtcNow;

            // Set rich presence
            client.SetPresence(new RichPresence()
            {
                Details = "play.crutionix.com:25565",
                State = "Playing on TBP",
                Timestamps = new Timestamps(gameStartTime.Value),
                Party = new Party()
                {
                    ID = "tbp_server",
                    Size = 1,
                    Max = 32
                },
                Assets = new Assets()
                {
                    LargeImageKey = "season4",
                    LargeImageText = "Season 4 | TBP",
                    SmallImageKey = "tbplay",
                    SmallImageText = "via TBPlay"
                },
                Buttons = new Button[]
                {
                    new Button() { Label = "Join them!", Url = "https://tbp.crutionix.com/play/?action=play" }
                }
            }) ;

            RPCUpdate.Start();
        }

        public void CheckMinecraftVersion(string requiredVersion)
        {
            // Path to the .minecraft folder
            string mcPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft"
            );

            string versionsPath = Path.Combine(mcPath, "versions");
            string versionFolder = Path.Combine(versionsPath, requiredVersion);

            if (!Directory.Exists(versionFolder))
            {
                MessageBox.Show(
                    $"You do not have Minecraft version {requiredVersion} installed.\n" +
                    "This is the version required by the server. Please install it in the official launcher before continuing.",
                    "Minecraft Version | TBPlay",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                //MessageBox.Show($"Version {requiredVersion} is installed ✅");
            }
        }

        private void HandleDownload(dynamic msg)
        {
            string type = msg.type;
            string name = msg.name;
            string version = msg.version;
            string url = msg.url;
            string profile = msg.profile ?? "";
            string description = msg.description ?? "";
            string fwd = msg.fwd ?? "";

            Properties.Settings.Default.DownloadItem = url;
            Properties.Settings.Default.Save();

            // UI logic as needed
            if (type == "modpack")
            {
                Properties.Settings.Default.DownloadType = "modpack";
                Properties.Settings.Default.DownloadVersion = version;
                Properties.Settings.Default.DownloadName = name;
                Properties.Settings.Default.Save();
            }
            else if (type == "resourcepack")
            {
                Properties.Settings.Default.DownloadType = "resourcepack";
                Properties.Settings.Default.DownloadVersion = version;
                Properties.Settings.Default.DownloadName = name;
                Properties.Settings.Default.Save();
            }
            else if (type == "world")
            {
                Properties.Settings.Default.DownloadType = "world";
                Properties.Settings.Default.DownloadVersion = version;
                Properties.Settings.Default.DownloadName = name;
                Properties.Settings.Default.Save();
            }

            DoContentInstall.Start();
            //MessageBox.Show(fwd);

            if (!string.IsNullOrEmpty(fwd))
            {
                WebView2.Source = new Uri(fwd);
            }

            NaviTimer.Start();
        }

        private void HandleInstallFabric(dynamic msg)
        {
            string fwd = msg.fwd ?? "";
            string dataPath = Path.GetDirectoryName(Application.ExecutablePath).Replace("TBP Dashboard.exe", null);
            string fabriclocation = Path.Combine(dataPath, "fabric-installer.exe");
            Process.Start(fabriclocation);

            if (!string.IsNullOrEmpty(fwd))
            {
                WebView2.Source = new Uri(fwd);
            }

            NaviTimer.Start();
        }

        private void CheckUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
           {
               this.Text = "Checking for updates... | TBPlay";
           }));
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
                this.Text = "TBPlay [Up-to-Date]";
            }
            else if (e.Error != null)
            {
                this.Text = "TBPlay [Up-to-Date]";

            }
            else
            {
                //Compare current stable version against installed version
                if (Properties.Settings.Default.CVER.Contains(Properties.Settings.Default.Version))
                {
                    this.Text = "TBPlay [Up-to-Date]";
                }
                else
                {
                    // Updates are available
                    this.Text = "TBPlay [Updates Available]";

                    // Ensure CoreWebView2 is ready (initialize earlier in app startup)
                    if (WebView2.CoreWebView2 != null)
                    {
                        string json = "{\"type\":\"update-available\",\"title\":\"Updates Available\",\"message\":\"A new version of TBPlay is ready to download and install. We recommend updating to maintain access to features and content.\"}";
                        WebView2.CoreWebView2.PostWebMessageAsJson(json);
                    }
                    else
                    {
                        FallbackUpdateTimer.Start();
                    }
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
            DialogResult dr = MessageBox.Show("There are updates available for TBPlay. Would you like to download and install the latest version?", "Update | TBPlay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private async void WebView2_CoreWebView2InitializationCompletedAsync(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e == null || !e.IsSuccess || WebView2.CoreWebView2 == null)
            {
                // Runtime missing or init failed; avoid null refs and let fallback timers handle UI messaging
                return;
            }

            WebView2.CoreWebView2.Settings.IsStatusBarEnabled = false;
            WebView2.CoreWebView2.Settings.IsWebMessageEnabled = true;
            WebView2.CoreWebView2.WebMessageReceived += WebView2_WebMessageReceived;

            try
            {
                await WebView2.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(@"
                    document.addEventListener('click', () => {
                        chrome.webview.postMessage({ action: 'click' });
                    });
                ");
            }
            catch { }

            if (Properties.Settings.Default.CheckUpdates == "TRUE")
            {
                StartTimer.Start();
            }

            // Honor tbplay:// launch flags once WV2 is ready
            try
            {
                switch (Properties.Settings.Default.launchFlag as string)
                {
                    case "play":
                        HandlePlay("fromURI");
                        break;
                    case "map":
                        WebView2.Source = new Uri("http://play.crutionix.com:8100/");
                        break;
                    case "url":
                        string postId = Properties.Settings.Default.postID;
                        if (!string.IsNullOrEmpty(postId))
                        {
                            string url = $"https://play.tbp.zone/minecraft?post=post{postId}";
                            WebView2.Source = new Uri(url);
                        }
                        break;
                }

                // Do NOT make WebView visible here; wait until play.tbp.zone has finished first navigation.
                // Properties.Settings.Default.hasWVSetup will be set when the first site (play.tbp.zone) loads.
            }
            catch { }
        }

        private bool discordUserSavedThisSession = false;
        private async void WebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (Properties.Settings.Default.hasWVSetup == false) { /* Do not unhide WebView here; wait for the play.tbp.zone navigation */ }

            //MessageBox.Show("NavigationCompleted fired!");
            if (WebView2.CanGoForward) { ForwardToolButton.Enabled = true; forwardToolStripMenuItem.Enabled = true; } else { ForwardToolButton.Enabled = false; forwardToolStripMenuItem.Enabled = false; }
            if (WebView2.CanGoBack) { BackToolButton.Enabled = true; backToolStripMenuItem.Enabled = true; } else { BackToolButton.Enabled = false; backToolStripMenuItem.Enabled = false; }

            Uri currentUri2 = new Uri(((WebView2)sender).Source.ToString());
            //MessageBox.Show("URL: " + currentUri2.ToString());

            Uri checkURL = new Uri(((WebView2)sender).Source.ToString());

            // Only show the WebView and hide the play logo after the first successful navigation to play.tbp.zone
            try
            {
                if (!firstPlaySiteLoaded && checkURL.Host.Equals("play.tbp.zone", StringComparison.OrdinalIgnoreCase))
                {
                    WebView2.Visible = true;
                    PlayLogo.Visible = false;
                    Properties.Settings.Default.hasWVSetup = true;
                    Properties.Settings.Default.Save();
                    firstPlaySiteLoaded = true;
                }
            }
            catch { }

            ToggleWebControlPanel(checkURL);
        }

        private void ToggleWebControlPanel(Uri currentUri)
        {
            if (currentUri.Host.Equals("play.tbp.zone", StringComparison.OrdinalIgnoreCase))
            {
                WebControlPanel.Visible = false;
                WebControlPanel.BringToFront();
            }
            else
            {
                WebControlPanel.Visible = true;
                WebControlPanel.BringToFront();
            }
        }

        private void WebControlPanel_Paint(object sender, PaintEventArgs e)
        {
            int shadowSize = 3; // how "thick" the shadow is
            for (int i = shadowSize; i >= 1; i--)
            {
                int alpha = (int)(40.0 * (i / (float)shadowSize)); // fade outward
                using (Pen pen = new Pen(Color.FromArgb(alpha, 0, 0, 0), 1))
                {
                    e.Graphics.DrawRectangle(
                        pen,
                        new Rectangle(i - 1, i - 1,
                        WebControlPanel.Width - ((i - 1) * 2),
                        WebControlPanel.Height - ((i - 1) * 2))
                    );
                }
            }
        }

        private void WebView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {

        }

        private void FindLauncher()
        {
            //Check for Win32 Install
            string InstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            string InstallPath10 = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            string BackupInstallpath = @"C:\Program Files (x86)\Minecraft Launcher\MinecraftLauncher.exe";


            if (InstallPath != null)
            {
                if (File.Exists(InstallPath + @"MinecraftLauncher.exe"))
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
            Properties.Settings.Default.launchFlag = null;
            Properties.Settings.Default.hasWVSetup = false;
            if(this.WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.isMaximised = "TRUE";
            }
            else
            {
                Properties.Settings.Default.isMaximised = "FALSE";
                Properties.Settings.Default.windowHeight = this.Height;
                Properties.Settings.Default.windowWidth = this.Width;
            }
            Properties.Settings.Default.Save();

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
            SettingsProcessing.AppendText("$wv2ignored=" + Settings.Default.wv2ignored + Environment.NewLine);
            SettingsProcessing.SaveFile(SettingsINI, RichTextBoxStreamType.PlainText);

            RPCUpdate.Stop();
            if (client != null)
            {
                try
                {
                    client.ClearPresence();
                    client.Dispose();
                }
                catch
                {
                    //
                }
            }

            Application.Exit();
        }

        private void DoContentInstall_Tick(object sender, EventArgs e)
        {
            DoContentInstall.Stop();
            DownloadContent dc = new DownloadContent();
            dc.Show();
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
            if (WebView2.CanGoBack) { WebView2.GoBack(); }
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            if (WebView2.CanGoForward) { WebView2.GoForward(); }
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

            // If initialization succeeded, ensure a default navigation occurs
            if (WebView2 != null && WebView2.CoreWebView2 != null)
            {
                switch (Properties.Settings.Default.launchFlag as string)
                {
                    case "play":
                        HandlePlay("");
                        break;
                    case "map":
                        WebView2.Source = new Uri("http://play.crutionix.com:8100/");
                        break;
                    case "url":
                        string postId = Properties.Settings.Default.postID;
                        string url = $"https://play.tbp.zone/minecraft?post=post_{postId}";
                        WebView2.Source = new Uri(url);
                        break;
                }

                // Do NOT unhide WebView here; wait for play.tbp.zone navigation to finish.
            }
            else
            {
                // Initialization did not complete; inform user
                // This can happen if WebView2 Runtime is disabled by policy or missing
                try
                {
                    this.Text = "TBPlay";
                }
                catch { }
            }

            // Also ensure PlayLogo is centered after load
            CenterPlayLogo();
        }

        private void OpenMinecraftDir_Click(object sender, EventArgs e)
        {
            try
            {
                string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Process.Start(dataPath + @"\.minecraft");
            }
            catch (Exception ex)
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
            WebView2.Source = new Uri("https://play.tbp.zone/policies/");
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

        private void NaviTimer_Tick(object sender, EventArgs e)
        {
            NaviTimer.Stop();
        }

        private void WebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {

        }

        private void RefreshToolButton_Click(object sender, EventArgs e)
        {

        }

        private void HomeToolButton_Click(object sender, EventArgs e)
        {
            WebView2.Source = new Uri("https://play.tbp.zone/");
        }

        private bool WebControlPanelCollapsed = false;

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebControlPanel.Size = new Size(36, 54);
            WebControlPanelCollapsed = true;
            WebControlPanel.Invalidate();
        }

        private void WebControlContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (WebControlPanelCollapsed == true)
            {
                collapseToolStripMenuItem.Visible = false;
                expandToolStripMenuItem.Visible = true;
            }
            else if (WebControlPanelCollapsed == false)
            {
                collapseToolStripMenuItem.Visible = true;
                expandToolStripMenuItem.Visible = false;
            }
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebControlPanel.Size = new Size(260, 54);
            WebControlPanelCollapsed = false;
            WebControlPanel.Invalidate();
        }

        private async void SavePinToolButton_Click(object sender, EventArgs e)
        {
            string currentUrl = WebView2.Source.ToString();
            string defaultName = WebView2.CoreWebView2.DocumentTitle;

            // Get favicon as base64 from WebView2
            string faviconBase64 = await GetFaviconBase64FromWebViewAsync(WebView2);

            using (SavePinForm form = new SavePinForm(defaultName, currentUrl, faviconBase64))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await SavePinAsync(form.PinName, form.PinUrl, form.FaviconBase64);
                }
            }
        }

        private Image Base64ToImage(string base64)
        {
            if (string.IsNullOrEmpty(base64))
                return null;

            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }


        private async Task SavePinAsync(string name, string url, string faviconBase64)
        {
            string userPinsFile = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"RWE Labs\TBP\pins.json"
            );
            Directory.CreateDirectory(Path.GetDirectoryName(userPinsFile));

            List<Pin> pins = File.Exists(userPinsFile)
                ? System.Text.Json.JsonSerializer.Deserialize<List<Pin>>(File.ReadAllText(userPinsFile)) ?? new List<Pin>()
                : new List<Pin>();

            Pin newPin = new Pin
            {
                Name = name,
                Url = url,
            };

            pins.Add(newPin);

            string json = System.Text.Json.JsonSerializer.Serialize(pins, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(userPinsFile, json);

            // Add the new pin to the existing menu instead of repopulating entire menu
            await AddSinglePinToMenuAsync(newPin);
        }

        private async Task AddSinglePinToMenuAsync(Pin pin)
        {
            ToolStripMenuItem item = await CreatePinMenuItemAsync(pin);
            PinsContextMenu.Items.Add(item);
        }

        private void DeletePin(Pin pinToDelete)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the pin: '{pinToDelete.Name}'?",
                "Delete Pin | TBPlay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string userPinsFile = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    @"RWE Labs\TBP\pins.json"
                );

                if (File.Exists(userPinsFile))
                {
                    List<Pin> pins = System.Text.Json.JsonSerializer.Deserialize<List<Pin>>(File.ReadAllText(userPinsFile)) ?? new List<Pin>();
                    pins.RemoveAll(p => p.Name == pinToDelete.Name && p.Url == pinToDelete.Url);

                    string json = System.Text.Json.JsonSerializer.Serialize(pins, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(userPinsFile, json);

                    // Remove the item from the menu
                    for (int i = PinsContextMenu.Items.Count - 1; i >= 0; i--)
                    {
                        if (PinsContextMenu.Items[i] is ToolStripMenuItem menuItem && 
                            menuItem.Text == pinToDelete.Name)
                        {
                            PinsContextMenu.Items.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private async void RPCUpdate_Tick(object sender, EventArgs e)
        {
            Console.Write("RPCUpdate has been ticked. Pinging for an update.");

            // Ping TBP
            var ms = await Task.Run(() => new MineStat("play.crutionix.com", 25565));
            //MineStat ms = new MineStat("play.crutionix.com", 25565);

            int online = 0;
            int max = 32;

            if (ms.ServerUp)
            {
                online = ms.CurrentPlayersInt;
                max = ms.MaximumPlayersInt;
            }

            // Update Discord presence
            client.SetPresence(new RichPresence()
            {
                Details = "play.crutionix.com:25565",
                State = ms.ServerUp ? "Playing on TBP" : "Server Offline",
                Timestamps = gameStartTime.HasValue ? new Timestamps(gameStartTime.Value) : null,
                Party = new Party()
                {
                    ID = "tbp_server",
                    Size = online,
                    Max = max
                },
                Assets = new Assets()
                {
                    LargeImageKey = "season4",
                    LargeImageText = "Season 4 | TBP",
                    SmallImageKey = "tbplay",
                    SmallImageText = "via TBPlay"
                },
                Buttons = new Button[]
                {
                    new Button() { Label = "Join them!", Url = "https://tbp.crutionix.com/play/?action=play" }
                }
            });

            Console.WriteLine("Updating an RPC: " + online.ToString() + " online players of " + max.ToString());
        }

        private async void checkforJavaRPC_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Java detection has been ticked.");
            await CheckMinecraftAndUpdateRPC();
        }

        private async Task CheckMinecraftAndUpdateRPC()
        {
            Console.Write("Checking if Minecraft is running...");
            var JavaMinecraft = Process.GetProcessesByName("javaw")
                .FirstOrDefault(p => p.MainWindowTitle.Contains("Minecraft"));
            bool minecraftNowRunning = JavaMinecraft != null;

            if(minecraftNowRunning && !isMinecraftRunning)
            {
                if (RPCUpdate.Enabled)
                {
                    //
                    Console.WriteLine("Minecraft was detected, with RPC already set from HandlePlay. Doing nothing.");
                }
                else
                {
                    Console.WriteLine("Minecraft was detected, but RPC was not set from HandlePlay. Starting RPCUpdate.");
                    RPCUpdate.Start();
                }
            }
            else
            {
                if (RPCUpdate.Enabled)
                {
                    RPCUpdate.Stop();
                    Console.WriteLine("Minecraft is not running, but RPCUpdate is setting the RPC. Stopping RPCUpdate.");
                }

                client.SetPresence(new RichPresence()
                {
                    Details = "In the launcher...",
                    State = "Browsing News and Events",
                    Assets = new Assets()
                    {
                        LargeImageKey = "tbplay",
                        LargeImageText = "News and Events | TBP",
                        SmallImageKey = "tbplay",
                        SmallImageText = "via TBPlay"
                    },
                    Buttons = new Button[]
                    {
                        new Button() { Label = "Open TBPlay", Url = "https://tbp.crutionix.com/play/?action=open" }
                    }
                });
                Console.WriteLine("Minecraft is not running. Setting a launcher RPC.");
            }
        }

        private void WebView2_MouseClick(object sender, MouseEventArgs e)
        {
            //Hide Pins Menu if Opened.
            if (PinsContextMenu.Enabled == true)
            {
                PinsContextMenu.Hide();
                PinsContextMenu.Enabled = false;
            }
            if (ModsContextMenu.Enabled == true)
            {
                ModsContextMenu.Hide();
                ModsContextMenu.Enabled = false;
            }
        }

        private void FallbackUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (WebView2.CoreWebView2 == null)
            {
                // If WebView2 isn't ready, skip posting the message to avoid null refs
                return;
            }

            string json = "{\"type\":\"update-available\",\"title\":\"Updates Available\",\"message\":\"A new version of TBPlay is ready to download and install. We recommend updating to maintain access to features and content.\"}";
            WebView2.CoreWebView2.PostWebMessageAsJson(json);
        }
    }
}
