﻿using StorkFlix.Model;
using System;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;
            panelPlaylistSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubMenu);
        }

        #region MediaSubMenu

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
      

            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
     
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
       
            hideSubMenu();
        }

        #endregion MediaSubMenu

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubMenu);
        }

        #region PlayListManagemetSubMenu

        private void button8_Click(object sender, EventArgs e)
        {
        
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
      
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
       
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            hideSubMenu();
        }

        #endregion PlayListManagemetSubMenu

        private void btnTools_Click(object sender, EventArgs e)
        {
        }

        #region ToolsSubMenu

        private void button13_Click(object sender, EventArgs e)
        {

            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
       
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
        
            hideSubMenu();
        }

        #endregion ToolsSubMenu

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
      
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
           
        
            hideSubMenu();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            label1.Text = AktifKullanici.kullaniciAdi;
        }
    }
}