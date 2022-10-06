using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestTypesController : ControllerBase
{
    private readonly ApplicationContext _context;

    public RequestTypesController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/RequestTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RequestType>>> GetRequestTypes()
    {
        return await _context.RequestTypes.ToListAsync();
    }

    // GET: api/RequestTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RequestType>> GetRequestType(int id)
    {
        var requestType = await _context.RequestTypes.FindAsync(id);

        if (requestType == null) return NotFound();

        return requestType;
    }

    // PUT: api/RequestTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRequestType(int id, RequestType requestType)
    {
        if (id != requestType.RequestTypeId) return BadRequest();

        _context.Entry(requestType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RequestTypeExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/RequestTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<RequestType>> PostRequestType(RequestType requestType)
    {
        _context.RequestTypes.Add(requestType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRequestType", new { id = requestType.RequestTypeId }, requestType);
    }

    // DELETE: api/RequestTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequestType(int id)
    {
        var requestType = await _context.RequestTypes.FindAsync(id);
        if (requestType == null) return NotFound();

        _context.RequestTypes.Remove(requestType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RequestTypeExists(int id)
    {
        return _context.RequestTypes.Any(e => e.RequestTypeId == id);
    }
}