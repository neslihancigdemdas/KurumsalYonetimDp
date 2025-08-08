using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurumsalYonetimAPI.Models
{
    public class Demirbas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DemirbasID { get; set; }
        [Required]
        public string DemirbasAdi { get; set; } = string.Empty;
        public string DemirbasTuru { get; set; } = string.Empty;
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SeriNumarasi { get; set; } = string.Empty;
        public string Durum { get; set; } = string.Empty;

    }
}
