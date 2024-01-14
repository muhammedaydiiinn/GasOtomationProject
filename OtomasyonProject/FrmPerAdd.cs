using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otomasyon_Projesi
{
    public partial class FrmPerAdd : Form
    {
        public FrmPerAdd()
        {
            InitializeComponent();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox'ların text'lerini kontrol et ve boş olup olmadıklarını kontrol et
            if (string.IsNullOrWhiteSpace(TxtAd.Text) || string.IsNullOrWhiteSpace(TxtSoyad.Text) || string.IsNullOrWhiteSpace(TxtNick.Text) || string.IsNullOrWhiteSpace(TxtEposta.Text) || string.IsNullOrWhiteSpace(TxtPass.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!IsValidEmail(TxtEposta.Text))
            {
                MessageBox.Show("Geçerli bir email adresi girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else { 
            // Tüm textbox'lar doluysa kayıt işlemini yap
            SqlBaglanti baglanti = new SqlBaglanti();
            bool kayitBasarili = baglanti.PerEkle(TxtAd.Text, TxtSoyad.Text, TxtNick.Text, TxtEposta.Text, TxtPass.Text);
            if (kayitBasarili)
            {
                MessageBox.Show("Kayıt Başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        }

        private void TxtEposta_Leave(object sender, EventArgs e)
        {
            
                string email = TxtEposta.Text;

                if (!string.IsNullOrWhiteSpace(email))
                {
                    try
                    {
                        // Girilen değerin e-posta formatında olup olmadığını kontrol et
                        MailAddress mail = new MailAddress(email);
                    }
                    catch (FormatException)
                    {
                        // Eğer e-posta formatında değilse tooltip göster
                        toolTip1.Show("Geçersiz e-posta adresi!", TxtEposta, TxtEposta.Width, 0, 2000);
                    }
                }
         
        }
    }
}
