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
    public partial class FrmFiyatGüncelle : Form
    {
        public FrmFiyatGüncelle()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();

        private void FiyatGüncelle_Load(object sender, EventArgs e)
        {
            List<string> yakitCinsleri = baglanti.GetYakitCinsleri();

            foreach (string isim in yakitCinsleri)
            {
                comboBox1.Items.Add(isim);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsatis.ReadOnly = false;
            label1.Visible = false;

            // ComboBox'tan seçili öğeyi al
            string selectedYakit = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedYakit))
            {
                // Fiyatı getir
                decimal satisfiyat = baglanti.GetFiyat(selectedYakit);
                decimal alisfiyat;
                decimal yuzdeDortEksik = satisfiyat - (satisfiyat * 0.04m);
                alisfiyat = Math.Round(yuzdeDortEksik, 2);

                // FiyatTextBox'ına fiyatları yaz
                txtsatis.Text = satisfiyat.ToString();
                txtAlis.Text = alisfiyat.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal yeniSatis = Convert.ToDecimal(txtsatis.Text);
            decimal yeniAlis = Convert.ToDecimal(txtAlis.Text);

            decimal yuzdeDortEksik = yeniSatis - (yeniSatis * 0.04m);
            yeniAlis = yuzdeDortEksik;

            bool güncellemeBasarili = baglanti.UpdateLitreSatisFiyati(yeniAlis,yeniSatis,comboBox1.Text);

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

        private void txtsatis_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer giriş char bir rakam veya virgül değilse ve bir kontrol karakteri değilse
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; // Etkisiz hale getir, yani girişi reddet
            }

            // Eğer zaten bir virgül varsa ve tekrar virgül girilmeye çalışılıyorsa
            if (e.KeyChar == ',' && txtsatis.Text.Contains(','))
            {
                e.Handled = true; // Etkisiz hale getir, yani girişi reddet
            }
        }

        

        private void label1_Click_1(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
