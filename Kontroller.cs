using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;

namespace StorkFlix
{
    class Kontroller
    {
        StorkModel db = new StorkModel();

        public int MailKullaniciAra(string mail)
        {
            var kullancilar = db.Kullanici.ToList();

            foreach (var item in kullancilar)
            {
                if(item.mail==mail)return item.id;
            }
            return -1;
        }

        public bool SifreKontrol(int id,string sifre)
        {
            var kullanci = db.Kullanici.Where(i => i.id == id).Single();

            if (kullanci.sifre == sifre) return true;

            return false;
        }
    }
}
