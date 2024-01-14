using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon_Projesi
{
    public partial class FrmFis : Form
    {
        private string plaka;
        private string yakit;
        private decimal miktar;
        private bool durum;
        private string username;
        public FrmFis()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();
        Satislar satislar = new Satislar();
        public void VeriAl(string plaka, string yakit,decimal miktar,bool durum,string username)
        {
            this.plaka = plaka;
            this.yakit = yakit;
            this.miktar= miktar;
            this.durum = durum;
            this.username = username;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Masaüstü yolu
            string folderName = "faturalar"; // Klasör adı
            string fullPath = Path.Combine(folderPath, folderName); // Tam dosya yolu

            if (!Directory.Exists(fullPath)) // Klasör zaten var mı kontrol et
            {
                Directory.CreateDirectory(fullPath); // Klasörü oluştur
            }

            Size panelSize = panel1.Size;
            Point panelLocation = this.PointToScreen(panel1.Location);

            Bitmap screenshot = new Bitmap(panelSize.Width, panelSize.Height);
            Graphics graphics = Graphics.FromImage(screenshot as Image);
            Rectangle cropRect = new Rectangle(0, 0, panelSize.Width, panelSize.Height-40); // Panel boyutları
            graphics.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, panelSize);
            Bitmap croppedScreenshot = screenshot.Clone(cropRect, screenshot.PixelFormat);

            string plakaValue = lblPlaka.Text;
            string fileName = $"{plakaValue}.png"; // Başlangıç dosya adı
            string savePath = Path.Combine(fullPath, fileName); // Başlangıç dosya yolu

            // Dosya adının var olup olmadığını kontrol et ve varsa bir sonraki dosya adını dene
            int counter = 1;
            while (File.Exists(savePath))
            {
                counter++;
                fileName = $"{plakaValue}_{counter}.png"; // Yeni dosya adı
                savePath = Path.Combine(fullPath, fileName); // Yeni dosya yolu
            }

            // Dosyayı kaydet
            croppedScreenshot.Save(savePath);

            // Diğer işlemler...

            screenshot.Dispose();
            croppedScreenshot.Dispose();

           

            this.Close();
        }

        private string FormatUsername(string username)
        {
            username = baglanti.GetKasiyerAdSoyad(username);
            string[] parts = username.Split(' '); // Boşluklara göre kelimeleri ayır

            // Her kelimenin baş harfini büyük yaparak formatla
            for (int i = 0; i < parts.Length; i++)
            {
                if (!string.IsNullOrEmpty(parts[i]))
                {
                    parts[i] = parts[i][0].ToString().ToUpper() + new string('*', parts[i].Length - 1);
                }
            }

            return string.Join(" ", parts); // Formatlanmış kelimeleri birleştir
        }
        private void FrmFis_Load(object sender, EventArgs e)
        {
            
            DateTime suAn = DateTime.Now;

            // Tarihi etikete ata
            lblTarih.Text = suAn.ToString("dd/MM/yyyy"); // Gün/Ay/Yıl formatında

            lblSaat.Text = suAn.ToString("HH:mm"); // Saat:Dakika formatında
            lblPlaka.Text = plaka;
            lblYakıtTürü.Text = yakit;
            lblMiktar.Text=miktar.ToString();
            lblFiyat.Text = baglanti.GetFiyat(yakit).ToString();

            

            string formattedUsername = FormatUsername(username);
            lblKasiyer.Text = formattedUsername;
            decimal birimFiyat = baglanti.GetFiyat(yakit);
            decimal tutar = satislar.Satis(birimFiyat, miktar);

            if (durum)
            {
                 label2.Visible = true;
                 label6.Visible = true;
                 lblDisc.Visible = true;
                    
                decimal indirimOrani = 0.1m; // %10 indirim
                decimal eksitutar = tutar * indirimOrani; // Tutarın %10'u
                tutar -= eksitutar;
                lblDisc.Text = eksitutar.ToString("N2");
                lblTutar.Text = tutar.ToString("N2");

                decimal kdvTutar = satislar.KdvHesabı(tutar);
                lblKdvTutar.Text = kdvTutar.ToString("N2");
                lblNakit.Text = tutar.ToString("N2");
                lblTop.Text = tutar.ToString("N2");
            }
            else {
                lblTutar.Text = tutar.ToString();
                decimal kdvTutar = satislar.KdvHesabı(tutar);
                lblKdvTutar.Text = kdvTutar.ToString();
                lblNakit.Text = tutar.ToString();
                lblTop.Text = tutar.ToString();
            }
            
        }
    }
}
