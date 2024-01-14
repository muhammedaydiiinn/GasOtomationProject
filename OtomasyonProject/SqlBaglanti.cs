using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Otomasyon_Projesi
{
    class SqlBaglanti
    {
        public SqlConnection Baglanti()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source="".\SQLEXPRESS"";Initial Catalog=AkaryakitOtomasyonProjeDb;Integrated Security=True;");
            baglanti.Open();
            return baglanti;
        }

        public bool AdminGiris(string user, string pass)
        {
            Baglanti();
            SqlCommand com = new SqlCommand();
            com.Connection = Baglanti();
            com.CommandText = "SELECT COUNT(*) FROM AdminGiris WHERE KullaniciAdi COLLATE Latin1_General_BIN = @Username AND Sifre = @Password";
            com.Parameters.AddWithValue("@Username", user);
            com.Parameters.AddWithValue("@Password", pass);
            int count = (int)com.ExecuteScalar();
            return count > 0; // Eğer veri varsa true, yoksa false döndürür

        }
        public string GetAdminAdSoyad(string username)
        {
            string ad = "";
            string soyad = "";

            using (SqlCommand komut = new SqlCommand("SELECT Adi, Soyadi FROM AdminGiris WHERE KullaniciAdi = @Username", Baglanti()))
            {
                komut.Parameters.AddWithValue("@Username", username);
                Baglanti();
                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ad = dr["Adi"].ToString();
                        soyad = dr["Soyadi"].ToString();
                    }
                }
                Baglanti().Close();
            }
            return ad + " " + soyad;
        }

        public bool PerEkle(string ad, string soyad, string k_adi, string eposta, string sifre)
        {
            Baglanti();
            SqlCommand komut = new SqlCommand("insert into AkaryakıtPersonelGiris (Per_AD,Per_Soyad,Per_KullaniciAdi,Sifre,eposta,PerSatisTutar) values (@p1,@p2,@p3,@p4,@p5,@p6)", Baglanti());
            komut.Parameters.AddWithValue("@p1", ad);
            komut.Parameters.AddWithValue("@p2", soyad);
            komut.Parameters.AddWithValue("@p3", k_adi);
            komut.Parameters.AddWithValue("@p4", sifre);
            komut.Parameters.AddWithValue("@p5", eposta);
            komut.Parameters.AddWithValue("@p6", 0);
            komut.ExecuteNonQuery();
            Baglanti().Close();
            return true;
        }
        public List<string> GetPersonelIsimleri()
        {
            List<string> isimler = new List<string>();

            using (SqlCommand komut = new SqlCommand("SELECT Per_AD, Per_Soyad FROM AkaryakıtPersonelGiris", Baglanti()))
            {
                Baglanti();
                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string ad = dr["Per_AD"].ToString();
                        string soyad = dr["Per_Soyad"].ToString();
                        isimler.Add(ad + " " + soyad);
                    }
                }
                Baglanti().Close();
            }
            return isimler;
        }
        public string GetPersonelDetails(string selectedPerson)
        {
            SqlCommand komut = new SqlCommand("SELECT ID, Per_AD, Per_Soyad, Per_KullaniciAdi, Sifre, eposta, PerMaas, PerSatisTutar FROM AkaryakıtPersonelGiris WHERE CONCAT(Per_AD, ' ', Per_Soyad) = @selectedPerson", Baglanti());
            komut.Parameters.AddWithValue("@selectedPerson", selectedPerson);

            string detaylar = "";

            using (SqlDataReader dr = komut.ExecuteReader())
            {
                if (dr.Read())
                {
                    detaylar += dr["ID"].ToString() + "|" + dr["Per_AD"].ToString() + "|" + dr["Per_Soyad"].ToString() + "|" + dr["Per_KullaniciAdi"].ToString() + "|" + dr["Sifre"].ToString() + "|" + dr["eposta"].ToString() + "|" + dr["PerMaas"].ToString() + "|" + dr["PerSatisTutar"].ToString();
                }
            }

            return detaylar;
        }
        public bool PerGuncelle(int id, string maas, string ad, string soyad, string k_adi, string eposta, string sifre)
        {
            SqlConnection connection = Baglanti(); // Bağlantıyı aç
            SqlCommand komut = new SqlCommand("UPDATE AkaryakıtPersonelGiris SET Per_AD=@p1, Per_Soyad=@p2, Per_KullaniciAdi=@p3, Sifre=@p4, eposta=@p5, PerMaas=@p6 WHERE ID=@id", connection);
            komut.Parameters.AddWithValue("@p1", ad);
            komut.Parameters.AddWithValue("@p2", soyad);
            komut.Parameters.AddWithValue("@p3", k_adi);
            komut.Parameters.AddWithValue("@p4", sifre);
            komut.Parameters.AddWithValue("@p5", eposta);
            komut.Parameters.AddWithValue("@p6", maas);
            komut.Parameters.AddWithValue("@id", id);

            komut.ExecuteNonQuery(); // Sorguyu çalıştır
            connection.Close(); // Bağlantıyı kapat

            return true;
        }
        public int GetPersonelID(string selectedPerson)
        {
            SqlCommand komut = new SqlCommand("SELECT ID FROM AkaryakıtPersonelGiris WHERE CONCAT(Per_AD, ' ', Per_Soyad) = @selectedPerson", Baglanti());
            komut.Parameters.AddWithValue("@selectedPerson", selectedPerson);

            int personelID = -1;

            using (SqlDataReader dr = komut.ExecuteReader())
            {
                if (dr.Read())
                {
                    personelID = Convert.ToInt32(dr["ID"]);
                }
            }
            return personelID;
        }
        public bool PerDelete(int personelID)
        {
            using (SqlConnection connection = Baglanti())
            {
                // AkaryakıtPersonelGiris tablosundan ilgili personeli sil
                SqlCommand deleteGirisCommand = new SqlCommand("DELETE FROM AkaryakıtPersonelGiris WHERE ID = @id", connection);
                deleteGirisCommand.Parameters.AddWithValue("@id", personelID);

                // AkaryakitPersonelSatis tablosundan ilgili personelin satış kayıtlarını sil
                SqlCommand deleteSatisCommand = new SqlCommand("DELETE FROM AkaryakitPersonelSatis WHERE ID = @id", connection);
                deleteSatisCommand.Parameters.AddWithValue("@id", personelID);

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    deleteGirisCommand.Transaction = transaction;
                    deleteSatisCommand.Transaction = transaction;

                    try
                    {
                        deleteSatisCommand.ExecuteNonQuery();
                        int result = deleteGirisCommand.ExecuteNonQuery();
                        transaction.Commit();
                        return result > 0; // Eğer en az bir satır silindi ise true dönecek
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Hata durumunda istisna fırlatılabilir veya başka bir işlem yapılabilir
                    }
                }
            }
        }
        public bool PerGiris(string user, string pass)
        {
            Baglanti();
            SqlCommand com = new SqlCommand();
            com.Connection = Baglanti();
            com.CommandText = "SELECT COUNT(*) FROM AkaryakıtPersonelGiris WHERE Per_KullaniciAdi COLLATE Latin1_General_BIN = @Username AND Sifre = @Password";
            com.Parameters.AddWithValue("@Username", user);
            com.Parameters.AddWithValue("@Password", pass);
            int count = (int)com.ExecuteScalar();
            return count > 0; // Eğer veri varsa true, yoksa false döndürür
        }
        public string GetKasiyerAdSoyad(string username)
        {
            string ad = "";
            string soyad = "";

            using (SqlCommand komut = new SqlCommand("SELECT Per_AD, Per_Soyad FROM AkaryakıtPersonelGiris WHERE Per_KullaniciAdi = @Username", Baglanti()))
            {
                komut.Parameters.AddWithValue("@Username", username);
                Baglanti();

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ad = dr["Per_AD"].ToString();
                        soyad = dr["Per_Soyad"].ToString();
                    }
                }
                Baglanti().Close();
            }
            return ad + " " + soyad;
        }
        public List<string> GetYakitCinsleri()
        {
            List<string> yakitCinsleri = new List<string>();

            using (Baglanti()) // Bağlantı fonksiyonunuz
            {
                Baglanti();

                using (SqlCommand komut = new SqlCommand("SELECT DISTINCT YakıtCinsi FROM YakitEnvanterTablo", Baglanti()))
                {
                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string yakitCinsi = dr["YakıtCinsi"].ToString();
                            yakitCinsleri.Add(yakitCinsi);
                        }
                    }
                }
            } // Otomatik olarak bağlantı kapanır

            return yakitCinsleri;
        }
        public decimal GetFiyat(string selectedYakit)
        {
            decimal satisfiyat = 0;

            using (Baglanti())
            {
                Baglanti();

                using (SqlCommand komut = new SqlCommand("SELECT LitreSatisFiyati FROM YakitEnvanterTablo WHERE YakıtCinsi = @selectedYakit", Baglanti()))
                {
                    komut.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            satisfiyat = Convert.ToDecimal(dr["LitreSatisFiyati"]);
                        }
                    }
                }

                Baglanti().Close();
            }

            return satisfiyat;
        }


        public bool UpdateLitreSatisFiyati(decimal yeniAlisFiyati, decimal yenisatisFiyat, string selectedYakit)
        {
            SqlCommand cmd = new SqlCommand("UPDATE YakitEnvanterTablo SET LitreSatisFiyati = @YeniSatisFiyat,LitreAlisFiyati = @yeniAlisFiyati WHERE YakıtCinsi = @selectedYakit", Baglanti());
            cmd.Parameters.AddWithValue("@YeniSatisFiyat", yenisatisFiyat);
            cmd.Parameters.AddWithValue("@selectedYakit", selectedYakit);
            cmd.Parameters.AddWithValue("@yeniAlisFiyati", yeniAlisFiyati);

            Baglanti();
            cmd.ExecuteNonQuery();
            Baglanti().Close();


            return true;
        }
        public decimal GetMiktar(string selectedYakit)
        {
            string miktar = "";
            using (SqlCommand komut = new SqlCommand("SELECT YakıtMiktari FROM YakitEnvanterTablo WHERE YakıtCinsi = @selectedYakit", Baglanti()))
            {
                komut.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        miktar = dr["YakıtMiktari"].ToString();
                    }
                }

                Baglanti();
            }

            return int.Parse(miktar);
        }
        public bool UpdateYakitMiktari(int eskiMiktar, int eklenenMiktar, string selectedYakit)
        {
            int yeniMiktar = eskiMiktar + eklenenMiktar;
            SqlCommand cmd = new SqlCommand("UPDATE YakitEnvanterTablo SET YakıtMiktari = @yeniMiktar WHERE YakıtCinsi = @selectedYakit", Baglanti());
            cmd.Parameters.AddWithValue("@yeniMiktar", yeniMiktar);
            cmd.Parameters.AddWithValue("@selectedYakit", selectedYakit);

            Baglanti();
            cmd.ExecuteNonQuery();
            Baglanti().Close();

            return true;
        }
        public int GetKasiyerID(string username)
        {
            int kasiyerID = -1; // Geçersiz bir değerle başlatılır, hata durumunda kontrol etmek için

            using (SqlCommand komut = new SqlCommand("SELECT ID FROM AkaryakıtPersonelGiris WHERE Per_KullaniciAdi = @Username", Baglanti()))
            {
                komut.Parameters.AddWithValue("@Username", username);

                Baglanti();

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        kasiyerID = Convert.ToInt32(dr["ID"]);
                    }
                }
            }

            return kasiyerID;
        }
        Satislar Satislar = new Satislar();
        public bool SatisYap(decimal satisLitre, string selectedYakit, string plaka, int personelId)
        {
            decimal birimFiyat = 0; // Başlangıç değeri

            // LitreSatisFiyati'ni çekme sorgusu
            using (SqlCommand fiyatSorgu = new SqlCommand("SELECT LitreSatisFiyati FROM YakitEnvanterTablo WHERE YakıtCinsi = @selectedYakit", Baglanti()))
            {
                fiyatSorgu.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                Baglanti();
                SqlDataReader dr = fiyatSorgu.ExecuteReader();

                if (dr.Read())
                {
                    birimFiyat = Convert.ToDecimal(dr["LitreSatisFiyati"]);
                }

                Baglanti().Close();
            }

            decimal tutar = Satislar.Satis(birimFiyat, satisLitre);



            decimal önceki = 0;

            using (SqlCommand fiyatSorgu = new SqlCommand("SELECT YakıtMiktari FROM YakitEnvanterTablo WHERE YakıtCinsi = @selectedYakit", Baglanti()))
            {
                fiyatSorgu.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                Baglanti();
                SqlDataReader dr = fiyatSorgu.ExecuteReader();

                if (dr.Read())
                {
                    önceki = Convert.ToDecimal(dr["YakıtMiktari"]);
                }

                Baglanti().Close();
            }


            decimal envanterMiktar = Satislar.EnvanterSatis(önceki, satisLitre);
            using (SqlCommand cmd = new SqlCommand("UPDATE YakitEnvanterTablo SET YakıtMiktari = @yeniMiktar WHERE YakıtCinsi = @selectedYakit", Baglanti()))
            {
                cmd.Parameters.AddWithValue("@yeniMiktar", envanterMiktar);
                cmd.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                Baglanti();
                cmd.ExecuteNonQuery();
                Baglanti().Close();
            }


            DateTime tarih = DateTime.Now;
            string formatliTarih = tarih.ToString("dd-MM-yyyy HH:mm");
            // SatisTablosuna eklemek için INSERT sorgusu
            using (SqlCommand cmd = new SqlCommand("INSERT INTO AkaryakitPersonelSatis (Plaka, ID, YakitTürü, Litre, Fiyat, Tarih) VALUES (@plaka, @personelId, @selectedYakit, @satisLitre, @tutar, @tarih)", Baglanti()))
            {
                cmd.Parameters.AddWithValue("@plaka", plaka);
                cmd.Parameters.AddWithValue("@personelId", personelId);
                cmd.Parameters.AddWithValue("@selectedYakit", selectedYakit);
                cmd.Parameters.AddWithValue("@satisLitre", satisLitre);
                cmd.Parameters.AddWithValue("@tutar", tutar);
                cmd.Parameters.AddWithValue("@tarih", formatliTarih);


                Baglanti();
                cmd.ExecuteNonQuery();
                Baglanti().Close();
                decimal toplamSatisTutar = GetKasa() + tutar;
                using (SqlCommand updateCommand = new SqlCommand("UPDATE KasaTablo SET Toplam = @ToplamSatisTutar WHERE ID = @KasaID", Baglanti()))
                {
                    updateCommand.Parameters.AddWithValue("@ToplamSatisTutar", toplamSatisTutar);
                    updateCommand.Parameters.AddWithValue("@KasaID", 1); // Örnek olarak KasaTablo'da ID 1 olan satırı güncelleyelim (ID'yi uygun şekilde değiştirebilirsiniz)

                    Baglanti();
                    updateCommand.ExecuteNonQuery();
                    Baglanti().Close();
                }
            }
            decimal öncekiTutar = 0;
            using (SqlCommand fiyatSorgu = new SqlCommand("SELECT PerSatisTutar FROM AkaryakıtPersonelGiris WHERE ID = @id", Baglanti()))
            {
                fiyatSorgu.Parameters.AddWithValue("@id", personelId);

                Baglanti();
                SqlDataReader dr = fiyatSorgu.ExecuteReader();

                if (dr.Read())
                {
                    öncekiTutar = Convert.ToDecimal(dr["PerSatisTutar"]);
                }

                Baglanti().Close();
            }
            decimal yeni = Satislar.PerSatisTotal(öncekiTutar, tutar);
            using (SqlCommand cmd = new SqlCommand("UPDATE AkaryakıtPersonelGiris SET PerSatisTutar = @satis WHERE ID = @id", Baglanti()))
            {
                cmd.Parameters.AddWithValue("@satis", yeni);
                cmd.Parameters.AddWithValue("@id", personelId);

                Baglanti();
                cmd.ExecuteNonQuery();
                Baglanti().Close();
            }


            return true;
        }
        public (string maas, string total) GetKasiyerBilgi(string username)
        {
            string maas = "";
            string total = "";

            using (SqlCommand komut = new SqlCommand("SELECT PerMaas, PerSatisTutar FROM AkaryakıtPersonelGiris WHERE Per_KullaniciAdi = @Username", Baglanti()))
            {
                komut.Parameters.AddWithValue("@Username", username);

                Baglanti();

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        maas = dr["PerMaas"].ToString();
                        total = dr["PerSatisTutar"].ToString();
                    }
                }

                Baglanti().Close();
            }

            return (maas, total);
        }
        public int PersonelID(string selectedPerson)
        {
            SqlCommand komut = new SqlCommand("SELECT ID FROM AkaryakıtPersonelGiris WHERE Per_AD= @selectedPerson", Baglanti());
            komut.Parameters.AddWithValue("@selectedPerson", selectedPerson);

            int personelID = -1;

            using (SqlDataReader dr = komut.ExecuteReader())
            {
                if (dr.Read())
                {
                    personelID = Convert.ToInt32(dr["ID"]);
                }
            }

            return personelID;
        }
        public DataTable GetPersonelSatisByID(int personelID)
        {
            DataTable dataTable = new DataTable();


            Baglanti();

            using (SqlCommand command = new SqlCommand("SELECT Plaka, YakitTürü AS 'Yakıt Türü',Litre AS 'Litre(L)', Fiyat AS 'Tutar(TL)', Tarih FROM AkaryakitPersonelSatis WHERE ID = @PersonelID", Baglanti()))
            {
                command.Parameters.AddWithValue("@PersonelID", personelID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            Baglanti().Close();

            return dataTable;
        }

        public decimal GetKasa()
        {
            decimal kasaTutar = 0;

            Baglanti();
            using (SqlCommand command = new SqlCommand("SELECT Toplam FROM KasaTablo", Baglanti()))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // Veritabanından okunan değeri decimal olarak dönüştürerek atama yapın
                        kasaTutar = Convert.ToDecimal(dr["Toplam"]);
                    }
                }
            }

            Baglanti().Close();


            return kasaTutar;
        }

        public bool YakitAl(decimal Miktar, string selected)
        {
            decimal satisfiyat = GetFiyat(selected);
            decimal alisfiyat;
            decimal yuzdeDortEksik = satisfiyat - (satisfiyat * 0.04m);
            alisfiyat = Math.Round(yuzdeDortEksik, 2); ;
            decimal alisTutar = Satislar.Alis(alisfiyat, Miktar);
            decimal kasa = GetKasa();
            decimal yeniKasa = kasa - alisTutar;

            using (SqlCommand updateCommand = new SqlCommand("UPDATE KasaTablo SET Toplam = @YeniKasa WHERE ID = @KasaID", Baglanti()))
            {
                updateCommand.Parameters.AddWithValue("@YeniKasa", yeniKasa);
                updateCommand.Parameters.AddWithValue("@KasaID", 1); // Örnek olarak KasaTablo'da ID 1 olan satırı güncelleyelim (ID'yi uygun şekilde değiştirebilirsiniz)

                Baglanti();
                updateCommand.ExecuteNonQuery();
                Baglanti().Close();
            }
            DateTime tarih = DateTime.Now;
            string formatliTarih = tarih.ToString("dd-MM-yyyy HH:mm");

            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO AkaryakitAlimTablo (Tarih, YakıtCinsi, AlımMiktari) VALUES (@Tarih, @YakitCinsi, @AlimMiktari)", Baglanti()))
            {
                insertCommand.Parameters.AddWithValue("@Tarih", formatliTarih);
                insertCommand.Parameters.AddWithValue("@YakitCinsi", selected);
                insertCommand.Parameters.AddWithValue("@AlimMiktari", Miktar);

                Baglanti();
                insertCommand.ExecuteNonQuery();
                Baglanti().Close();
            }
            
            return true;
        }
        public DataTable GetPersonelAlim()
        {
            // SQL sorgusu (PerSatisTutar değeri sıfır olmayan kayıtları alacak şekilde güncellendi)
            string query = "SELECT YakıtCinsi, AlımMiktari, Tarih FROM AkaryakitAlimTablo";

            // Veritabanından veri al
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, Baglanti()))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        public DataTable GetPersonelSatis()
        {
            // SQL sorgusu (PerSatisTutar değeri sıfır olmayan kayıtları alacak şekilde güncellendi)
            string query = "SELECT Per_AD, PerSatisTutar FROM AkaryakıtPersonelGiris WHERE PerSatisTutar <> 0";

            // Veritabanından veri al
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, Baglanti()))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }



        public DataTable GetAdSoyadSatis()
        {
            // SQL sorgusu
            string query = "SELECT Per_AD AS 'Ad', Per_Soyad AS 'Soyad', PerSatisTutar AS 'Toplam Satış' FROM AkaryakıtPersonelGiris";
            Baglanti();

            // Veritabanından veri al
            SqlDataAdapter adapter = new SqlDataAdapter(query, Baglanti());
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public bool TasitEkle(string plaka)
        {
            Baglanti();
            SqlCommand komut = new SqlCommand("insert into AkaryakitTasitmatik (Plaka) values (@p1)", Baglanti());
            komut.Parameters.AddWithValue("@p1", plaka);
            komut.ExecuteNonQuery();
            Baglanti().Close();
            return true;
        }

        public bool PlakaVarMi(string plaka)
        {
            Baglanti();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM AkaryakitTasitmatik WHERE Plaka = @plaka", Baglanti());
            cmd.Parameters.AddWithValue("@plaka", plaka);

            int count = (int)cmd.ExecuteScalar();
            Baglanti().Close();
            return count > 0;
        }


        public int TasitmatikGirisSayisi(string plaka)
        {
            using (SqlConnection conn = Baglanti())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM AkaryakitPersonelSatis WHERE Plaka = @plaka", conn);
                cmd.Parameters.AddWithValue("@plaka", plaka);

                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }

        public bool TasitmatikSatisYap(decimal satisLitre, string selectedYakit, string plaka, int personelId)
        {
            decimal birimFiyat = 0; // Başlangıç değeri

            // LitreSatisFiyati'ni çekme sorgusu
            using (SqlCommand fiyatSorgu = new SqlCommand("SELECT LitreSatisFiyati FROM YakitEnvanterTabloYakit WHERE YakıtCinsi = @selectedYakit", Baglanti()))
            {
                fiyatSorgu.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                Baglanti();
                SqlDataReader dr = fiyatSorgu.ExecuteReader();

                if (dr.Read())
                {
                    birimFiyat = Convert.ToDecimal(dr["LitreSatisFiyati"]);
                }

                Baglanti().Close();
            }

            decimal tutar = Satislar.Satis(birimFiyat, satisLitre);
            decimal indirimOrani = 0.1m; // %10 indirim
            decimal eksitutar = tutar * indirimOrani; // Tutarın %10'u
            tutar = tutar - eksitutar;


            decimal önceki = 0;

            using (SqlCommand fiyatSorgu = new SqlCommand("SELECT YakıtMiktari FROM YakitEnvanterTablo WHERE YakıtCinsi = @selectedYakit", Baglanti()))
            {
                fiyatSorgu.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                Baglanti();
                SqlDataReader dr = fiyatSorgu.ExecuteReader();

                if (dr.Read())
                {
                    önceki = Convert.ToDecimal(dr["YakıtMiktari"]);
                }

                Baglanti().Close();
            }


            decimal envanterMiktar = Satislar.EnvanterSatis(önceki, satisLitre);
            using (SqlCommand cmd = new SqlCommand("UPDATE YakitEnvanterTablo SET YakıtMiktari = @yeniMiktar WHERE YakıtCinsi = @selectedYakit", Baglanti()))
            {
                cmd.Parameters.AddWithValue("@yeniMiktar", envanterMiktar);
                cmd.Parameters.AddWithValue("@selectedYakit", selectedYakit);

                Baglanti();
                cmd.ExecuteNonQuery();
                Baglanti().Close();
            }


            DateTime tarih = DateTime.Now;
            string formatliTarih = tarih.ToString("dd-MM-yyyy HH:mm");
            // SatisTablosuna eklemek için INSERT sorgusu
            using (SqlCommand cmd = new SqlCommand("INSERT INTO AkaryakitPersonelSatis (Plaka, ID, YakitTürü, Litre, Fiyat, Tarih) VALUES (@plaka, @personelId, @selectedYakit, @satisLitre, @tutar, @tarih)", Baglanti()))
            {
                cmd.Parameters.AddWithValue("@plaka", plaka);
                cmd.Parameters.AddWithValue("@personelId", personelId);
                cmd.Parameters.AddWithValue("@selectedYakit", selectedYakit);
                cmd.Parameters.AddWithValue("@satisLitre", satisLitre);
                cmd.Parameters.AddWithValue("@tutar", tutar);
                cmd.Parameters.AddWithValue("@tarih", formatliTarih);

                Baglanti();
                cmd.ExecuteNonQuery();
                Baglanti().Close();
                decimal toplamSatisTutar = GetKasa() + tutar;
                using (SqlCommand updateCommand = new SqlCommand("UPDATE KasaTablo SET Toplam = @ToplamSatisTutar WHERE ID = @KasaID", Baglanti()))
                {
                    updateCommand.Parameters.AddWithValue("@ToplamSatisTutar", toplamSatisTutar);
                    updateCommand.Parameters.AddWithValue("@KasaID", 1); // Örnek olarak KasaTablo'da ID 1 olan satırı güncelleyelim (ID'yi uygun şekilde değiştirebilirsiniz)

                    Baglanti();
                    updateCommand.ExecuteNonQuery();
                    Baglanti().Close();
                }
            }
            decimal öncekiTutar = 0;
            using (SqlCommand fiyatSorgu = new SqlCommand("SELECT PerSatisTutar FROM AkaryakıtPersonelGiris WHERE ID = @id", Baglanti()))
            {
                fiyatSorgu.Parameters.AddWithValue("@id", personelId);

                Baglanti();
                SqlDataReader dr = fiyatSorgu.ExecuteReader();

                if (dr.Read())
                {
                    öncekiTutar = Convert.ToDecimal(dr["PerSatisTutar"]);
                }

                Baglanti().Close();
            }
            decimal yeni = Satislar.PerSatisTotal(öncekiTutar, tutar);
            using (SqlCommand cmd = new SqlCommand("UPDATE AkaryakıtPersonelGiris SET PerSatisTutar = @satis WHERE ID = @id", Baglanti()))
            {
                cmd.Parameters.AddWithValue("@satis", yeni);
                cmd.Parameters.AddWithValue("@id", personelId);

                Baglanti();
                cmd.ExecuteNonQuery();
                Baglanti().Close();
            }


            return true;
        }
    }
}