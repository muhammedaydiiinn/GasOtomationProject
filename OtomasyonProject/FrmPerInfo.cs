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
    public partial class FrmPerInfo : Form
    {
        public FrmPerInfo()
        {
            InitializeComponent();
        }
        SqlBaglanti sqlBaglanti = new SqlBaglanti();
        public string username1;

        private void FrmPerInfo_Load(object sender, EventArgs e)
        {
            labeluser.Text = username1;

            (string maas, string total) kasiyerBilgi = sqlBaglanti.GetKasiyerBilgi(username1);
            string maasDegeri = kasiyerBilgi.maas;
            string totalDegeri = kasiyerBilgi.total;

            lblAd.Text= sqlBaglanti.GetKasiyerAdSoyad(username1);
            lblMaas.Text = maasDegeri.ToString();
            lblToplam.Text = totalDegeri.ToString();
            label2.Visible = true;
            label4.Visible = true;
        }
    }
}
