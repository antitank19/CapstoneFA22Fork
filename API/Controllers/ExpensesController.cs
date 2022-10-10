using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/Expenses
    public ExpensesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses(ODataQueryOptions<ExpenseGetDto>? options)
    {
        var list = await _serviceWrapper.Expenses.GetExpenseList().ToListAsync();
        if (!list.Any())
            return NotFound();

        return Ok(await list.AsQueryable().GetQueryAsync(_mapper, options));
    }

    // GET: api/Expenses/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Expense>> GetExpense(int id, ODataQueryOptions<ExpenseGetDto>? options)
    {
        var list = (await _serviceWrapper.Expenses.GetExpenseList().ToListAsync())
            .Where(x => x.ExpenseId == id).AsQueryable();
        if (list.IsNullOrEmpty())
            return NotFound("Expense not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).FirstOrDefaultAsync());
    }

    // PUT: api/Expenses/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutExpense(int id, ExpenseUpdateDto expense)
    {
        if (id != expense.ExpenseId) return BadRequest();
        var updateExpense = new Expense
        {
            ExpenseId = id,
            Name = expense.Name,
            SupervisorId = expense.SupervisorId,
            ExpenseTypeId = expense.ExpenseTypeId
        };
        var result1 = await _serviceWrapper.Expenses.UpdateExpense(updateExpense);
        if (result1 == null) 
            return NotFound("Expense not found");
        var addNewExpenseHistory = new ExpenseHistory
        {
            Name = updateExpense.Name,
            Date = DateTime.Today,
            ExpenseId = updateExpense.ExpenseId
        };
        var result2 = await _serviceWrapper.ExpenseHistories.AddExpenseHistory(addNewExpenseHistory);
        if (result2 == null) 
            return NotFound("Expense History not added");
        return Ok("Expense updated successfully");
    }

    // POST: api/Expenses
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Expense>> PostExpense(ExpenseCreateDto expense)
    {
        var newExpense = new Expense
        {
            SupervisorId = expense.SupervisorId,
            Name = expense.Name,
            ExpenseTypeId = expense.ExpenseTypeId
        };
        var result = await _serviceWrapper.Expenses.AddExpense(newExpense);
        if (result == null)
            return NotFound("Expense not found");
        return CreatedAtAction("GetExpense", new { id = expense.ExpenseId }, expense);
    }

    // DELETE: api/Expenses/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var result = await _serviceWrapper.Expenses.DeleteExpense(id);
        if (!result)
            return NotFound("Expense not found");
        return Ok("Expense deleted");
    }
}