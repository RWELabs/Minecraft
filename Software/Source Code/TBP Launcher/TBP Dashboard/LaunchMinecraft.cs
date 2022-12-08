using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System;

private void button1_Click(object sender, EventArgs e)
{
    //If user clicks Play
    if (WebView2.Source.ToString().EndsWith("#wingo?ref=play"))
    {
        ActivityForm af = new ActivityForm();
        af.Show();
        string LaunchProcedure = Properties.Settings.Default.LaunchMinecraft;

        if (string.IsNullOrEmpty(LaunchProcedure))
        {
            string InstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            if (InstallPath != null)
            {
                try
                {
                    Process.Start(InstallPath + @"MinecraftLauncher.exe");
                    Properties.Settings.Default.LaunchMinecraft = InstallPath + @"MinecraftLauncher.exe";
                    Properties.Settings.Default.Save();
                }
                catch
                {
                    try
                    {
                        string InstallLocation = Path.GetDirectoryName(Application.ExecutablePath).Replace("TBP Dashboard.exe", null);
                        Process.Start(InstallLocation + "mclauncher.lnk");
                        Properties.Settings.Default.LaunchMinecraft = Properties.Settings.Default.MSStoreMinecraftLocation;
                        Properties.Settings.Default.Save();
                    }
                    catch
                    {

                    }
                }
            }
        }
        else if (string.IsNullOrWhiteSpace(LaunchProcedure))
        {
            string InstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
            if (InstallPath != null)
            {
                try
                {
                    Process.Start(InstallPath + @"MinecraftLauncher.exe");
                    Properties.Settings.Default.LaunchMinecraft = InstallPath + @"MinecraftLauncher.exe";
                    Properties.Settings.Default.Save();
                }
                catch
                {
                    try
                    {
                        string InstallLocation = Path.GetDirectoryName(Application.ExecutablePath).Replace("TBP Dashboard.exe", null);
                        Process.Start(InstallLocation + "mclauncher.lnk");
                        Properties.Settings.Default.LaunchMinecraft = Properties.Settings.Default.MSStoreMinecraftLocation;
                        Properties.Settings.Default.Save();
                    }
                    catch
                    {

                    }
                }
            }
        }
        else if (LaunchProcedure == "\"explorer.exe\", @\"shell:AppsFolder\\Microsoft.4297127D64EC6_8wekyb3d8bbwe!Minecraft\");")
        {
            try
            {
                Process.Start(LaunchProcedure);
                string InstallLocation = Path.GetDirectoryName(Application.ExecutablePath).Replace("TBP Dashboard.exe", null);
                Process.Start(InstallLocation + "mclauncher.lnk");
            }
            catch
            {
                //
            }
        }
    }

    if (WebView2.Source.ToString().EndsWith("#wingo?ref=play"))
    {
        //Play
        try
        {
            Process.Start(Properties.Settings.Default.LaunchMinecraft);
        }
        catch
        {
            //couldn't launch from there...
            try
            {
                Process.Start(
                "explorer.exe",
                @"shell:AppsFolder\Microsoft.4297127D64EC6_8wekyb3d8bbwe!Minecraft");

                Properties.Settings.Default.LaunchMinecraft = Properties.Settings.Default.MSStoreMinecraftLocation;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                try
                {
                    Process.Start(Properties.Settings.Default.LaunchMinecraft);
                }
                catch
                {
                    //couldn't launch from there...
                    try
                    {
                        Process.Start(
                        "explorer.exe",
                        @"shell:AppsFolder\Microsoft.4297127D64EC6_8wekyb3d8bbwe!Minecraft");

                        Properties.Settings.Default.LaunchMinecraft = Properties.Settings.Default.MSStoreMinecraftLocation;
                        Properties.Settings.Default.Save();
                    }
                    catch
                    {
                        string InstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mojang\InstalledProducts\Minecraft Launcher", "Installed", null);
                        if (InstallPath != null)
                        {
                            MessageBox.Show("We weren't able to find your Minecraft Launcher install location. You might need to manually assign it in the application settings.");
                        }
                        else
                        {
                            Process.Start(InstallPath + "MinecraftLauncher.exe");
                            Properties.Settings.Default.LaunchMinecraft = InstallPath + "MinecraftLauncher.exe";
                            Properties.Settings.Default.Save();
                        }
                    }
                }
            }
        }
    }
}