using StorkFlix.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class FormHesabim : Form
    {
        public FormHesabim()
        {
            InitializeComponent();
        }

        private void FormHesabim_Load(object sender, EventArgs e)
        {
            lblName.Text = AktifKullanici.kullaniciAdi;
            lblMail.Text = AktifKullanici.kullaniciMail;
            lblDate.Text = AktifKullanici.kullaniciDgn.ToString("MM-dd-yyyy");
        }

        private void BtnSecimIptal_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void BtnSecimYap_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }
    }
}
