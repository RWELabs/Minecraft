namespace TBP_Dashboard
{
    partial class SavePinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavePinForm));
            this.txtPinName = new System.Windows.Forms.TextBox();
            this.SavePin = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.PBfavicon = new System.Windows.Forms.PictureBox();
            this.webURL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBfavicon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPinName
            // 
            this.txtPinName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.txtPinName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPinName.ForeColor = System.Drawing.Color.White;
            this.txtPinName.Location = new System.Drawing.Point(6, 7);
            this.txtPinName.Name = "txtPinName";
            this.txtPinName.Size = new System.Drawing.Size(282, 13);
            this.txtPinName.TabIndex = 0;
            // 
            // SavePin
            // 
            this.SavePin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SavePin.FlatAppearance.BorderSize = 0;
            this.SavePin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SavePin.ForeColor = System.Drawing.Color.White;
            this.SavePin.Location = new System.Drawing.Point(254, 174);
            this.SavePin.Name = "SavePin";
            this.SavePin.Size = new System.Drawing.Size(84, 34);
            this.SavePin.TabIndex = 1;
            this.SavePin.Text = "Save";
            this.SavePin.UseVisualStyleBackColor = false;
            this.SavePin.Click += new System.EventHandler(this.SavePin_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(160, 174);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(84, 34);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // PBfavicon
            // 
            this.PBfavicon.Image = global::TBP_Dashboard.Properties.Resources.icons8_website_28;
            this.PBfavicon.Location = new System.Drawing.Point(8, 111);
            this.PBfavicon.Name = "PBfavicon";
            this.PBfavicon.Size = new System.Drawing.Size(30, 20);
            this.PBfavicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBfavicon.TabIndex = 3;
            this.PBfavicon.TabStop = false;
            // 
            // webURL
            // 
            this.webURL.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.webURL.Location = new System.Drawing.Point(44, 137);
            this.webURL.Name = "webURL";
            this.webURL.Size = new System.Drawing.Size(275, 23);
            this.webURL.TabIndex = 4;
            this.webURL.Text = "label1";
            this.webURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.txtPinName);
            this.panel1.Location = new System.Drawing.Point(44, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 28);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(316, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Pin This Site";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.Font = new System.Drawing.Font("Segoe UI Semilight", 10.25F);
            this.StatusText.ForeColor = System.Drawing.Color.White;
            this.StatusText.Location = new System.Drawing.Point(12, 46);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(330, 51);
            this.StatusText.TabIndex = 14;
            this.StatusText.Text = "Pinned pages can be accessed with a single click from the \"Pins\" menu.";
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SavePinForm
            // 
            this.AcceptButton = this.SavePin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(352, 233);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webURL);
            this.Controls.Add(this.PBfavicon);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SavePin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SavePinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Pin | TBPlay";
            ((System.ComponentModel.ISupportInitialize)(this.PBfavicon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPinName;
        private System.Windows.Forms.Button SavePin;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.PictureBox PBfavicon;
        private System.Windows.Forms.Label webURL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StatusText;
    }
}