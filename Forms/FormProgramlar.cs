using StorkFlix.Classes;
using StorkFlix.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class FormProgramlar : Form
    {
        public FormProgramlar()
        {
            InitializeComponent();
        }

        private readonly StorkData Baglanti = new StorkData();
        private int SonrakiBuyukluk = 680;
        private int OncekiBuyukluk = 392;

        private void ResimDiz()
        {
            panel1.Controls.Clear();
            int x = 0, y = 0;
            foreach (var item in StorkData.ProgramListesi)
            {
                var dosyaYolu = "_" + item.id.ToString();
                object O = Properties.Resources.ResourceManager.GetObject(dosyaYolu);

                PictureBox lst = new PictureBox
                {
                    Image = (Image)O,
                    Size = new System.Drawing.Size(160, 240),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = item.isim,
                    Tag=item.id
                };
                lst.Click += new EventHandler(Image_Click);
                lst.MouseHover += new EventHandler(Image_MouseHover);

                if (x < (panel1.Size.Width - 170))
                {
                    lst.Location = new Point(x, y);
                    panel1.Controls.Add(lst);
                    x += 170;
                }
                else
                {
                    x = 0;
                    y += 250;
                    lst.Location = new Point(x, y);
                    panel1.Controls.Add(lst);
                    x += 170;
                }
            }
        }

        private void Image_MouseHover(object sender, EventArgs e)
        {
            PictureBox Image = sender as PictureBox;
            toolTip1.SetToolTip(Image, Image.Name.ToString());
        }

        private void Image_Click(object sender, EventArgs e)
        {
            PictureBox Image = sender as PictureBox;
            Baglanti.ProgramSec(Convert.ToInt32(Image.Tag));
            this.Close();
        }

        private void Diziler_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = false;
            DataGridDoldur();
            ResimDiz();
            backgroundWorker1.RunWorkerAsync();
        }

        private void Panel1_Resize(object sender, EventArgs e)
        {
            if (panel1.Width > SonrakiBuyukluk)
            {
                OncekiBuyukluk = SonrakiBuyukluk;
                SonrakiBuyukluk += 170;
                ResimDiz();
            }
            else if (panel1.Width < OncekiBuyukluk)
            {
                SonrakiBuyukluk = OncekiBuyukluk;
                OncekiBuyukluk -= 170;
                ResimDiz();
            }
        }

        private void DataGridDoldur()
        {
            dataGridView1.DataSource = StorkData.TurListesi;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.RowTemplate.MinimumHeight = 32;
        }

        private void DataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            label1.Visible = false;
            int?[] diziTurler = new int?[dataGridView1.SelectedRows.Count];

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                diziTurler[i] = (dataGridView1.SelectedRows[i].Index + 1);
            }

            Baglanti.ListeFiltrele(diziTurler);
            ResimDiz();

            if (panel1.Controls.Count < 1)
            {
                if (diziTurler.Count() > 1) label1.Text = "   Bu Kategorilere Uygun " + StorkData.SeciliProgramTuru + " Yok";
                else label1.Text = "   Bu Kategoriye Uygun " + StorkData.SeciliProgramTuru + " Yok";
                label1.Visible = true;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Thread.Sleep(100);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panel1.AutoScroll = true;
        }

        private void TextboxMail_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;

            Baglanti.ProgramAra(textboxMail.Text);
            ResimDiz();

            if (panel1.Controls.Count < 1)
            {
                label1.Text = "   Bu İsimde Bir " + StorkData.SeciliProgramTuru + " Yok";
                label1.Visible = true;
            }
        }

        private void animaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (animaCheckBox1.Checked == false) dataGridView1.MultiSelect = false;
            else dataGridView1.MultiSelect = true;
        }
    }
}