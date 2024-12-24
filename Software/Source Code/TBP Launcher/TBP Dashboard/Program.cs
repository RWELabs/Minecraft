using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBP_Dashboard
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Version requiredVersion = new Version(10, 0, 22000); 
            Version currentVersion = Environment.OSVersion.Version;

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string ModFolder = AppData + @"\.minecraft\mods";

            if (!Directory.Exists(ModFolder)) { Directory.CreateDirectory(ModFolder); }

            if (currentVersion >= requiredVersion)
            {
                //System is running Windows 11 21H2
                Application.Run(new SignIn());
            } 
            else 
            {
                //System is running on a version of Windows, older than Windows 11 21H2

                if(Properties.Settings.Default.wv2ignored.ToLower() == "true")
                {
                    Application.Run(new SignIn());
                }
                else if (Properties.Settings.Default.wv2ignored.ToLower() == "false")
                {
                    try
                    {
                        string WV = CoreWebView2Environment.GetAvailableBrowserVersionString(null);

                        if (WV == null)
                        {
                            string Message = "We were unable to find a valid WebView2 Core Environment on this PC. Would you like to try installing WebView2?";
                            string Title = "Prerequisite Install | TBP Launcher";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show(Message, Title, buttons);

                            if (result == DialogResult.Yes)
                            {
                                Application.Run(new FirstRunSetup());
                            }
                            else
                            {
                                Application.Run(new SignIn());
                                Properties.Settings.Default.wv2ignored = "true";
                                Properties.Settings.Default.Save();
                            }
                        }
                        else
                        {
                            Application.Run(new SignIn());
                        }
                    }
                    catch (Exception ex)
                    {
                        {
                            //MessageBox.Show($"There was an issue determining your available web browser environment. {ex.Message}");
                            string Message = "We were unable to find a valid WebView2 Core Environment on this PC. Would you like to try installing WebView2?";
                            string Title = "Prerequisite Install | TBP Launcher";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show(Message, Title, buttons);

                            if (result == DialogResult.Yes)
                            {
                                Application.Run(new FirstRunSetup());
                            }
                            else
                            {
                                Application.Run(new SignIn());
                                Properties.Settings.Default.wv2ignored = "true";
                                Properties.Settings.Default.Save();
                            }
                        }
                    }
                }
            }
        }
    }
}
