using KurumsalYonetimAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class ServisIslem
{
    [Key]
    public int IslemId { get; set; }
    public int ServisKayitId { get; set; }
    public string YapilanIslem { get; set; } = string.Empty;
    public DateTime Tarih { get; set; }
    public decimal? Ucret { get; set; }
    public ServisKayit? ServisKayit { get; set; }



}
