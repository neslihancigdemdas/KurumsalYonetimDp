using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurumsalYonetimAPI.Models
{
    public class Calisan
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CalisanID { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Ad { get; set; } = string.Empty; 

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string Soyad { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Departman en fazla 50 karakter olabilir.")]
        public string Departman { get; set; } = string.Empty;

        [StringLength(15, ErrorMessage = "Telefon numarası en fazla 15 karakter olabilir.")]
       
        public string Telefon { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")] 
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sicil Numarası alanı zorunludur.")]
        [StringLength(20, ErrorMessage = "Sicil Numarası en fazla 20 karakter olabilir.")]
        public string SicilNo { get; set; } = string.Empty;

        [StringLength(250)]
        public string? ResimYolu { get; set; }

    }
}