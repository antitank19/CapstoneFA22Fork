using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseTypesController : ControllerBase
{
    private readonly ApplicationContext _context;

    public ExpenseTypesController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/ExpenseTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseType>>> GetExpenseTypes()
    {
        return await _context.ExpenseTypes.ToListAsync();
    }

    // GET: api/ExpenseTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseType>> GetExpenseType(int id)
    {
        var expenseType = await _context.ExpenseTypes.FindAsync(id);

        if (expenseType == null) return NotFound();

        return expenseType;
    }

    // PUT: api/ExpenseTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutExpenseType(int id, ExpenseType expenseType)
    {
    }

    // POST: api/ExpenseTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ExpenseType>> PostExpenseType(ExpenseType expenseType)
    {
        return CreatedAtAction("GetExpenseType", new { id = expenseType.ExpenseTypeId }, expenseType);
    }

    // DELETE: api/ExpenseTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseType(int id)
    {
    }
}