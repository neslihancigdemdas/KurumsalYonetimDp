using System;

namespace KurumsalYonetim
{
    partial class formCihaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCihaz));
            this.cmbMusteriSec = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMarka = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbSeriNumarası = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbaciklama = new System.Windows.Forms.RichTextBox();
            this.dgvCihaz = new System.Windows.Forms.DataGridView();
            this.rbtngarantivar = new System.Windows.Forms.RadioButton();
            this.rbtngarantiyok = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.lbKayitTarihi = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCihaz)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMusteriSec
            // 
            this.cmbMusteriSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbMusteriSec.FormattingEnabled = true;
            this.cmbMusteriSec.Location = new System.Drawing.Point(356, 44);
            this.cmbMusteriSec.Name = "cmbMusteriSec";
            this.cmbMusteriSec.Size = new System.Drawing.Size(293, 34);
            this.cmbMusteriSec.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(-35, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "MÜŞTERİ SEÇ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(73, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "MARKA :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(967, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "AÇIKLAMA :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(831, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "GARANTİ DURUMU :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(73, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "MODEL :";
            // 
            // tbMarka
            // 
            this.tbMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbMarka.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbMarka.Location = new System.Drawing.Point(356, 97);
            this.tbMarka.Name = "tbMarka";
            this.tbMarka.Size = new System.Drawing.Size(293, 32);
            this.tbMarka.TabIndex = 5;
            // 
            // tbModel
            // 
            this.tbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbModel.Location = new System.Drawing.Point(356, 153);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(293, 32);
            this.tbModel.TabIndex = 6;
            // 
            // tbSeriNumarası
            // 
            this.tbSeriNumarası.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbSeriNumarası.Location = new System.Drawing.Point(356, 207);
            this.tbSeriNumarası.Name = "tbSeriNumarası";
            this.tbSeriNumarası.Size = new System.Drawing.Size(293, 32);
            this.tbSeriNumarası.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(-71, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(299, 37);
            this.label6.TabIndex = 8;
            this.label6.Text = "SERİ NUMARASI :";
            // 
            // rtbaciklama
            // 
            this.rtbaciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rtbaciklama.Location = new System.Drawing.Point(1214, 164);
            this.rtbaciklama.Name = "rtbaciklama";
            this.rtbaciklama.Size = new System.Drawing.Size(410, 164);
            this.rtbaciklama.TabIndex = 10;
            this.rtbaciklama.Text = "";
            // 
            // dgvCihaz
            // 
            this.dgvCihaz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCihaz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCihaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCihaz.Location = new System.Drawing.Point(-28, 643);
            this.dgvCihaz.Name = "dgvCihaz";
            this.dgvCihaz.RowHeadersWidth = 62;
            this.dgvCihaz.RowTemplate.Height = 28;
            this.dgvCihaz.Size = new System.Drawing.Size(1587, 265);
            this.dgvCihaz.TabIndex = 56;
            this.dgvCihaz.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCihaz_SelectionChanged);
            // 
            // rbtngarantivar
            // 
            this.rbtngarantivar.AutoSize = true;
            this.rbtngarantivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtngarantivar.Location = new System.Drawing.Point(1214, 20);
            this.rbtngarantivar.Name = "rbtngarantivar";
            this.rbtngarantivar.Size = new System.Drawing.Size(207, 33);
            this.rbtngarantivar.TabIndex = 59;
            this.rbtngarantivar.TabStop = true;
            this.rbtngarantivar.Text = "GARANTİ VAR";
            this.rbtngarantivar.UseVisualStyleBackColor = true;
            // 
            // rbtngarantiyok
            // 
            this.rbtngarantiyok.AutoSize = true;
            this.rbtngarantiyok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtngarantiyok.Location = new System.Drawing.Point(1434, 20);
            this.rbtngarantiyok.Name = "rbtngarantiyok";
            this.rbtngarantiyok.Size = new System.Drawing.Size(211, 33);
            this.rbtngarantiyok.TabIndex = 60;
            this.rbtngarantiyok.TabStop = true;
            this.rbtngarantiyok.Text = "GARANTİ YOK";
            this.rbtngarantiyok.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(920, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 37);
            this.label7.TabIndex = 61;
            this.label7.Text = "KAYIT TARİHİ :";
            // 
            // lbKayitTarihi
            // 
            this.lbKayitTarihi.AutoSize = true;
            this.lbKayitTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbKayitTarihi.Location = new System.Drawing.Point(1228, 72);
            this.lbKayitTarihi.Name = "lbKayitTarihi";
            this.lbKayitTarihi.Size = new System.Drawing.Size(0, 37);
            this.lbKayitTarihi.TabIndex = 62;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTemizle.BackgroundImage")));
            this.btnTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTemizle.Location = new System.Drawing.Point(959, 339);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(215, 220);
            this.btnTemizle.TabIndex = 66;
            this.btnTemizle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSil.BackgroundImage")));
            this.btnSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSil.Location = new System.Drawing.Point(649, 358);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(215, 182);
            this.btnSil.TabIndex = 65;
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuncelle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.BackgroundImage")));
            this.btnGuncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuncelle.Location = new System.Drawing.Point(356, 339);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(243, 220);
            this.btnGuncelle.TabIndex = 64;
            this.btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEkle.BackgroundImage")));
            this.btnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEkle.Location = new System.Drawing.Point(50, 349);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(244, 201);
            this.btnEkle.TabIndex = 63;
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // formCihaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1731, 736);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lbKayitTarihi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rbtngarantiyok);
            this.Controls.Add(this.rbtngarantivar);
            this.Controls.Add(this.dgvCihaz);
            this.Controls.Add(this.rtbaciklama);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSeriNumarası);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.tbMarka);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMusteriSec);
            this.Name = "formCihaz";
            this.Text = "formCihaz";
            this.Load += new System.EventHandler(this.formCihaz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCihaz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMusteriSec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMarka;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbSeriNumarası;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbaciklama;
        private System.Windows.Forms.DataGridView dgvCihaz;
        private System.Windows.Forms.RadioButton rbtngarantivar;
        private System.Windows.Forms.RadioButton rbtngarantiyok;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbKayitTarihi;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
    }
}