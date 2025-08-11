using KurumsalYonetimAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KurumsalYonetimAPI.Models;
[Route("api/[controller]")]

[ApiController]
public class ServisDurumGecmisiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServisDurumGecmisiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServisDurumGecmisi>>> GetDurumlar()
    {
        return await _context.ServisDurumGecmisi
             .Include(d => d.ServisKayit)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServisDurumGecmisi>> GetDurum(int id)
    {
        var durum = await _context.ServisDurumGecmisi.FindAsync(id);

        if (durum == null)
            return NotFound();

        return durum;
    }

    [HttpPost]
    public async Task<ActionResult<ServisDurumGecmisi>> PostDurum(ServisDurumGecmisi durum)
    {
        durum.Tarih = DateTime.Now;
        _context.ServisDurumGecmisi.Add(durum);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDurum), new { id = durum.DurumId }, durum);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDurum(int id, ServisDurumGecmisi durum)
    {
        if (id != durum.DurumId)
            return BadRequest();

        _context.Entry(durum).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DurumExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDurum(int id)
    {
        var durum = await _context.ServisDurumGecmisi.FindAsync(id);
        if (durum == null)
            return NotFound();

        _context.ServisDurumGecmisi.Remove(durum);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DurumExists(int id)
    {
        return _context.ServisDurumGecmisi.Any(e => e.DurumId == id);
    }
}
