using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otomasyon_Projesi
{
    public class SifreSifirlayici
    {
        SqlConnection con;
        SqlCommand comm;
        SqlBaglanti baglanti = new SqlBaglanti();
        string GondericiMail = "sender2323@hotmail.com"; // Gönderici e-posta adresi
        string GondericiPass = "23sender23"; // Gönderici e-posta şifresi
        string yeniSifre;
        
        public string randomSifre(string kullanici, string email) 
        {
            con = new SqlConnection(@"Data Source="".\SQLEXPRESS"";Initial Catalog=AkaryakitOtomasyonProjeDb;Integrated Security=True");
            comm = new SqlCommand();
            con.Open();
            comm.Connection = con;
            comm.CommandText = "Select * From AkaryakitPersonelGiris where Per_KullaniciAdi = '" + kullanici + "' And eposta = '" + email + "'";
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {
                Random rand = new Random();
                yeniSifre = rand.Next(1000, 10000).ToString();
                reader.Close();
                // Şifre güncelleme işlemi
                comm = new SqlCommand("UPDATE AkaryakitPersonelGiris SET Sifre = @YeniSifre WHERE Per_KullaniciAdi = @username", con);
                comm.Parameters.AddWithValue("@YeniSifre", yeniSifre);
                comm.Parameters.AddWithValue("@username", kullanici);
                comm.ExecuteNonQuery();
            }
            else
            {
                // Kullanıcı doğrulama hatası veya başka bir işlem yapılabilir.
                MessageBox.Show("Kullanıcı doğrulama hatası", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return yeniSifre;
        }
        public void sifreSifirla(string k_eposta)
        {   

            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.outlook.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential(GondericiMail, GondericiPass);
            
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(GondericiMail, "Şifre Sıfırlama");
            mail.To.Add(k_eposta); // Kullanıcının e-posta adresi
            mail.Subject = "Şifre Sıfırlama İsteği";
            mail.IsBodyHtml = true;
            mail.Body = $"{DateTime.Now.ToString()} tarihindeki şifre sıfırlama isteği için oluşturulan yeni şifreniz: {yeniSifre}";
            sc.Send(mail);
            MessageBox.Show("Yeni şifreniz e-posta ile gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
