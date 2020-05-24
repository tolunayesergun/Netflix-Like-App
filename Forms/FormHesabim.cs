using StorkFlix.Classes;
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
            lblName.Text = AktifKullanici.kullaniciAdi;
            lblMail.Text = AktifKullanici.kullaniciMail;
            lblDate.Text = AktifKullanici.kullaniciDgn.ToString("MM-dd-yyyy");

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
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            textboxKadi.Text = AktifKullanici.kullaniciAdi;
            textboxMail.Text = AktifKullanici.kullaniciMail;
            textboxDg.Text = AktifKullanici.kullaniciDgn.ToString("MM-dd-yyyy");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Baglanti.BilgiGuncelle(textboxKadi.Text, textboxMail.Text, Convert.ToDateTime(textboxDg.Text));
            AktifKullanici.kullaniciAdi = textboxKadi.Text;
            AktifKullanici.kullaniciMail = textboxMail.Text;
            AktifKullanici.kullaniciDgn = Convert.ToDateTime(textboxDg.Text);
            lblName.Text = AktifKullanici.kullaniciAdi;
            lblMail.Text = AktifKullanici.kullaniciMail;
            lblDate.Text = AktifKullanici.kullaniciDgn.ToString("MM-dd-yyyy");
            panel6.Visible = false;
        }

        private void lblSifreDegis_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void btnsfreIptal_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void sfreKydt_Click(object sender, EventArgs e)
        {
        }

        private void lblCikisYap_Click(object sender, EventArgs e)
        {
            AktifKullanici.kullaniciId = -1;
            this.Close();
        }
    }
}