using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurumsalYonetimAPI.Models
{
    public class Musteriler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusteriID { get; set; }

        [Required(ErrorMessage = "AdSoyad alanı zorunludur.")]
        [MaxLength(100)]
        public string AdSoyad { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Telefon { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Adres { get; set; } = string.Empty;

        public DateTime KayitTarihi { get; set; } = DateTime.Now;
     
    }
}
