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
    public partial class FrmEnvanter : Form
    {
        private FrmAdminPanel adminPanelForm;
        private FrmHomePage homePage;

        public FrmEnvanter(FrmAdminPanel adminPanelForm)
        {
            InitializeComponent();
            this.adminPanelForm = adminPanelForm;
        }
        public FrmEnvanter()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();


        private void cmbYakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            string selectedYakit = cmbYakit.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedYakit))
            {
                decimal miktarDecimal = baglanti.GetMiktar(selectedYakit);
                string miktar = miktarDecimal.ToString();

                // FiyatTextBox'ına fiyatı yaz
                lblMiktar.Text = miktar;

                // İlerleme çubuğunu miktar oranında güncelle
                if (int.TryParse(miktar, out int progress))
                {
                    progressBar1.Value = progress;
                    lblMiktar.Visible = true;
                    label5.Visible = true;
                }
            }
        }


        private void FrmEnvanter_Load(object sender, EventArgs e)
        {
            
            List<string> yakitCinsleri = baglanti.GetYakitCinsleri();

            foreach (string isim in yakitCinsleri)
            {
                cmbYakit.Items.Add(isim);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
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
                if (testMiktar <= 10000) {
                    bool eklemeBasarili = baglanti.UpdateYakitMiktari(eskiMiktar, eklenenMiktar, cmbYakit.Text);

                    if (eklemeBasarili)
                    {
                        txtEkle.Text = "";
                        string selectedYakit = cmbYakit.SelectedItem.ToString();
                        decimal miktarDecimal = baglanti.GetMiktar(selectedYakit);
                        string miktar1 = miktarDecimal.ToString(); 
                        lblMiktar.Text = miktar1;
                        int progress = int.Parse(miktar1);
                        progressBar1.Value = progress;
                        baglanti.YakitAl(eklenenMiktar, selectedYakit);
                        this.adminPanelForm.KasaGüncelle();

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

        private void txtEkle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEkle_TextChanged(object sender, EventArgs e)
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
