using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorkFlix.Model
{
    class AktifKullanici
    {
        public static int kullaniciId { get; set; }
        public static string kullaniciAdi { get; set; }
        public static string kullaniciMail { get; set; }
        public static string kullaniciSifre { get; set; }
        public static DateTime kullaniciDgn { get; set; }
        public static string kullaniciProfil { get; set; }

        public  void KullaniciSec(string mail)
        {
            StorkModel db = new StorkModel();
            var kullaniciBilgileri = db.Kullanici.Where(i => i.mail == mail).First();

            kullaniciId = kullaniciBilgileri.id;
            kullaniciAdi = kullaniciBilgileri.isim;
            kullaniciMail = kullaniciBilgileri.mail;
            kullaniciSifre = kullaniciBilgileri.sifre;
            kullaniciDgn = kullaniciBilgileri.dogumTarihi;
            kullaniciProfil = kullaniciBilgileri.profilFotorafi;
        }
    }
}
