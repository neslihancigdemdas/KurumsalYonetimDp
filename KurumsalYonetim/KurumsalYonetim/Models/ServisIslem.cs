using System;

namespace KurumsalYonetim.Models
{
    public class ServisIslem
    {
        public int IslemId { get; set; }
        public int ServisKayitId { get; set; }
        public string YapilanIslem { get; set; }
        public DateTime Tarih { get; set; }
        public decimal? Ucret { get; set; }
        public ServisKayit ServisKayit { get; set; }
    }
}
