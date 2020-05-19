namespace StorkFlix
{
    partial class Giris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.panelGiris = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelSifreHata = new System.Windows.Forms.Label();
            this.labelMailHata = new System.Windows.Forms.Label();
            this.labelKayitOl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxPassword = new AnimaTextBox();
            this.btnGiris = new AnimaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxMail = new AnimaTextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panelKayit = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textboxKayitSifreTekrar = new AnimaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textboxKayitDogumTarihi = new AnimaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textboxKayitSifre = new AnimaTextBox();
            this.labelGirisYap = new System.Windows.Forms.Label();
            this.btnKayitOl = new AnimaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxKayitMail = new AnimaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textboxKayitAd = new AnimaTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panelKayit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGiris
            // 
            this.panelGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelGiris.Controls.Add(this.pictureBox9);
            this.panelGiris.Controls.Add(this.pictureBox2);
            this.panelGiris.Controls.Add(this.labelSifreHata);
            this.panelGiris.Controls.Add(this.labelMailHata);
            this.panelGiris.Controls.Add(this.labelKayitOl);
            this.panelGiris.Controls.Add(this.label2);
            this.panelGiris.Controls.Add(this.textboxPassword);
            this.panelGiris.Controls.Add(this.btnGiris);
            this.panelGiris.Controls.Add(this.label1);
            this.panelGiris.Controls.Add(this.textboxMail);
            this.panelGiris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGiris.Location = new System.Drawing.Point(0, 0);
            this.panelGiris.Name = "panelGiris";
            this.panelGiris.Size = new System.Drawing.Size(384, 588);
            this.panelGiris.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 230);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(369, 340);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // labelSifreHata
            // 
            this.labelSifreHata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSifreHata.AutoSize = true;
            this.labelSifreHata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelSifreHata.ForeColor = System.Drawing.Color.Crimson;
            this.labelSifreHata.Location = new System.Drawing.Point(147, 478);
            this.labelSifreHata.Name = "labelSifreHata";
            this.labelSifreHata.Size = new System.Drawing.Size(91, 17);
            this.labelSifreHata.TabIndex = 23;
            this.labelSifreHata.Text = "Şifre Yanlış";
            this.labelSifreHata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSifreHata.Visible = false;
            // 
            // labelMailHata
            // 
            this.labelMailHata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMailHata.AutoSize = true;
            this.labelMailHata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMailHata.ForeColor = System.Drawing.Color.Crimson;
            this.labelMailHata.Location = new System.Drawing.Point(61, 478);
            this.labelMailHata.Name = "labelMailHata";
            this.labelMailHata.Size = new System.Drawing.Size(263, 17);
            this.labelMailHata.TabIndex = 22;
            this.labelMailHata.Text = "Bu isimde kayıtlı bir mail adresi yok";
            this.labelMailHata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMailHata.Visible = false;
            // 
            // labelKayitOl
            // 
            this.labelKayitOl.AutoSize = true;
            this.labelKayitOl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelKayitOl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKayitOl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.labelKayitOl.Location = new System.Drawing.Point(167, 557);
            this.labelKayitOl.Name = "labelKayitOl";
            this.labelKayitOl.Size = new System.Drawing.Size(51, 13);
            this.labelKayitOl.TabIndex = 20;
            this.labelKayitOl.Text = "Kayıt Ol";
            this.labelKayitOl.Click += new System.EventHandler(this.LabelKayitOl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label2.Location = new System.Drawing.Point(82, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Şifre";
            // 
            // textboxPassword
            // 
            this.textboxPassword.Dark = false;
            this.textboxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxPassword.Location = new System.Drawing.Point(79, 399);
            this.textboxPassword.MaxLength = 32767;
            this.textboxPassword.MultiLine = false;
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.Numeric = false;
            this.textboxPassword.ReadOnly = false;
            this.textboxPassword.Size = new System.Drawing.Size(226, 34);
            this.textboxPassword.TabIndex = 2;
            this.textboxPassword.UseSystemPasswordChar = true;
            // 
            // btnGiris
            // 
            this.btnGiris.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnGiris.ImageLocation = new System.Drawing.Point(30, 6);
            this.btnGiris.ImageSize = new System.Drawing.Size(14, 14);
            this.btnGiris.Location = new System.Drawing.Point(110, 502);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(165, 39);
            this.btnGiris.TabIndex = 3;
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(82, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "E-Posta";
            // 
            // textboxMail
            // 
            this.textboxMail.Dark = false;
            this.textboxMail.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxMail.Location = new System.Drawing.Point(79, 320);
            this.textboxMail.MaxLength = 32767;
            this.textboxMail.MultiLine = false;
            this.textboxMail.Name = "textboxMail";
            this.textboxMail.Numeric = false;
            this.textboxMail.ReadOnly = false;
            this.textboxMail.Size = new System.Drawing.Size(226, 34);
            this.textboxMail.TabIndex = 1;
            this.textboxMail.UseSystemPasswordChar = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(79, 34);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(226, 218);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 2;
            this.pictureBox9.TabStop = false;
            // 
            // panelKayit
            // 
            this.panelKayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelKayit.Controls.Add(this.label5);
            this.panelKayit.Controls.Add(this.label8);
            this.panelKayit.Controls.Add(this.textboxKayitSifreTekrar);
            this.panelKayit.Controls.Add(this.label6);
            this.panelKayit.Controls.Add(this.textboxKayitDogumTarihi);
            this.panelKayit.Controls.Add(this.label7);
            this.panelKayit.Controls.Add(this.textboxKayitSifre);
            this.panelKayit.Controls.Add(this.labelGirisYap);
            this.panelKayit.Controls.Add(this.btnKayitOl);
            this.panelKayit.Controls.Add(this.label3);
            this.panelKayit.Controls.Add(this.textboxKayitMail);
            this.panelKayit.Controls.Add(this.label4);
            this.panelKayit.Controls.Add(this.textboxKayitAd);
            this.panelKayit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKayit.Location = new System.Drawing.Point(0, 0);
            this.panelKayit.Name = "panelKayit";
            this.panelKayit.Size = new System.Drawing.Size(384, 588);
            this.panelKayit.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label5.Location = new System.Drawing.Point(161, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 29);
            this.label5.TabIndex = 32;
            this.label5.Text = "Kayıt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label8.Location = new System.Drawing.Point(87, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "Şifre Tekrar";
            // 
            // textboxKayitSifreTekrar
            // 
            this.textboxKayitSifreTekrar.Dark = false;
            this.textboxKayitSifreTekrar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxKayitSifreTekrar.Location = new System.Drawing.Point(79, 333);
            this.textboxKayitSifreTekrar.MaxLength = 32767;
            this.textboxKayitSifreTekrar.MultiLine = false;
            this.textboxKayitSifreTekrar.Name = "textboxKayitSifreTekrar";
            this.textboxKayitSifreTekrar.Numeric = false;
            this.textboxKayitSifreTekrar.ReadOnly = false;
            this.textboxKayitSifreTekrar.Size = new System.Drawing.Size(226, 34);
            this.textboxKayitSifreTekrar.TabIndex = 4;
            this.textboxKayitSifreTekrar.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label6.Location = new System.Drawing.Point(85, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "Doğum Tarihi";
            // 
            // textboxKayitDogumTarihi
            // 
            this.textboxKayitDogumTarihi.Dark = false;
            this.textboxKayitDogumTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxKayitDogumTarihi.Location = new System.Drawing.Point(79, 411);
            this.textboxKayitDogumTarihi.MaxLength = 32767;
            this.textboxKayitDogumTarihi.MultiLine = false;
            this.textboxKayitDogumTarihi.Name = "textboxKayitDogumTarihi";
            this.textboxKayitDogumTarihi.Numeric = false;
            this.textboxKayitDogumTarihi.ReadOnly = false;
            this.textboxKayitDogumTarihi.Size = new System.Drawing.Size(226, 34);
            this.textboxKayitDogumTarihi.TabIndex = 5;
            this.textboxKayitDogumTarihi.UseSystemPasswordChar = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label7.Location = new System.Drawing.Point(87, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 18);
            this.label7.TabIndex = 28;
            this.label7.Text = "Şire";
            // 
            // textboxKayitSifre
            // 
            this.textboxKayitSifre.Dark = false;
            this.textboxKayitSifre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxKayitSifre.Location = new System.Drawing.Point(79, 255);
            this.textboxKayitSifre.MaxLength = 32767;
            this.textboxKayitSifre.MultiLine = false;
            this.textboxKayitSifre.Name = "textboxKayitSifre";
            this.textboxKayitSifre.Numeric = false;
            this.textboxKayitSifre.ReadOnly = false;
            this.textboxKayitSifre.Size = new System.Drawing.Size(226, 34);
            this.textboxKayitSifre.TabIndex = 3;
            this.textboxKayitSifre.UseSystemPasswordChar = false;
            // 
            // labelGirisYap
            // 
            this.labelGirisYap.AutoSize = true;
            this.labelGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGirisYap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.labelGirisYap.Location = new System.Drawing.Point(163, 552);
            this.labelGirisYap.Name = "labelGirisYap";
            this.labelGirisYap.Size = new System.Drawing.Size(58, 13);
            this.labelGirisYap.TabIndex = 25;
            this.labelGirisYap.Text = "Giriş Yap";
            this.labelGirisYap.Click += new System.EventHandler(this.LabelGirisYap_Click);
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitOl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnKayitOl.ImageLocation = new System.Drawing.Point(30, 6);
            this.btnKayitOl.ImageSize = new System.Drawing.Size(14, 14);
            this.btnKayitOl.Location = new System.Drawing.Point(110, 495);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(165, 39);
            this.btnKayitOl.TabIndex = 6;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.UseVisualStyleBackColor = true;
            this.btnKayitOl.Click += new System.EventHandler(this.BtnKayitOl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(85, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "E-Posta";
            // 
            // textboxKayitMail
            // 
            this.textboxKayitMail.Dark = false;
            this.textboxKayitMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxKayitMail.Location = new System.Drawing.Point(79, 177);
            this.textboxKayitMail.MaxLength = 32767;
            this.textboxKayitMail.MultiLine = false;
            this.textboxKayitMail.Name = "textboxKayitMail";
            this.textboxKayitMail.Numeric = false;
            this.textboxKayitMail.ReadOnly = false;
            this.textboxKayitMail.Size = new System.Drawing.Size(226, 34);
            this.textboxKayitMail.TabIndex = 2;
            this.textboxKayitMail.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(87, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "İsim";
            // 
            // textboxKayitAd
            // 
            this.textboxKayitAd.Dark = false;
            this.textboxKayitAd.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textboxKayitAd.Location = new System.Drawing.Point(79, 99);
            this.textboxKayitAd.MaxLength = 32767;
            this.textboxKayitAd.MultiLine = false;
            this.textboxKayitAd.Name = "textboxKayitAd";
            this.textboxKayitAd.Numeric = false;
            this.textboxKayitAd.ReadOnly = false;
            this.textboxKayitAd.Size = new System.Drawing.Size(226, 34);
            this.textboxKayitAd.TabIndex = 1;
            this.textboxKayitAd.UseSystemPasswordChar = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(384, 588);
            this.Controls.Add(this.panelGiris);
            this.Controls.Add(this.panelKayit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stork Flix";
            this.panelGiris.ResumeLayout(false);
            this.panelGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panelKayit.ResumeLayout(false);
            this.panelKayit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGiris;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Panel panelKayit;
        private System.Windows.Forms.Label label2;
        private AnimaTextBox textboxPassword;
        private AnimaButton btnGiris;
        private System.Windows.Forms.Label label1;
        private AnimaTextBox textboxMail;
        private System.Windows.Forms.Label labelKayitOl;
        private System.Windows.Forms.Label labelGirisYap;
        private AnimaButton btnKayitOl;
        private System.Windows.Forms.Label label3;
        private AnimaTextBox textboxKayitMail;
        private System.Windows.Forms.Label label4;
        private AnimaTextBox textboxKayitAd;
        private System.Windows.Forms.Label label8;
        private AnimaTextBox textboxKayitSifreTekrar;
        private System.Windows.Forms.Label label6;
        private AnimaTextBox textboxKayitDogumTarihi;
        private System.Windows.Forms.Label label7;
        private AnimaTextBox textboxKayitSifre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelMailHata;
        private System.Windows.Forms.Label labelSifreHata;
    }
}

