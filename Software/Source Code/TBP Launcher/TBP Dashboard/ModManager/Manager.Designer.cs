namespace TBP_Dashboard.ModManager
{
    partial class Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.ModList = new System.Windows.Forms.CheckedListBox();
            this.DeleteMod = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.InstallMod = new System.Windows.Forms.Button();
            this.InstallModpack = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PresetManagement = new System.Windows.Forms.RichTextBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ModList
            // 
            this.ModList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModList.CheckOnClick = true;
            this.ModList.FormattingEnabled = true;
            this.ModList.Location = new System.Drawing.Point(12, 118);
            this.ModList.Margin = new System.Windows.Forms.Padding(7, 7, 3, 3);
            this.ModList.Name = "ModList";
            this.ModList.Size = new System.Drawing.Size(466, 334);
            this.ModList.TabIndex = 0;
            // 
            // DeleteMod
            // 
            this.DeleteMod.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteMod.Image = global::TBP_Dashboard.Properties.Resources.Close;
            this.DeleteMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteMod.Location = new System.Drawing.Point(339, 468);
            this.DeleteMod.Name = "DeleteMod";
            this.DeleteMod.Size = new System.Drawing.Size(139, 45);
            this.DeleteMod.TabIndex = 1;
            this.DeleteMod.Text = "Delete Mod";
            this.DeleteMod.UseVisualStyleBackColor = true;
            this.DeleteMod.Click += new System.EventHandler(this.DeleteMod_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(492, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(39, 17);
            this.Status.Text = "Ready";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "The following is a list of mods that are installed on your system. Enable or disa" +
    "ble specific mods by checking/unchecking them.";
            // 
            // InstallMod
            // 
            this.InstallMod.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.InstallMod.Image = global::TBP_Dashboard.Properties.Resources.InstallModpack;
            this.InstallMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InstallMod.Location = new System.Drawing.Point(12, 468);
            this.InstallMod.Name = "InstallMod";
            this.InstallMod.Size = new System.Drawing.Size(139, 45);
            this.InstallMod.TabIndex = 5;
            this.InstallMod.Text = "Install Mod";
            this.InstallMod.UseVisualStyleBackColor = true;
            this.InstallMod.Click += new System.EventHandler(this.InstallMod_Click);
            // 
            // InstallModpack
            // 
            this.InstallModpack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.InstallModpack.Enabled = false;
            this.InstallModpack.Image = global::TBP_Dashboard.Properties.Resources.InstallMod;
            this.InstallModpack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InstallModpack.Location = new System.Drawing.Point(167, 468);
            this.InstallModpack.Name = "InstallModpack";
            this.InstallModpack.Size = new System.Drawing.Size(155, 45);
            this.InstallModpack.TabIndex = 6;
            this.InstallModpack.Text = "Install Modpack";
            this.ToolTip.SetToolTip(this.InstallModpack, "Modpacks can be installed from the main dashboard, by navigating to the mod downl" +
        "oad section. This feature is intended for manual installation and is not yet imp" +
        "lemented.");
            this.InstallModpack.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::TBP_Dashboard.Properties.Resources.ModManagement;
            this.pictureBox2.Location = new System.Drawing.Point(15, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(447, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // PresetManagement
            // 
            this.PresetManagement.Location = new System.Drawing.Point(12, 118);
            this.PresetManagement.Name = "PresetManagement";
            this.PresetManagement.Size = new System.Drawing.Size(466, 334);
            this.PresetManagement.TabIndex = 9;
            this.PresetManagement.Text = "";
            // 
            // ToolTip
            // 
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Feature Availability";
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(492, 553);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.InstallModpack);
            this.Controls.Add(this.InstallMod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DeleteMod);
            this.Controls.Add(this.ModList);
            this.Controls.Add(this.PresetManagement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Beta] Minecraft Mod Management";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ModList;
        private System.Windows.Forms.Button DeleteMod;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InstallMod;
        private System.Windows.Forms.Button InstallModpack;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox PresetManagement;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}