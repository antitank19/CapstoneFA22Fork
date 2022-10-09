using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly ApplicationContext _context;

    public ServicesController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/ServiceEntitys
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceEntity>>> GetServiceEntitys()
    {
        return await _context.Services.ToListAsync();
    }

    // GET: api/ServiceEntitys/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceEntity>> GetServiceEntity(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service == null) return NotFound();

        return service;
    }

    // PUT: api/ServiceEntitys/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutServiceEntity(int id, ServiceEntity service)
    {
        if (id != service.ServiceId) return BadRequest();

        _context.Entry(service).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceEntityExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/ServiceEntitys
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ServiceEntity>> PostServiceEntity(ServiceEntity service)
    {
        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetServiceEntity", new { id = service.ServiceId }, service);
    }

    // DELETE: api/ServiceEntitys/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServiceEntity(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ServiceEntityExists(int id)
    {
        return _context.Services.Any(e => e.ServiceId == id);
    }
}