using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurumsalYonetimAPI.Models
{
    public class Atama
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtamaID { get; set; }

        [Required]
        public int DemirbasID { get; set; }

        [Required]
        public int CalisanID { get; set; }

        [Required]
        public DateTime AtamaTarihi { get; set; } = DateTime.Now;

        public DateTime? TeslimTarihi { get; set; }

        [ForeignKey("DemirbasID")]
        public Demirbas? Demirbas { get; set; }

        [ForeignKey("CalisanID")]
        public Calisan? Calisan { get; set; }
    }
}
