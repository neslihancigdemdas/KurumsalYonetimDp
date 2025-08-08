using KurumsalYonetimAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class ServisDurumGecmisi
{
    [Key]
    public int DurumId { get; set; }
    public int ServisKayitId { get; set; }
    public string Durum { get; set; } = string.Empty;
    public DateTime Tarih { get; set; }
    public string? Aciklama { get; set; }
    public ServisKayit ?ServisKayit { get; set; }


}
