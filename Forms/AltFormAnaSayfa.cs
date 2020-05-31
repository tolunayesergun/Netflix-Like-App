using StorkFlix.Model;
using StorkFlix.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorkFlix.Forms
{
    public partial class AltFormAnaSayfa : Form
    {
        public AltFormAnaSayfa()
        {
            InitializeComponent();
        }

        private void AltFormAnaSayfa_Load(object sender, EventArgs e)
        {
         

            IcerikleriYerlestir();
        }

        private void IcerikleriYerlestir()
        {
            for (int i = 0; i < StorkData.tempList.Count(); i++)
            {
                string Fotoraf = "_" + StorkData.tempList[i].id;
                object Ob = Properties.Resources.ResourceManager.GetObject(Fotoraf);
                (panel2.Controls["FilmAfis" + (i + 1)] as PictureBox).Image = (Image)Ob;
                (panel2.Controls["FilmAfis" + (i + 1)] as PictureBox).Tag= StorkData.tempList[i].id;
                (panel2.Controls["lblFilmAd" + (i + 1)] as TextBox).Text = StorkData.tempList[i].isim;
                (panel2.Controls["lblPuan" + (i + 1)] as Label).Text = StorkData.tempList[i].KullaniciProgram.Average(y => y.puan).ToString();
         
            }
        }

        private void FilmAfis_Click(object sender, EventArgs e)
        {
            PictureBox Image = sender as PictureBox;
            StorkData Baglanti = new StorkData();
            Baglanti.ProgramSec(Convert.ToInt32(Image.Tag));
            this.Close();
        }

        private void lblFilmAd_Click(object sender, EventArgs e)
        {
            StorkData Baglanti = new StorkData();
            TextBox lbbl = sender as TextBox;
            Baglanti.ProgramSec(Convert.ToInt32((panel2.Controls["FilmAfis" + lbbl.Name.Substring(9)] as PictureBox).Tag));
            this.Close();
        }
    }
}
