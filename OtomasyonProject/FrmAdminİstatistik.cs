using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Otomasyon_Projesi
{
    public partial class FrmAdminİstatistik : Form
    {
        public FrmAdminİstatistik()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();

        private void FrmAdminİstatistik_Load(object sender, EventArgs e)
        {   
            tabloTool.Checked = true;
            histTool.Checked = false;
            pastaTool.Checked = false;
            ToolAlım.Checked = false;


            DataTable table = baglanti.GetAdSoyadSatis();
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
            
        }


        private void tabloTool_Click(object sender, EventArgs e)
        {
            tabloTool.Checked = true;
            histTool.Checked = false;
            pastaTool.Checked = false;
            ToolAlım.Checked = false;


            chartHist.Visible = false;
            dataGridView1.Visible = true;
            chartPasta.Visible = false;
            dataGridView2.Visible = false;

            DataTable table = baglanti.GetAdSoyadSatis();
            dataGridView1.DataSource = table;

            dataGridView1.ClearSelection();

        }

        private void pastaTool_Click(object sender, EventArgs e)
        {

            tabloTool.Checked = false;
            histTool.Checked = false;
            pastaTool.Checked = true;
            ToolAlım.Checked = false;

            chartHist.Visible = false;
            dataGridView1.Visible = false;
            chartPasta.Visible = true;
            dataGridView2.Visible = false;

            DataTable table = baglanti.GetPersonelSatis();

            chartPasta.Series.Clear();
            chartPasta.Series.Add("Satışlar");
            chartPasta.Series["Satışlar"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie; // Pasta grafiği için tip belirleme
            chartPasta.Series["Satışlar"].XValueMember = "Per_AD";
            chartPasta.Series["Satışlar"].YValueMembers = "PerSatisTutar";
            chartPasta.DataSource = table;

            double sumOfSales = Convert.ToDouble(table.Compute("SUM(PerSatisTutar)", string.Empty));
            foreach (var point in chartPasta.Series["Satışlar"].Points)
            {
                double salesValue = Convert.ToDouble(point.YValues[0]);
                point.Label = string.Format("{0:0.##}%", (salesValue / sumOfSales) * 100);
            }
        }






        private void histTool_Click_1(object sender, EventArgs e)
        {
            tabloTool.Checked = false;
            histTool.Checked = true;
            pastaTool.Checked = false;
            ToolAlım.Checked = false;

            chartPasta.Visible = false;
            dataGridView1.Visible = false;
            chartHist.Visible = true;
            dataGridView2.Visible = false;

            DataTable table = baglanti.GetPersonelSatis();

            chartHist.Series.Clear();
            chartHist.Series.Add("Satışlar");
            chartHist.Series["Satışlar"].XValueMember = "Per_AD";
            chartHist.Series["Satışlar"].YValueMembers = "PerSatisTutar";
            chartHist.DataSource = table;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            FrmSatisİstatistik perSatisForm = Application.OpenForms.OfType<FrmSatisİstatistik>().FirstOrDefault();
            if (perSatisForm != null)
            {
                perSatisForm.Close(); // Eğer açıksa, önceki formu kapat
            }

            FrmSatisİstatistik perSatis = new FrmSatisİstatistik();
            perSatis.name = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            perSatis.ShowDialog(); // Yeni formu aç
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tabloTool.Checked = false;
            histTool.Checked = false;
            pastaTool.Checked = false;
            ToolAlım.Checked = true;


            chartHist.Visible = false;
            dataGridView1.Visible = false;
            chartPasta.Visible = false;
            dataGridView2.Visible = true;

            DataTable table2 = baglanti.GetPersonelAlim();
            dataGridView2.DataSource = table2;

            dataGridView2.ClearSelection();
        }
    }
}
