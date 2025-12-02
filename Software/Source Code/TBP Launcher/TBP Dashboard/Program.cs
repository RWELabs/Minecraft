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

            // Global error handlers to avoid silent crashes and capture diagnostics
            Application.ThreadException += (sender, e) => LogAndShowFatal(e.Exception, "UI Thread Exception");
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                LogAndShowFatal(ex, "Unhandled Exception");
            };

            // NOTE: Environment.OSVersion.Version is NOT reliable for distinguishing
            // Windows 10 vs Windows 11 without a proper application manifest.
            // Many .NET Framework/WinForms apps will report a Windows 10 build
            // even when running on Windows 11, causing false "older OS" logic paths.
            // We switch to registry-based detection of ProductName.

            bool isWin11OrLater = IsWindows11OrLater();

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string ModFolder = AppData + @"\.minecraft\mods";

            if (!Directory.Exists(ModFolder)) { Directory.CreateDirectory(ModFolder); }

            if (isWin11OrLater)
            {
                // Assume WebView2 Evergreen Runtime typically present; attempt silent check but avoid noisy prompt.
                try
                {
                    string available = CoreWebView2Environment.GetAvailableBrowserVersionString(null);
                    // If null, we will still let the SignIn form attempt initialization; only that form should decide on fallback UX.
                }
                catch (Exception ex) { LogException(ex, "WV2 check (Win11 path)"); }
                Properties.Settings.Default.wv2ignored = "true"; // treat as bypass for legacy prerequisite prompt
                Properties.Settings.Default.Save();
                SafeLaunch();
                return;
            }

            // Older OS path (Windows 10 or undetected): retain previous prompt logic but streamline.
            if (Properties.Settings.Default.wv2ignored.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                SafeLaunch();
                return;
            }

            // Only prompt if runtime truly not available; otherwise proceed.
            bool webView2Missing = false;
            try
            {
                string version = CoreWebView2Environment.GetAvailableBrowserVersionString(null);
                if (version == null) webView2Missing = true;
            }
            catch { webView2Missing = true; }

            if (webView2Missing)
            {
                string message = "WebView2 Runtime was not detected. Install now? (Required for embedded content)";
                string title = "Prerequisite | TBPlay";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Run(new FirstRunSetup());
                }
                else
                {
                    Properties.Settings.Default.wv2ignored = "true";
                    Properties.Settings.Default.Save();
                    SafeLaunch();
                }
            }
            else
            {
                SafeLaunch();
            }
        }

        private static void LaunchFromArgsOrDefault()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string uri = args[1];
                if (uri.StartsWith("tbplay://open", StringComparison.OrdinalIgnoreCase))
                {
                    Application.Run(new SignIn());
                }
                else if (uri.StartsWith("tbplay://play", StringComparison.OrdinalIgnoreCase))
                {
                    Properties.Settings.Default.launchFlag = "play";
                    Application.Run(new SignIn());
                }
                else if (uri.StartsWith("tbplay://map", StringComparison.OrdinalIgnoreCase))
                {
                    Properties.Settings.Default.launchFlag = "map";
                    Application.Run(new SignIn());
                }
                else if (uri.StartsWith("tbplay://minecraft/post", StringComparison.OrdinalIgnoreCase))
                {
                    Properties.Settings.Default.launchFlag = "url";
                    Properties.Settings.Default.postID = uri.Substring("tbplay://minecraft/post".Length).Trim('/');
                    //MessageBox.Show(Properties.Settings.Default.postID);
                    Application.Run(new SignIn());
                }
                else if (uri.StartsWith("tbplay://", StringComparison.OrdinalIgnoreCase))
                {
                    Application.Run(new SignIn());
                }
                else
                {
                    Application.Run(new SignIn());
                }
            }
            else
            {
                Application.Run(new SignIn());
            }
        }

        private static void SafeLaunch()
        {
            try
            {
                LaunchFromArgsOrDefault();
            }
            catch (Exception ex)
            {
                LogAndShowFatal(ex, "Launch failure");
            }
        }

        private static void LogAndShowFatal(Exception ex, string context)
        {
            LogException(ex, context);
            try
            {
                MessageBox.Show(
                    "TBPlay failed to start. A log has been saved to %AppData%\\RWE Labs\\TBP\\logs.\n\n" +
                    (ex != null ? ex.Message : "Unknown error"),
                    "TBPlay | Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch { }
        }

        private static void LogException(Exception ex, string context)
        {
            try
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string logDir = Path.Combine(appData, "RWE Labs", "TBP", "logs");
                Directory.CreateDirectory(logDir);
                string logPath = Path.Combine(logDir, "launcher.log");
                using (var sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {context}");
                    if (ex != null)
                    {
                        sw.WriteLine(ex.ToString());
                    }
                    sw.WriteLine("---");
                }
            }
            catch { /* best-effort logging */ }
        }

        private static bool IsWindows11OrLater()
        {
            try
            {
                // ProductName usually contains "Windows 11" (e.g., "Windows 11 Pro")
                // Future-proof: also treat Windows 12 similarly if appears.
                var productName = Registry.GetValue(
                    "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
                    "ProductName",
                    "") as string;
                if (string.IsNullOrEmpty(productName)) return false;
                return productName.IndexOf("Windows 11", StringComparison.OrdinalIgnoreCase) >= 0
                       || productName.IndexOf("Windows 12", StringComparison.OrdinalIgnoreCase) >= 0;
            }
            catch { return false; }
        }
    }
}
