using StorkFlix.Classes;
using System;
using System.Threading;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private bool IslemVarmi = false;


        private void btnDizi_Click(object sender, EventArgs e)
        {
            if (IslemVarmi == false)
            {
                StorkData.SeciliProgramTuru = "Dizi";
                pictureBox2.Enabled = true;
                pictureBox2.Visible = true;
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox2.BringToFront();
                IslemVarmi = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnFilm_Click(object sender, EventArgs e)
        {
            if (IslemVarmi == false)
            {
                StorkData.SeciliProgramTuru = "Film";
                pictureBox2.Enabled = true;
                pictureBox2.Visible = true;
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox2.BringToFront();
                IslemVarmi = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StorkData listgetir = new StorkData();
            listgetir.ListeDoldur();
            listgetir.TurDoldur();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Enabled = false;
            IslemVarmi = false;   
            openChildForm(new FormProgramlar());
        }

        private void AnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}