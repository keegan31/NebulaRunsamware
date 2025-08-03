namespace NebulaRun
{
    partial class Nbl
    { //The Ransom UI
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Label labelDiscordUser;
        private System.Windows.Forms.Label labelVictimCode;
        private System.Windows.Forms.PictureBox pictureBoxNebula;

        private System.Windows.Forms.TextBox textBoxDecryptPassword;
        private System.Windows.Forms.Button buttonDecrypt;

       
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NotifyIcon notifyIcon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                notifyIcon?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nbl));
            this.labelTitle = new System.Windows.Forms.Label();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.labelDiscordUser = new System.Windows.Forms.Label();
            this.labelVictimCode = new System.Windows.Forms.Label();
            this.pictureBoxNebula = new System.Windows.Forms.PictureBox();
            this.textBoxDecryptPassword = new System.Windows.Forms.TextBox();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNebula)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelTitle.Location = new System.Drawing.Point(10, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Nebula Decryptor";
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.BackColor = System.Drawing.Color.Black;
            this.richTextBoxMessage.Font = new System.Drawing.Font("Consolas", 10F);
            this.richTextBoxMessage.ForeColor = System.Drawing.Color.DodgerBlue;
            this.richTextBoxMessage.Location = new System.Drawing.Point(243, 54);
            this.richTextBoxMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ReadOnly = true;
            this.richTextBoxMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxMessage.Size = new System.Drawing.Size(645, 227);
            this.richTextBoxMessage.TabIndex = 1;
            this.richTextBoxMessage.Text = resources.GetString("richTextBoxMessage.Text");
            // 
            // labelDiscordUser
            // 
            this.labelDiscordUser.AutoSize = true;
            this.labelDiscordUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelDiscordUser.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelDiscordUser.Location = new System.Drawing.Point(12, 291);
            this.labelDiscordUser.Name = "labelDiscordUser";
            this.labelDiscordUser.Size = new System.Drawing.Size(321, 28);
            this.labelDiscordUser.TabIndex = 2;
            this.labelDiscordUser.Text = "Discord Username: yessir063332";
            // 
            // labelVictimCode
            // 
            this.labelVictimCode.AutoSize = true;
            this.labelVictimCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelVictimCode.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelVictimCode.Location = new System.Drawing.Point(12, 363);
            this.labelVictimCode.Name = "labelVictimCode";
            this.labelVictimCode.Size = new System.Drawing.Size(161, 28);
            this.labelVictimCode.TabIndex = 3;
            this.labelVictimCode.Text = "Victim Code: ---";
            // 
            // pictureBoxNebula
            // 
            this.pictureBoxNebula.Location = new System.Drawing.Point(3, 40);
            this.pictureBoxNebula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxNebula.Name = "pictureBoxNebula";
            this.pictureBoxNebula.Size = new System.Drawing.Size(225, 241);
            this.pictureBoxNebula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNebula.TabIndex = 5;
            this.pictureBoxNebula.TabStop = false;
            // 
            // textBoxDecryptPassword
            // 
            this.textBoxDecryptPassword.BackColor = System.Drawing.Color.Black;
            this.textBoxDecryptPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxDecryptPassword.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBoxDecryptPassword.Location = new System.Drawing.Point(198, 328);
            this.textBoxDecryptPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDecryptPassword.Name = "textBoxDecryptPassword";
            this.textBoxDecryptPassword.Size = new System.Drawing.Size(505, 30);
            this.textBoxDecryptPassword.TabIndex = 6;
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.BackColor = System.Drawing.Color.Black;
            this.buttonDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDecrypt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonDecrypt.Location = new System.Drawing.Point(733, 328);
            this.buttonDecrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(137, 30);
            this.buttonDecrypt.TabIndex = 7;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = false;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Black;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonClose.Location = new System.Drawing.Point(865, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 30);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Nebula Decryptor (hidden)";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // Nbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(900, 400);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.textBoxDecryptPassword);
            this.Controls.Add(this.pictureBoxNebula);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.labelDiscordUser);
            this.Controls.Add(this.labelVictimCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Nbl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNebula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
