namespace TBP_Dashboard.Get
{
    partial class DownloadContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadContent));
            this.FileRead = new System.Windows.Forms.RichTextBox();
            this.FileDestination = new System.Windows.Forms.TextBox();
            this.DownloadProgress = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusText = new System.Windows.Forms.Label();
            this.StartFabricInstaller = new System.Windows.Forms.Timer(this.components);
            this.StartModpackUnzip = new System.Windows.Forms.Timer(this.components);
            this.ResourcePackInstallTimer = new System.Windows.Forms.Timer(this.components);
            this.StartWorldHandling = new System.Windows.Forms.Timer(this.components);
            this.DisableMods = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // FileRead
            // 
            this.FileRead.Location = new System.Drawing.Point(12, 12);
            this.FileRead.Name = "FileRead";
            this.FileRead.Size = new System.Drawing.Size(15, 39);
            this.FileRead.TabIndex = 0;
            this.FileRead.Text = "";
            // 
            // FileDestination
            // 
            this.FileDestination.Location = new System.Drawing.Point(12, 31);
            this.FileDestination.Name = "FileDestination";
            this.FileDestination.Size = new System.Drawing.Size(15, 20);
            this.FileDestination.TabIndex = 1;
            this.FileDestination.TextChanged += new System.EventHandler(this.FileDestination_TextChanged);
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DownloadProgress.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.DownloadProgress.Location = new System.Drawing.Point(14, 290);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(377, 23);
            this.DownloadProgress.TabIndex = 9;
            this.DownloadProgress.Text = "label1";
            this.DownloadProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(14, 267);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(377, 14);
            this.ProgressBar.TabIndex = 8;
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F);
            this.StatusText.ForeColor = System.Drawing.Color.White;
            this.StatusText.Location = new System.Drawing.Point(14, 138);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(377, 23);
            this.StatusText.TabIndex = 7;
            this.StatusText.Text = "StatusText";
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartFabricInstaller
            // 
            this.StartFabricInstaller.Interval = 2500;
            this.StartFabricInstaller.Tick += new System.EventHandler(this.StartFabricInstaller_Tick);
            // 
            // StartModpackUnzip
            // 
            this.StartModpackUnzip.Interval = 2500;
            this.StartModpackUnzip.Tick += new System.EventHandler(this.StartModpackUnzip_Tick);
            // 
            // ResourcePackInstallTimer
            // 
            this.ResourcePackInstallTimer.Interval = 3000;
            this.ResourcePackInstallTimer.Tick += new System.EventHandler(this.ResourcePackInstallTimer_Tick);
            // 
            // StartWorldHandling
            // 
            this.StartWorldHandling.Interval = 4500;
            this.StartWorldHandling.Tick += new System.EventHandler(this.StartWorldHandling_Tick);
            // 
            // DisableMods
            // 
            this.DisableMods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DisableMods_DoWork);
            this.DisableMods.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DisableMods_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Working on it...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TBP_Dashboard.Properties.Resources.GreenLoadingSpinner;
            this.pictureBox3.Location = new System.Drawing.Point(21, 174);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(362, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TBP_Dashboard.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // DownloadContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(405, 344);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownloadProgress);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.FileDestination);
            this.Controls.Add(this.FileRead);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Content | TBPlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadContent_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox FileRead;
        private System.Windows.Forms.TextBox FileDestination;
        private System.Windows.Forms.Label DownloadProgress;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Timer StartFabricInstaller;
        private System.Windows.Forms.Timer StartModpackUnzip;
        private System.Windows.Forms.Timer ResourcePackInstallTimer;
        private System.Windows.Forms.Timer StartWorldHandling;
        private System.ComponentModel.BackgroundWorker DisableMods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}