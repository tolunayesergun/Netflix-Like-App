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
        public static KullaniciProgram SonBolum { get; set; }
        public static string SeciliProgramTuru { get; set; }
        public static int TempBolum { get; set; }

        public void ProgramSec(int GelenId)
        {
            SecilenProgram = db.Programlar.Where(i => i.id == GelenId).Single();
        }

        public void ListeDoldur()
        {
            ProgramListesi = db.Programlar.Where(i => i.tip == SeciliProgramTuru).OrderByDescending(i => i.id).ToList();
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

                ProgramListesi = sorgu.ToList().OrderByDescending(i => i.aid).Select(r => new Programlar
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
                                          .Where(i => i.isim.StartsWith(Kelime))
                                          .OrderByDescending(i => i.id).ToList();
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

        public int MailKullaniciAra(string mail, string sifre)
        {
            //Mail-Şifre Kontrolü Yapan sorguyu barındıran metot

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

        public void KullaniciEkle(string nme, string maill, string psw, DateTime dgtrh)
        {
            //Kullanıcı ekleme sorgusunu gerçekleştiren metot

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

        //////////////////////// Kullanıcı Program Tablosu işlemleri ////////////////////////

        public void KullanicProgramKayitEkle(int gelenBolum)
        {
            KullaniciProgram kat = new KullaniciProgram
            {
                kullaniciId = AktifKullanici.kullaniciId,
                programId = SecilenProgram.id,
                izlemeTarihi = DateTime.Now,
                izlemeSuresi = 0,
                puan = 0,
                bolum = gelenBolum,
                tamamlandi = 0
            };
            db.KullaniciProgram.Add(kat);
            db.SaveChanges();
        }

        public int SonBolumBul()
        {
            var TempSonBolum = db.KullaniciProgram.Where(i => i.kullaniciId == AktifKullanici.kullaniciId).Where(i => i.programId == SecilenProgram.id).OrderByDescending(i => i.bolum).FirstOrDefault();
            if (TempSonBolum == null)
            {
                TempBolum = 1;
                return 1;
            }
            else
            {
                if (TempSonBolum.bolum == SecilenProgram.bolum)
                {
                    TempBolum = Convert.ToInt32(SecilenProgram.bolum);
                    return 0;
                }
                if (TempSonBolum.tamamlandi == 1)
                {
                    TempBolum = Convert.ToInt32(TempSonBolum.bolum) + 1;
                    return TempBolum;
                }
                TempBolum = Convert.ToInt32(TempSonBolum.bolum);
                return -1;
            }
        }

        public void BolumBilgileriniYaz()
        {
            SonBolum = db.KullaniciProgram.Where(i => i.kullaniciId == AktifKullanici.kullaniciId).Where(i => i.programId == SecilenProgram.id).Where(i => i.bolum == TempBolum).FirstOrDefault();
            if(SonBolum==null)
            {
                KullanicProgramKayitEkle(TempBolum);
                BolumBilgileriniYaz();
            }
        }



        public void BolumIzlemeBilgisiGuncelle(int GelenSure,int GelenBolum)
        {
            KullaniciProgram SureGuncelle = (from i in db.KullaniciProgram where 
                                             i.kullaniciId == AktifKullanici.kullaniciId &&
                                             i.programId==SecilenProgram.id &&
                                             i.bolum== GelenBolum
                                             select i).SingleOrDefault();

            SureGuncelle.izlemeSuresi = GelenSure;

            db.SaveChanges();
        }
    }
}