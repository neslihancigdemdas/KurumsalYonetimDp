using KurumsalYonetimAPI.Controllers;
using KurumsalYonetimAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KurumsalYonetimAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
 
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Demirbas> Demirbaslar { get; set; }
        public DbSet<Atama> Atamalar { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Cihaz> Cihazlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<ServisKayit> ServisKayit { get; set; }
        public DbSet<ServisDurumGecmisi> ServisDurumGecmisi { get; set; }
        public DbSet<ServisIslem> ServisIslem { get; set; }
        public DbSet<CalisanProfil> CalisanProfiller { get; set; }

        //public DbSet<CalisanDTO> calisanDTOs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Kullanici>(entity =>
            {
                
                entity.HasIndex(u => u.KullaniciAdi)
                      .IsUnique();

                entity.Property(u => u.OlusturmaTarihi)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(u => u.SonGirisTarihi)
                      .IsRequired(false);

            });

            modelBuilder.Entity<Calisan>(entity =>
            {
                entity.HasIndex(c => c.SicilNo)
                      .IsUnique();

            
            });
            base.OnModelCreating(modelBuilder);

        }
    }
}