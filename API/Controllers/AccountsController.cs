
using API.Models;
using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public AccountsController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/Accounts
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountGetDto>>> GetAccounts(ODataQueryOptions<AccountGetDto>? options)
    {
        var list = _serviceWrapper.Accounts.GetAccountList();
        if (!list.Any())
            return NotFound("No account available");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    [HttpPost("register")]
    public async Task<ActionResult<AccountGetDto>> CreateAccount(AccountCreateDto account)
    {
        var newAccount = new Account()
        {
            Username = account.Username,
            Password = account.Password,
            Email = account.Email,
            Phone = account.Phone,
            Status = true,
            RoleId = account.RoleId
        };
            var result = await _serviceWrapper.Accounts.AddAccount(newAccount);
        if (result == null)
            return NotFound("Account not created");
        return CreatedAtAction("GetAccount", new { id = result.AccountId }, result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AccountGetDto>> GetAccount(int id, ODataQueryOptions<AccountGetDto>? options)
    {
        var list = _serviceWrapper.Accounts.GetAccountList()
            .Where(e => e.AccountId == id);
        if (list.IsNullOrEmpty() || !list.Any()) 
            return NotFound("Account not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
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
            AccountId = account.AccountId,
            Username = account.Username,
            Password = account.Password,
            Email = account.Email,
            Phone = account.Phone,
            RoleId = account.RoleId
        };

        var result = await _serviceWrapper.Accounts.UpdateAccount(updateAccount);
        if (result == null)
            return NotFound("Updating account failed");

        return Ok(result);

        //return Ok($"Updated at : {DateTime.Now.ToShortDateString()}");
    }

    // POST: api/Accounts/Login
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        var renter = await _serviceWrapper.Accounts.Login(loginModel.Username, loginModel.Password);
        var jwtToken = _serviceWrapper.Tokens.CreateTokenForAccount(renter);
        return Ok(jwtToken);
    }

    [HttpPut("Toggle/{id:int}")]
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