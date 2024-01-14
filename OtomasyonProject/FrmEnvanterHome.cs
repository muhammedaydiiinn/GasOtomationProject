using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otomasyon_Projesi
{
    public partial class FrmEnvanterHome : Form
    {
        private FrmHomePage homePage;

        public FrmEnvanterHome(FrmHomePage homePage)
        {
            InitializeComponent();
            this.homePage = homePage;
        }
        public FrmEnvanterHome()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            // Seçili yakıtın kontrolü
            if (cmbYakit.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir yakıt seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Eklenecek miktarın kontrolü
            if (string.IsNullOrWhiteSpace(txtEkle.Text))
            {
                MessageBox.Show("Lütfen eklenecek miktarı girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int eskiMiktar = Convert.ToInt32(lblMiktar.Text);
            int eklenenMiktar = Convert.ToInt32(txtEkle.Text);

            

            int testMiktar = eskiMiktar + eklenenMiktar;
            
            if (testMiktar <= 10000)
            {
                bool eklemeBasarili = baglanti.UpdateYakitMiktari(eskiMiktar, eklenenMiktar, cmbYakit.Text);
                
                if (eklemeBasarili)
                {
                    txtEkle.Text = "";
                    string selectedYakit = cmbYakit.SelectedItem.ToString();
                    decimal miktarDecimal = baglanti.GetMiktar(selectedYakit);

                    string miktar1 = miktarDecimal.ToString();
                    lblMiktar.Text = miktar1;
                    int progress = int.Parse(miktar1);
                    prgsYkt.Value = progress;
                    baglanti.YakitAl(eklenenMiktar, selectedYakit);
                    this.homePage.KasaGüncelle();
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Depo Sınırına Ulaşıldı, Eklenemez!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void FrmEnvanterHome_Load(object sender, EventArgs e)
        {
            List<string> yakitCinsleri = baglanti.GetYakitCinsleri();

            foreach (string isim in yakitCinsleri)
            {
                cmbYakit.Items.Add(isim);
            }
        }

        private void cmbYakit_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label1.Visible = false;
            string selectedYakit = cmbYakit.SelectedItem.ToString();

            decimal miktarDecimal = baglanti.GetMiktar(selectedYakit);
            string miktar = miktarDecimal.ToString();

            // FiyatTextBox'ına fiyatı yaz
            lblMiktar.Text = miktar.ToString();
            int progress = int.Parse(miktar);
            prgsYkt.Value = progress;
            lblMiktar.Visible = true;
            label5.Visible = true;
        }

        private void txtEkle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

      

        private void txtEkle_TextChanged_1(object sender, EventArgs e)
        {
            if (cmbYakit.SelectedItem == null && !string.IsNullOrEmpty(txtEkle.Text))
                        {
                            MessageBox.Show("Yakıt seçmeden miktar giremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEkle.Text = string.Empty; // Miktarı temizle
                        }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            cmbYakit.DroppedDown = true;
        }
    }
}
