using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ApplicationContext _context;

    public RequestsController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/Requests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
    {
        return await _context.Requests.ToListAsync();
    }

    // GET: api/Requests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Request>> GetRequest(int id)
    {
        var request = await _context.Requests.FindAsync(id);

        if (request == null) return NotFound();

        return request;
    }

    // PUT: api/Requests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRequest(int id, Request request)
    {
        if (id != request.RequestId) return BadRequest();
    }

    // POST: api/Requests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Request>> PostRequest(Request request)
    {
        return CreatedAtAction("GetRequest", new { id = request.RequestId }, request);
    }

    // DELETE: api/Requests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
    }
}