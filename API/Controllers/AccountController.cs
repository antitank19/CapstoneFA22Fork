using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Service.IService;
using AutoMapper.AspNet.OData;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public AccountController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/Accounts
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IQueryable<AccountGetDto>>> GetAccounts(ODataQueryOptions<AccountGetDto>? options)
    {
        IQueryable<Account> result = (await _serviceWrapper.Accounts.GetAccountList()).AsQueryable();
        if (!result.Any())
            return NotFound("No account available");

        //var response = "abc";
        //IQueryable<AccountGetDto> response;
        //if (options == null)
        //    response = _mapper.Map<IEnumerable<AccountGetDto>>(result.AsQueryable()).AsQueryable();
        //else
           var response = await (await _serviceWrapper.Accounts.GetAccountList()).AsQueryable().GetQueryAsync(_mapper, options
               //, new QuerySettings { ODataSettings = new ODataSettings { HandleNullPropagation = HandleNullPropagationOption.Default } }
               );
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AccountGetDto>> GetAccount(int id)
    {
        var result = await _serviceWrapper.Accounts.GetAccountById(id);
        if (result == null)
            return NotFound("Account not found");

        return Ok(result);
    }

    // PUT: api/Accounts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountUpdateDto account)
    {
        if (id != account.AccountId)
            return BadRequest();

        var updateAccount = new Account
        {
            Username = account.Username,
            Password = account.Password,
            Email = account.Email,
            Phone = account.Phone,
            RoleId = account.RoleId
        };

        var result = await _serviceWrapper.Accounts.UpdateAccount(updateAccount);
        if (result == null)
            return NotFound("Updating account failed");

        return Ok($"Updated at : {DateTime.Now.ToShortDateString()}");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> ToggleAccountStatus(int id, [FromBody] AccountUpdateDto account)
    {
        if (id != account.AccountId)
            return BadRequest("Id mismatch");

        var result = await _serviceWrapper.Accounts.ToggleAccountStatus(id);
        if (!result)
            return BadRequest("Updating account status failed");

        return Ok($"Status updated at : {DateTime.Now.ToShortDateString()}");
    }

    // DELETE: api/Accounts/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var result = await _serviceWrapper.Accounts.DeleteAccount(id);

        if (!result)
            return BadRequest("Account failed to delete");

        return Ok($"Account deleted at : {DateTime.Now.ToShortDateString()}");
    }
}