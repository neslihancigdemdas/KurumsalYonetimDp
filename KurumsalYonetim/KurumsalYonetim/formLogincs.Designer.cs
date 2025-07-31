namespace KurumsalYonetim
{
    partial class formLogincs
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
            this.btSifreYenileme = new System.Windows.Forms.Button();
            this.tbSifre = new System.Windows.Forms.TextBox();
            this.tbKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.btnHesapOlusturma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSifreYenileme
            // 
            this.btSifreYenileme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSifreYenileme.Location = new System.Drawing.Point(477, 198);
            this.btSifreYenileme.Name = "btSifreYenileme";
            this.btSifreYenileme.Size = new System.Drawing.Size(277, 240);
            this.btSifreYenileme.TabIndex = 16;
            this.btSifreYenileme.Text = "ŞİFRE YENİLEME";
            this.btSifreYenileme.UseVisualStyleBackColor = true;
            this.btSifreYenileme.Click += new System.EventHandler(this.btSifreYenileme_Click);
            // 
            // tbSifre
            // 
            this.tbSifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSifre.Location = new System.Drawing.Point(205, 78);
            this.tbSifre.Name = "tbSifre";
            this.tbSifre.Size = new System.Drawing.Size(160, 26);
            this.tbSifre.TabIndex = 15;
            // 
            // tbKullaniciAdi
            // 
            this.tbKullaniciAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbKullaniciAdi.Location = new System.Drawing.Point(205, 27);
            this.tbKullaniciAdi.Name = "tbKullaniciAdi";
            this.tbKullaniciAdi.Size = new System.Drawing.Size(160, 26);
            this.tbKullaniciAdi.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 78);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 5, 3, 1);
            this.label2.Size = new System.Drawing.Size(79, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "ŞİFRE :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 5, 3, 1);
            this.label1.Size = new System.Drawing.Size(145, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "KULLANICI ADI :";
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGirisYap.Location = new System.Drawing.Point(103, 124);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(194, 82);
            this.btnGirisYap.TabIndex = 11;
            this.btnGirisYap.Text = "GİRİŞ YAP";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // btnHesapOlusturma
            // 
            this.btnHesapOlusturma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHesapOlusturma.Location = new System.Drawing.Point(477, 12);
            this.btnHesapOlusturma.Name = "btnHesapOlusturma";
            this.btnHesapOlusturma.Size = new System.Drawing.Size(277, 160);
            this.btnHesapOlusturma.TabIndex = 17;
            this.btnHesapOlusturma.Text = "HESAP OLUŞTURMA";
            this.btnHesapOlusturma.UseVisualStyleBackColor = true;
            this.btnHesapOlusturma.Click += new System.EventHandler(this.btnHesapOlusturma_Click);
            // 
            // formLogincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHesapOlusturma);
            this.Controls.Add(this.btSifreYenileme);
            this.Controls.Add(this.tbSifre);
            this.Controls.Add(this.tbKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGirisYap);
            this.Name = "formLogincs";
            this.Text = "formLogincs";
            this.Load += new System.EventHandler(this.formLogincs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSifreYenileme;
        private System.Windows.Forms.TextBox tbSifre;
        private System.Windows.Forms.TextBox tbKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.Button btnHesapOlusturma;
    }
}