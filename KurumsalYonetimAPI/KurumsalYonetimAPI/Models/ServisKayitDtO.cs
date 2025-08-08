namespace KurumsalYonetimAPI.Models
{
    namespace KurumsalYonetimAPI.Models
    {
        public class ServisKayitDTO
        {
            public int ServisKayitId { get; set; }
            public int CihazId { get; set; }
            public int? MusteriId { get; set; }
            public DateTime KayitTarihi { get; set; }
            public string? Aciklama { get; set; }

            public string? MusteriAdSoyad { get; set; }
            public string? CihazMarka { get; set; }
        }
    }

}
