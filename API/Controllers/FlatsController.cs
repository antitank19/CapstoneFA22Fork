using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlatsController : ControllerBase
{
    private readonly ApplicationContext _context;

    public FlatsController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/Flats
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flat>>> GetFlats()
    {
        return await _context.Flats.ToListAsync();
    }

    // GET: api/Flats/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Flat>> GetFlat(int id)
    {
        var flat = await _context.Flats.FindAsync(id);

        if (flat == null) return NotFound();

        return flat;
    }

    // PUT: api/Flats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFlat(int id, Flat flat)
    {
        if (id != flat.FlatId) return BadRequest();
    }

    // POST: api/Flats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Flat>> PostFlat(Flat flat)
    {
        return CreatedAtAction("GetFlat", new { id = flat.FlatId }, flat);
    }

    // DELETE: api/Flats/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlat(int id)
    {
    }
}