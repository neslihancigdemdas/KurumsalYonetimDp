using KurumsalYonetimAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ServisIslemController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServisIslemController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServisIslem>>> GetIslemler()
    {
        return await _context.ServisIslem
            .Include(i => i.ServisKayit)  
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServisIslem>> GetIslem(int id)
    {
        var islem = await _context.ServisIslem.FindAsync(id);

        if (islem == null)
            return NotFound();

        return islem;
    }

    [HttpPost]
    public async Task<ActionResult<ServisIslem>> PostIslem(ServisIslem islem)
    {
        islem.Tarih = DateTime.Now; // Sunucu tarafında tarih ayarlanabilir

        _context.ServisIslem.Add(islem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIslem), new { id = islem.IslemId }, islem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutIslem(int id, ServisIslem islem)
    {
        if (id != islem.IslemId)
            return BadRequest();

        _context.Entry(islem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IslemExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIslem(int id)
    {
        var islem = await _context.ServisIslem.FindAsync(id);
        if (islem == null)
            return NotFound();

        _context.ServisIslem.Remove(islem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IslemExists(int id)
    {
        return _context.ServisIslem.Any(e => e.IslemId == id);
    }
}
