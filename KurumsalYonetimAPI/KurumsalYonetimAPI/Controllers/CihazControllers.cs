using KurumsalYonetimAPI.Data;
using KurumsalYonetimAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CihazlarController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CihazlarController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCihazlar()
    {
        List<Cihaz> cihazlar = await _context.Cihazlar.ToListAsync();
        return Ok(cihazlar);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCihaz(int id)
    {
        Cihaz? cihaz = await _context.Cihazlar.FindAsync(id);
        if (cihaz == null)
        {
            return NotFound();
        }

        return Ok(cihaz);
    }

    [HttpPost]
    public async Task<IActionResult> PostCihaz([FromBody] Cihaz cihaz)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        cihaz.KayitTarihi = System.DateTime.Now;

        _context.Cihazlar.Add(cihaz);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCihaz), new { id = cihaz.CihazID }, cihaz);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCihaz(int id, [FromBody] Cihaz cihaz)
    {
        if (id != cihaz.CihazID)
        {
            return BadRequest();
        }

        _context.Entry(cihaz).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            bool cihazExists = await _context.Cihazlar.AnyAsync(c => c.CihazID == id);
            if (!cihazExists)
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
    public async Task<IActionResult> DeleteCihaz(int id)
    {
        Cihaz? cihaz = await _context.Cihazlar.FindAsync(id);
        if (cihaz == null)
        {
            return NotFound();
        }

        _context.Cihazlar.Remove(cihaz);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
