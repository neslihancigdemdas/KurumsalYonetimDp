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

    // GET: api/ServisDurumGecmisi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServisDurumGecmisi>>> GetDurumlar()
    {
        return await _context.ServisDurumGecmisi
             .Include(d => d.ServisKayit)
            .ToListAsync();
    }

    // GET: api/ServisDurumGecmisi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServisDurumGecmisi>> GetDurum(int id)
    {
        var durum = await _context.ServisDurumGecmisi.FindAsync(id);

        if (durum == null)
            return NotFound();

        return durum;
    }

    // POST: api/ServisDurumGecmisi
    [HttpPost]
    public async Task<ActionResult<ServisDurumGecmisi>> PostDurum(ServisDurumGecmisi durum)
    {
        durum.Tarih = DateTime.Now; // Sunucu tarafında tarih ayarlanabilir

        _context.ServisDurumGecmisi.Add(durum);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDurum), new { id = durum.DurumId }, durum);
    }

    // PUT: api/ServisDurumGecmisi/5
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

    // DELETE: api/ServisDurumGecmisi/5
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
