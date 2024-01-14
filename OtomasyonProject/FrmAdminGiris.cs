using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otomasyon_Projesi
{
    public partial class FrmAdminGiris : Form
    {
        
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            bool girisBasarili = baglanti.AdminGiris(TextKullanici.Text,TextPass.Text);

            if (girisBasarili)
            {
                FrmAdminPanel Yönetici_Page = new FrmAdminPanel();
                Yönetici_Page.name = baglanti.GetAdminAdSoyad(TextKullanici.Text);
                Yönetici_Page.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre hatalı!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextKullanici.Clear();
                TextPass.Clear();
                TextKullanici.Focus();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmKasiyerGiris form1 = new FrmKasiyerGiris();
            form1.Show();
            this.Hide();
        }

        private void FrmAdminGiris_Load(object sender, EventArgs e)
        {
            
            TextKullanici.Focus();

        }

        private bool isVisible = true;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isVisible)
            {
                TextPass.PasswordChar = '\0'; // Şifre karakterini görünür yap
                pictureBox1.Image = Properties.Resources.icons8_eye_96;
            }
            else
            {
                TextPass.PasswordChar = '*'; // Şifre karakterini gizle
                pictureBox1.Image = Properties.Resources.icons8_hide_96;
            }

            isVisible = !isVisible; // Durumu tersine çevir
        }


    }
}
