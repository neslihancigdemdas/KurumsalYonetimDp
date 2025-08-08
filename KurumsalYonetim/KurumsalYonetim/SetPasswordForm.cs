using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class SetPasswordForm : Form
    {
        public SetPasswordForm()
        {
            InitializeComponent();
            tbNewPassword.PasswordChar = '*';
            tbConfirmPassword.PasswordChar = '*';
        }

        private void SetPasswordForm_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
        }

        private async void btnRequestReset_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = tbUsernameOrEmail.Text.Trim();
            string yeniSifre = tbNewPassword.Text.Trim();
            string yeniSifreTekrar = tbConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(yeniSifreTekrar))
            {
                lblMessage.Text = "Lütfen tüm alanları doldurun.";
                return;
            }

            if (yeniSifre != yeniSifreTekrar)
            {
                lblMessage.Text = "Şifreler eşleşmiyor.";
                return;
            }

            var httpClient = new HttpClient();
            var requestData = new
            {
                KullaniciAdi = kullaniciAdi,
                YeniSifre = yeniSifre
            };

            var json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5011/api/Auth/set-password", content);

                string responseText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Text = "✅ Şifre başarıyla değiştirildi.";
                }
                else
                {
                    lblMessage.Text = $"❌ Hata: {responseText}";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "❌ İstek gönderilirken bir hata oluştu: " + ex.Message;
            }
        }
    }
}
