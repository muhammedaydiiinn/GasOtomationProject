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
    public partial class FrmSatisİstatistik : Form
    {
        public FrmSatisİstatistik()
        {
            InitializeComponent();
        }
        public string name;
        SqlBaglanti baglanti = new SqlBaglanti();
        private void FrmPerSatis_Load(object sender, EventArgs e)
        {
            int ID =  baglanti.PersonelID(name);
            DataTable table = baglanti.GetPersonelSatisByID(ID);

            // DataGridView'e verileri ekleme
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();

        }
    }
}
