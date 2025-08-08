using KurumsalYonetimAPI.Data;
using KurumsalYonetimAPI.Models;
using KurumsalYonetimAPI.Models.KurumsalYonetimAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ServisKayitController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServisKayitController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/ServisKayit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServisKayitDTO>>> GetServisKayitlari()
    {
        var servisListesi = await _context.ServisKayit
            .Include(s => s.Musteri)
            .Include(s => s.Cihaz)
            .Select(s => new ServisKayitDTO
            {
                ServisKayitId = s.ServisKayitId,
                CihazId = s.CihazId,
                MusteriId = s.MusteriId,
                Aciklama = s.Aciklama,
                KayitTarihi = s.KayitTarihi,
                MusteriAdSoyad = s.Musteri != null ? s.Musteri.AdSoyad : null,
                CihazMarka = s.Cihaz != null ? s.Cihaz.Marka : null
            })
            .ToListAsync();

        return servisListesi;
    }

    // GET: api/ServisKayit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServisKayit>> GetServisKayit(int id)
    {
        var servis = await _context.ServisKayit
            .Include(s => s.Durumlar.OrderByDescending(d => d.Tarih))
            .Include(s => s.Islemler.OrderBy(i => i.Tarih))
            .Include(s => s.Musteri)
            .Include(s => s.Cihaz)
            .FirstOrDefaultAsync(s => s.ServisKayitId == id);

        if (servis == null)
            return NotFound();

        // İstersen burada DTO'ya dönüştürebilirsin, ya da direkt model dönebilirsin
        // Eğer direkt model döneceksen aşağıdaki iki satırı ekleyerek ilgili alanları da doldurabilirsin:
        servis.MusteriAdSoyad = servis.Musteri != null ? servis.Musteri.AdSoyad : null;
        servis.CihazMarka = servis.Cihaz != null ? servis.Cihaz.Marka : null;

        return servis;
    }

    // POST: api/ServisKayit
    [HttpPost]
    public async Task<ActionResult<ServisKayit>> PostServisKayit(ServisKayit servis)
    {
        servis.KayitTarihi = DateTime.Now;

        _context.ServisKayit.Add(servis);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetServisKayit), new { id = servis.ServisKayitId }, servis);
    }

    // PUT: api/ServisKayit/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutServisKayit(int id, ServisKayit servis)
    {
        if (id != servis.ServisKayitId)
        {
            return BadRequest("ID eşleşmiyor.");
        }

        var mevcutKayit = await _context.ServisKayit.FindAsync(id);
        if (mevcutKayit == null)
        {
            return NotFound("Kayıt bulunamadı.");
        }

        mevcutKayit.CihazId = servis.CihazId;
        mevcutKayit.MusteriId = servis.MusteriId;
        mevcutKayit.Aciklama = servis.Aciklama;
        // KayitTarihi genellikle değişmez, istersen değiştirebilirsin.

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServisKayitExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/ServisKayit/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServisKayit(int id)
    {
        var servis = await _context.ServisKayit.FindAsync(id);
        if (servis == null)
        {
            return NotFound();
        }

        _context.ServisKayit.Remove(servis);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ServisKayitExists(int id)
    {
        return _context.ServisKayit.Any(e => e.ServisKayitId == id);
    }
}
