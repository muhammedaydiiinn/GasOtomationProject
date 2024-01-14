using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomasyon_Projesi
{
    class Satislar
    {
        public decimal Satis(decimal birimFiyat, decimal Miktar)
        {
            decimal odemeTutarı = birimFiyat * Miktar;
            return odemeTutarı;
        }
        public decimal KdvHesabı(decimal tutar)
        {
            decimal kdv = tutar * 0.18m; // KDV miktarını hesapla
            return Math.Round(kdv, 2); // KDV miktarını virgülden sonra iki basamağa yuvarla ve döndür
        }


        public decimal EnvanterSatis(decimal önceki, decimal Miktar)
        {
            decimal yeni = önceki - Miktar;

            return yeni;
        }

        public decimal PerSatisTotal(decimal önceki, decimal sonraki)
        {
            decimal total = önceki + sonraki;
            return total;
        }

        public decimal Alis(decimal alisFiyat, decimal Miktar)
        {
            return alisFiyat * Miktar;
        }
        
    }
}
