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
            this.SuspendLayout();
            // 
            // LauncherLocation
            // 
            this.LauncherLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LauncherLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LauncherLocation.ForeColor = System.Drawing.Color.White;
            this.LauncherLocation.Location = new System.Drawing.Point(12, 86);
            this.LauncherLocation.Name = "LauncherLocation";
            this.LauncherLocation.Size = new System.Drawing.Size(405, 13);
            this.LauncherLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
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
            this.SetManually.Location = new System.Drawing.Point(14, 109);
            this.SetManually.Name = "SetManually";
            this.SetManually.Size = new System.Drawing.Size(145, 23);
            this.SetManually.TabIndex = 2;
            this.SetManually.Text = "Set Manually (Browse)";
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
            this.Save.Location = new System.Drawing.Point(336, 249);
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
            this.Cancel.Location = new System.Drawing.Point(242, 249);
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
            this.Clear.Location = new System.Drawing.Point(349, 109);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(68, 23);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(405, 46);
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
            this.SetMSLauncher.Location = new System.Drawing.Point(165, 109);
            this.SetMSLauncher.Name = "SetMSLauncher";
            this.SetMSLauncher.Size = new System.Drawing.Size(178, 23);
            this.SetMSLauncher.TabIndex = 7;
            this.SetMSLauncher.Text = "Set to Microsoft Store Launcher";
            this.SetMSLauncher.UseVisualStyleBackColor = false;
            this.SetMSLauncher.Click += new System.EventHandler(this.SetMSLauncher_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Updates";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label4.Location = new System.Drawing.Point(13, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(405, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "The following settings pertain solely to updating TBPlay.";
            // 
            // CheckTBPUpdates
            // 
            this.CheckTBPUpdates.AutoSize = true;
            this.CheckTBPUpdates.Location = new System.Drawing.Point(16, 193);
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
            this.CheckForUpdates.Location = new System.Drawing.Point(16, 216);
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
            this.CurrentVersion.Location = new System.Drawing.Point(13, 249);
            this.CurrentVersion.Name = "CurrentVersion";
            this.CurrentVersion.Size = new System.Drawing.Size(76, 13);
            this.CurrentVersion.TabIndex = 12;
            this.CurrentVersion.Text = "CurrentVersion";
            // 
            // AvailableVersion
            // 
            this.AvailableVersion.AutoSize = true;
            this.AvailableVersion.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.AvailableVersion.Location = new System.Drawing.Point(13, 265);
            this.AvailableVersion.Name = "AvailableVersion";
            this.AvailableVersion.Size = new System.Drawing.Size(85, 13);
            this.AvailableVersion.TabIndex = 13;
            this.AvailableVersion.Text = "AvailableVersion";
            this.AvailableVersion.Visible = false;
            // 
            // Preferences
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(436, 322);
            this.ControlBox = false;
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
            this.Controls.Add(this.LauncherLocation);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings | TBPlay";
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
    }
}