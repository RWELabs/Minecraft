using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

            try
            {
                string WV = CoreWebView2Environment.GetAvailableBrowserVersionString();
                
                if(WV != null)
                {
                    Application.Run(new SignIn());
                }
                else
                {
                    Application.Run(new FirstRunSetup());
                }
            }
            catch
            {
                Application.Run(new FirstRunSetup());
            }
        }
    }
}
