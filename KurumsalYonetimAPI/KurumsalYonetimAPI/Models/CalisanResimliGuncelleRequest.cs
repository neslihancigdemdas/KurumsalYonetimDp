namespace KurumsalYonetimAPI.Models
{
    public class CalisanResimGuncelleRequest
    {
        public int CalisanID { get; set; } 
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public IFormFile? Resim { get; set; }
    }
}
