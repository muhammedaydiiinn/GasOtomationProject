using Microsoft.Identity.Client;
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
    public partial class FrmAdminPanel : Form
    {
        private void EnvanterAc()
        {
            FrmEnvanter frmEnvanter = new FrmEnvanter(this);
            frmEnvanter.ShowDialog();
        }

        public FrmAdminPanel()
        {
            InitializeComponent();


            timer1.Interval = 1000; // 1 saniyede bir tetiklenecek
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start(); // Zamanlayıcıyı başlatın
        }
        SqlBaglanti baglanti = new SqlBaglanti();
        public string name;

        public void KasaGüncelle()
        {
            lblKasa.Text = baglanti.GetKasa().ToString();
        }
        private void PerAddBox_Click(object sender, EventArgs e)
        {
            FrmPerAdd perEkle = new FrmPerAdd();
            perEkle.ShowDialog();
        }

        private void PerUpdateBox_Click(object sender, EventArgs e)
        {
            FrmPerUpdate perUpdate = new FrmPerUpdate();
            perUpdate.ShowDialog();
        }

       

        private void PerİnfoBox_Click(object sender, EventArgs e)
        {
            FrmAdminPerİnfo perİnfo = new FrmAdminPerİnfo();
            perİnfo.ShowDialog();
        }

        private void EnvanterBox_Click(object sender, EventArgs e)
        {
            EnvanterAc();
        }

        private void İstatistikBox_Click(object sender, EventArgs e)
        {
            FrmAdminİstatistik istatistik = new FrmAdminİstatistik();
            istatistik.ShowDialog();

        }

        private void Yönetici_Panel_Load(object sender, EventArgs e)
        {
            labelTarihSaat.Text = DateTime.Now.ToString();
            UserLabel.Text = name;
            KasaGüncelle();
        }
        private void FiyatBox_Click(object sender, EventArgs e)
        {
            FrmFiyatGüncelle frmFiyat = new FrmFiyatGüncelle();
            frmFiyat.ShowDialog();

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kapatmak İstediğinize Emin Misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FrmKasiyerGiris form1 = new FrmKasiyerGiris();
                form1.Show();
                this.Close();
            }
        }

        private void btnTasitMatik_Click(object sender, EventArgs e)
        {
            FrmTasıtmatik frmTasıtmatik = new FrmTasıtmatik();
            frmTasıtmatik.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTarihSaat.Text = DateTime.Now.ToString();
        }
    }
}
