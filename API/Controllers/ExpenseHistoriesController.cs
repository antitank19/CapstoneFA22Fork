using AutoMapper;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseHistoriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ExpenseHistoriesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/ExpenseHistories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseHistory>>> GetExpenseHistories()
    {
    }

    // GET: api/ExpenseHistories/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ExpenseHistory>> GetExpenseHistory(int id)
    {
        return expenseHistory;
    }

    // PUT: api/ExpenseHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutExpenseHistory(int id, ExpenseHistory expenseHistory)
    {
        if (id != expenseHistory.ExpenseHistoryId) return BadRequest();
    }

    // POST: api/ExpenseHistories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ExpenseHistory>> PostExpenseHistory(ExpenseHistory expenseHistory)
    {
        return CreatedAtAction("GetExpenseHistory", new { id = expenseHistory.ExpenseHistoryId }, expenseHistory);
    }

    // DELETE: api/ExpenseHistories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseHistory(int id)
    {
        return NoContent();
    }
}