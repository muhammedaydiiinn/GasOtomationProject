using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon_Projesi
{
    public partial class FrmAdminPerİnfo : Form
    {
        public FrmAdminPerİnfo()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();

        private void FrmAdminPerİnfo_Load(object sender, EventArgs e)
        {
            List<string> personelIsimleri = baglanti.GetPersonelIsimleri();

            foreach (string isim in personelIsimleri)
            {
                cmbPersoel.Items.Add(isim); // Diğer personel isimlerini ekle
            }

        }


        private void cmbPersoel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label3.Visible = false;
            lblAd.Text = "";
            lblSatis.Text = "";
            lblEposta.Text = "";
            lblMaas.Text = "";
            lblSatis.Visible = false;
            lblMaas.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            string selectedPerson = cmbPersoel.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedPerson))
            {
                string details = baglanti.GetPersonelDetails(selectedPerson);

                if (!string.IsNullOrEmpty(details))
                {
                    string[] detailsSplit = details.Split('|');

                    lblAd.Text = $"{detailsSplit[1]} {detailsSplit[2]}";
                    lblEposta.Text = detailsSplit[5];
                    lblMaas.Text = detailsSplit[6];

                    // Satis değeri kontrolü ve ekranda gösterimi
                    if (decimal.TryParse(detailsSplit[7], out decimal satisValue) && satisValue > 0)
                    {
                        lblSatis.Text = satisValue.ToString(); // Satış değeri varsa göster
                        lblSatis.Visible = true;
                        lblMaas.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            cmbPersoel.DroppedDown = true;
        }
    }
}
