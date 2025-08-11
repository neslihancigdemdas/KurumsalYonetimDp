using KurumsalYonetimAPI.Data;
using KurumsalYonetimAPI.Models;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace KurumsalYonetimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalisanlarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalisanlarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calisan>>> GetCalisanlar()
        {
          
            if (_context.Calisanlar == null)
            {
                return NotFound("Çalışanlar bulunamadı.");
            }
            return await _context.Calisanlar.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calisan>> GetCalisan(int id) 
        {
            if (_context.Calisanlar == null)
            {
                return NotFound("Çalışanlar bulunamadı.");
            }
            Calisan? calisan = await _context.Calisanlar.FindAsync(id);

            if (calisan == null)
            {
                return NotFound("Çalışan bulunamadı.");
            }

            return calisan;
        }

        [HttpPost]
        public async Task<ActionResult<Calisan>> AddCalisan(Calisan calisan) 
        {
            if (_context.Calisanlar == null)
            {
                return Problem("Varlık kümesi 'ApplicationDbContext.Calisanlar' null.");
            }

            if (await _context.Calisanlar.AnyAsync(c => c.SicilNo == calisan.SicilNo))
            {
                return Conflict("Bu Sicil Numarası zaten mevcut.");
            }

            _context.Calisanlar.Add(calisan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCalisan), new { id = calisan.CalisanID }, calisan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalisan(int id, Calisan calisan)
        {
            if (id != calisan.CalisanID)
            {
                return BadRequest("ID uyuşmuyor.");
            }

            // Çalışanın veritabanında olup olmadığını kontrol et
            if (!_context.Calisanlar.Any(e => e.CalisanID == id))
            {
                return NotFound("Güncellenmek istenen çalışan bulunamadı.");
            }

           
            if (await _context.Calisanlar.AnyAsync(c => c.SicilNo == calisan.SicilNo && c.CalisanID != id))
            {
                return Conflict("Güncellemeye çalıştığınız Sicil Numarası başka bir çalışana ait.");
            }


            _context.Entry(calisan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Concurrency hatası durumunda (örneğin aynı anda başka birisi değiştirirse)
                if (!CalisanExists(id))
                {
                    return NotFound("Güncellenmek istenen çalışan bulunamadı.");
                }
                else
                {
                    throw; 
                }
            }

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
            if (_context.Calisanlar == null)
            {
                return NotFound("Varlık kümesi 'ApplicationDbContext.Calisanlar' null.");
            }
            Calisan? calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan == null)
            {
                return NotFound("Silinecek çalışan bulunamadı.");
            }

            _context.Calisanlar.Remove(calisan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CalisanExists(int id)
        {
            return _context.Calisanlar.Any(e => e.CalisanID == id);
        }
    }
}


