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
    public partial class FrmGirisAnimasyon : Form
    {
        public FrmGirisAnimasyon()
        {
            InitializeComponent();
        }
        bool baslangıcEnabled = false;
     
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            {
                if (!baslangıcEnabled)
                {
                    this.Opacity += 0.009;

                }
                if (this.Opacity == 1.0)
                {
                    baslangıcEnabled = true;
                }
                if (baslangıcEnabled)
                {
                    this.Opacity -= 0.009;
                    if (this.Opacity == 0)
                    {
                        FrmKasiyerGiris gtr = new FrmKasiyerGiris();
                        gtr.Show();
                        this.Hide();
                        timer1.Enabled = false;
                        baslangıcEnabled = true;
                    }
                }

            }
        }

    }
}
