using KurumsalYonetimAPI.Controllers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace KurumsalYonetimAPI.Models
{
    public class Kullanici
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Kullanıcı Adı en fazla 50 karakter olabilir.")] 
        public required string KullaniciAdi { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "Şifre Hash değeri en fazla 128 karakter olabilir.")] 
        public required string SifreHash { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Şifre Salt değeri en fazla 32 karakter olabilir.")] 
        public required string SifreSalt { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Rol en fazla 20 karakter olabilir.")]
        public required string Rol { get; set; }

        public bool AktifMi { get; set; } = true; 
        public bool SifreDegistirilmelidir { get; set; } = true;
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now; 
        public DateTime? SonGirisTarihi { get; set; }


        public virtual CalisanProfil? CalisanProfil { get; set; }
    }
}