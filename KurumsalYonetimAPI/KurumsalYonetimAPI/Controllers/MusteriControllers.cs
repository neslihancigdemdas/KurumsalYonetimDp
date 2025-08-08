using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KurumsalYonetimAPI.Data;
using KurumsalYonetimAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalYonetimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MusteriController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<Musteriler>>> GetMusteriler()
        {
            List<Musteriler> musteriler = await _context.Musteriler.ToListAsync();
            return musteriler;
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Musteriler>> GetMusteri(int id)
        {
            Musteriler? musteri = await _context.Musteriler.FindAsync(id);

            if (musteri == null)
            {
                return NotFound();
            }

            return musteri;
        }

      
        [HttpPost]
        public async Task<ActionResult<Musteriler>> PostMusteri(Musteriler musteri)
        {
            _context.Musteriler.Add(musteri);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusteri), new { id = musteri.MusteriID }, musteri);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusteri(int id, Musteriler musteri)
        {
            if (id != musteri.MusteriID)
            {
                return BadRequest();
            }

            _context.Entry(musteri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusteriExists(id))
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

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusteri(int id)
        {
            Musteriler? musteri = await _context.Musteriler.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }

            _context.Musteriler.Remove(musteri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusteriExists(int id)
        {
            bool exists = _context.Musteriler.Any(m => m.MusteriID == id);
            return exists;
        }
    }
}
