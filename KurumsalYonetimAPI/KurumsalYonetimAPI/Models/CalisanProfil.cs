using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurumsalYonetimAPI.Models
{
    public class CalisanProfil
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }

        public string? AdSoyad { get; set; }

        public string? SeriNO { get; set; }

        public string? ResimYolu { get; set; }

        public bool OnayDurumu { get; set; } = false;

        // Navigation
        public virtual Kullanici? Kullanici { get; set; }
    }
}
