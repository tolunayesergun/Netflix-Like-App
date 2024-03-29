﻿using StorkFlix.Classes;
using StorkFlix.Forms;
using StorkFlix.Model;
using System;
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
        private Form activeForm = null;

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
            if (IslemVarmi == false)
            {
                pictureBox2.Enabled = true;
                pictureBox2.Visible = true;
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox2.BringToFront();
                IslemVarmi = true;
                backgroundWorker3.RunWorkerAsync();
            }
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
            if (AktifKullanici.kullaniciId != -1) Application.Exit();
        }

        private void PanelChildForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (AktifKullanici.kullaniciId == -1) { Giris Tekrar = new Giris(); Tekrar.Show(); this.Hide(); }
            if (StorkData.SecilenProgram != null)
            {
                pictureBox2.Enabled = true;
                pictureBox2.Visible = true;
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox2.BringToFront();
                IslemVarmi = true;
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StorkData Baglanti = new StorkData();
            Baglanti.KullaniciKayitKontrol();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Enabled = false;
            IslemVarmi = false;
            AltForumGetir(new AltFormEkran());
        }

        private void btnAltAnaSayfa_Click(object sender, EventArgs e)
        {
            if (IslemVarmi == false)
            {
                pictureBox2.Enabled = true;
                pictureBox2.Visible = true;
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox2.BringToFront();
                IslemVarmi = true;
                backgroundWorker3.RunWorkerAsync();
            }
        }

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StorkData Baglanti = new StorkData();
            Baglanti.OnerilenleriBul();
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IslemVarmi = false;
            AltForumGetir(new AltFormAnaSayfa());
            pictureBox2.Enabled = false;
        }
    }
}