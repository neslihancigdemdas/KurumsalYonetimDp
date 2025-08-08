namespace KurumsalYonetimAPI.Models
{
    public class CalisanDTO
    {
    }
    public class CalisanDogrulamaRequest
    {
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string SicilNo { get; set; } = string.Empty;
    }

    public class CalisanBilgiGuncelleRequest
    {
        public string? Telefon { get; set; }
        public string? Email { get; set; }
    }
    public class DogrulamaRequest
    {
        public string ?Ad { get; set; }
        public string ?Soyad { get; set; }
        public string ?SicilNo { get; set; }
    }
    public class CalisanResimliGuncelleRequest
    {
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public IFormFile? Resim { get; set; }
    }

}
