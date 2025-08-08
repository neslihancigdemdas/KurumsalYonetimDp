using System.ComponentModel.DataAnnotations;

namespace KurumsalYonetimAPI.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz.")]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre boş olamaz.")]
        public string Sifre { get; set; } = string.Empty;
    }
}