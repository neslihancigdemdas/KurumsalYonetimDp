using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class FormTeknikServis : Form
    {
        public FormTeknikServis()
        {
            InitializeComponent();
        }

        private void FormTeknikServis_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            formMusteri musteriform = new formMusteri();
            musteriform.Show();
        }

        private void btnCihazlar_Click(object sender, EventArgs e)
        {
            formCihaz cihazform = new formCihaz();
            cihazform.Show();
        }

        private void btnServisKaydi_Click(object sender, EventArgs e)
        {
            formServisKaydi servisKaydiform = new formServisKaydi();
            servisKaydiform.Show();
        }

        private void btnServisListele_Click(object sender, EventArgs e)
        {
            formServisListele servisListeleform = new formServisListele();
            servisListeleform.Show();
        }

        private void btnNotEkle_Click(object sender, EventArgs e)
        {
            formNotEkle notEkleform = new formNotEkle();
            notEkleform.Show();
        }
    }
}
