using AutoMapper;
using Domain.EntitiesDTO.Major;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MajorsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public MajorsController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Majors
    [HttpGet]
    public async Task<ActionResult<MajorDto>> GetMajors()
    {
        var result = await _serviceWrapper.Majors.GetMajorList();
        if (!result.Any())
            return NotFound("No major available");

        var response = _mapper.Map<IEnumerable<Major>>(result);
        return Ok(response);
    }

} /*

// GET: api/Majors/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Major>> GetMajor(int id)
    {
        var major = await _context.Majors.FindAsync(id);

        if (major == null) return NotFound();

        return major;
    }

    // PUT: api/Majors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMajor(int id, Major major)
    {
        if (id != major.MajorId) return BadRequest();

        _context.Entry(major).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MajorExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Majors
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Major>> PostMajor(Major major)
    {
        _context.Majors.Add(major);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMajor", new { id = major.MajorId }, major);
    }

    // DELETE: api/Majors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMajor(int id)
    {
        var major = await _context.Majors.FindAsync(id);
        if (major == null) return NotFound();

        _context.Majors.Remove(major);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MajorExists(int id)
    {
        return _context.Majors.Any(e => e.MajorId == id);
    }
}
*/