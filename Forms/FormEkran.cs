using StorkFlix.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StorkFlix.Forms
{
    public partial class FormEkran : Form
    {
        public FormEkran()
        {
            InitializeComponent();
        }

        private decimal sure = 0;
        bool Secim = false;
        private void FormEkran_Load(object sender, EventArgs e)
        {
            label2.Text = StorkData.SecilenProgram.isim;
            string FotorafAdi = "sc" + StorkData.SecilenProgram.id;
            object O = Properties.Resources.ResourceManager.GetObject(FotorafAdi);
            pictureBox1.Image = (Image)O;
            label4.Text = StorkData.SecilenProgram.uzunluk.ToString() + ":00";

            string Fotoraf;
            if (StorkData.SecilenProgram.id % 2 == 1)
                Fotoraf = "open1";
            else Fotoraf = "open2";
            object Ob = Properties.Resources.ResourceManager.GetObject(Fotoraf);
            pictureBox4.Image = (Image)Ob;

            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "BolumSayisi";
            for (int i = 0; i < StorkData.SecilenProgram.bolum; i++)
            {
                dataGridView1.Rows.Add((i + 1) + ".Bölüm");
            }
        }

        private void FormEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            StorkData.SecilenProgram = null;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = (Convert.ToInt32(trackBar1.Value) * 5).ToString() + "%";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 100)
            {
                progressBar1.Value += 1;
                sure += Convert.ToDecimal(StorkData.SecilenProgram.uzunluk) / 100m;
                label3.Text = Math.Floor(sure).ToString("00") + ":00";
            }
            else
            {
                timer1.Stop();
                pictureBox3.Visible = false;
                pictureBox4.Enabled = false;
                pictureBox4.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == false)
            {
                timer1.Start();
                pictureBox3.Visible = true;
                pictureBox4.Enabled = true;
                pictureBox4.Visible = true;
            }
            else
            {
                timer1.Stop();
                pictureBox3.Visible = false;
                pictureBox4.Enabled = false;
                pictureBox4.Visible = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            sure = 0;
            label3.Text = "00:00";
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

        private void Star_Click(object sender, EventArgs e)
        {
            if (Secim == false) Secim = true;
            else Secim = false;
        }
    }
}