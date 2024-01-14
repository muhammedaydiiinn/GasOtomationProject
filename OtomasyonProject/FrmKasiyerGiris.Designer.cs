namespace Otomasyon_Projesi
{
    partial class FrmKasiyerGiris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKasiyerGiris));
            this.exitBox = new System.Windows.Forms.PictureBox();
            this.TextKullaniici = new System.Windows.Forms.TextBox();
            this.TextPass = new System.Windows.Forms.TextBox();
            this.BtnGiris = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYönetici = new System.Windows.Forms.Button();
            this.pbEye = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEye)).BeginInit();
            this.SuspendLayout();
            // 
            // exitBox
            // 
            this.exitBox.BackColor = System.Drawing.Color.Transparent;
            this.exitBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBox.Image = ((System.Drawing.Image)(resources.GetObject("exitBox.Image")));
            this.exitBox.Location = new System.Drawing.Point(630, 4);
            this.exitBox.Name = "exitBox";
            this.exitBox.Size = new System.Drawing.Size(37, 32);
            this.exitBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitBox.TabIndex = 0;
            this.exitBox.TabStop = false;
            this.exitBox.Click += new System.EventHandler(this.exitBox_Click);
            // 
            // TextKullaniici
            // 
            this.TextKullaniici.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(51)))), ((int)(((byte)(97)))));
            this.TextKullaniici.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextKullaniici.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TextKullaniici.ForeColor = System.Drawing.Color.White;
            this.TextKullaniici.Location = new System.Drawing.Point(266, 265);
            this.TextKullaniici.Name = "TextKullaniici";
            this.TextKullaniici.Size = new System.Drawing.Size(171, 26);
            this.TextKullaniici.TabIndex = 4;
            // 
            // TextPass
            // 
            this.TextPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(51)))), ((int)(((byte)(97)))));
            this.TextPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextPass.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.TextPass.ForeColor = System.Drawing.Color.White;
            this.TextPass.Location = new System.Drawing.Point(266, 319);
            this.TextPass.Name = "TextPass";
            this.TextPass.PasswordChar = '*';
            this.TextPass.Size = new System.Drawing.Size(166, 26);
            this.TextPass.TabIndex = 5;
            // 
            // BtnGiris
            // 
            this.BtnGiris.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGiris.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGiris.Location = new System.Drawing.Point(352, 363);
            this.BtnGiris.Name = "BtnGiris";
            this.BtnGiris.Size = new System.Drawing.Size(85, 34);
            this.BtnGiris.TabIndex = 6;
            this.BtnGiris.Text = "Giriş";
            this.BtnGiris.UseVisualStyleBackColor = false;
            this.BtnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(228, 374);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 16);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Şifremi Unuttum";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(106, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(464, 42);
            this.label4.TabIndex = 8;
            this.label4.Text = "AKARYAKIT OTOMASYONU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(35)))), ((int)(((byte)(75)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(238, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 39);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kasiyer Giriş";
            // 
            // btnYönetici
            // 
            this.btnYönetici.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(35)))), ((int)(((byte)(75)))));
            this.btnYönetici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnYönetici.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYönetici.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYönetici.ForeColor = System.Drawing.Color.White;
            this.btnYönetici.Location = new System.Drawing.Point(409, 160);
            this.btnYönetici.Name = "btnYönetici";
            this.btnYönetici.Size = new System.Drawing.Size(127, 31);
            this.btnYönetici.TabIndex = 10;
            this.btnYönetici.Text = "Yönetici Giriş";
            this.btnYönetici.UseVisualStyleBackColor = false;
            this.btnYönetici.Click += new System.EventHandler(this.btnYönetici_Click);
            // 
            // pbEye
            // 
            this.pbEye.BackColor = System.Drawing.Color.Transparent;
            this.pbEye.Image = global::Otomasyon_Projesi.Properties.Resources.icons8_hide_96;
            this.pbEye.Location = new System.Drawing.Point(400, 316);
            this.pbEye.Name = "pbEye";
            this.pbEye.Size = new System.Drawing.Size(40, 30);
            this.pbEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEye.TabIndex = 11;
            this.pbEye.TabStop = false;
            this.pbEye.Click += new System.EventHandler(this.pbEye_Click);
            // 
            // FrmKasiyerGiris
            // 
            this.AcceptButton = this.BtnGiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(671, 558);
            this.ControlBox = false;
            this.Controls.Add(this.pbEye);
            this.Controls.Add(this.btnYönetici);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.BtnGiris);
            this.Controls.Add(this.TextPass);
            this.Controls.Add(this.TextKullaniici);
            this.Controls.Add(this.exitBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKasiyerGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox exitBox;
        public System.Windows.Forms.TextBox TextKullaniici;
        private System.Windows.Forms.TextBox TextPass;
        private System.Windows.Forms.Button BtnGiris;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYönetici;
        private System.Windows.Forms.PictureBox pbEye;
    }
}

