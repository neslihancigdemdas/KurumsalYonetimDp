namespace KurumsalYonetim
{
    partial class FormSecenekler
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSecenekler));
            this.btnTeknikServis = new System.Windows.Forms.Button();
            this.btnDemirbasAtama = new System.Windows.Forms.Button();
            this.btnDemirbaslar = new System.Windows.Forms.Button();
            this.btnCalisanlar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTeknikServis
            // 
            this.btnTeknikServis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTeknikServis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTeknikServis.BackgroundImage")));
            this.btnTeknikServis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTeknikServis.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTeknikServis.Location = new System.Drawing.Point(1033, 141);
            this.btnTeknikServis.Name = "btnTeknikServis";
            this.btnTeknikServis.Size = new System.Drawing.Size(396, 363);
            this.btnTeknikServis.TabIndex = 7;
            this.btnTeknikServis.UseVisualStyleBackColor = true;
            this.btnTeknikServis.Click += new System.EventHandler(this.btnTeknikServis_Click);
            // 
            // btnDemirbasAtama
            // 
            this.btnDemirbasAtama.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDemirbasAtama.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDemirbasAtama.BackgroundImage")));
            this.btnDemirbasAtama.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDemirbasAtama.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDemirbasAtama.Location = new System.Drawing.Point(635, 136);
            this.btnDemirbasAtama.Name = "btnDemirbasAtama";
            this.btnDemirbasAtama.Size = new System.Drawing.Size(368, 368);
            this.btnDemirbasAtama.TabIndex = 6;
            this.btnDemirbasAtama.Text = "  \r\nDEMİBAŞLARI \r\nÇALIŞANLARA \r\n    ATAMA ";
            this.btnDemirbasAtama.UseVisualStyleBackColor = true;
            this.btnDemirbasAtama.Click += new System.EventHandler(this.btnDemirbasAtama_Click);
            // 
            // btnDemirbaslar
            // 
            this.btnDemirbaslar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDemirbaslar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDemirbaslar.BackgroundImage")));
            this.btnDemirbaslar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDemirbaslar.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDemirbaslar.Location = new System.Drawing.Point(209, 133);
            this.btnDemirbaslar.Name = "btnDemirbaslar";
            this.btnDemirbaslar.Size = new System.Drawing.Size(406, 371);
            this.btnDemirbaslar.TabIndex = 5;
            this.btnDemirbaslar.Text = "DEMİRBAŞLAR ";
            this.btnDemirbaslar.UseVisualStyleBackColor = true;
            this.btnDemirbaslar.Click += new System.EventHandler(this.btnDemirbaslar_Click);
            // 
            // btnCalisanlar
            // 
            this.btnCalisanlar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCalisanlar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalisanlar.BackgroundImage")));
            this.btnCalisanlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalisanlar.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCalisanlar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCalisanlar.Location = new System.Drawing.Point(-206, 127);
            this.btnCalisanlar.Name = "btnCalisanlar";
            this.btnCalisanlar.Size = new System.Drawing.Size(388, 377);
            this.btnCalisanlar.TabIndex = 4;
            this.btnCalisanlar.UseVisualStyleBackColor = true;
            this.btnCalisanlar.Click += new System.EventHandler(this.btnCalisanlar_Click);
            // 
            // FormSecenekler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1772, 711);
            this.Controls.Add(this.btnTeknikServis);
            this.Controls.Add(this.btnDemirbasAtama);
            this.Controls.Add(this.btnDemirbaslar);
            this.Controls.Add(this.btnCalisanlar);
            this.Name = "FormSecenekler";
            this.Text = "SEÇENEKLER";
            this.Load += new System.EventHandler(this.FormSecenekler_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTeknikServis;
        private System.Windows.Forms.Button btnDemirbasAtama;
        private System.Windows.Forms.Button btnDemirbaslar;
        private System.Windows.Forms.Button btnCalisanlar;
    }
}

