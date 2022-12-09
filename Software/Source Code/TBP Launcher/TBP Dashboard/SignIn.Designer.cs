﻿namespace TBP_Dashboard
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
            this.ToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Back = new System.Windows.Forms.ToolStripMenuItem();
            this.Forward = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.MCATimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.LoadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebView2)).BeginInit();
            this.MenuStrip.SuspendLayout();
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
            this.LoadingPanel.BackColor = System.Drawing.Color.White;
            this.LoadingPanel.Controls.Add(this.UpdateHeader);
            this.LoadingPanel.Controls.Add(this.pictureBox2);
            this.LoadingPanel.Controls.Add(this.pictureBox1);
            this.LoadingPanel.Location = new System.Drawing.Point(1016, 646);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(32, 26);
            this.LoadingPanel.TabIndex = 2;
            this.LoadingPanel.Visible = false;
            // 
            // UpdateHeader
            // 
            this.UpdateHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateHeader.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateHeader.ForeColor = System.Drawing.Color.Gray;
            this.UpdateHeader.Location = new System.Drawing.Point(3, -99);
            this.UpdateHeader.Name = "UpdateHeader";
            this.UpdateHeader.Size = new System.Drawing.Size(22, 25);
            this.UpdateHeader.TabIndex = 2;
            this.UpdateHeader.Text = "Checking for updates...";
            this.UpdateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UpdateHeader.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::TBP_Dashboard.Properties.Resources.TBPLauncherHeader;
            this.pictureBox2.Location = new System.Drawing.Point(3, -43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::TBP_Dashboard.Properties.Resources._285;
            this.pictureBox1.Location = new System.Drawing.Point(3, -60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 64);
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
            this.WebView2.Location = new System.Drawing.Point(0, 24);
            this.WebView2.Name = "WebView2";
            this.WebView2.Size = new System.Drawing.Size(1049, 662);
            this.WebView2.TabIndex = 3;
            this.WebView2.Visible = false;
            this.WebView2.ZoomFactor = 1D;
            this.WebView2.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.WebView2_CoreWebView2InitializationCompleted);
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
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainIcon,
            this.FileMenu,
            this.ViewMenu,
            this.ToolsMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1048, 24);
            this.MenuStrip.TabIndex = 4;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.Visible = false;
            // 
            // MainIcon
            // 
            this.MainIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MainIcon.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.MainIcon.Image = global::TBP_Dashboard.Properties.Resources.icons8_minecraft_grass_cube_100;
            this.MainIcon.Name = "MainIcon";
            this.MainIcon.Size = new System.Drawing.Size(28, 20);
            this.MainIcon.MouseEnter += new System.EventHandler(this.MainIcon_MouseEnter);
            this.MainIcon.MouseLeave += new System.EventHandler(this.MainIcon_MouseLeave);
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenSettings,
            this.toolStripSeparator1,
            this.Exit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
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
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Maximise,
            this.Minimise});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
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
            // ToolsMenu
            // 
            this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Back,
            this.Forward,
            this.Refresh});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(46, 20);
            this.ToolsMenu.Text = "Tools";
            // 
            // Back
            // 
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(132, 22);
            this.Back.Text = "Back";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(132, 22);
            this.Forward.Text = "Forward";
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // Refresh
            // 
            this.Refresh.Name = "Refresh";
            this.Refresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.Refresh.Size = new System.Drawing.Size(132, 22);
            this.Refresh.Text = "Refresh";
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // MCATimer
            // 
            this.MCATimer.Interval = 5000;
            this.MCATimer.Tick += new System.EventHandler(this.MCATimer_Tick);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1048, 684);
            this.Controls.Add(this.WebView2);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.WebView);
            this.Controls.Add(this.LoadingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(1064, 723);
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TBP Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignIn_FormClosing);
            this.Load += new System.EventHandler(this.SignIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.LoadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebView2)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem Back;
        private System.Windows.Forms.ToolStripMenuItem Forward;
        private System.Windows.Forms.ToolStripMenuItem Refresh;
        private System.Windows.Forms.Timer MCATimer;
    }
}
