using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalYonetim.Models
{
    public class Musteri
    {
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
    }

}
