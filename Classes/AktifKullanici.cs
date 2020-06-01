using System;
using System.Linq;

namespace StorkFlix.Model
{
    internal class AktifKullanici
    {
        public static int kullaniciId { get; set; }
        public static string kullaniciAdi { get; set; }
        public static string kullaniciMail { get; set; }
        public static string kullaniciSifre { get; set; }
        public static DateTime kullaniciDgn { get; set; }
        public static string kullaniciProfil { get; set; }

        public static int?[] favKats = new int?[3];

        public void KullaniciSec(string mail)
        {
            StorkModel db = new StorkModel();
            var kullaniciBilgileri = db.Kullanici.Where(i => i.mail == mail).First();

            kullaniciId = kullaniciBilgileri.id;
            kullaniciAdi = kullaniciBilgileri.isim;
            kullaniciMail = kullaniciBilgileri.mail;
            kullaniciSifre = kullaniciBilgileri.sifre;
            kullaniciDgn = kullaniciBilgileri.dogumTarihi;
            kullaniciProfil = kullaniciBilgileri.profilFotorafi;

            if (kullaniciBilgileri.FavKats != null)
            {
                string[] kats = kullaniciBilgileri.FavKats.Split(',');
                for (int i = 0; i < 3; i++)
                {
                    favKats[i] = Convert.ToInt32(kats[i]);
                }
            }
        }

        public void favDegistir(string favs)
        {
            string[] kats = favs.Split(',');
            for (int i = 0; i < 3; i++)
            {
                favKats[i] = Convert.ToInt32(kats[i]);
            }
        }
    }
}