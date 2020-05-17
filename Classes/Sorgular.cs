using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;

namespace StorkFlix
{
    class Sorgular
    {
        readonly StorkModel db = new StorkModel();

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
                    if(item.sifre==sifre)
                    {
                        return 1;
                    }
                    break;
                }
            }
            return mailkontrol;
        }


        //Kullanıcı ekleme sorgusunu gerçekleştiren metot
        public void KullaniciEkle(string nme,string maill,string psw,DateTime dgtrh)
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
