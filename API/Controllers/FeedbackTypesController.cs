using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbackTypesController : ControllerBase
{
    private readonly ApplicationContext _context;

    public FeedbackTypesController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/FeedbackTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeedbackType>>> GetFeedbackTypes()
    {
        return await _context.FeedbackTypes.ToListAsync();
    }

    // GET: api/FeedbackTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FeedbackType>> GetFeedbackType(int id)
    {
        var feedbackType = await _context.FeedbackTypes.FindAsync(id);

        if (feedbackType == null) return NotFound();

        return feedbackType;
    }

    // PUT: api/FeedbackTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFeedbackType(int id, FeedbackType feedbackType)
    {
        if (id != feedbackType.FeedbackTypeId) return BadRequest();
    }

    // POST: api/FeedbackTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<FeedbackType>> PostFeedbackType(FeedbackType feedbackType)
    {
        return CreatedAtAction("GetFeedbackType", new { id = feedbackType.FeedbackTypeId }, feedbackType);
    }

    // DELETE: api/FeedbackTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedbackType(int id)
    {
    }
}