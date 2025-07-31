using System;

namespace KurumsalYonetim
{
    internal class Musteri
    {
        public string AdSoyad { get; internal set; }
        public string Telefon { get; internal set; }
        public string Email { get; internal set; }
        public string Adres { get; internal set; }
        public DateTime KayitTarihi { get; internal set; }
        public int MusteriID { get; internal set; }
    }
}