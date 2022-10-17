using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;
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
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IQueryable<ExpenseHistoryGetDto>>> GetExpenseHistories(
        ODataQueryOptions<ExpenseHistoryGetDto>? options)
    {
        var list = _serviceWrapper.ExpenseHistories.GetExpenseHistoryList();
        if (!list.Any())
            return NotFound("Expense history not found");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/ExpenseHistories/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ExpenseHistory>> GetExpenseHistory(int id,
        ODataQueryOptions<ExpenseHistoryGetDto>? options)
    {
        var list = _serviceWrapper.ExpenseHistories.GetExpenseHistoryList()
            .Where(x => x.ExpenseHistoryId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Expense history not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/ExpenseHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutExpenseHistory(int id, ExpenseHistoryCreateDto expenseHistory)
    {
        if (id != expenseHistory.ExpenseHistoryId)
            return BadRequest("Expense history not found");

        var expenseCheck = await _serviceWrapper.Expenses.GetExpenseById(id);
        if (expenseCheck == null)
            return NotFound("Expense type not found");

        var updateExpenseHistory = new ExpenseHistory
        {
            ExpenseHistoryId = id,
            ExpenseId = expenseHistory.ExpenseId,
            Name = expenseHistory.Name,
            Date = expenseHistory.Date
        };
        var result = await _serviceWrapper.ExpenseHistories.UpdateExpenseHistory(updateExpenseHistory);
        if (result == null)
            return NotFound("Expense history not found");
        return Ok("Expense history updated");
    }

    // POST: api/ExpenseHistories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ExpenseHistory>> PostExpenseHistory(ExpenseHistoryUpdateDto expenseHistory)
    {
        var newExpenseHistory = new ExpenseHistory
        {
            Name = expenseHistory.Name,
            Date = expenseHistory.Date
        };
        var result = await _serviceWrapper.ExpenseHistories.AddExpenseHistory(newExpenseHistory);
        if (result == null)
            return BadRequest("Expense history not added");

        return CreatedAtAction("GetExpenseHistory", new { id = expenseHistory.ExpenseHistoryId }, expenseHistory);
    }

    // DELETE: api/ExpenseHistories/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteExpenseHistory(int id)
    {
        var result = await _serviceWrapper.ExpenseHistories.DeleteExpenseHistory(id);
        if (!result)
            return NotFound("Expense History not found");

        return Ok("Expense History deleted");
    }
}