using StorkFlix.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StorkFlix.Forms
{
    public partial class AltFormEkran : Form
    {
        public AltFormEkran()
        {
            InitializeComponent();
        }

        private decimal sure = 0;
        private bool Secim = false;
        private readonly StorkData Baglanti = new StorkData();

        private void FormEkran_Load(object sender, EventArgs e)
        {
            GifGetir();
            BolumUzunlukYaz();
            BolumleriListele();
            YildizDoldur(Convert.ToInt32(StorkData.SonBolum.puan));
        }

        private void YeniBolumSecildi()
        {
            Baglanti.BolumBilgileriniYaz();
            BolumUzunlukYaz();
            YildizDoldur(Convert.ToInt32(StorkData.SonBolum.puan));
        }

        private void BolumleriListele()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "BolumSayisi";
            for (int i = 0; i < StorkData.SecilenProgram.bolum; i++)
            {
                dataGridView1.Rows.Add((i + 1) + ".Bölüm");
            }
            dataGridView1.Rows[StorkData.TempBolum - 1].Cells[0].Selected = true;
            //   dataGridView1.Rows[1].Cells[0].Style.ForeColor = Color.Red;
        }

        private void GifGetir()
        {
            string Fotoraf;
            if (StorkData.SecilenProgram.id % 2 == 1)
                Fotoraf = "open1";
            else Fotoraf = "open2";
            object Ob = Properties.Resources.ResourceManager.GetObject(Fotoraf);
            pictureBox4.Image = (Image)Ob;
        }

        private void BolumUzunlukYaz()
        {
            int bolumUzunlugu = Convert.ToInt32(StorkData.SecilenProgram.uzunluk);
            lblProgramAdi.Text = StorkData.SecilenProgram.isim;
            string FotorafAdi = "sc" + StorkData.SecilenProgram.id;
            object O = Properties.Resources.ResourceManager.GetObject(FotorafAdi);
            pictureBox1.Image = (Image)O;
            lblBolumUzunluk.Text = bolumUzunlugu.ToString() + ":00";

            sure = Convert.ToInt32(StorkData.SonBolum.izlemeSuresi);
            lblKaldiginDakika.Text = Math.Floor(sure).ToString("00") + ":00";
            progressBar1.Value = Convert.ToInt32(Math.Floor((sure * 100m) / bolumUzunlugu));
        }

        private void FormEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            Baglanti.BolumIzlemeBilgisiGuncelle(Convert.ToInt32(Math.Floor(sure)));
            StorkData.SecilenProgram = null;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblSesSeviyesi.Text = (Convert.ToInt32(trackBar1.Value) * 5).ToString() + "%";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 100)
            {
                progressBar1.Value += 1;
                sure += Convert.ToDecimal(StorkData.SecilenProgram.uzunluk) / 100m;
                lblKaldiginDakika.Text = Math.Floor(sure).ToString("00") + ":00";
            }
            else
            {
                timer1.Stop();
                btnStop.Visible = false;
                pictureBox4.Enabled = false;
                pictureBox4.Visible = false;
                Baglanti.BolumTamamla(true);
            }
        }

        private void btnPlayStop_Click(object sender, EventArgs e)
        {
            if (btnStop.Visible == false)
            {
                timer1.Start();
                btnStop.Visible = true;
                pictureBox4.Enabled = true;
                pictureBox4.Visible = true;
            }
            else
            {
                timer1.Stop();
                btnStop.Visible = false;
                pictureBox4.Enabled = false;
                pictureBox4.Visible = false;
            }
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            sure = 0;
            lblKaldiginDakika.Text = "00:00";
        }

        private void Star_MouseEnter(object sender, EventArgs e)
        {
            if (Secim == false)
            {
                PictureBox Image = sender as PictureBox;
                int target = Convert.ToInt32(Image.Name.Substring(4));
                PictureBox[] boxes = { Star1, Star2, Star3, Star4, Star5, Star6, Star7, Star8, Star9, Star10 };

                for (int i = 0; i < target; i++)
                {
                    boxes[i].BackColor = Color.White;
                }
                for (int i = target; i < 10; i++)
                {
                    boxes[i].BackColor = Color.Transparent;
                }
            }
        }

        private void YildizDoldur(int yildizSayisi)
        {
            PictureBox[] boxes = { Star1, Star2, Star3, Star4, Star5, Star6, Star7, Star8, Star9, Star10 };

            for (int i = 0; i < yildizSayisi; i++)
            {
                boxes[i].BackColor = Color.White;
            }
            for (int i = yildizSayisi; i < 10; i++)
            {
                boxes[i].BackColor = Color.Transparent;
            }
            if (yildizSayisi > 0)
            {
                Secim = true;
            }
            else
            {
                Secim = false;
            }
        }

        private void Star_Click(object sender, EventArgs e)
        {
            if (Secim == false)
            {
                Secim = true;
                PictureBox Image = sender as PictureBox;
                int Gpuan = Convert.ToInt32(Image.Name.Substring(4));
                Baglanti.PuanGuncelle(Gpuan);
            }
            else Secim = false;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            Baglanti.BolumIzlemeBilgisiGuncelle(Convert.ToInt32(Math.Floor(sure)));
            StorkData.TempBolum = dataGridView1.SelectedRows[0].Index + 1;
            YeniBolumSecildi();
        }
    }
}