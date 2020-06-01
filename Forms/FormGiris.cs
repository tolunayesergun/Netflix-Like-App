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
            lblBasarili.Visible = false;
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
            lblalanEksik.Visible = false;

            if (textboxKayitAd.Text != "" && textboxKayitMail.Text != "" && textboxKayitSifre.Text != "" && textboxKayitSifreTekrar.Text != "" && textboxKayitDogumAyTarihi.Text != "" && textboxKayitDogumGunTarihi.Text != "" && textboxKayitDogumYilTarihi.Text != "")
            {
                if (textboxKayitSifre.Text == textboxKayitSifreTekrar.Text)
                {
                    if (Convert.ToInt32(textboxKayitDogumGunTarihi.Text) <= 31 && Convert.ToInt32(textboxKayitDogumGunTarihi.Text) > 0 && Convert.ToInt32(textboxKayitDogumAyTarihi.Text) <= 12 && Convert.ToInt32(textboxKayitDogumAyTarihi.Text) > 0 && Convert.ToInt32(textboxKayitDogumYilTarihi.Text) <= 2020 && Convert.ToInt32(textboxKayitDogumYilTarihi.Text) > 1890)
                    {
                        string nme = textboxKayitAd.Text, maill = textboxKayitMail.Text, psw = textboxKayitSifre.Text;
                        int KullaniciKontrol = DataBaglan.MailKullaniciAra(maill, psw);
                        if (KullaniciKontrol == 0)
                        {
                            try
                            {
                                DateTime dgtrh = Convert.ToDateTime(textboxKayitDogumYilTarihi.Text + "-" + textboxKayitDogumAyTarihi.Text + "-" + textboxKayitDogumGunTarihi.Text);
                                DataBaglan.KullaniciEkle(nme, maill, psw, dgtrh);
                                panelKategoriSec.Visible = true;
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
                else lblTekrarHatasi.Visible = true;
            }
            else lblalanEksik.Visible = true;
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
            DataBaglan.TurDoldur();
            dataGridView1.DataSource = StorkData.TurListesi;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
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
                FavKatsKaydet.Visible = false;
            }
            else
            {
                lblSecimSayisi.Visible = false;
                FavKatsKaydet.Visible = true;
            }
        }

        private void FavKatsKaydet_Click(object sender, EventArgs e)
        {
            string favkats = "";
            for (int i = 0; i < 3; i++)
            {
                favkats += dataGridView1.SelectedRows[i].Index + 1;
                if (i != 2) favkats += ",";
            }
            DataBaglan.FavSec(favkats, textboxKayitMail.Text);
            panelKayit.Visible = false;
            lblBasarili.Visible = true;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}