namespace TBP_Dashboard
{
    partial class UpdateDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDownload));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.StatusText = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadProgress = new System.Windows.Forms.Label();
            this.StartExecute = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::TBP_Dashboard.Properties.Resources._285;
            this.pictureBox1.Location = new System.Drawing.Point(342, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TBP_Dashboard.Properties.Resources.TBPLauncherHeader;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(236, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.StatusText.Location = new System.Drawing.Point(14, 83);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(377, 23);
            this.StatusText.TabIndex = 2;
            this.StatusText.Text = "StatusText";
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(14, 113);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(377, 28);
            this.ProgressBar.TabIndex = 3;
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DownloadProgress.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.DownloadProgress.Location = new System.Drawing.Point(14, 148);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(377, 23);
            this.DownloadProgress.TabIndex = 4;
            this.DownloadProgress.Text = "label1";
            this.DownloadProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartExecute
            // 
            this.StartExecute.Interval = 1500;
            this.StartExecute.Tick += new System.EventHandler(this.StartExecute_Tick);
            // 
            // UpdateDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(405, 194);
            this.ControlBox = false;
            this.Controls.Add(this.DownloadProgress);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updating TBP Launcher...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label DownloadProgress;
        private System.Windows.Forms.Timer StartExecute;
    }
}