namespace TBP_Dashboard
{
    partial class SignIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.WebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DiscordSwitchAccounts = new System.Windows.Forms.ToolStripDropDownButton();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.UpdateHeader = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CheckUpdates = new System.ComponentModel.BackgroundWorker();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.WebView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.DoContentInstall = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MainIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Maximise = new System.Windows.Forms.ToolStripMenuItem();
            this.Minimise = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenPrivacyPolicy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TestFeatures = new System.Windows.Forms.ToolStripMenuItem();
            this.testDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModManager = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMinecraftDir = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.InstallUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.DismissUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.pinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modpackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MP_Vanilla = new System.Windows.Forms.ToolStripMenuItem();
            this.MP_Origins1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MP_Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ModManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MCATimer = new System.Windows.Forms.Timer(this.components);
            this.SettingsProcessing = new System.Windows.Forms.RichTextBox();
            this.ModsProcessing = new System.Windows.Forms.RichTextBox();
            this.NaviTimer = new System.Windows.Forms.Timer(this.components);
            this.LazyLoader = new System.Windows.Forms.PictureBox();
            this.WebControlPanel = new System.Windows.Forms.Panel();
            this.WebControlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePinToolButton = new System.Windows.Forms.Button();
            this.HomeToolButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BackToolButton = new System.Windows.Forms.Button();
            this.ForwardToolButton = new System.Windows.Forms.Button();
            this.RefreshToolButton = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RPCUpdate = new System.Windows.Forms.Timer(this.components);
            this.checkforJavaRPC = new System.Windows.Forms.Timer(this.components);
            this.discordSSOTerminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.LoadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebView2)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LazyLoader)).BeginInit();
            this.WebControlPanel.SuspendLayout();
            this.WebControlContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // WebView
            // 
            this.WebView.AllowExternalDrop = true;
            this.WebView.CreationProperties = null;
            this.WebView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.WebView.Location = new System.Drawing.Point(0, 0);
            this.WebView.Name = "WebView";
            this.WebView.Size = new System.Drawing.Size(32, 26);
            this.WebView.TabIndex = 0;
            this.WebView.Visible = false;
            this.WebView.ZoomFactor = 1D;
            this.WebView.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.WebView_CoreWebView2InitializationCompleted);
            this.WebView.NavigationStarting += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs>(this.WebView_NavigationStarting);
            this.WebView.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.WebView_NavigationCompleted);
            this.WebView.SourceChanged += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs>(this.WebView_SourceChanged);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.DiscordSwitchAccounts});
            this.StatusStrip.Location = new System.Drawing.Point(0, 662);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1048, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            this.StatusStrip.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.ForeColor = System.Drawing.Color.Gray;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(74, 17);
            this.StatusLabel.Text = "Please wait...";
            // 
            // DiscordSwitchAccounts
            // 
            this.DiscordSwitchAccounts.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DiscordSwitchAccounts.Image = global::TBP_Dashboard.Properties.Resources.DiscordLogoPng;
            this.DiscordSwitchAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DiscordSwitchAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DiscordSwitchAccounts.Margin = new System.Windows.Forms.Padding(25, 2, 0, 0);
            this.DiscordSwitchAccounts.Name = "DiscordSwitchAccounts";
            this.DiscordSwitchAccounts.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.DiscordSwitchAccounts.ShowDropDownArrow = false;
            this.DiscordSwitchAccounts.Size = new System.Drawing.Size(135, 20);
            this.DiscordSwitchAccounts.Text = "Switch Accounts";
            this.DiscordSwitchAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.DiscordSwitchAccounts.Visible = false;
            this.DiscordSwitchAccounts.Click += new System.EventHandler(this.DiscordSwitchAccounts_Click);
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LoadingPanel.Controls.Add(this.UpdateHeader);
            this.LoadingPanel.Controls.Add(this.pictureBox2);
            this.LoadingPanel.Controls.Add(this.pictureBox1);
            this.LoadingPanel.Location = new System.Drawing.Point(238, 90);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(581, 439);
            this.LoadingPanel.TabIndex = 2;
            this.LoadingPanel.Visible = false;
            // 
            // UpdateHeader
            // 
            this.UpdateHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateHeader.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateHeader.ForeColor = System.Drawing.Color.DarkGray;
            this.UpdateHeader.Location = new System.Drawing.Point(3, 314);
            this.UpdateHeader.Name = "UpdateHeader";
            this.UpdateHeader.Size = new System.Drawing.Size(571, 25);
            this.UpdateHeader.TabIndex = 2;
            this.UpdateHeader.Text = "Checking for updates...";
            this.UpdateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UpdateHeader.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::TBP_Dashboard.Properties.Resources.TBPlayText;
            this.pictureBox2.Location = new System.Drawing.Point(3, 370);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(571, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::TBP_Dashboard.Properties.Resources._2851;
            this.pictureBox1.Location = new System.Drawing.Point(3, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CheckUpdates
            // 
            this.CheckUpdates.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckUpdates_DoWork);
            this.CheckUpdates.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CheckUpdates_RunWorkerCompleted);
            // 
            // StartTimer
            // 
            this.StartTimer.Interval = 2245;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // WebView2
            // 
            this.WebView2.AllowExternalDrop = true;
            this.WebView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebView2.CreationProperties = null;
            this.WebView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.WebView2.Location = new System.Drawing.Point(0, 32);
            this.WebView2.Name = "WebView2";
            this.WebView2.Size = new System.Drawing.Size(1049, 666);
            this.WebView2.TabIndex = 3;
            this.WebView2.Visible = false;
            this.WebView2.ZoomFactor = 1D;
            this.WebView2.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.WebView2_CoreWebView2InitializationCompleted);
            this.WebView2.NavigationStarting += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs>(this.WebView2_NavigationStarting);
            this.WebView2.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.WebView2_NavigationCompleted);
            this.WebView2.SourceChanged += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs>(this.WebView2_SourceChanged);
            // 
            // DoContentInstall
            // 
            this.DoContentInstall.Interval = 1000;
            this.DoContentInstall.Tick += new System.EventHandler(this.DoContentInstall_Tick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainIcon,
            this.FileMenu,
            this.ViewMenu,
            this.ToolsMenu,
            this.UpdateNotification,
            this.pinsToolStripMenuItem,
            this.modpackToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1048, 32);
            this.MenuStrip.TabIndex = 4;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.Visible = false;
            // 
            // MainIcon
            // 
            this.MainIcon.AutoSize = false;
            this.MainIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MainIcon.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.MainIcon.Image = global::TBP_Dashboard.Properties.Resources.IconSpw;
            this.MainIcon.Name = "MainIcon";
            this.MainIcon.Size = new System.Drawing.Size(28, 28);
            this.MainIcon.Click += new System.EventHandler(this.MainIcon_DoubleClick);
            // 
            // FileMenu
            // 
            this.FileMenu.AutoSize = false;
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenSettings,
            this.toolStripSeparator1,
            this.Exit});
            this.FileMenu.ForeColor = System.Drawing.Color.White;
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 26);
            this.FileMenu.Text = "File";
            // 
            // OpenSettings
            // 
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(135, 22);
            this.OpenSettings.Text = "Settings";
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // Exit
            // 
            this.Exit.Image = global::TBP_Dashboard.Properties.Resources.icons8_close_window_96__1_;
            this.Exit.Name = "Exit";
            this.Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.Exit.Size = new System.Drawing.Size(135, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.AutoSize = false;
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Maximise,
            this.Minimise,
            this.toolStripSeparator4,
            this.backToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.toolStripSeparator5,
            this.OpenPrivacyPolicy});
            this.ViewMenu.ForeColor = System.Drawing.Color.White;
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 26);
            this.ViewMenu.Text = "View";
            // 
            // Maximise
            // 
            this.Maximise.Name = "Maximise";
            this.Maximise.ShortcutKeyDisplayString = "Ctrl+Plus";
            this.Maximise.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.Maximise.Size = new System.Drawing.Size(190, 22);
            this.Maximise.Text = "Maximise";
            this.Maximise.Click += new System.EventHandler(this.Maximise_Click);
            // 
            // Minimise
            // 
            this.Minimise.Name = "Minimise";
            this.Minimise.ShortcutKeyDisplayString = "Ctrl+Minus";
            this.Minimise.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.Minimise.Size = new System.Drawing.Size(190, 22);
            this.Minimise.Text = "Minimise";
            this.Minimise.Click += new System.EventHandler(this.Minimise_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(187, 6);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Image = global::TBP_Dashboard.Properties.Resources.icons8_back_28;
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.Back_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Image = global::TBP_Dashboard.Properties.Resources.icons8_forward_28;
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.Forward_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(187, 6);
            // 
            // OpenPrivacyPolicy
            // 
            this.OpenPrivacyPolicy.Name = "OpenPrivacyPolicy";
            this.OpenPrivacyPolicy.Size = new System.Drawing.Size(190, 22);
            this.OpenPrivacyPolicy.Text = "Privacy Policy";
            this.OpenPrivacyPolicy.Click += new System.EventHandler(this.OpenPrivacyPolicy_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.AutoSize = false;
            this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Refresh,
            this.toolStripSeparator2,
            this.TestFeatures,
            this.OpenMinecraftDir});
            this.ToolsMenu.ForeColor = System.Drawing.Color.White;
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(46, 26);
            this.ToolsMenu.Text = "Tools";
            // 
            // Refresh
            // 
            this.Refresh.Image = global::TBP_Dashboard.Properties.Resources.icons8_refresh_28;
            this.Refresh.Name = "Refresh";
            this.Refresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.Refresh.Size = new System.Drawing.Size(208, 22);
            this.Refresh.Text = "Refresh";
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // TestFeatures
            // 
            this.TestFeatures.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testDownloadToolStripMenuItem,
            this.OpenModManager,
            this.discordSSOTerminateToolStripMenuItem});
            this.TestFeatures.Name = "TestFeatures";
            this.TestFeatures.Size = new System.Drawing.Size(208, 22);
            this.TestFeatures.Text = "Beta Features";
            this.TestFeatures.Visible = false;
            // 
            // testDownloadToolStripMenuItem
            // 
            this.testDownloadToolStripMenuItem.Name = "testDownloadToolStripMenuItem";
            this.testDownloadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.testDownloadToolStripMenuItem.Text = "TestDownload";
            this.testDownloadToolStripMenuItem.Click += new System.EventHandler(this.testDownloadToolStripMenuItem_Click);
            // 
            // OpenModManager
            // 
            this.OpenModManager.Name = "OpenModManager";
            this.OpenModManager.Size = new System.Drawing.Size(186, 22);
            this.OpenModManager.Text = "ModManager";
            this.OpenModManager.Click += new System.EventHandler(this.OpenModManager_Click);
            // 
            // OpenMinecraftDir
            // 
            this.OpenMinecraftDir.Name = "OpenMinecraftDir";
            this.OpenMinecraftDir.Size = new System.Drawing.Size(208, 22);
            this.OpenMinecraftDir.Text = "Open Minecraft Directory";
            this.OpenMinecraftDir.Click += new System.EventHandler(this.OpenMinecraftDir_Click);
            // 
            // UpdateNotification
            // 
            this.UpdateNotification.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UpdateNotification.AutoSize = false;
            this.UpdateNotification.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstallUpdate,
            this.DismissUpdate});
            this.UpdateNotification.ForeColor = System.Drawing.Color.White;
            this.UpdateNotification.Image = global::TBP_Dashboard.Properties.Resources.UpdatesIcon;
            this.UpdateNotification.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.UpdateNotification.Name = "UpdateNotification";
            this.UpdateNotification.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.UpdateNotification.Size = new System.Drawing.Size(122, 26);
            this.UpdateNotification.Text = "Updates Available";
            this.UpdateNotification.Visible = false;
            // 
            // InstallUpdate
            // 
            this.InstallUpdate.Image = global::TBP_Dashboard.Properties.Resources.icons8_tick_box_96;
            this.InstallUpdate.Name = "InstallUpdate";
            this.InstallUpdate.Size = new System.Drawing.Size(133, 22);
            this.InstallUpdate.Text = "Install Now";
            this.InstallUpdate.Click += new System.EventHandler(this.InstallUpdate_Click);
            // 
            // DismissUpdate
            // 
            this.DismissUpdate.Image = global::TBP_Dashboard.Properties.Resources.icons8_close_window_96__1_;
            this.DismissUpdate.Name = "DismissUpdate";
            this.DismissUpdate.Size = new System.Drawing.Size(133, 22);
            this.DismissUpdate.Text = "Dismiss";
            this.DismissUpdate.Click += new System.EventHandler(this.DismissUpdate_Click);
            // 
            // pinsToolStripMenuItem
            // 
            this.pinsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pinsToolStripMenuItem.Image = global::TBP_Dashboard.Properties.Resources.icons8_pin_28;
            this.pinsToolStripMenuItem.Name = "pinsToolStripMenuItem";
            this.pinsToolStripMenuItem.Size = new System.Drawing.Size(57, 28);
            this.pinsToolStripMenuItem.Text = "Pins";
            // 
            // modpackToolStripMenuItem
            // 
            this.modpackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MP_Vanilla,
            this.MP_Origins1,
            this.MP_Custom,
            this.toolStripSeparator3,
            this.ModManagerMenuItem});
            this.modpackToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modpackToolStripMenuItem.Image = global::TBP_Dashboard.Properties.Resources.Potato;
            this.modpackToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.modpackToolStripMenuItem.Name = "modpackToolStripMenuItem";
            this.modpackToolStripMenuItem.Size = new System.Drawing.Size(121, 28);
            this.modpackToolStripMenuItem.Text = "Active Modpack";
            // 
            // MP_Vanilla
            // 
            this.MP_Vanilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MP_Vanilla.CheckOnClick = true;
            this.MP_Vanilla.ForeColor = System.Drawing.Color.White;
            this.MP_Vanilla.Name = "MP_Vanilla";
            this.MP_Vanilla.Size = new System.Drawing.Size(242, 22);
            this.MP_Vanilla.Text = "No Modpack (Vanilla Minecraft)";
            this.MP_Vanilla.Click += new System.EventHandler(this.VanillaMPChosen);
            // 
            // MP_Origins1
            // 
            this.MP_Origins1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MP_Origins1.CheckOnClick = true;
            this.MP_Origins1.ForeColor = System.Drawing.Color.White;
            this.MP_Origins1.Name = "MP_Origins1";
            this.MP_Origins1.Size = new System.Drawing.Size(242, 22);
            this.MP_Origins1.Text = "TBP Origins (Season 1)";
            this.MP_Origins1.Click += new System.EventHandler(this.OriginsMPChosen);
            // 
            // MP_Custom
            // 
            this.MP_Custom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MP_Custom.CheckOnClick = true;
            this.MP_Custom.ForeColor = System.Drawing.Color.White;
            this.MP_Custom.Name = "MP_Custom";
            this.MP_Custom.Size = new System.Drawing.Size(242, 22);
            this.MP_Custom.Text = "Custom Modpack";
            this.MP_Custom.Click += new System.EventHandler(this.CustomMPChosen);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(239, 6);
            // 
            // ModManagerMenuItem
            // 
            this.ModManagerMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ModManagerMenuItem.ForeColor = System.Drawing.Color.White;
            this.ModManagerMenuItem.Image = global::TBP_Dashboard.Properties.Resources.InstallModpack;
            this.ModManagerMenuItem.Name = "ModManagerMenuItem";
            this.ModManagerMenuItem.Size = new System.Drawing.Size(242, 22);
            this.ModManagerMenuItem.Text = "Mod Manager";
            this.ModManagerMenuItem.Click += new System.EventHandler(this.OpenModManager_Click);
            // 
            // MCATimer
            // 
            this.MCATimer.Interval = 5000;
            this.MCATimer.Tick += new System.EventHandler(this.MCATimer_Tick);
            // 
            // SettingsProcessing
            // 
            this.SettingsProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SettingsProcessing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SettingsProcessing.Location = new System.Drawing.Point(12, 32);
            this.SettingsProcessing.Name = "SettingsProcessing";
            this.SettingsProcessing.Size = new System.Drawing.Size(381, 300);
            this.SettingsProcessing.TabIndex = 5;
            this.SettingsProcessing.Text = "";
            this.SettingsProcessing.Visible = false;
            // 
            // ModsProcessing
            // 
            this.ModsProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ModsProcessing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModsProcessing.Location = new System.Drawing.Point(118, 65);
            this.ModsProcessing.Name = "ModsProcessing";
            this.ModsProcessing.Size = new System.Drawing.Size(482, 317);
            this.ModsProcessing.TabIndex = 6;
            this.ModsProcessing.Text = "";
            this.ModsProcessing.Visible = false;
            // 
            // NaviTimer
            // 
            this.NaviTimer.Interval = 2500;
            this.NaviTimer.Tick += new System.EventHandler(this.NaviTimer_Tick);
            // 
            // LazyLoader
            // 
            this.LazyLoader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LazyLoader.Image = global::TBP_Dashboard.Properties.Resources._294__1_;
            this.LazyLoader.Location = new System.Drawing.Point(386, 10);
            this.LazyLoader.Name = "LazyLoader";
            this.LazyLoader.Size = new System.Drawing.Size(259, 14);
            this.LazyLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LazyLoader.TabIndex = 7;
            this.LazyLoader.TabStop = false;
            this.LazyLoader.Visible = false;
            // 
            // WebControlPanel
            // 
            this.WebControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.WebControlPanel.ContextMenuStrip = this.WebControlContextMenu;
            this.WebControlPanel.Controls.Add(this.SavePinToolButton);
            this.WebControlPanel.Controls.Add(this.HomeToolButton);
            this.WebControlPanel.Controls.Add(this.pictureBox3);
            this.WebControlPanel.Controls.Add(this.BackToolButton);
            this.WebControlPanel.Controls.Add(this.ForwardToolButton);
            this.WebControlPanel.Controls.Add(this.RefreshToolButton);
            this.WebControlPanel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.WebControlPanel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.WebControlPanel.Location = new System.Drawing.Point(12, 631);
            this.WebControlPanel.Name = "WebControlPanel";
            this.WebControlPanel.Size = new System.Drawing.Size(260, 54);
            this.WebControlPanel.TabIndex = 8;
            this.WebControlPanel.Visible = false;
            this.WebControlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WebControlPanel_Paint);
            this.WebControlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebControlPanel_MouseDown);
            this.WebControlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WebControlPanel_MouseMove);
            this.WebControlPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WebControlPanel_MouseUp);
            // 
            // WebControlContextMenu
            // 
            this.WebControlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseToolStripMenuItem,
            this.expandToolStripMenuItem});
            this.WebControlContextMenu.Name = "contextMenuStrip1";
            this.WebControlContextMenu.Size = new System.Drawing.Size(120, 48);
            this.WebControlContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.WebControlContextMenu_Opening);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.Image = global::TBP_Dashboard.Properties.Resources.icons8_collapse_28;
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            this.collapseToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.collapseToolStripMenuItem.Text = "Collapse";
            this.collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.Image = global::TBP_Dashboard.Properties.Resources.icons8_expand_28;
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.expandToolStripMenuItem.Text = "Expand";
            this.expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // SavePinToolButton
            // 
            this.SavePinToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.SavePinToolButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SavePinToolButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SavePinToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SavePinToolButton.Image = global::TBP_Dashboard.Properties.Resources.icons8_pin_28;
            this.SavePinToolButton.Location = new System.Drawing.Point(82, 8);
            this.SavePinToolButton.Name = "SavePinToolButton";
            this.SavePinToolButton.Size = new System.Drawing.Size(38, 38);
            this.SavePinToolButton.TabIndex = 5;
            this.ToolTip1.SetToolTip(this.SavePinToolButton, "Pin this page");
            this.SavePinToolButton.UseVisualStyleBackColor = false;
            this.SavePinToolButton.Click += new System.EventHandler(this.SavePinToolButton_Click);
            // 
            // HomeToolButton
            // 
            this.HomeToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.HomeToolButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.HomeToolButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.HomeToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeToolButton.Image = global::TBP_Dashboard.Properties.Resources.icons8_squared_menu_28;
            this.HomeToolButton.Location = new System.Drawing.Point(36, 8);
            this.HomeToolButton.Name = "HomeToolButton";
            this.HomeToolButton.Size = new System.Drawing.Size(38, 38);
            this.HomeToolButton.TabIndex = 4;
            this.ToolTip1.SetToolTip(this.HomeToolButton, "Return to the TBPlay Dashboard.");
            this.HomeToolButton.UseVisualStyleBackColor = false;
            this.HomeToolButton.Click += new System.EventHandler(this.HomeToolButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.ContextMenuStrip = this.WebControlContextMenu;
            this.pictureBox3.Image = global::TBP_Dashboard.Properties.Resources.icons8_menu_28;
            this.pictureBox3.Location = new System.Drawing.Point(5, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebControlPanel_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WebControlPanel_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WebControlPanel_MouseUp);
            // 
            // BackToolButton
            // 
            this.BackToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.BackToolButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackToolButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.BackToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToolButton.Image = global::TBP_Dashboard.Properties.Resources.icons8_back_28;
            this.BackToolButton.Location = new System.Drawing.Point(126, 8);
            this.BackToolButton.Name = "BackToolButton";
            this.BackToolButton.Size = new System.Drawing.Size(38, 38);
            this.BackToolButton.TabIndex = 2;
            this.ToolTip1.SetToolTip(this.BackToolButton, "Navigate to the previous page.");
            this.BackToolButton.UseVisualStyleBackColor = false;
            this.BackToolButton.Click += new System.EventHandler(this.Back_Click);
            // 
            // ForwardToolButton
            // 
            this.ForwardToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.ForwardToolButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForwardToolButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ForwardToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardToolButton.Image = global::TBP_Dashboard.Properties.Resources.icons8_forward_28;
            this.ForwardToolButton.Location = new System.Drawing.Point(214, 8);
            this.ForwardToolButton.Name = "ForwardToolButton";
            this.ForwardToolButton.Size = new System.Drawing.Size(38, 38);
            this.ForwardToolButton.TabIndex = 1;
            this.ToolTip1.SetToolTip(this.ForwardToolButton, "Navigate forward in your page history.");
            this.ForwardToolButton.UseVisualStyleBackColor = false;
            this.ForwardToolButton.Click += new System.EventHandler(this.Forward_Click);
            // 
            // RefreshToolButton
            // 
            this.RefreshToolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.RefreshToolButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.RefreshToolButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.RefreshToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshToolButton.Image = global::TBP_Dashboard.Properties.Resources.icons8_refresh_28;
            this.RefreshToolButton.Location = new System.Drawing.Point(170, 8);
            this.RefreshToolButton.Name = "RefreshToolButton";
            this.RefreshToolButton.Size = new System.Drawing.Size(38, 38);
            this.RefreshToolButton.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.RefreshToolButton, "Refresh the current page.");
            this.RefreshToolButton.UseVisualStyleBackColor = false;
            this.RefreshToolButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // ToolTip1
            // 
            this.ToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ToolTip1.ForeColor = System.Drawing.SystemColors.Info;
            // 
            // RPCUpdate
            // 
            this.RPCUpdate.Interval = 30000;
            this.RPCUpdate.Tick += new System.EventHandler(this.RPCUpdate_Tick);
            // 
            // checkforJavaRPC
            // 
            this.checkforJavaRPC.Interval = 60000;
            this.checkforJavaRPC.Tick += new System.EventHandler(this.checkforJavaRPC_Tick);
            // 
            // discordSSOTerminateToolStripMenuItem
            // 
            this.discordSSOTerminateToolStripMenuItem.Name = "discordSSOTerminateToolStripMenuItem";
            this.discordSSOTerminateToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.discordSSOTerminateToolStripMenuItem.Text = "DiscordSSOTerminate";
            this.discordSSOTerminateToolStripMenuItem.Click += new System.EventHandler(this.discordSSOTerminateToolStripMenuItem_Click);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1048, 696);
            this.Controls.Add(this.LazyLoader);
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.WebControlPanel);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.WebView2);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.WebView);
            this.Controls.Add(this.ModsProcessing);
            this.Controls.Add(this.SettingsProcessing);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(1064, 735);
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TBPlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignIn_FormClosing);
            this.Load += new System.EventHandler(this.SignIn_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.LoadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebView2)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LazyLoader)).EndInit();
            this.WebControlPanel.ResumeLayout(false);
            this.WebControlContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 WebView;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Panel LoadingPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker CheckUpdates;
        private System.Windows.Forms.Label UpdateHeader;
        private System.Windows.Forms.Timer StartTimer;
        private Microsoft.Web.WebView2.WinForms.WebView2 WebView2;
        private System.Windows.Forms.Timer DoContentInstall;
        private System.Windows.Forms.ToolStripDropDownButton DiscordSwitchAccounts;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MainIcon;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem Maximise;
        private System.Windows.Forms.ToolStripMenuItem Minimise;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem Refresh;
        private System.Windows.Forms.Timer MCATimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem OpenMinecraftDir;
        private System.Windows.Forms.ToolStripMenuItem TestFeatures;
        private System.Windows.Forms.ToolStripMenuItem testDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenModManager;
        private System.Windows.Forms.ToolStripMenuItem OpenPrivacyPolicy;
        private System.Windows.Forms.ToolStripMenuItem UpdateNotification;
        private System.Windows.Forms.ToolStripMenuItem InstallUpdate;
        private System.Windows.Forms.ToolStripMenuItem DismissUpdate;
        private System.Windows.Forms.RichTextBox SettingsProcessing;
        private System.Windows.Forms.RichTextBox ModsProcessing;
        private System.Windows.Forms.ToolStripMenuItem modpackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MP_Vanilla;
        private System.Windows.Forms.ToolStripMenuItem MP_Origins1;
        private System.Windows.Forms.ToolStripMenuItem MP_Custom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ModManagerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Timer NaviTimer;
        private System.Windows.Forms.PictureBox LazyLoader;
        private System.Windows.Forms.Panel WebControlPanel;
        private System.Windows.Forms.Button RefreshToolButton;
        private System.Windows.Forms.Button ForwardToolButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button BackToolButton;
        private System.Windows.Forms.Button HomeToolButton;
        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ContextMenuStrip WebControlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinsToolStripMenuItem;
        private System.Windows.Forms.Button SavePinToolButton;
        private System.Windows.Forms.Timer RPCUpdate;
        private System.Windows.Forms.Timer checkforJavaRPC;
        private System.Windows.Forms.ToolStripMenuItem discordSSOTerminateToolStripMenuItem;
    }
}

