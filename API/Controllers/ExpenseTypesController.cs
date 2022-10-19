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
public class ExpenseTypesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/ExpenseTypes
    public ExpenseTypesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> GetExpenseTypes(/*ODataQueryOptions<ExpenseTypeGetDto>? options*/)
    {
        var list = _serviceWrapper.ExpenseTypes.GetExpenseTypeList();
        if (!list.Any())
            return NotFound("No expense type available");

        //return Ok(await list.GetQueryAsync(_mapper, options));
        return Ok(_mapper.Map<List<ExpenseTypeGetDto>>(list));
    }

    // GET: api/ExpenseTypes/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetExpenseType(int id/*, ODataQueryOptions<ExpenseTypeGetDto>? options*/)
    {
        //var list = _serviceWrapper.ExpenseTypes.GetExpenseTypeList()
        //    .Where(x => x.ExpenseTypeId == id);
        //if (list.IsNullOrEmpty())
        //    return NotFound("No expense type not found");
        //return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
        var entity = await _serviceWrapper.Expenses.GetExpenseById(id);
        if (entity == null)
            return NotFound("Expense type not found");
        var dto = _mapper.Map<ExpenseTypeGetDto>(entity);
        return Ok(dto);
    }

    // PUT: api/ExpenseTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutExpenseType(int id, ExpenseTypeUpdateDto expenseType)
    {
        if (id != expenseType.ExpenseTypeId) return BadRequest();
        var updateExpenseType = new ExpenseType
        {
            ExpenseTypeId = id,
            Name = expenseType.Name,
            Price = expenseType.Price,
            Status = expenseType.Status
        };
        var result = await _serviceWrapper.ExpenseTypes.UpdateExpenseType(updateExpenseType);
        if (result == null)
            return NotFound("No expense type not found");
        return Ok("Expense type updated successfully");
    }

    // POST: api/ExpenseTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ExpenseType>> PostExpenseType(ExpenseTypeGetDto expenseType)
    {
        var newExpenseType = new ExpenseType
        {
            Name = expenseType.Name,
            Price = expenseType.Price,
            Status = expenseType.Status
        };
        var result = await _serviceWrapper.ExpenseTypes.AddExpenseType(newExpenseType);
        if (result == null)
            return NotFound("No expense type not found");

        return CreatedAtAction("GetExpenseType", expenseType);
    }

    // DELETE: api/ExpenseTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteExpenseType(int id)
    {
        var result = await _serviceWrapper.ExpenseTypes.DeleteExpenseType(id);
        if (!result)
            return NotFound("Expense type not found");

        return Ok("Expense type deleted");
    }
}