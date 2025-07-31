using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using KurumsalYonetim.Controllers;
using KurumsalYonetim.Models;

namespace KurumsalYonetim
{
    public partial class formLogincs : Form
    {
        public formLogincs()
        {
            InitializeComponent();
            tbSifre.PasswordChar = '*';
        }
        public class RegisterRequest
        {
            public string KullaniciAdi { get; set; } = string.Empty;
            public string Sifre { get; set; } = string.Empty;
            public string Rol { get; set; } = "Kullanici"; 
        }

        private async void btnHesapOlusturma_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = tbKullaniciAdi.Text.Trim();
            string sifre = tbSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.");
                return;
            }

             RegisterRequest registerRequest = new RegisterRequest
             {    
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre,
                 Rol = "Kullanici"

             };
            
             

            string json = JsonConvert.SerializeObject(registerRequest);
    
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5011/api/Auth/register", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Kayıt başarılı!");
                        tbKullaniciAdi.Text = "";
                        tbSifre.Text = "";
                    }
                    else
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Kayıt başarısız: " + responseText);
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show("İstek hatası: " + httpEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmeyen bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void btSifreYenileme_Click(object sender, EventArgs e)
        {
            SetPasswordForm formsetpassword = new SetPasswordForm(tbKullaniciAdi.Text.Trim());
            formsetpassword.ShowDialog();
        }
        public class LoginRequest 
        {
            public string KullaniciAdi { get; set; } = string.Empty;
            public string Sifre { get; set; } = string.Empty;
        }
        public class LoginResponse
        {
            public string Message { get; set; } = string.Empty;
            public string Rol { get; set; } = string.Empty;
            public bool RequirePasswordChange { get; set; }
        }

        private async void btnGirisYap_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = tbKullaniciAdi.Text.Trim(); 
            string sifre = tbSifre.Text; 

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginRequest loginRequest = new LoginRequest
            {
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre
            };

            string json = JsonConvert.SerializeObject(loginRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            
            string apiBaseUrl = "http://localhost:5011"; 

            using (HttpClient client = new HttpClient())
            {
                string responseText = string.Empty;
                try
                {
                    HttpResponseMessage response = await client.PostAsync($"{apiBaseUrl}/api/Auth/login", content);
                    string v = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(v);

                        MessageBox.Show("Giriş Başarılı");
                        FormSecenekler mainForm = new FormSecenekler(kullaniciAdi, loginResponse.Rol);
                         mainForm.Show();                   
  
                    }
                    else 
                    {
                        MessageBox.Show("Giriş başarısız: " + v, "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show("API bağlantı hatası: " + httpEx.Message + "\nAPI'nin çalıştığından ve doğru adresi kullandığınızdan emin olun.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (JsonException jsonEx)
                {
                    MessageBox.Show("API yanıtı işlenirken hata oluştu: " + jsonEx.Message + "\nYanıt: " + responseText, "Yanıt İşleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void formLogincs_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
