using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseHistoriesController : ControllerBase
{
    private readonly ApplicationContext _context;

    public ExpenseHistoriesController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/ExpenseHistories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseHistory>>> GetExpenseHistories()
    {
        return await _context.ExpenseHistories.ToListAsync();
    }

    // GET: api/ExpenseHistories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseHistory>> GetExpenseHistory(int id)
    {
        var expenseHistory = await _context.ExpenseHistories.FindAsync(id);

        if (expenseHistory == null) return NotFound();

        return expenseHistory;
    }

    // PUT: api/ExpenseHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutExpenseHistory(int id, ExpenseHistory expenseHistory)
    {
        if (id != expenseHistory.ExpenseHistoryId) return BadRequest();

        _context.Entry(expenseHistory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExpenseHistoryExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/ExpenseHistories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ExpenseHistory>> PostExpenseHistory(ExpenseHistory expenseHistory)
    {
        _context.ExpenseHistories.Add(expenseHistory);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetExpenseHistory", new { id = expenseHistory.ExpenseHistoryId }, expenseHistory);
    }

    // DELETE: api/ExpenseHistories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseHistory(int id)
    {
        var expenseHistory = await _context.ExpenseHistories.FindAsync(id);
        if (expenseHistory == null) return NotFound();

        _context.ExpenseHistories.Remove(expenseHistory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ExpenseHistoryExists(int id)
    {
        return _context.ExpenseHistories.Any(e => e.ExpenseHistoryId == id);
    }
}