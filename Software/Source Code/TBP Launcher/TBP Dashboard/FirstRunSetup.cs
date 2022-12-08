using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBP_Dashboard
{
    public partial class FirstRunSetup : Form
    {
        public FirstRunSetup()
        {
            InitializeComponent();

            StatusText.Text = "Reading files...";
            FRIStatusBar.Value = 1;

            MSWebViewInstall.Start();
        }

        private void MSWebViewInstall_Tick(object sender, EventArgs e)
        {
            MSWebViewInstall.Stop();
            StatusText.Text = "Installing Component: Microsoft.WebView2";
            FRIStatusBar.Value = FRIStatusBar.Value + 27;

            string DataFolder = Application.ExecutablePath.Replace("TBP Dashboard.exe", null);

            ProcessStartInfo install = new ProcessStartInfo();
            install.FileName = DataFolder + "MicrosoftEdgeWebview2Setup.exe";
            install.Arguments = "/silent /install";
            install.WorkingDirectory = DataFolder;
            install.UseShellExecute = true;
            //install.RedirectStandardOutput = true;
            install.CreateNoWindow = true;
            Process.Start(install);
            CheckInstallProgress.Start();
        }

        private void CheckInstallProgress_Tick(object sender, EventArgs e)
        {
            try
            {
                string WV = CoreWebView2Environment.GetAvailableBrowserVersionString();

                if (WV != null)
                {
                    CheckInstallProgress.Stop();
                    StatusText.Text = "Installed Microsoft.WebView2 " + WV;
                    FRIStatusBar.Value = 99;
                    FinishSetup();
                }
                else
                {
                    if (FRIStatusBar.Value <= 99)
                    {
                        FRIStatusBar.Value = FRIStatusBar.Value + 1;
                    }
                    else
                    {
                        FRIStatusBar.Value = 99;
                    }
                }
            }
            catch
            {
                if (FRIStatusBar.Value <= 99)
                {
                    FRIStatusBar.Value = FRIStatusBar.Value + 1;
                }
                else
                {
                    FRIStatusBar.Value = 99;
                }
            }
        }

        private void FinishSetup()
        {
            StatusText.Text = "Finishing Setup...";

            this.Hide();
            SignIn dash = new SignIn();
            dash.Show();
        }
    }
}
