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
            this.dgvDemirbaslar.Location = new System.Drawing.Point(159, 306);
            this.dgvDemirbaslar.Name = "dgvDemirbaslar";
            this.dgvDemirbaslar.RowHeadersWidth = 62;
            this.dgvDemirbaslar.RowTemplate.Height = 28;
            this.dgvDemirbaslar.Size = new System.Drawing.Size(1061, 239);
            this.dgvDemirbaslar.TabIndex = 51;
            // 
            // cmbDurum
            // 
            this.cmbDurum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Items.AddRange(new object[] {
            "Stokta",
            "Atanmış",
            "Bakımda",
            "Hurdaya Ayrıldı"});
            this.cmbDurum.Location = new System.Drawing.Point(639, 210);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(146, 28);
            this.cmbDurum.TabIndex = 50;
            // 
            // tbModel
            // 
            this.tbModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbModel.Location = new System.Drawing.Point(639, 160);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(146, 26);
            this.tbModel.TabIndex = 49;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemizle.Location = new System.Drawing.Point(1084, 175);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(152, 67);
            this.btnTemizle.TabIndex = 48;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.Location = new System.Drawing.Point(1084, 105);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(152, 64);
            this.btnSil.TabIndex = 47;
            this.btnSil.Text = "SİL ";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuncelle.Location = new System.Drawing.Point(880, 175);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(187, 67);
            this.btnGuncelle.TabIndex = 46;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEkle.Location = new System.Drawing.Point(880, 105);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(180, 63);
            this.btnEkle.TabIndex = 45;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // tbMarka
            // 
            this.tbMarka.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbMarka.Location = new System.Drawing.Point(639, 104);
            this.tbMarka.Name = "tbMarka";
            this.tbMarka.Size = new System.Drawing.Size(146, 26);
            this.tbMarka.TabIndex = 44;
            // 
            // tbSeriNo
            // 
            this.tbSeriNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSeriNo.Location = new System.Drawing.Point(311, 212);
            this.tbSeriNo.Name = "tbSeriNo";
            this.tbSeriNo.Size = new System.Drawing.Size(146, 26);
            this.tbSeriNo.TabIndex = 43;
            // 
            // tbDemirbasTuru
            // 
            this.tbDemirbasTuru.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDemirbasTuru.Location = new System.Drawing.Point(311, 163);
            this.tbDemirbasTuru.Name = "tbDemirbasTuru";
            this.tbDemirbasTuru.Size = new System.Drawing.Size(146, 26);
            this.tbDemirbasTuru.TabIndex = 42;
            // 
            // tbDemirbasAd
            // 
            this.tbDemirbasAd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDemirbasAd.Location = new System.Drawing.Point(311, 105);
            this.tbDemirbasAd.Name = "tbDemirbasAd";
            this.tbDemirbasAd.Size = new System.Drawing.Size(146, 26);
            this.tbDemirbasAd.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(488, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 26);
            this.label6.TabIndex = 40;
            this.label6.Text = "DURUM : ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(488, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 26);
            this.label5.TabIndex = 39;
            this.label5.Text = "MODEL : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(486, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 26);
            this.label4.TabIndex = 38;
            this.label4.Text = "MARKA : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(122, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 26);
            this.label3.TabIndex = 37;
            this.label3.Text = "Seri Numarası:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(113, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 26);
            this.label2.TabIndex = 36;
            this.label2.Text = "Demirbaş Türü:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(122, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 35;
            this.label1.Text = "Demirbaş Adı:";
            // 
            // FormDemirbaslar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 649);
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