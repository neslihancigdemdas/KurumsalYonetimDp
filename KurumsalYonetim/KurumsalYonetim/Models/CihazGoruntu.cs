using System;

namespace KurumsalYonetim.Models
{
    public class CihazGoruntu
    {
        public int CihazID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string SeriNo { get; set; }
        public string GarantiDurumu { get; set; }
        public string Aciklama { get; set; }
        public string MusteriAdi { get; set; }
        public DateTime KayitTarihi { get; set; }
    }

}
