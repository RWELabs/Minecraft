using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TBP_World_Saver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("Something happened","Something happened",MessageBoxButtons.OK,MessageBoxIcon.Error);
            label1.Text = "Version: " + Properties.Settings.Default.Version;

            string savelocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\";
            Properties.Settings.Default.SaveLocation = savelocation;
            Properties.Settings.Default.Save();

            //MessageBox.Show(Properties.Settings.Default.SaveLocation);
        }

        private void UpdateButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load("https://www.ryanwalpole.com/h/tbpsaver/updatecheck.xml");
            string allText = document.InnerText;
            if (allText.Contains(Properties.Settings.Default.Version))
            {
                UpdateButton.Text = "Updates Available!";
                DialogResult dr = MessageBox.Show("There is an update available for TBP World Saver. Would you like to update now?", "TBP World Saver", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (WebClient wc = new WebClient())
                    {
                        string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                        string updatelocation = Path.Combine(dataPath, "tbpsaverlatest.exe");
                        progressBar1.Visible = true;
                        UpdateButton.Text = "Downloading Updates..";

                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri("https://www.ryanwalpole.com/h/tbpsaver/latest.exe"),
                            // Param2 = Path to save
                            updatelocation
                        );
                        this.BringToFront();
                    }
                }
            }
            else if (!allText.Contains(Properties.Settings.Default.Version))
            {
                UpdateButton.Text = "Up to date!";
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            long FileSize = e.TotalBytesToReceive / 1024;
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + e.TotalBytesToReceive.ToString() + " bytes";

            if (progressBar1.Value > 99)
            {
                this.BringToFront();
                progressBar1.Value = 100;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string updatelocation = Path.Combine(dataPath, "tbpsaverlatest.exe");

            Process.Start(updatelocation);

            timer1.Stop();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DefaultLocation.Checked == true)
            {
                //do nothing
            }
            else if (DefaultLocation.Checked == false)
            {
                string folderpath = "";
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult dr2 = fbd.ShowDialog();

                if (dr2 == DialogResult.OK)
                {
                    folderpath = fbd.SelectedPath;
                    Properties.Settings.Default.SaveLocation = folderpath;
                    Properties.Settings.Default.Save();
                }
            }

            if (comboBox1.SelectedItem.ToString() == "TBP Season 1 (2019-2020)")
            {
                Properties.Settings.Default.WorldZipName = "TBPS1";
                Properties.Settings.Default.DownloadLocation = "https://onedrive.live.com/download?cid=2843D66BB53B6198&resid=2843D66BB53B6198%211331884&authkey=AK8iegVe3GvdjJQ";
                Properties.Settings.Default.Save();
            }
            else if (comboBox1.SelectedItem.ToString() == "TBP Season 2 (2020-2021)")
            {
                Properties.Settings.Default.WorldZipName = "TBPS2";
                Properties.Settings.Default.DownloadLocation = "https://onedrive.live.com/download?cid=2843D66BB53B6198&resid=2843D66BB53B6198%211344362&authkey=ABm7f2n5V6SQ4gM";
                Properties.Settings.Default.Save();
            }
            else if (comboBox1.SelectedItem.ToString() == "TBP Skyblock Season 1 (2021)")
            {
                Properties.Settings.Default.WorldZipName = "TBPSkyblockS1";
                Properties.Settings.Default.DownloadLocation = "https://onedrive.live.com/download?cid=2843D66BB53B6198&resid=2843D66BB53B6198%211344387&authkey=AEZmTPatEkutLOo";
                Properties.Settings.Default.Save();
            }

            DialogResult dr = MessageBox.Show("TBP Worlds are often upwards of several gigabytes in size. Once you have started downloading a world, you can only abort the download by closing the application. If the file is 50% downloaded when you abort, you will need to manually remove this file from the download location to clear space. Please ensure that you have the correct disk space to download such a large world save. Are you sure you want to continue?","Are you sure you want to continue?",MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(dr == DialogResult.Yes)
            {
                Download.Enabled = false;
                Download.Text = "Downloading...";
                progressBar2.Visible = true;

                using (WebClient wc = new WebClient())
                {
                    string updatelocation = Properties.Settings.Default.SaveLocation + @"\" + Properties.Settings.Default.WorldZipName + ".zip";
                    progressBar2.Visible = true;

                    wc.DownloadProgressChanged += wc_DownloadProgressChanged2;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(Properties.Settings.Default.DownloadLocation),
                        // Param2 = Path to save
                        updatelocation
                    );
                    this.BringToFront();
                }
            }
        }

        void wc_DownloadProgressChanged2(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
            long FileSize = e.TotalBytesToReceive / 1024;
            DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + e.TotalBytesToReceive.ToString() + " bytes";

            if (progressBar2.Value == 100)
            {
                this.BringToFront();
                progressBar2.Value = 100;
                timer2.Start();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            progressBar2.Visible = false;
            DLPercentText.Text = " ";
            Download.Enabled = true;
            Download.Text = "Download";
            comboBox1.SelectedIndex = 0;

            string save = Properties.Settings.Default.SaveLocation + @"\" + Properties.Settings.Default.WorldZipName + ".zip";
            string extract = Properties.Settings.Default.SaveLocation + @"\";
            try
            {
                ZipFile.ExtractToDirectory(save, extract);
                MessageBox.Show("The world save has successfully been installed. If you chose to install it to the default directory, you should now see it in your Minecraft single player menu.");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error installing the world save." + Environment.NewLine + Environment.NewLine + ex.Message.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/RyanWalpoleEnterprises/Minecraft/blob/master/World-Saver/README.md");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Reset();
        }
    }
}
