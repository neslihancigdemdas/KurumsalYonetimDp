using KurumsalYonetimAPI.Data;
using KurumsalYonetimAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KurumsalYonetimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemirbaslarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DemirbaslarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demirbas>>> GetDemirbaslar()
        {
            return await _context.Demirbaslar.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Demirbas>> AddDemirbas(Demirbas demirbas)
        {
            _context.Demirbaslar.Add(demirbas);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDemirbas), new { id = demirbas.DemirbasID }, demirbas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Demirbas>> GetDemirbas(int id)
        {
            var demirbas = await _context.Demirbaslar.FindAsync(id);
            if (demirbas == null) return NotFound();
            return demirbas;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDemirbas(int id, Demirbas demirbas)
        {
            if (id != demirbas.DemirbasID) return BadRequest();

            _context.Entry(demirbas).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemirbas(int id)
        {
            var demirbas = await _context.Demirbaslar.FindAsync(id);
            if (demirbas == null) return NotFound();

            _context.Demirbaslar.Remove(demirbas);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Demirbas>>> GetAvailableDemirbaslar()
        {
           
            var allDemirbaslar = await _context.Demirbaslar.ToListAsync();

            var activeAssignments = await _context.Atamalar
                                                .Where(a => a.TeslimTarihi == null)
                                                .Select(a => a.DemirbasID)
                                                .ToListAsync();

            var availableDemirbaslar = allDemirbaslar
                .Where(d => !activeAssignments.Contains(d.DemirbasID))
                .ToList();

            return Ok(availableDemirbaslar);
        }
    }
}
