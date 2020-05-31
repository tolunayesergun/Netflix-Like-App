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
            lblKayitliHatasi.Visible = false;
            lblTekrarHatasi.Visible = false;
            lblDogHata.Visible = false;
            string nme = textboxKayitAd.Text, maill = textboxKayitMail.Text, psw = textboxKayitSifre.Text;
            int KullaniciKontrol = DataBaglan.MailKullaniciAra(maill, psw);
            if (KullaniciKontrol == 0)
            {
                if (textboxKayitSifre.Text == textboxKayitSifreTekrar.Text)
                {
                    if (Convert.ToInt32(textboxKayitDogumGunTarihi.Text) <= 31 && Convert.ToInt32(textboxKayitDogumGunTarihi.Text) > 0 && Convert.ToInt32(textboxKayitDogumAyTarihi.Text) <= 12 && Convert.ToInt32(textboxKayitDogumAyTarihi.Text) > 0 && Convert.ToInt32(textboxKayitDogumYilTarihi.Text) <= 2020 && Convert.ToInt32(textboxKayitDogumYilTarihi.Text) > 1890)
                    {
                        DateTime dgtrh = Convert.ToDateTime(textboxKayitDogumYilTarihi.Text + "-" + textboxKayitDogumAyTarihi.Text + "-" + textboxKayitDogumGunTarihi.Text);
                        DataBaglan.KullaniciEkle(nme, maill, psw, dgtrh);
                    }
                    else lblDogHata.Visible = true;
                }
                else lblTekrarHatasi.Visible = true;
            }
            else lblKayitliHatasi.Visible = true;
        }

        private void LabelKayitOl_Click(object sender, EventArgs e)
        {
            TurDataGridiniDoldur();
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
            TurDataGridiniDoldur();
            if (Properties.Settings.Default.KullaniciAdi != "")
            {
                textboxMail.Text = Properties.Settings.Default.KullaniciAdi;
                textboxPassword.Text = Properties.Settings.Default.Sifre;
                chckBeniHatirla.Checked = true;
                btnGiris.TabIndex = 1;
            }
        }

        private void TurDataGridiniDoldur()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Turler";
            dataGridView1.Rows.Add("Aksiyon ve Macera");
            dataGridView1.Rows.Add("Belgesel");
            dataGridView1.Rows.Add("Bilim Kurgu");
            dataGridView1.Rows.Add("Bilim ve Doğa");
            dataGridView1.Rows.Add("Çocuk ve Aile");
            dataGridView1.Rows.Add("Dramalar");
            dataGridView1.Rows.Add("Gerilim");
            dataGridView1.Rows.Add("Komedi");
            dataGridView1.Rows.Add("Korku");
            dataGridView1.Rows.Add("Romantizim");
            dataGridView1.Rows.Add("Reality Program");
            dataGridView1.Rows.Add("Anime");
            dataGridView1.ClearSelection();
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 3)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            if (dataGridView1.SelectedRows.Count < 3)
            {
                lblSecimSayisi.Text = "Kalan Seçim Sayısı : " + (3 - dataGridView1.SelectedRows.Count);
                lblSecimSayisi.Visible = true;
            }
            else lblSecimSayisi.Visible = false;
        }
    }
}