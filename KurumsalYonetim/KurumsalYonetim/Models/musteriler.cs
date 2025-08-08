using Newtonsoft.Json;
using System;

namespace KurumsalYonetim.Models
{
    public class Musteriler
    {
        public static object Content { get; internal set; }
        [JsonProperty("musteriID")]
        public int MusteriID { get; set; }

        [JsonProperty("adSoyad")]
        public string AdSoyad { get; set; } = string.Empty;

        [JsonProperty("telefon")]
        public string Telefon { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("adres")]
        public string Adres { get; set; }

        [JsonProperty("kayitTarihi")]
        public DateTime KayitTarihi { get; set; }

        public class Musteri
        {
            public int MusteriID { get; set; }
            public string AdSoyad { get; set; } = string.Empty;
        }
    }

}
