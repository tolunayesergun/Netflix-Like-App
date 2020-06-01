using StorkFlix.Classes;
using StorkFlix.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StorkFlix.Forms
{
    public partial class AltFormAnaSayfa : Form
    {
        public AltFormAnaSayfa()
        {
            InitializeComponent();
        }

        private readonly StorkData Baglanti = new StorkData();

        private void AltFormAnaSayfa_Load(object sender, EventArgs e)
        {
            if (StorkData.tempList == null)
            {
                panel3.Visible = true;
            }
            else
            {
                IcerikleriYerlestir();
            }
        }

        private void IcerikleriYerlestir()
        {
            for (int i = 0; i < StorkData.tempList.Count(); i++)
            {
                string Fotoraf = "_" + StorkData.tempList[i].id;
                object Ob = Properties.Resources.ResourceManager.GetObject(Fotoraf);
                (panel2.Controls["FilmAfis" + (i + 1)] as PictureBox).Image = (Image)Ob;
                (panel2.Controls["FilmAfis" + (i + 1)] as PictureBox).Tag = StorkData.tempList[i].id;
                (panel2.Controls["lblFilmAd" + (i + 1)] as TextBox).Text = StorkData.tempList[i].isim;
                (panel2.Controls["lblPuan" + (i + 1)] as Label).Text = StorkData.PuanListesi[i].ToString();
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

        private void panel3_VisibleChanged(object sender, EventArgs e)
        {
            TurDataGridiniDoldur();
        }

        private void TurDataGridiniDoldur()
        {
            Baglanti.TurDoldur();
            dataGridView1.DataSource = StorkData.TurListesi;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
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
            panel4.Visible = true;
            string favkats = "";
            for (int i = 0; i < 3; i++)
            {
                favkats += dataGridView1.SelectedRows[i].Index + 1;
                if (i != 2) favkats += ",";
            }
            Baglanti.FavSec(favkats, AktifKullanici.kullaniciMail);
            AktifKullanici aktif = new AktifKullanici();
            aktif.favDegistir(favkats);
            panel3.Visible = false;
            Baglanti.OnerilenleriBul();
            IcerikleriYerlestir();
            panel4.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}