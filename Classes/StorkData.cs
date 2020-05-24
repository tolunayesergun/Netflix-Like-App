using StorkFlix.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorkFlix.Classes
{
    internal class StorkData
    {
        private readonly StorkModel db = new StorkModel();
        public static List<Programlar> ProgramListesi { get; set; }
        public static List<Turler> TurListesi { get; set; }
        public static Programlar SecilenProgram { get; set; }
        public static string SeciliProgramTuru { get; set; }

        public void ProgramSec(int GelenId)
        {
            SecilenProgram = db.Programlar.Where(i => i.id == GelenId).Single();
        }

        public void ListeDoldur()
        {
            ProgramListesi = db.Programlar.Where(i => i.tip == SeciliProgramTuru).OrderByDescending(i=> i.id).ToList();
        }

        public void ListeFiltrele(int?[] Filtreler)
        {
            if (Filtreler.Count() == 0)
            {
                ProgramListesi = db.Programlar.Where(i => i.tip == SeciliProgramTuru).OrderByDescending(i => i.id).ToList();
            }
            else
            {
                // Önce Linq sorgusu alınıp, sonra extension şekilde liste değiştiriliyor
                var sorgu = (from i in db.Programlar
                             join x in db.ProgramTurleri
                             on i.id equals x.programId
                             where Filtreler.Contains(x.turId) && i.tip == SeciliProgramTuru
                             group i by new
                             {
                                 i.id,
                                 i.isim,
                                 i.tip,
                                 i.bolum,
                                 i.uzunluk
                             } into gcs
                             where gcs.Count() == Filtreler.Count()
                             select new
                             {
                                 aid = gcs.Key.id,
                                 aisim = gcs.Key.isim,
                                 atip = gcs.Key.tip,
                                 abolum = gcs.Key.bolum,
                                 auzunluk = gcs.Key.uzunluk
                             }).ToList();

                ProgramListesi = sorgu.ToList().Select(r => new Programlar
                {
                    id = r.aid,
                    isim = r.aisim,
                    tip = r.atip,
                    bolum = r.abolum,
                    uzunluk = r.auzunluk
                }).ToList();
            }
        }

        public void ProgramAra(string Kelime)
        {
            ProgramListesi = db.Programlar.Where(i => i.tip == SeciliProgramTuru)
                                          .Where(i => i.isim.StartsWith(Kelime)).ToList();
        }

        public void TurDoldur()
        {
            TurListesi = db.Turler.ToList();
        }

        public void ProfilSec(string ImageName)
        {
            Kullanici profilSec = (from i in db.Kullanici where i.id == AktifKullanici.kullaniciId select i).SingleOrDefault();

            profilSec.profilFotorafi = ImageName;

            db.SaveChanges();
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

        public void BilgiGuncelle(string nme, string maill, DateTime dgtrh)
        {
            Kullanici BilgiDegistir = (from i in db.Kullanici where i.id == AktifKullanici.kullaniciId select i).SingleOrDefault();

            BilgiDegistir.isim = nme;
            BilgiDegistir.mail = maill;
            BilgiDegistir.dogumTarihi = dgtrh;

            db.SaveChanges();
        }
    }
}