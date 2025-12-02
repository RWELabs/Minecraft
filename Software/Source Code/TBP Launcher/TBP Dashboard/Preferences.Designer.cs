namespace TBP_Dashboard
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.LauncherLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SetManually = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SetMSLauncher = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckTBPUpdates = new System.Windows.Forms.CheckBox();
            this.CheckForUpdates = new System.Windows.Forms.Button();
            this.CurrentVersion = new System.Windows.Forms.Label();
            this.AvailableVersion = new System.Windows.Forms.Label();
            this.FindLauncherStart = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LauncherLocation
            // 
            this.LauncherLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LauncherLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LauncherLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LauncherLocation.ForeColor = System.Drawing.Color.White;
            this.LauncherLocation.Location = new System.Drawing.Point(5, 3);
            this.LauncherLocation.Name = "LauncherLocation";
            this.LauncherLocation.Size = new System.Drawing.Size(395, 14);
            this.LauncherLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Launcher Location:";
            // 
            // SetManually
            // 
            this.SetManually.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SetManually.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SetManually.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetManually.Location = new System.Drawing.Point(104, 167);
            this.SetManually.Name = "SetManually";
            this.SetManually.Size = new System.Drawing.Size(95, 23);
            this.SetManually.TabIndex = 2;
            this.SetManually.Text = "Find (Browse)";
            this.SetManually.UseVisualStyleBackColor = false;
            this.SetManually.Click += new System.EventHandler(this.SetManually_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Image = global::TBP_Dashboard.Properties.Resources.Check;
            this.Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Save.Location = new System.Drawing.Point(335, 334);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(88, 54);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save Changes";
            this.Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Image = global::TBP_Dashboard.Properties.Resources.Close;
            this.Cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Cancel.Location = new System.Drawing.Point(241, 334);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 54);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Clear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Location = new System.Drawing.Point(370, 167);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(48, 23);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(405, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "When you click play, we\'ll launch the following executable. If you leave this emp" +
    "ty or click \"Clear\" we\'ll attempt to find it automatically when you click \"Play\"" +
    " from the launcher.";
            // 
            // SetMSLauncher
            // 
            this.SetMSLauncher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SetMSLauncher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SetMSLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetMSLauncher.Location = new System.Drawing.Point(205, 167);
            this.SetMSLauncher.Name = "SetMSLauncher";
            this.SetMSLauncher.Size = new System.Drawing.Size(159, 23);
            this.SetMSLauncher.TabIndex = 7;
            this.SetMSLauncher.Text = "Use Microsoft Store Launcher";
            this.SetMSLauncher.UseVisualStyleBackColor = false;
            this.SetMSLauncher.Click += new System.EventHandler(this.SetMSLauncher_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Updates";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label4.Location = new System.Drawing.Point(12, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(405, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "The following settings pertain solely to updating TBPlay.";
            // 
            // CheckTBPUpdates
            // 
            this.CheckTBPUpdates.AutoSize = true;
            this.CheckTBPUpdates.Location = new System.Drawing.Point(15, 252);
            this.CheckTBPUpdates.Name = "CheckTBPUpdates";
            this.CheckTBPUpdates.Size = new System.Drawing.Size(210, 17);
            this.CheckTBPUpdates.TabIndex = 10;
            this.CheckTBPUpdates.Text = "Check for updates when TBPlay starts.";
            this.CheckTBPUpdates.UseVisualStyleBackColor = true;
            // 
            // CheckForUpdates
            // 
            this.CheckForUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.CheckForUpdates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.CheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckForUpdates.Location = new System.Drawing.Point(15, 275);
            this.CheckForUpdates.Name = "CheckForUpdates";
            this.CheckForUpdates.Size = new System.Drawing.Size(143, 23);
            this.CheckForUpdates.TabIndex = 11;
            this.CheckForUpdates.Text = "Check for Updates";
            this.CheckForUpdates.UseVisualStyleBackColor = false;
            this.CheckForUpdates.Click += new System.EventHandler(this.CheckForUpdates_Click);
            // 
            // CurrentVersion
            // 
            this.CurrentVersion.AutoSize = true;
            this.CurrentVersion.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CurrentVersion.Location = new System.Drawing.Point(12, 320);
            this.CurrentVersion.Name = "CurrentVersion";
            this.CurrentVersion.Size = new System.Drawing.Size(76, 13);
            this.CurrentVersion.TabIndex = 12;
            this.CurrentVersion.Text = "CurrentVersion";
            // 
            // AvailableVersion
            // 
            this.AvailableVersion.AutoSize = true;
            this.AvailableVersion.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.AvailableVersion.Location = new System.Drawing.Point(12, 336);
            this.AvailableVersion.Name = "AvailableVersion";
            this.AvailableVersion.Size = new System.Drawing.Size(85, 13);
            this.AvailableVersion.TabIndex = 13;
            this.AvailableVersion.Text = "AvailableVersion";
            this.AvailableVersion.Visible = false;
            // 
            // FindLauncherStart
            // 
            this.FindLauncherStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.FindLauncherStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.FindLauncherStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindLauncherStart.Location = new System.Drawing.Point(12, 167);
            this.FindLauncherStart.Name = "FindLauncherStart";
            this.FindLauncherStart.Size = new System.Drawing.Size(86, 23);
            this.FindLauncherStart.TabIndex = 14;
            this.FindLauncherStart.Text = "Find (Auto)";
            this.FindLauncherStart.UseVisualStyleBackColor = false;
            this.FindLauncherStart.Click += new System.EventHandler(this.FindLauncherStart_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TBP_Dashboard.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TBP_Dashboard.Properties.Resources.IconSpw;
            this.pictureBox1.Location = new System.Drawing.Point(359, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.LauncherLocation);
            this.panel1.Location = new System.Drawing.Point(12, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 22);
            this.panel1.TabIndex = 20;
            // 
            // Preferences
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(435, 401);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.FindLauncherStart);
            this.Controls.Add(this.AvailableVersion);
            this.Controls.Add(this.CurrentVersion);
            this.Controls.Add(this.CheckForUpdates);
            this.Controls.Add(this.CheckTBPUpdates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SetMSLauncher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SetManually);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings | TBPlay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LauncherLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SetManually;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SetMSLauncher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CheckTBPUpdates;
        private System.Windows.Forms.Button CheckForUpdates;
        private System.Windows.Forms.Label CurrentVersion;
        private System.Windows.Forms.Label AvailableVersion;
        private System.Windows.Forms.Button FindLauncherStart;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}