namespace KurumsalYonetim.Models
{
    public class CurrentUser
    {
        // Admin mi olduğunu belirtir.
        public bool IsAdmin { get; set; }

        public int CalisanID { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string SicilNo { get; set; }
    }
}
