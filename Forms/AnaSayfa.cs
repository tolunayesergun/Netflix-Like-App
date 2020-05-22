using StorkFlix.Classes;
using StorkFlix.Forms;
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


        private void BtnDizi_Click(object sender, EventArgs e)
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

        private void BtnFilm_Click(object sender, EventArgs e)
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

        private void BtnHesabim_Click(object sender, EventArgs e)
        {
            AltForumGetir(new FormHesabim());
        }

        private Form activeForm = null;

        public void AltForumGetir(Form altForum)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = altForum;
            altForum.TopLevel = false;
            altForum.FormBorderStyle = FormBorderStyle.None;
            altForum.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(altForum);
            panelChildForm.Tag = altForum;
            altForum.BringToFront();
            altForum.Show();
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
            AltForumGetir(new FormProgramlar());
        }

        private void AnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PanelChildForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            if(StorkData.SecilenProgram!=null)AltForumGetir(new FormEkran());
        }


    }
}