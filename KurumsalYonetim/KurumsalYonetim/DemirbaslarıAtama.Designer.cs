namespace KurumsalYonetim
{
    partial class FormDemirbaslarıAtama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemirbaslarıAtama));
            this.dgvAtamalar = new System.Windows.Forms.DataGridView();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnTeslimEt = new System.Windows.Forms.Button();
            this.btnAta = new System.Windows.Forms.Button();
            this.dtpTeslimtarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpAtamatarih = new System.Windows.Forms.DateTimePicker();
            this.cmbdemirbassec = new System.Windows.Forms.ComboBox();
            this.cmbcalisansec = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtamalar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAtamalar
            // 
            this.dgvAtamalar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvAtamalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAtamalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtamalar.Location = new System.Drawing.Point(-169, 399);
            this.dgvAtamalar.Name = "dgvAtamalar";
            this.dgvAtamalar.RowHeadersWidth = 62;
            this.dgvAtamalar.RowTemplate.Height = 28;
            this.dgvAtamalar.Size = new System.Drawing.Size(1854, 296);
            this.dgvAtamalar.TabIndex = 30;
            this.dgvAtamalar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAtamalar_CellContentClick);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSil.BackgroundImage")));
            this.btnSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSil.Location = new System.Drawing.Point(809, 201);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(209, 177);
            this.btnSil.TabIndex = 29;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTemizle.BackgroundImage")));
            this.btnTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTemizle.Location = new System.Drawing.Point(1037, 201);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(219, 177);
            this.btnTemizle.TabIndex = 28;
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnTeslimEt
            // 
            this.btnTeslimEt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTeslimEt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTeslimEt.BackgroundImage")));
            this.btnTeslimEt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTeslimEt.Location = new System.Drawing.Point(1112, 19);
            this.btnTeslimEt.Name = "btnTeslimEt";
            this.btnTeslimEt.Size = new System.Drawing.Size(211, 171);
            this.btnTeslimEt.TabIndex = 27;
            this.btnTeslimEt.UseVisualStyleBackColor = true;
            this.btnTeslimEt.Click += new System.EventHandler(this.btnTeslimEt_Click);
            // 
            // btnAta
            // 
            this.btnAta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAta.BackgroundImage")));
            this.btnAta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAta.Location = new System.Drawing.Point(706, 15);
            this.btnAta.Name = "btnAta";
            this.btnAta.Size = new System.Drawing.Size(210, 175);
            this.btnAta.TabIndex = 26;
            this.btnAta.UseVisualStyleBackColor = true;
            this.btnAta.Click += new System.EventHandler(this.btnAta_Click);
            // 
            // dtpTeslimtarihi
            // 
            this.dtpTeslimtarihi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTeslimtarihi.Checked = false;
            this.dtpTeslimtarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTeslimtarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTeslimtarihi.Location = new System.Drawing.Point(240, 201);
            this.dtpTeslimtarihi.Name = "dtpTeslimtarihi";
            this.dtpTeslimtarihi.ShowCheckBox = true;
            this.dtpTeslimtarihi.Size = new System.Drawing.Size(353, 39);
            this.dtpTeslimtarihi.TabIndex = 25;
            // 
            // dtpAtamatarih
            // 
            this.dtpAtamatarih.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpAtamatarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpAtamatarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAtamatarih.Location = new System.Drawing.Point(240, 139);
            this.dtpAtamatarih.Name = "dtpAtamatarih";
            this.dtpAtamatarih.Size = new System.Drawing.Size(353, 39);
            this.dtpAtamatarih.TabIndex = 24;
            // 
            // cmbdemirbassec
            // 
            this.cmbdemirbassec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbdemirbassec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdemirbassec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbdemirbassec.FormattingEnabled = true;
            this.cmbdemirbassec.Location = new System.Drawing.Point(240, 82);
            this.cmbdemirbassec.Name = "cmbdemirbassec";
            this.cmbdemirbassec.Size = new System.Drawing.Size(353, 40);
            this.cmbdemirbassec.TabIndex = 23;
            // 
            // cmbcalisansec
            // 
            this.cmbcalisansec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbcalisansec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcalisansec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbcalisansec.FormattingEnabled = true;
            this.cmbcalisansec.Location = new System.Drawing.Point(240, 31);
            this.cmbcalisansec.Name = "cmbcalisansec";
            this.cmbcalisansec.Size = new System.Drawing.Size(353, 40);
            this.cmbcalisansec.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(-225, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(435, 55);
            this.label6.TabIndex = 21;
            this.label6.Text = "TESLİM TARİHİ : ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(-210, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(407, 55);
            this.label3.TabIndex = 20;
            this.label3.Text = "ATAMA TARİHİ :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(-222, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 55);
            this.label2.TabIndex = 19;
            this.label2.Text = "DEMİRBAŞ SEÇ :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(-178, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 55);
            this.label1.TabIndex = 18;
            this.label1.Text = "ÇALIŞAN SEÇ : ";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuncelle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.BackgroundImage")));
            this.btnGuncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuncelle.Location = new System.Drawing.Point(922, 14);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(184, 176);
            this.btnGuncelle.TabIndex = 31;
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // FormDemirbaslarıAtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1748, 693);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.dgvAtamalar);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnTeslimEt);
            this.Controls.Add(this.btnAta);
            this.Controls.Add(this.dtpTeslimtarihi);
            this.Controls.Add(this.dtpAtamatarih);
            this.Controls.Add(this.cmbdemirbassec);
            this.Controls.Add(this.cmbcalisansec);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDemirbaslarıAtama";
            this.Text = "DemirbaslarıAtama";
            this.Load += new System.EventHandler(this.FormDemirbaslarıAtama_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtamalar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAtamalar;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnTeslimEt;
        private System.Windows.Forms.Button btnAta;
        private System.Windows.Forms.DateTimePicker dtpTeslimtarihi;
        private System.Windows.Forms.DateTimePicker dtpAtamatarih;
        private System.Windows.Forms.ComboBox cmbdemirbassec;
        private System.Windows.Forms.ComboBox cmbcalisansec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuncelle;
    }
}