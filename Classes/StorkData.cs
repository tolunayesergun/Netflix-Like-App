using StorkFlix.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorkFlix.Classes
{
    internal class StorkData
    {
        #region Nesneler
        private readonly StorkModel db = new StorkModel();
        public static List<Programlar> ProgramListesi { get; set; }
        public static List<Turler> TurListesi { get; set; }
        public static Programlar SecilenProgram { get; set; }
        public static KullaniciProgram SonBolum { get; set; }
        public static List<BagliTablo> IzlemeGecmisi { get; set; }
        public static List<Programlar> tempList { get; set; }
        public static string SeciliProgramTuru { get; set; }
        public static int TempBolum { get; set; }

        public static decimal[] PuanListesi = new decimal[6];

        #endregion Nesneler

        #region AnaSayfa
        //////////////////////// AnaSayfa Formu Data Base İşlemleri ////////////////////////
        public void OnerilenleriBul(int?[] Filtreler)
        {
            tempList = new List<Programlar>();

            foreach (int i in Filtreler)
            {
                int[] tempArray = tempList.Select(x => x.id).ToArray();

                tempList.AddRange(db.Programlar
                      .Where(y => y.ProgramTurleri.Any(z => z.turId == i) && !(tempArray.Contains(y.id)))
                      .OrderByDescending(x => x.KullaniciProgram.Average(y => y.puan))
                      .Take(2)
                      .ToList());
            }
            for (int i = 0; i < StorkData.tempList.Count; i++) PuanListesi[i] = Convert.ToDecimal(StorkData.tempList[i].KullaniciProgram.Average(y => y.puan));

        }
        #endregion AnaSayfa

        #region Ekran
        //////////////////////// Ekran Formu Data Base İşlemleri ////////////////////////
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
            if (SonBolum == null)
            {
                KullanicProgramKayitEkle(TempBolum);
                BolumBilgileriniYaz();
            }
        }

        public void BolumIzlemeBilgisiGuncelle(int GelenSure)
        {
            KullaniciProgram SureGuncelle = db.KullaniciProgram.SingleOrDefault(i =>
               i.kullaniciId == AktifKullanici.kullaniciId &&
               i.programId == SecilenProgram.id &&
               i.bolum == TempBolum
               );
            SureGuncelle.izlemeSuresi = GelenSure;
            SureGuncelle.izlemeTarihi = DateTime.Now;
            db.SaveChanges();
        }

        public void PuanGuncelle(int Puan)
        {
            KullaniciProgram puanGuncelle = db.KullaniciProgram.SingleOrDefault(i =>
            i.kullaniciId == AktifKullanici.kullaniciId &&
            i.programId == SecilenProgram.id &&
            i.bolum == TempBolum);
            if (puanGuncelle != null)
            {
                puanGuncelle.puan = Puan;
                db.SaveChanges();
            }
        }

        public void BolumTamamla(bool tamamlandimi)
        {
            KullaniciProgram tamamlamaGuncelle = db.KullaniciProgram.SingleOrDefault(i =>
               i.kullaniciId == AktifKullanici.kullaniciId &&
               i.programId == SecilenProgram.id &&
               i.bolum == TempBolum
               );

            if (tamamlandimi == true) tamamlamaGuncelle.tamamlandi = 1;
            else tamamlamaGuncelle.tamamlandi = 0;
            db.SaveChanges();
        }

        public void KullaniciKayitKontrol()
        {
            int SonBolum = SonBolumBul();
            if (SonBolum > 0)
            {
                KullanicProgramKayitEkle(SonBolum);
            }

            BolumBilgileriniYaz();
        }
        #endregion Ekran

        #region Hesabim
        //////////////////////// Hesabım Formu Data Base İşlemleri ////////////////////////
        public void IzlemeGecmisiOlustur(int KullaniciId)
        {
            #region entityFrameWorkKullanimi

            // Hız probleminden dolayı, extansion yerine linq kullandık.
            //IzlemeGecmisi = db.KullaniciProgram.Where(x => x.kullaniciId == KullaniciId).OrderByDescending(x => x.izlemeTarihi).ToList();

            #endregion entityFrameWorkKullanimi
            #region SqlSorgusu

            /*select p.isim,kp.Bolum,kp.izlemeSuresi,kp.puan,kp.izlemeTarihi
            from KullaniciProgram as kp inner join Programlar as p on kp.programId=p.id
            where kullaniciId=1 order by  kp.id desc */

            #endregion SqlSorgusu

            IzlemeGecmisi = (from i in db.KullaniciProgram
                             join x in db.Programlar
                             on i.programId equals x.id
                             where i.kullaniciId == KullaniciId
                             orderby i.izlemeTarihi descending
                             select new BagliTablo
                             {
                                 Ad = x.isim,
                                 BolumNo = i.bolum,
                                 izlemeSure = i.izlemeSuresi,
                                 iPuan = i.puan,
                                 iTarih = i.izlemeTarihi,
                                 BolumSayisi = x.bolum
                             }).ToList();
        }

        public void ProfilSec(string ImageName)
        {
            Kullanici profilSec = db.Kullanici.SingleOrDefault(k => k.id == AktifKullanici.kullaniciId);

            profilSec.profilFotorafi = ImageName;

            db.SaveChanges();
        }

        public void BilgiGuncelle(string nme, string maill, DateTime dgtrh)
        {
            Kullanici BilgiDegistir = db.Kullanici.SingleOrDefault(k => k.id == AktifKullanici.kullaniciId);

            BilgiDegistir.isim = nme;
            BilgiDegistir.mail = maill;
            BilgiDegistir.dogumTarihi = dgtrh;

            db.SaveChanges();
        }

        public void SifreGuncelle(string yeniSifre)
        {
            var GuncellencekVeri = db.Kullanici.SingleOrDefault(k => k.id == AktifKullanici.kullaniciId);
            if (GuncellencekVeri != null)
            {
                GuncellencekVeri.sifre = yeniSifre;
                db.SaveChanges();
            }
        }
        #endregion Hesabim

        #region Programlar
        //////////////////////// Programlar Formu Data Base İşlemleri ////////////////////////
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
                ProgramListesi = db.Programlar
                    .Where(y => y.ProgramTurleri.Select(x => x.turId)
                    .Intersect(Filtreler).Count() == Filtreler.Count() && y.tip == SeciliProgramTuru)
                    .OrderByDescending(i => i.id)
                    .ToList();

                #region LinqKullanimi

                //Eğer lazyloading açık ise include yazıp joinlemeye gerek yok otomatik entity frtamework o işlemi yapacak
                //Eğer lazyloading kapatılmış ise include(x=>x.altsınıf) şeklinde istenen alt ilişkiler manuel joinlenir
                // Önce Linq sorgusu alınıp, sonra extension şekilde liste değiştiriliyor
                //var sorgu = (from i in db.Programlar
                //             join x in db.ProgramTurleri
                //             on i.id equals x.programId
                //             where Filtreler.Contains(x.turId) && i.tip == SeciliProgramTuru
                //             group i by new
                //             {
                //                 i.id,
                //                 i.isim,
                //                 i.tip,
                //                 i.bolum,
                //                 i.uzunluk
                //             } into gcs
                //             where gcs.Count() == Filtreler.Count()
                //             select new
                //             {
                //                 aid = gcs.Key.id,
                //                 aisim = gcs.Key.isim,
                //                 atip = gcs.Key.tip,
                //                 abolum = gcs.Key.bolum,
                //                 auzunluk = gcs.Key.uzunluk
                //             }).ToList();

                //ProgramListesi = sorgu2.ToList().OrderByDescending(i => i.id).Select(r => new Programlar
                //{
                //    id = r.id,
                //    isim = r.isim,
                //    tip = r.tip,
                //    bolum = r.bolum,
                //    uzunluk = r.uzunluk
                //}).ToList();

                #endregion LinqKullanimi
            }
        }

        public void ProgramAra(string Kelime)
        {
            ProgramListesi = db.Programlar.Where(i => i.tip == SeciliProgramTuru && i.isim.StartsWith(Kelime)).OrderByDescending(i => i.id).ToList();
        }

        public void TurDoldur()
        {
            TurListesi = db.Turler.ToList();
        }
        #endregion Programlar

        #region Giris
        //////////////////////// Giriş Formu Data Base İşlemleri ////////////////////////
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
        #endregion Giris

    }
    public class BagliTablo
    {
        public string Ad { get; set; }
        public int? BolumNo { get; set; }
        public int? BolumSayisi { get; set; }
        public int? izlemeSure { get; set; }
        public decimal? iPuan { get; set; }
        public DateTime? iTarih { get; set; }
    }
}