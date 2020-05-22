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
        }

        private void FormEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            StorkData.SecilenProgram = null;
        }
    }
}
