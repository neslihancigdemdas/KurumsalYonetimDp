namespace KurumsalYonetim
{
    partial class FormTeknikServis
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
            this.btnMusteriler = new System.Windows.Forms.Button();
            this.btnNotEkle = new System.Windows.Forms.Button();
            this.btnCihazlar = new System.Windows.Forms.Button();
            this.btnServisKaydi = new System.Windows.Forms.Button();
            this.btnServisListele = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMusteriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteriler.Location = new System.Drawing.Point(96, 85);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new System.Drawing.Size(179, 86);
            this.btnMusteriler.TabIndex = 0;
            this.btnMusteriler.Text = "MÜŞTERİ\r\n";
            this.btnMusteriler.UseVisualStyleBackColor = true;
            this.btnMusteriler.Click += new System.EventHandler(this.btnMusteriler_Click);
            // 
            // btnNotEkle
            // 
            this.btnNotEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNotEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNotEkle.Location = new System.Drawing.Point(917, 85);
            this.btnNotEkle.Name = "btnNotEkle";
            this.btnNotEkle.Size = new System.Drawing.Size(179, 86);
            this.btnNotEkle.TabIndex = 1;
            this.btnNotEkle.Text = "NOT EKLE";
            this.btnNotEkle.UseVisualStyleBackColor = true;
            this.btnNotEkle.Click += new System.EventHandler(this.btnNotEkle_Click);
            // 
            // btnCihazlar
            // 
            this.btnCihazlar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCihazlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCihazlar.Location = new System.Drawing.Point(305, 85);
            this.btnCihazlar.Name = "btnCihazlar";
            this.btnCihazlar.Size = new System.Drawing.Size(179, 86);
            this.btnCihazlar.TabIndex = 2;
            this.btnCihazlar.Text = "CİHAZ";
            this.btnCihazlar.UseVisualStyleBackColor = true;
            this.btnCihazlar.Click += new System.EventHandler(this.btnCihazlar_Click);
            // 
            // btnServisKaydi
            // 
            this.btnServisKaydi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnServisKaydi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnServisKaydi.Location = new System.Drawing.Point(507, 85);
            this.btnServisKaydi.Name = "btnServisKaydi";
            this.btnServisKaydi.Size = new System.Drawing.Size(179, 86);
            this.btnServisKaydi.TabIndex = 3;
            this.btnServisKaydi.Text = "SERVİS KAYDI ";
            this.btnServisKaydi.UseVisualStyleBackColor = true;
            this.btnServisKaydi.Click += new System.EventHandler(this.btnServisKaydi_Click);
            // 
            // btnServisListele
            // 
            this.btnServisListele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnServisListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnServisListele.Location = new System.Drawing.Point(718, 85);
            this.btnServisListele.Name = "btnServisListele";
            this.btnServisListele.Size = new System.Drawing.Size(179, 86);
            this.btnServisListele.TabIndex = 4;
            this.btnServisListele.Text = "SERVİS LİSTELE";
            this.btnServisListele.UseVisualStyleBackColor = true;
            this.btnServisListele.Click += new System.EventHandler(this.btnServisListele_Click);
            // 
            // FormTeknikServis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 531);
            this.Controls.Add(this.btnServisListele);
            this.Controls.Add(this.btnServisKaydi);
            this.Controls.Add(this.btnCihazlar);
            this.Controls.Add(this.btnNotEkle);
            this.Controls.Add(this.btnMusteriler);
            this.Name = "FormTeknikServis";
            this.Text = "FormTeknikServis";
            this.Load += new System.EventHandler(this.FormTeknikServis_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMusteriler;
        private System.Windows.Forms.Button btnNotEkle;
        private System.Windows.Forms.Button btnCihazlar;
        private System.Windows.Forms.Button btnServisKaydi;
        private System.Windows.Forms.Button btnServisListele;
    }
}