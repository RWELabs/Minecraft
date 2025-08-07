namespace TBP_Dashboard
{
    partial class FirstRunSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstRunSetup));
            this.FRIStatusBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MSWebViewInstall = new System.Windows.Forms.Timer(this.components);
            this.CheckInstallProgress = new System.Windows.Forms.Timer(this.components);
            this.Backup = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FRIStatusBar
            // 
            this.FRIStatusBar.Location = new System.Drawing.Point(12, 98);
            this.FRIStatusBar.Name = "FRIStatusBar";
            this.FRIStatusBar.Size = new System.Drawing.Size(314, 23);
            this.FRIStatusBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status";
            // 
            // StatusText
            // 
            this.StatusText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.StatusText.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.StatusText.Location = new System.Drawing.Point(56, 79);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(270, 13);
            this.StatusText.TabIndex = 2;
            this.StatusText.Text = "Please wait...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TBP_Dashboard.Properties.Resources.TBPlayText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MSWebViewInstall
            // 
            this.MSWebViewInstall.Interval = 1300;
            this.MSWebViewInstall.Tick += new System.EventHandler(this.MSWebViewInstall_Tick);
            // 
            // CheckInstallProgress
            // 
            this.CheckInstallProgress.Interval = 1891;
            this.CheckInstallProgress.Tick += new System.EventHandler(this.CheckInstallProgress_Tick);
            // 
            // Backup
            // 
            this.Backup.Interval = 1000;
            this.Backup.Tick += new System.EventHandler(this.Backup_Tick);
            // 
            // FirstRunSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(338, 138);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FRIStatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FirstRunSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup | TBPlay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar FRIStatusBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer MSWebViewInstall;
        private System.Windows.Forms.Timer CheckInstallProgress;
        private System.Windows.Forms.Timer Backup;
    }
}