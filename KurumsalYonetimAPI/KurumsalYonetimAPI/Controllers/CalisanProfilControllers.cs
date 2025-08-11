using KurumsalYonetimAPI.Data;
using KurumsalYonetimAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace KurumsalYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalisanSelfServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CalisanSelfServiceController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("dogrula")]
        public async Task<IActionResult> DogrulaCalisan([FromBody] CalisanDogrulamaRequest request)
        {
            var calisan = await _context.Calisanlar.FirstOrDefaultAsync(c =>
                c.Ad == request.Ad &&
                c.Soyad == request.Soyad &&
                c.SicilNo == request.SicilNo
            );

            if (calisan == null)
                return NotFound("Girilen bilgilere ait bir çalışan bulunamadı.");

            return Ok(calisan);
        }

        [HttpPut("guncelle/{id}")]
        public async Task<IActionResult> GuncelleBilgiler(int id, [FromBody] CalisanBilgiGuncelleRequest request)
        {
            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan == null)
                return NotFound("Çalışan bulunamadı.");

            calisan.Telefon = request.Telefon ?? calisan.Telefon;
            calisan.Email = request.Email ?? calisan.Email;

            await _context.SaveChangesAsync();
            return Ok("Bilgiler başarıyla güncellendi.");
        }

        [HttpPost("dogrulama islemi")]
        public IActionResult Dogrula([FromBody] DogrulamaRequest model)
        {
            var calisan = _context.Calisanlar
                .FirstOrDefault(c => c.Ad == model.Ad && c.Soyad == model.Soyad && c.SicilNo == model.SicilNo);

            if (calisan == null)
                return NotFound("Bilgiler eşleşmedi.");

            return Ok(calisan); 
        }

        [HttpPut("guncelle-resimli/{id}")]
        public async Task<IActionResult> GuncelleBilgilerWithImage(int id, [FromForm] CalisanResimliGuncelleRequest request)
        {
            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan == null)
                return NotFound("Çalışan bulunamadı.");

            if (request.Resim != null && request.Resim.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Resim.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Resim.CopyToAsync(stream);
                }

                calisan.ResimYolu = $"/uploads/{uniqueFileName}";
            }

            calisan.Telefon = request.Telefon ?? calisan.Telefon;
            calisan.Email = request.Email ?? calisan.Email;

            await _context.SaveChangesAsync();
            return Ok("Bilgiler ve fotoğraf başarıyla güncellendi.");
        }
    }
}
