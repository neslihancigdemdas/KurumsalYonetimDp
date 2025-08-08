namespace KurumsalYonetim
{
    partial class formServisIslem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formServisIslem));
            this.dataGridViewIslemler = new System.Windows.Forms.DataGridView();
            this.cmbServisKayit = new System.Windows.Forms.ComboBox();
            this.txtYapilanIslem = new System.Windows.Forms.RichTextBox();
            this.txtUcret = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lblHataMesaji = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIslemler)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewIslemler
            // 
            this.dataGridViewIslemler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewIslemler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIslemler.Location = new System.Drawing.Point(-223, 477);
            this.dataGridViewIslemler.Name = "dataGridViewIslemler";
            this.dataGridViewIslemler.RowHeadersWidth = 62;
            this.dataGridViewIslemler.RowTemplate.Height = 28;
            this.dataGridViewIslemler.Size = new System.Drawing.Size(1694, 274);
            this.dataGridViewIslemler.TabIndex = 56;
            this.dataGridViewIslemler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIslemler_CellClick);
            // 
            // cmbServisKayit
            // 
            this.cmbServisKayit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbServisKayit.FormattingEnabled = true;
            this.cmbServisKayit.Location = new System.Drawing.Point(247, 116);
            this.cmbServisKayit.Name = "cmbServisKayit";
            this.cmbServisKayit.Size = new System.Drawing.Size(409, 28);
            this.cmbServisKayit.TabIndex = 57;
            // 
            // txtYapilanIslem
            // 
            this.txtYapilanIslem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtYapilanIslem.Location = new System.Drawing.Point(247, 163);
            this.txtYapilanIslem.Name = "txtYapilanIslem";
            this.txtYapilanIslem.Size = new System.Drawing.Size(409, 96);
            this.txtYapilanIslem.TabIndex = 58;
            this.txtYapilanIslem.Text = "";
            // 
            // txtUcret
            // 
            this.txtUcret.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUcret.Location = new System.Drawing.Point(247, 273);
            this.txtUcret.Name = "txtUcret";
            this.txtUcret.Size = new System.Drawing.Size(409, 26);
            this.txtUcret.TabIndex = 59;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTarih.Location = new System.Drawing.Point(247, 316);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(409, 26);
            this.dtpTarih.TabIndex = 60;
            // 
            // lblHataMesaji
            // 
            this.lblHataMesaji.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHataMesaji.AutoSize = true;
            this.lblHataMesaji.Location = new System.Drawing.Point(116, 371);
            this.lblHataMesaji.Name = "lblHataMesaji";
            this.lblHataMesaji.Size = new System.Drawing.Size(0, 20);
            this.lblHataMesaji.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(-95, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 29);
            this.label1.TabIndex = 62;
            this.label1.Text = "SERVİS KAYIT :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(-109, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 29);
            this.label2.TabIndex = 63;
            this.label2.Text = "YAPILAN İŞLEM : ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(-10, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 29);
            this.label3.TabIndex = 64;
            this.label3.Text = "ÜCRET :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(11, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 29);
            this.label4.TabIndex = 65;
            this.label4.Text = "TARİH :";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTemizle.BackgroundImage")));
            this.btnTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTemizle.Location = new System.Drawing.Point(1158, 229);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(215, 220);
            this.btnTemizle.TabIndex = 69;
            this.btnTemizle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSil.BackgroundImage")));
            this.btnSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSil.Location = new System.Drawing.Point(1158, 20);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(215, 182);
            this.btnSil.TabIndex = 68;
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuncelle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.BackgroundImage")));
            this.btnGuncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuncelle.Location = new System.Drawing.Point(881, 229);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(243, 220);
            this.btnGuncelle.TabIndex = 67;
            this.btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEkle.BackgroundImage")));
            this.btnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEkle.Location = new System.Drawing.Point(881, 21);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(243, 181);
            this.btnEkle.TabIndex = 66;
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // formServisIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 732);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHataMesaji);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.txtUcret);
            this.Controls.Add(this.txtYapilanIslem);
            this.Controls.Add(this.cmbServisKayit);
            this.Controls.Add(this.dataGridViewIslemler);
            this.Name = "formServisIslem";
            this.Text = "formServisİslem";
            this.Load += new System.EventHandler(this.formServisIslem_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIslemler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewIslemler;
        private System.Windows.Forms.ComboBox cmbServisKayit;
        private System.Windows.Forms.RichTextBox txtYapilanIslem;
        private System.Windows.Forms.TextBox txtUcret;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblHataMesaji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
    }
}