using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RenterController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public RenterController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    private readonly ApplicationContext _context;

    public RenterController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/Renters
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Renter>>> GetRenters()
    {
        return await _context.Renters.ToListAsync();
    }

    // GET: api/Renters/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Renter>> GetRenter(int id)
    {
        var renter = await _context.Renters.FindAsync(id);

        if (renter == null)
        {
            return NotFound();
        }

        return renter;
    }

    // PUT: api/Renters/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRenter(int id, Renter renter)
    {
        if (id != renter.RenterId)
        {
            return BadRequest();
        }

        _context.Entry(renter).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RenterExists(id))
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

    // POST: api/Renters
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Renter>> PostRenter(Renter renter)
    {
        _context.Renters.Add(renter);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRenter", new { id = renter.RenterId }, renter);
    }

    // DELETE: api/Renters/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRenter(int id)
    {
        var renter = await _context.Renters.FindAsync(id);
        if (renter == null)
        {
            return NotFound();
        }

        _context.Renters.Remove(renter);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RenterExists(int id)
    {
        return _context.Renters.Any(e => e.RenterId == id);
    }
}