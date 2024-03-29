﻿using StorkFlix.Classes;
using StorkFlix.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class FormHesabim : Form
    {
        public FormHesabim()
        {
            InitializeComponent();
        }

        private readonly StorkData Baglanti = new StorkData();

        private void FormHesabim_Load(object sender, EventArgs e)
        {
            ProfilBilgileriniGetir();
            IzlemeGecmisiniGetir();
        }

        private void IzlemeGecmisiniGetir()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Program ve Bölümü";
            dataGridView1.Columns[1].Name = "İzleme Süresi";
            dataGridView1.Columns[2].Name = "Verdiğiniz Puan";
            dataGridView1.Columns[3].Name = "İzleme Tarihi";
            Baglanti.IzlemeGecmisiOlustur(AktifKullanici.kullaniciId);
            for (int i = 0; i < StorkData.IzlemeGecmisi.Count; i++)
            {
                if (StorkData.IzlemeGecmisi[i].izlemeSure != 0)
                {
                    string ProgramBilgisi = Convert.ToString(StorkData.IzlemeGecmisi[i].Ad);
                    if (StorkData.IzlemeGecmisi[i].BolumSayisi > 1)
                        ProgramBilgisi = StorkData.IzlemeGecmisi[i].Ad + " " + StorkData.IzlemeGecmisi[i].BolumNo + ".Bolüm";

                    string DakikaBilgisi = StorkData.IzlemeGecmisi[i].izlemeSure + " Dakika";

                    string PuanBilgisi = "Puanlanmadı";
                    if (StorkData.IzlemeGecmisi[i].iPuan > 0)
                        PuanBilgisi = StorkData.IzlemeGecmisi[i].iPuan.ToString();

                    string TarihBilgisi = Convert.ToDateTime(StorkData.IzlemeGecmisi[i].iTarih).ToString("HH:mm:ss") + "     " +
                                          Convert.ToDateTime(StorkData.IzlemeGecmisi[i].iTarih).ToString("dd/MM/yyyy");

                    dataGridView1.Rows.Add(ProgramBilgisi, DakikaBilgisi, PuanBilgisi, TarihBilgisi);
                }
            }
        }

        private void ProfilBilgileriniGetir()
        {
            lblName.Text = AktifKullanici.kullaniciAdi;
            lblMail.Text = AktifKullanici.kullaniciMail;
            lblDate.Text = AktifKullanici.kullaniciDgn.ToString("dd-MM-yyyy");

            string FotorafAdi = "profil2";
            if (AktifKullanici.kullaniciProfil != null) FotorafAdi = AktifKullanici.kullaniciProfil;
            object O = Properties.Resources.ResourceManager.GetObject(FotorafAdi);
            pictureBox1.Image = (Image)O;
        }

        private void BtnSecimIptal_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void BtnSecimYap_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox Image = sender as PictureBox;
            var FotorafAdi = Image.Name;
            object O = Properties.Resources.ResourceManager.GetObject(FotorafAdi);
            pictureBox1.Image = (Image)O;
            AktifKullanici.kullaniciProfil = Image.Name;
            Baglanti.ProfilSec(Image.Name);

            panel4.Visible = false;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel5.Visible = true;
            panel7.Visible = false;
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            textboxKadi.Text = AktifKullanici.kullaniciAdi;
            textboxMail.Text = AktifKullanici.kullaniciMail;
            string[] GunAyYil = AktifKullanici.kullaniciDgn.ToString("yyyy-MM-dd").Split('-');
            textboxKayitDogumYilTarihi.Text = GunAyYil[0];
            textboxKayitDogumAyTarihi.Text = GunAyYil[1];
            textboxKayitDogumGunTarihi.Text = GunAyYil[2];
            lblKayitliHatasi.Visible = false;
            lblDogHata.Visible = false;
            lblalanEksik.Visible = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            lblKayitliHatasi.Visible = false;
            lblDogHata.Visible = false;
            lblalanEksik.Visible = false;

            if (textboxKadi.Text != "" && textboxMail.Text != "" && textboxKayitDogumAyTarihi.Text != "" && textboxKayitDogumGunTarihi.Text != "" && textboxKayitDogumYilTarihi.Text != "")
            {
                if (Convert.ToInt32(textboxKayitDogumGunTarihi.Text) <= 31 && Convert.ToInt32(textboxKayitDogumGunTarihi.Text) > 0 && Convert.ToInt32(textboxKayitDogumAyTarihi.Text) <= 12 && Convert.ToInt32(textboxKayitDogumAyTarihi.Text) > 0 && Convert.ToInt32(textboxKayitDogumYilTarihi.Text) <= 2020 && Convert.ToInt32(textboxKayitDogumYilTarihi.Text) > 1890)
                {
                    string maill = textboxMail.Text;
                    int KullaniciKontrol = Baglanti.MailKullaniciAra(maill, "1");
                    if (maill == AktifKullanici.kullaniciMail || KullaniciKontrol == 0)
                    {
                        try
                        {
                            DateTime dgtrh = Convert.ToDateTime(textboxKayitDogumYilTarihi.Text + "-" + textboxKayitDogumAyTarihi.Text + "-" + textboxKayitDogumGunTarihi.Text);
                            Baglanti.BilgiGuncelle(textboxKadi.Text, textboxMail.Text, dgtrh);
                            AktifKullanici.kullaniciAdi = textboxKadi.Text;
                            AktifKullanici.kullaniciMail = textboxMail.Text;
                            AktifKullanici.kullaniciDgn = dgtrh;
                            lblName.Text = AktifKullanici.kullaniciAdi;
                            lblMail.Text = AktifKullanici.kullaniciMail;
                            lblDate.Text = AktifKullanici.kullaniciDgn.ToString("dd-MM-yyyy");
                            panel6.Visible = false;
                            panel5.Visible = true;
                            panel7.Visible = false;
                        }
                        catch (FormatException)
                        {
                            lblDogHata.Visible = true;
                        }
                    }
                    else lblKayitliHatasi.Visible = true;
                }
                else lblDogHata.Visible = true;
            }
            else lblalanEksik.Visible = true;
        }

        private void lblSifreDegis_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void btnsfreIptal_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel6.Visible = true;
            panel5.Visible = false;
        }

        private void sfreKydt_Click(object sender, EventArgs e)
        {
            if (lblEskiSifre.Text == AktifKullanici.kullaniciSifre)
            {
                if (LblYeniSifre.Text == lblYeniSifreTekrar.Text)
                {
                    Baglanti.SifreGuncelle(LblYeniSifre.Text);
                    lblUyumProblemi.Visible = false;
                    panel7.Visible = false;
                    panel6.Visible = true;
                    panel5.Visible = false;
                }
                else
                {
                    lblUyumProblemi.Visible = true;
                }
                labelSifreHata.Visible = false;
            }
            else
            {
                labelSifreHata.Visible = true;
            }
        }

        private void lblCikisYap_Click(object sender, EventArgs e)
        {
            AktifKullanici.kullaniciId = -1;
            this.Close();
        }

        private void lblSifreDegis_Click_1(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel6.Visible = false;
            panel5.Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}