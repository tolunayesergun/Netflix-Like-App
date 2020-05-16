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

        private void button1_Click_1(object sender, EventArgs e)
        {
            StorkModel db = new StorkModel();

            string nme = textBox1.Text;

            string maill = textBox2.Text;

            string psw = textBox3.Text;

            DateTime dgtrh = Convert.ToDateTime(textBox4.Text);

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

   
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            Kontroller kontrol = new Kontroller();
            AktifKullanici Aktif = new AktifKullanici();
            AnaSayfa anasayfa = new AnaSayfa();

            string txtMail = textboxMail.Text, txtSifre = textboxPassword.Text;
            int kulId = kontrol.MailKullaniciAra(txtMail);

            if (kulId == -1) MessageBox.Show("Bu isimde kayıtlı bir mail adresi yok");
            else
            {
                bool sifreKontrol = kontrol.SifreKontrol(kulId, txtSifre);

                if (sifreKontrol == true)
                {
                    Aktif.KullaniciSec(kulId);
                    this.Hide();
                    anasayfa.Show();
                }
                else MessageBox.Show("Şifre Yanlış");
            }
        }

        private void LabelKayitOl_Click(object sender, EventArgs e)
        {
            panelKayit.BringToFront();
        }
    }
}