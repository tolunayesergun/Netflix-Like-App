using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class Diziler : Form
    {
        public Diziler()
        {
            InitializeComponent();
        }

        private static readonly StorkModel db = new StorkModel();
        private readonly System.Collections.Generic.List<Programlar> diziler = db.Programlar.ToList();
        int SonrakiBuyukluk = 560;
        int OncekiBuyukluk = 392;
        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResimDiz()
        {
            int x = 0, y = 0;

            foreach (var item in diziler)
            {
                var dosyaYolu = "_" + item.id.ToString();
                object O = Properties.Resources.ResourceManager.GetObject(dosyaYolu);

                PictureBox lst = new PictureBox
                {
                    Image = (Image)O,
                    Size = new System.Drawing.Size(160, 240),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                if (x < (panel1.Size.Width - 168))
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

        private void Diziler_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ResimDiz();
        }

        private void Panel1_Resize(object sender, EventArgs e)
        {

            if (panel1.Width > SonrakiBuyukluk )
            {
                OncekiBuyukluk = SonrakiBuyukluk;
                SonrakiBuyukluk += 168;
                panel1.Controls.Clear();
                ResimDiz();
               
            }
            else if(panel1.Width < OncekiBuyukluk)
            {
                SonrakiBuyukluk = OncekiBuyukluk;
                OncekiBuyukluk -= 168;
                panel1.Controls.Clear();
                ResimDiz();
            }

        }
       

    }
}