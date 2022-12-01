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
    public partial class ActivityForm : Form
    {
        public ActivityForm()
        {
            InitializeComponent();
        }

        private void CloseWindow_Tick(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (Process process in Process.GetProcessesByName("Minecraft Launcher (32 bit)"))
            {
                counter++;
                //MessageBox.Show("MC32");
            }
            foreach (Process process in Process.GetProcessesByName("Minecraft"))
            {
                counter++;
                //MessageBox.Show("MC");
            }
            foreach (Process process in Process.GetProcessesByName("MinecraftLauncher"))
            {
                counter++;
                //MessageBox.Show("MCL");
            }

            if (counter > 0)
            {
                CloseWindow.Stop();
                this.Close();
            }
            else
            {
                //game not running - assume not installed
                GameNotInstalled.Start();
            }

        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
            CloseWindow.Start();
        }

        private void GameNotInstalled_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("We tried looking for the Minecraft Launcher, but we weren't able to find it. You can specify the location manually through the TBP Launcher settings.");
            GameNotInstalled.Stop();
            this.Close();
        }

        private void ActivityForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseWindow.Stop();
            GameNotInstalled.Stop();
        }
    }
}
