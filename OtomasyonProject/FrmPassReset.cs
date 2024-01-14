using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon_Projesi
{
    public partial class FrmPassReset : Form
    {
       
        public FrmPassReset()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmKasiyerGiris form1 = new FrmKasiyerGiris();
            form1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                SifreSifirlayici sifirlayici = new SifreSifirlayici();

                sifirlayici.randomSifre(textBox1.Text, textBox2.Text);

                sifirlayici.sifreSifirla(textBox2.Text);
                FrmKasiyerGiris form1 = new FrmKasiyerGiris();
                form1.Show();
                this.Close();
            }else
            {
                MessageBox.Show("Değerler boş olamaz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            


        }

       
    }
}
