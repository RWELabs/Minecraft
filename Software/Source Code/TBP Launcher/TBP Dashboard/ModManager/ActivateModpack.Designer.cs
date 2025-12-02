namespace TBP_Dashboard.ModManager
{
    partial class ActivateModpack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivateModpack));
            this.ProcessingList = new System.Windows.Forms.RichTextBox();
            this.DisableMods = new System.ComponentModel.BackgroundWorker();
            this.EnableMods = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessingList
            // 
            this.ProcessingList.Location = new System.Drawing.Point(12, 224);
            this.ProcessingList.Name = "ProcessingList";
            this.ProcessingList.Size = new System.Drawing.Size(19, 12);
            this.ProcessingList.TabIndex = 0;
            this.ProcessingList.Text = "";
            this.ProcessingList.Visible = false;
            // 
            // DisableMods
            // 
            this.DisableMods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DisableMods_DoWork);
            this.DisableMods.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DisableMods_RunWorkerCompleted);
            // 
            // EnableMods
            // 
            this.EnableMods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.EnableMods_DoWork);
            this.EnableMods.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.EnableMods_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TBP_Dashboard.Properties.Resources.GreenLoadingSpinner;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Working on it...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F);
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(12, 67);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(335, 23);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Please wait...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActivateModpack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(359, 248);
            this.ControlBox = false;
            this.Controls.Add(this.ProcessingList);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActivateModpack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Swapping Modpacks | TBPlay";
            this.Load += new System.EventHandler(this.ActivateModpack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ProcessingList;
        private System.ComponentModel.BackgroundWorker DisableMods;
        private System.ComponentModel.BackgroundWorker EnableMods;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StatusLabel;
    }
}