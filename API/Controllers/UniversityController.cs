using AutoMapper;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public UniversityController(IMapper mapper, IServiceWrapper serviceWrapper, ApplicationContext context)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _context = context;
    }


    // GET: api/Universities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<University>>> GetUniversity()
    {
        return await _context.University.ToListAsync();
    }

    // GET: api/Universities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<University>> GetUniversity(int id)
    {
        var university = await _context.University.FindAsync(id);

        if (university == null) return NotFound();

        return university;
    }

    // PUT: api/Universities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUniversity(int id, University university)
    {
        if (id != university.UniversityId) return BadRequest();

        _context.Entry(university).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UniversityExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Universities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<University>> PostUniversity(University university)
    {
        _context.University.Add(university);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUniversity", new { id = university.UniversityId }, university);
    }

    // DELETE: api/Universities/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        var university = await _context.University.FindAsync(id);
        if (university == null) return NotFound();

        _context.University.Remove(university);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UniversityExists(int id)
    {
        return _context.University.Any(e => e.UniversityId == id);
    }
}