using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon_Projesi
{
    public partial class FrmSatisYap : Form
    {
        private FrmHomePage homePage;
        public FrmSatisYap(FrmHomePage homePage)
        {
            InitializeComponent();
            this.homePage = homePage;
        }
        SqlBaglanti baglanti = new SqlBaglanti();
        public string username1;

        private void VeriAktar()
        {
            FrmFis frmFis = new FrmFis();
            frmFis.VeriAl(mskPlaka.Text, CmbYakit.SelectedItem.ToString(), Convert.ToDecimal(numericUpDown.Value),durum,username1);

            // FrmFis formunu açmak için ShowDialog() kullanın
            
            frmFis.ShowDialog();
            
            this.Hide(); // FrmSatisYap'ı kapatın
            
            
        }
       
        private void FrmSatisYap_Load(object sender, EventArgs e)
        {
            List<string> yakitCinsleri = baglanti.GetYakitCinsleri();

            foreach (string isim in yakitCinsleri)
            {
                CmbYakit.Items.Add(isim);
            }
            label4.Text = username1;
            mskPlaka.KeyPress += mskPlaka_KeyPress;
        }
        private bool durum;
        private void BtnSatis_Click(object sender, EventArgs e)
        {

            try
            {
                string username = label4.Text;
                string selectedYakit = CmbYakit.SelectedItem.ToString();
                string plaka = mskPlaka.Text;
                bool plakaVarMi = baglanti.PlakaVarMi(plaka);

                if (string.IsNullOrWhiteSpace(plaka))
                {
                    MessageBox.Show("Lütfen plaka giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // username çekme
                if (plakaVarMi)
                {
                    int girisSayisi = baglanti.TasitmatikGirisSayisi(plaka);

                    if (girisSayisi > 0 && girisSayisi % 10 == 0)
                    {
                        decimal satisLitre = Convert.ToDecimal(numericUpDown.Value);

                        int ID = baglanti.GetKasiyerID(username);


                        bool satisBasarili = baglanti.TasitmatikSatisYap(satisLitre, selectedYakit, plaka, ID);
                        MessageBox.Show("Her 10. girişe özel %10 indirim uygulandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        durum = true;
                        if (satisBasarili)
                        {

                            VeriAktar();
                            this.homePage.KasaGüncelle();
                        }
                    }
                    else
                    {

                        decimal satisLitre = Convert.ToDecimal(numericUpDown.Value);

                        int ID = baglanti.GetKasiyerID(username);


                        bool satisBasarili = baglanti.SatisYap(satisLitre, selectedYakit, plaka, ID);

                        if (satisBasarili)
                        {

                            VeriAktar();
                            this.homePage.KasaGüncelle();
                        }
                    }


                }
                else
                {


                    decimal satisLitre = Convert.ToDecimal(numericUpDown.Value);

                    int ID = baglanti.GetKasiyerID(username);


                    bool satisBasarili = baglanti.SatisYap(satisLitre, selectedYakit, plaka, ID);

                    if (satisBasarili)
                    {
                        
                        VeriAktar();
                        this.homePage.KasaGüncelle();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            

        }

        private void CmbYakit_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedYakit = CmbYakit.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedYakit))
            {
                decimal satisLitre = Convert.ToDecimal(baglanti.GetFiyat(selectedYakit));
                label10.Text = satisLitre.ToString();
                txtLitreFiyat.Text = satisLitre.ToString();

                txtTutar.Text = "";
                numericUpDown.Value = 0;
            }


        }
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbYakit.SelectedItem != null && !string.IsNullOrWhiteSpace(mskPlaka.Text))
                {
                   decimal satisLitre = Convert.ToDecimal(label10.Text);

                    decimal miktar = Convert.ToDecimal(numericUpDown.Value);
                    decimal tutar = satisLitre * miktar;
                    txtTutar.Text = tutar.ToString();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(mskPlaka.Text))
                    {
                        MessageBox.Show("Lütfen plaka giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Yakıt Seçiniz!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("Bağlantı süresi aşıldı: " + ex.Message, "Timeout Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnTasitMatik_Click(object sender, EventArgs e)
        {
            string plaka = mskPlaka.Text;
            bool plakaVarMi = baglanti.PlakaVarMi(plaka);
            if (string.IsNullOrWhiteSpace(plaka))
            {
                MessageBox.Show("Lütfen plaka giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else { 

            if (plakaVarMi)
            {
                MessageBox.Show("Taşıtmatik Var", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Taşıtmatik Yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            }
        }

        private void mskPlaka_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
