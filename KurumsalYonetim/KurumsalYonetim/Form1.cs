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
    public partial class FormSecenekler : Form
    {
        public FormSecenekler(string kullaniciAdi, string rol)
        {
            InitializeComponent();

        }

        private void btnCalisanlar_Click(object sender, EventArgs e)
        {
          FormCalisanlar calisanlarform = new FormCalisanlar();
            calisanlarform.Show();
        }

        private void btnDemirbaslar_Click(object sender, EventArgs e)
        {
            FormDemirbaslar demibaslarform = new FormDemirbaslar();
            demibaslarform.Show();
        }

        private void btnDemirbasAtama_Click(object sender, EventArgs e)
        {
            FormDemirbaslarıAtama demirbaslaraatamaform = new FormDemirbaslarıAtama();
            demirbaslaraatamaform.Show();
        }

        private void btnTeknikServis_Click(object sender, EventArgs e)
        {
            FormTeknikServis teknikserivsform = new FormTeknikServis();
            teknikserivsform.Show();

        }

        private void FormSecenekler_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
