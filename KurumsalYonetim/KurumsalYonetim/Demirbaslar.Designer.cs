namespace KurumsalYonetim
{
    partial class FormDemirbaslar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemirbaslar));
            this.dgvDemirbaslar = new System.Windows.Forms.DataGridView();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.tbMarka = new System.Windows.Forms.TextBox();
            this.tbSeriNo = new System.Windows.Forms.TextBox();
            this.tbDemirbasTuru = new System.Windows.Forms.TextBox();
            this.tbDemirbasAd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemirbaslar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDemirbaslar
            // 
            this.dgvDemirbaslar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvDemirbaslar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDemirbaslar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemirbaslar.Location = new System.Drawing.Point(-336, 482);
            this.dgvDemirbaslar.Name = "dgvDemirbaslar";
            this.dgvDemirbaslar.RowHeadersWidth = 62;
            this.dgvDemirbaslar.RowTemplate.Height = 28;
            this.dgvDemirbaslar.Size = new System.Drawing.Size(1740, 239);
            this.dgvDemirbaslar.TabIndex = 51;
            // 
            // cmbDurum
            // 
            this.cmbDurum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Items.AddRange(new object[] {
            "Stokta",
            "Atanmış",
            "Bakımda",
            "Hurdaya Ayrıldı"});
            this.cmbDurum.Location = new System.Drawing.Point(503, 203);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(286, 40);
            this.cmbDurum.TabIndex = 50;
            // 
            // tbModel
            // 
            this.tbModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbModel.Location = new System.Drawing.Point(504, 134);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(286, 39);
            this.tbModel.TabIndex = 49;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTemizle.BackgroundImage")));
            this.btnTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTemizle.Location = new System.Drawing.Point(1122, 235);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(215, 220);
            this.btnTemizle.TabIndex = 48;
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSil.BackgroundImage")));
            this.btnSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSil.Location = new System.Drawing.Point(1122, 26);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(215, 182);
            this.btnSil.TabIndex = 47;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuncelle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.BackgroundImage")));
            this.btnGuncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuncelle.Location = new System.Drawing.Point(845, 235);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(243, 220);
            this.btnGuncelle.TabIndex = 46;
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEkle.BackgroundImage")));
            this.btnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEkle.Location = new System.Drawing.Point(845, 27);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(243, 181);
            this.btnEkle.TabIndex = 45;
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // tbMarka
            // 
            this.tbMarka.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbMarka.Location = new System.Drawing.Point(504, 78);
            this.tbMarka.Name = "tbMarka";
            this.tbMarka.Size = new System.Drawing.Size(286, 39);
            this.tbMarka.TabIndex = 44;
            // 
            // tbSeriNo
            // 
            this.tbSeriNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSeriNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbSeriNo.Location = new System.Drawing.Point(-15, 203);
            this.tbSeriNo.Name = "tbSeriNo";
            this.tbSeriNo.Size = new System.Drawing.Size(233, 39);
            this.tbSeriNo.TabIndex = 43;
            // 
            // tbDemirbasTuru
            // 
            this.tbDemirbasTuru.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDemirbasTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbDemirbasTuru.Location = new System.Drawing.Point(-15, 134);
            this.tbDemirbasTuru.Name = "tbDemirbasTuru";
            this.tbDemirbasTuru.Size = new System.Drawing.Size(233, 39);
            this.tbDemirbasTuru.TabIndex = 42;
            // 
            // tbDemirbasAd
            // 
            this.tbDemirbasAd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDemirbasAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbDemirbasAd.Location = new System.Drawing.Point(-15, 68);
            this.tbDemirbasAd.Name = "tbDemirbasAd";
            this.tbDemirbasAd.Size = new System.Drawing.Size(233, 39);
            this.tbDemirbasAd.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(263, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 55);
            this.label6.TabIndex = 40;
            this.label6.Text = "DURUM : ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(270, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 55);
            this.label5.TabIndex = 39;
            this.label5.Text = "MODEL : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(263, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 55);
            this.label4.TabIndex = 38;
            this.label4.Text = "MARKA : ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(-358, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 55);
            this.label3.TabIndex = 37;
            this.label3.Text = "Seri Numarası:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(-380, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 55);
            this.label2.TabIndex = 36;
            this.label2.Text = "Demirbaş Türü:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(-346, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 55);
            this.label1.TabIndex = 35;
            this.label1.Text = "Demirbaş Adı:";
            // 
            // FormDemirbaslar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1738, 719);
            this.Controls.Add(this.dgvDemirbaslar);
            this.Controls.Add(this.cmbDurum);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.tbMarka);
            this.Controls.Add(this.tbSeriNo);
            this.Controls.Add(this.tbDemirbasTuru);
            this.Controls.Add(this.tbDemirbasAd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDemirbaslar";
            this.Text = "Demirbaslar";
            this.Load += new System.EventHandler(this.FormDemirbaslar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemirbaslar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDemirbaslar;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox tbMarka;
        private System.Windows.Forms.TextBox tbSeriNo;
        private System.Windows.Forms.TextBox tbDemirbasTuru;
        private System.Windows.Forms.TextBox tbDemirbasAd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}