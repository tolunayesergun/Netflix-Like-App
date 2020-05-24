using StorkFlix.Classes;
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

        private bool IslemVarmi = false;
        private readonly StorkData DataBaglan = new StorkData();

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (IslemVarmi == false)
            {
                pictureBox2.Visible = true;
                labelSifreHata.Visible = false;
                labelMailHata.Visible = false;
                IslemVarmi = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            string nme = textboxKayitAd.Text, maill = textboxKayitMail.Text, psw = textboxKayitSifre.Text;

            DateTime dgtrh = Convert.ToDateTime(textboxKayitDogumTarihi.Text);

            DataBaglan.KullaniciEkle(nme, maill, psw, dgtrh);
        }

        private void LabelKayitOl_Click(object sender, EventArgs e)
        {
            panelKayit.BringToFront();
        }

        private void LabelGirisYap_Click(object sender, EventArgs e)
        {
            panelGiris.BringToFront();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DataBaglan.TurDoldur();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IslemVarmi = false;
            pictureBox2.Visible = false;

            AktifKullanici Aktif = new AktifKullanici();
            AnaSayfa anasayfa = new AnaSayfa();

            string txtMail = textboxMail.Text, txtSifre = textboxPassword.Text;
            int KullaniciKontrol = DataBaglan.MailKullaniciAra(txtMail, txtSifre);

            if (KullaniciKontrol == 0) labelMailHata.Visible = true;
            else
            {
                if (KullaniciKontrol == 1)
                {
                    if (chckBeniHatirla.Checked == true)
                    {
                        Properties.Settings.Default.KullaniciAdi = textboxMail.Text;
                        Properties.Settings.Default.Sifre = textboxPassword.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.KullaniciAdi = "";
                        Properties.Settings.Default.Sifre = "";
                        Properties.Settings.Default.Save();
                    }
                    Aktif.KullaniciSec(txtMail);
                    anasayfa.Show();
                    this.Hide();
                }
                else labelSifreHata.Visible = true;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox3.Visible = true;

            textboxPassword.UseSystemPasswordChar = true;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox3.Visible = false;
            textboxPassword.UseSystemPasswordChar = false;
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.KullaniciAdi != "")
            {
                textboxMail.Text = Properties.Settings.Default.KullaniciAdi;
                textboxPassword.Text = Properties.Settings.Default.Sifre;
                chckBeniHatirla.Checked = true;
                btnGiris.TabIndex = 1;
            }
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}