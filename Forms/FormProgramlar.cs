using StorkFlix.Classes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class FormProgramlar : Form
    {
        public FormProgramlar()
        {
            InitializeComponent();
        }

        private int SonrakiBuyukluk = 680;
        private int OncekiBuyukluk = 392;

        private void ResimDiz()
        {
            int x = 0, y = 0;

            foreach (var item in StorkData.DiziListesi)
            {
                var dosyaYolu = "_" + item.id.ToString();
                object O = Properties.Resources.ResourceManager.GetObject(dosyaYolu);

                PictureBox lst = new PictureBox
                {
                    Image = (Image)O,
                    Size = new System.Drawing.Size(160, 240),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name=item.isim
       
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
        }

        private void DataGridDoldur()
        {
   

            dataGridView1.DataSource = StorkData.TurListesi;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        private void Diziler_Load(object sender, EventArgs e)
        {
            
            DataGridDoldur();        
            panel1.Controls.Clear();
            ResimDiz();
         
        }

        private void Panel1_Resize(object sender, EventArgs e)
        {
            if (panel1.Width > SonrakiBuyukluk)
            {
                OncekiBuyukluk = SonrakiBuyukluk;
                SonrakiBuyukluk += 170;
                panel1.Controls.Clear();
                ResimDiz();
            }
            else if (panel1.Width < OncekiBuyukluk)
            {
                SonrakiBuyukluk = OncekiBuyukluk;
                OncekiBuyukluk -= 170;
                panel1.Controls.Clear();
                ResimDiz();
            }
          
        }



        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

    }
}