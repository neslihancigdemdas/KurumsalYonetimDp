namespace KurumsalYonetim
{
    partial class SetPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPasswordForm));
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblYeniSifre = new System.Windows.Forms.Label();
            this.tbUsernameOrEmail = new System.Windows.Forms.TextBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.lbyenisifretekrar = new System.Windows.Forms.Label();
            this.btnRequestReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(198, 447);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 52);
            this.lblMessage.TabIndex = 0;
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciAdi.Location = new System.Drawing.Point(156, 204);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(237, 40);
            this.lblKullaniciAdi.TabIndex = 1;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblYeniSifre
            // 
            this.lblYeniSifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYeniSifre.AutoSize = true;
            this.lblYeniSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYeniSifre.Location = new System.Drawing.Point(200, 273);
            this.lblYeniSifre.Name = "lblYeniSifre";
            this.lblYeniSifre.Size = new System.Drawing.Size(193, 40);
            this.lblYeniSifre.TabIndex = 2;
            this.lblYeniSifre.Text = "Yeni Şifre:";
            // 
            // tbUsernameOrEmail
            // 
            this.tbUsernameOrEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbUsernameOrEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbUsernameOrEmail.Location = new System.Drawing.Point(458, 208);
            this.tbUsernameOrEmail.Name = "tbUsernameOrEmail";
            this.tbUsernameOrEmail.Size = new System.Drawing.Size(608, 39);
            this.tbUsernameOrEmail.TabIndex = 3;
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbNewPassword.Location = new System.Drawing.Point(458, 273);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(608, 39);
            this.tbNewPassword.TabIndex = 4;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(458, 342);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(608, 39);
            this.tbConfirmPassword.TabIndex = 6;
            // 
            // lbyenisifretekrar
            // 
            this.lbyenisifretekrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbyenisifretekrar.AutoSize = true;
            this.lbyenisifretekrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbyenisifretekrar.Location = new System.Drawing.Point(79, 342);
            this.lbyenisifretekrar.Name = "lbyenisifretekrar";
            this.lbyenisifretekrar.Size = new System.Drawing.Size(314, 40);
            this.lbyenisifretekrar.TabIndex = 5;
            this.lbyenisifretekrar.Text = "Yeni Şifre Tekrar:";
            // 
            // btnRequestReset
            // 
            this.btnRequestReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRequestReset.BackColor = System.Drawing.Color.Silver;
            this.btnRequestReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRequestReset.BackgroundImage")));
            this.btnRequestReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRequestReset.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRequestReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRequestReset.Location = new System.Drawing.Point(1203, 102);
            this.btnRequestReset.Name = "btnRequestReset";
            this.btnRequestReset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRequestReset.Size = new System.Drawing.Size(312, 359);
            this.btnRequestReset.TabIndex = 7;
            this.btnRequestReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRequestReset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnRequestReset.UseVisualStyleBackColor = false;
            this.btnRequestReset.Click += new System.EventHandler(this.btnRequestReset_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(565, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 64);
            this.label1.TabIndex = 8;
            this.label1.Text = "ŞİFRE YENİLEME ";
            // 
            // SetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1748, 706);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRequestReset);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lbyenisifretekrar);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.tbUsernameOrEmail);
            this.Controls.Add(this.lblYeniSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.lblMessage);
            this.Name = "SetPasswordForm";
            this.Text = "ŞİFRE SIFIRLAMA";
            this.Load += new System.EventHandler(this.SetPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblYeniSifre;
        private System.Windows.Forms.TextBox tbUsernameOrEmail;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lbyenisifretekrar;
        private System.Windows.Forms.Button btnRequestReset;
        private System.Windows.Forms.Label label1;
    }
}