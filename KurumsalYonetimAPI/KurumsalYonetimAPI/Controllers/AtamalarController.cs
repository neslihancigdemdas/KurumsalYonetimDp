using KurumsalYonetimAPI.Data;
using KurumsalYonetimAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KurumsalYonetimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtamalarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AtamalarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tüm atamaları listele
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atama>>> GetAtamalar()
        {
            return await _context.Atamalar
                .Include(a => a.Demirbas)
                .Include(a => a.Calisan)
                .ToListAsync();
        }

        // Atama yap
        [HttpPost]
        public async Task<ActionResult<Atama>> YapAtama(Atama atama)
        {
            _context.Atamalar.Add(atama);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAtama), new { id = atama.AtamaID }, atama);
        }

        // Belirli atamayı getir
        [HttpGet("{id}")]
        public async Task<ActionResult<Atama>> GetAtama(int id)
        {
            var atama = await _context.Atamalar
                .Include(a => a.Demirbas)
                .Include(a => a.Calisan)
                .FirstOrDefaultAsync(a => a.AtamaID == id);

            if (atama == null)
                return NotFound();

            return atama;
        }

        // Güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> Guncelle(int id, Atama atama)
        {
            if (id != atama.AtamaID)
                return BadRequest();

            _context.Entry(atama).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Teslim et (sadece teslim tarihini günceller)
        [HttpPut("teslim/{id}")]
        public async Task<IActionResult> TeslimEt(int id)
        {
            var atama = await _context.Atamalar.FindAsync(id);
            if (atama == null)
                return NotFound();

            atama.TeslimTarihi = DateTime.Now;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Sil(int id)
        {
            var atama = await _context.Atamalar.FindAsync(id);
            if (atama == null)
                return NotFound();

            _context.Atamalar.Remove(atama);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
