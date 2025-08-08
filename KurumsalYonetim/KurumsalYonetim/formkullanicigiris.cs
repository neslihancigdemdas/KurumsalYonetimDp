using System;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class formkullanicigiris : Form
    {
        public formkullanicigiris()
        {
            InitializeComponent();
        }

        public formkullanicigiris(string responseData)
        {
            ResponseData = responseData;
        }

        public string ResponseData { get; }

        private void formkullanicigiris_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
