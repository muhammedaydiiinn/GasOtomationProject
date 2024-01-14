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
    public partial class FrmBos : Form
    {
        public FrmBos()
        {
            InitializeComponent();
        }

        private void FrmBos_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual; // Başlangıç konumunu manuel olarak ayarla
            int yAralik = 10; // İstediğiniz kadar aşağıya kaydırma miktarı

            // Yeni konumu hesapla ve ayarla
            this.Location = new Point(this.Location.X, this.Location.Y + yAralik);
        }
    }
}
