using System;
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
            formServisKayit ServisKayitform = new formServisKayit();
            ServisKayitform.Show();
        }

        private void btnServisDurumGecmis_Click(object sender, EventArgs e)
        {
            formServisDurumGecmis servisDurumGecmisform = new formServisDurumGecmis();
            servisDurumGecmisform.Show();
        }

        private void btnServisİslem_Click(object sender, EventArgs e)
        {
            formServisIslem servisIslemForm = new formServisIslem();
            servisIslemForm.Show();
        }
    }
}
