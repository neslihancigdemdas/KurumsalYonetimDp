using System;

namespace KurumsalYonetim.Models
{
    public class cihaz
    {
        public int CihazID { get; set; }
        public int MusteriID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string SeriNo { get; set; }
        public bool GarantiDurumu { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
