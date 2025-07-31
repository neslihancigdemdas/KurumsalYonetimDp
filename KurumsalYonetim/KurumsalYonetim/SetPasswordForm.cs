using KurumsalYonetim.Controllers;
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
    public partial class SetPasswordForm : Form
    {
        private readonly string _kullaniciAdi;
        private readonly APIServis _apiServis;
        public bool PasswordChangedSuccessfully { get; private set; } = false;

        public SetPasswordForm(string kullaniciAdi)
        {
            InitializeComponent();
            _kullaniciAdi = kullaniciAdi;
             _apiServis = new APIServis("http://localhost:5011/");
            lblKullaniciAdi.Text = $"Kullanıcı Adı: {_kullaniciAdi}";

            tbYeniSifre.PasswordChar = '*';
            tbYeniSifreTekrar.PasswordChar = '*';
        }
        private async void btnSetPassword_Click(object sender, EventArgs e)
        {
            string yeniSifre = tbYeniSifre.Text;
            string yeniSifreTekrar = tbYeniSifreTekrar.Text;

            if (string.IsNullOrWhiteSpace(yeniSifre) || string.IsNullOrWhiteSpace(yeniSifreTekrar))
            {
                MessageBox.Show("Yeni şifre ve şifre tekrarı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Yeni şifreler uyuşmuyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsPasswordStrong(yeniSifre))
            {
                MessageBox.Show("Şifre en az 8 karakter uzunluğunda olmalı ve büyük harf, küçük harf, rakam ve özel karakter içermelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            (bool success, string message) = await _apiServis.SetPasswordAsync(_kullaniciAdi, yeniSifre);

            if (success)
            {
                MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordChangedSuccessfully = true; 
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 &&
                    password.Any(char.IsUpper) && 
                    password.Any(char.IsLower) && 
                    password.Any(char.IsDigit) &&  
                    password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private void SetPasswordForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
