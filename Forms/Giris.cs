using StorkFlix.Model;
using System;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private readonly Sorgular sorgu = new Sorgular();

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            AktifKullanici Aktif = new AktifKullanici();
            AnaSayfa anasayfa = new AnaSayfa();

            string txtMail = textboxMail.Text, txtSifre = textboxPassword.Text;
            int KullaniciKontrol = sorgu.MailKullaniciAra(txtMail, txtSifre);

            if (KullaniciKontrol == 0) MessageBox.Show("Bu isimde kayıtlı bir mail adresi yok");
            else
            {
                if (KullaniciKontrol == 1)
                {
                    Aktif.KullaniciSec(txtMail);
                    this.Hide();
                    anasayfa.Show();
                }
                else MessageBox.Show("Şifre Yanlış");
            }
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            string nme = textboxKayitAd.Text, maill = textboxKayitMail.Text, psw = textboxKayitSifre.Text;

            DateTime dgtrh = Convert.ToDateTime(textboxKayitDogumTarihi.Text);

            sorgu.KullaniciEkle(nme, maill, psw, dgtrh);
        }

        private void LabelKayitOl_Click(object sender, EventArgs e)
        {
            panelKayit.BringToFront();
        }

        private void LabelGirisYap_Click(object sender, EventArgs e)
        {
            panelGiris.BringToFront();
        }
    }
}