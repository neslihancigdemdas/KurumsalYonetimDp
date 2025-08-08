namespace KurumsalYonetimAPI.Models
{
    public class Cihaz
    {
        public int CihazID { get; set; } 
        public int MusteriID { get; set; } 
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SeriNo { get; set; } = string.Empty;
        public bool GarantiDurumu { get; set; }
        public string Aciklama { get; set; } = string.Empty;
        public DateTime KayitTarihi { get; set; }
        public Musteriler? Musteri { get; set; }
    }
}
