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
    public partial class FrmPerUpdate : Form
    {
        public FrmPerUpdate()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();
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
            if (comboBox1.SelectedItem == null || string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("Lütfen bir personel seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!IsValidEmail(textBoxEposta.Text))
            {
                MessageBox.Show("Geçerli bir email adresi girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool güncellemeBasarili = baglanti.PerGuncelle(Convert.ToInt32(idLabel.Text), textBoxMaas.Text, txtAdSoyad.Text, textBoxSoyad.Text, textBoxKullaniciAdi.Text, textBoxEposta.Text, textBoxSifre.Text);

                if (güncellemeBasarili)
                {
                    MessageBox.Show("Güncelleme Başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void PerUpdate_Load(object sender, EventArgs e)
        {
            List<string> personelIsimleri = baglanti.GetPersonelIsimleri();

            foreach (string isim in personelIsimleri)
            {
                comboBox1.Items.Add(isim);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // İlgili alanları düzenlenebilir hale getir
            txtAdSoyad.ReadOnly = false;
            textBoxSoyad.ReadOnly = false;
            textBoxKullaniciAdi.ReadOnly = false;
            textBoxSifre.ReadOnly = false;
            textBoxEposta.ReadOnly = false;
            textBoxMaas.ReadOnly = false;
            label7.Visible = false;

            // TextBox'ları temizle
            txtAdSoyad.Text = "";
            textBoxSoyad.Text = "";
            textBoxKullaniciAdi.Text = "";
            textBoxSifre.Text = "";
            textBoxEposta.Text = "";
            textBoxMaas.Text = "";

            // Seçilen personele ait detayları al
            string selectedPerson = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedPerson))
            {
                string details = baglanti.GetPersonelDetails(selectedPerson);

                string[] detailsSplit = details.Split('|');

                // Detayları TextBox'lara doldur
                idLabel.Text = detailsSplit[0];
                txtAdSoyad.Text = detailsSplit[1];
                textBoxSoyad.Text = detailsSplit[2];
                textBoxKullaniciAdi.Text = detailsSplit[3];
                textBoxSifre.Text = detailsSplit[4];
                textBoxEposta.Text = detailsSplit[5];
                textBoxMaas.Text = detailsSplit[6];
            }
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("Lütfen bir personel seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string selectedPerson = comboBox1.SelectedItem.ToString();
            int personelID = baglanti.GetPersonelID(selectedPerson);

            if (personelID != -1)
            {
                bool silindiMi = baglanti.PerDelete(personelID);
                if (silindiMi)
                {
                    MessageBox.Show("Personel Çıkarıldı.");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("İşlem Başarısız");
                }
            }
            else
            {
                MessageBox.Show("ID bulunamadı.");
            }
        }

        private void textBoxEposta_Leave(object sender, EventArgs e)
        {
                string email = textBoxEposta.Text;

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
                        toolTip1.Show("Geçersiz e-posta adresi!", textBoxEposta, textBoxEposta.Width, 0, 2000);
                    }
                }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}