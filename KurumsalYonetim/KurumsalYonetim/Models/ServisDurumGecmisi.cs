using System;

namespace KurumsalYonetim.Models
{
    public class ServisDurumGecmisi
    {
        public int DurumId { get; set; }
        public int ServisKayitId { get; set; }
        public string Durum { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public ServisKayit ServisKayit { get; set; }
    }
}
