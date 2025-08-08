namespace KurumsalYonetim.Models
{
    public class LoginRequest
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }

    public class SetPasswordRequest
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string YeniSifre { get; set; } = string.Empty;
    }


    public class LoginResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool RequirePasswordChange { get; set; }
        public string Rol { get; internal set; }
    }
}