using System;

namespace KurumsalYonetim.Models
{
    public class ServisListele
    {
        public int ServisID { get; set; }
        public string MusteriAdi { get; set; } = string.Empty;
        public string CihazSeriNo { get; set; }
        public DateTime GelisTarihi { get; set; }
        public string ServisDurumu { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public decimal Ucret { get; set; }
    }
}
