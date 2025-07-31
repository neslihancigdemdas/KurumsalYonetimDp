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
            this.btnTeknikServis = new System.Windows.Forms.Button();
            this.btnDemirbasAtama = new System.Windows.Forms.Button();
            this.btnDemirbaslar = new System.Windows.Forms.Button();
            this.btnCalisanlar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTeknikServis
            // 
            this.btnTeknikServis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTeknikServis.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTeknikServis.Location = new System.Drawing.Point(96, 431);
            this.btnTeknikServis.Name = "btnTeknikServis";
            this.btnTeknikServis.Size = new System.Drawing.Size(1055, 159);
            this.btnTeknikServis.TabIndex = 7;
            this.btnTeknikServis.Text = "TEKNİK SERVİS TAKİP";
            this.btnTeknikServis.UseVisualStyleBackColor = true;
            this.btnTeknikServis.Click += new System.EventHandler(this.btnTeknikServis_Click);
            // 
            // btnDemirbasAtama
            // 
            this.btnDemirbasAtama.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDemirbasAtama.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDemirbasAtama.Location = new System.Drawing.Point(841, 40);
            this.btnDemirbasAtama.Name = "btnDemirbasAtama";
            this.btnDemirbasAtama.Size = new System.Drawing.Size(345, 341);
            this.btnDemirbasAtama.TabIndex = 6;
            this.btnDemirbasAtama.Text = "DEMİBAŞLARI ÇALIŞANLARA ATAMA ";
            this.btnDemirbasAtama.UseVisualStyleBackColor = true;
            this.btnDemirbasAtama.Click += new System.EventHandler(this.btnDemirbasAtama_Click);
            // 
            // btnDemirbaslar
            // 
            this.btnDemirbaslar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDemirbaslar.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDemirbaslar.Location = new System.Drawing.Point(418, 40);
            this.btnDemirbaslar.Name = "btnDemirbaslar";
            this.btnDemirbaslar.Size = new System.Drawing.Size(378, 341);
            this.btnDemirbaslar.TabIndex = 5;
            this.btnDemirbaslar.Text = "DEMİRBAŞLAR ";
            this.btnDemirbaslar.UseVisualStyleBackColor = true;
            this.btnDemirbaslar.Click += new System.EventHandler(this.btnDemirbaslar_Click);
            // 
            // btnCalisanlar
            // 
            this.btnCalisanlar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCalisanlar.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCalisanlar.Location = new System.Drawing.Point(60, 40);
            this.btnCalisanlar.Name = "btnCalisanlar";
            this.btnCalisanlar.Size = new System.Drawing.Size(319, 341);
            this.btnCalisanlar.TabIndex = 4;
            this.btnCalisanlar.Text = "ÇALIŞANLAR ";
            this.btnCalisanlar.UseVisualStyleBackColor = true;
            this.btnCalisanlar.Click += new System.EventHandler(this.btnCalisanlar_Click);
            // 
            // FormSecenekler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 625);
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

