using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorkFlix.Classes
{
    class StorkData
    {
        
        private static readonly StorkModel db = new StorkModel();
        public static List<Programlar> DiziListesi { get; set; }
        public static List<Turler> TurListesi { get; set; }

        public void ListeDoldur(int Tur)
        {
            if(Tur==1)DiziListesi = db.Programlar.Where(i => i.tip == "Dizi").ToList();
            else DiziListesi = db.Programlar.Where(i => i.tip == "Film").ToList();
        }

        public void TurDoldur()
        {
            TurListesi = db.Turler.ToList();
        }


        //Mail-Şifre Kontrolü Yapan sorguyu barındıran metot
        public int MailKullaniciAra(string mail, string sifre)
        {
            var kullancilar = db.Kullanici.ToList();
            int mailkontrol = 0;

            foreach (var item in kullancilar)
            {
                if (item.mail == mail)
                {
                    mailkontrol = 2;
                    if (item.sifre == sifre)
                    {
                        return 1;
                    }
                    break;
                }
            }
            return mailkontrol;
        }

        //Kullanıcı ekleme sorgusunu gerçekleştiren metot
        public void KullaniciEkle(string nme, string maill, string psw, DateTime dgtrh)
        {
            Kullanici kat = new Kullanici
            {
                isim = nme,
                mail = maill,
                sifre = psw,
                dogumTarihi = dgtrh
            };
            db.Kullanici.Add(kat);
            db.SaveChanges();
        }
    }
}
