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
    public partial class FormEkran : Form
    {
        public FormEkran()
        {
            InitializeComponent();
        }

        private void FormEkran_Load(object sender, EventArgs e)
        {
            label2.Text = StorkData.SecilenProgram.isim;
            string FotorafAdi = "sc" + StorkData.SecilenProgram.id;
            object O = Properties.Resources.ResourceManager.GetObject(FotorafAdi);
            pictureBox1.Image = (Image)O;
        }

        private void FormEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            StorkData.SecilenProgram = null;
        }
    }
}
