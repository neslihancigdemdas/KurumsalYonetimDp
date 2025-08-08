using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurumsalYonetimAPI.Models
{
    public class ServisKayit
    {
        [Key]
        public int ServisKayitId { get; set; }

        public int CihazId { get; set; }
        public int? MusteriId { get; set; }

        public DateTime KayitTarihi { get; set; }
        public string? Aciklama { get; set; }

        // Navigation Properties - İsimlendirme önemli! Büyük harf ile
        public virtual Cihaz? Cihaz { get; set; }
        public virtual Musteriler? Musteri { get; set; }

        // DTO amaçlı, EF ile mapping yapılmaması için [NotMapped] kullanıyoruz
        [NotMapped]
        public string? MusteriAdSoyad { get; set; }

        [NotMapped]
        public string? CihazMarka { get; set; }

        public virtual ICollection<ServisDurumGecmisi> Durumlar { get; set; } = new List<ServisDurumGecmisi>();
        public virtual ICollection<ServisIslem> Islemler { get; set; } = new List<ServisIslem>();
    }
}
