using API.Models;
using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
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
    public async Task<ActionResult<IQueryable<AccountGetDto>>> GetAccounts(ODataQueryOptions<AccountGetDto>? deleteMePlz)
    {
        var list = (await _serviceWrapper.Accounts.GetAccountList()).AsQueryable();
        if (!list.Any())
            return NotFound("No account available");

        //if (options == null)
        //    response = _mapper.Map<IEnumerable<AccountGetDto>>(result.AsQueryable()).AsQueryable();
        //else
        var dtos = await list.AsQueryable().GetQueryAsync(_mapper, deleteMePlz);
        return Ok(dtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AccountGetDto>> GetAccount(int id, ODataQueryOptions<AccountGetDto>? deleteMePlz)
    {
        var list = (await _serviceWrapper.Accounts.GetAccountList()).Where(e => e.AccountId == id);
        if (list.IsNullOrEmpty())
        {
            return NotFound("Account not found");
        }
        var dto = (await list.AsQueryable().GetQueryAsync(_mapper, deleteMePlz)).ToArray()[0];
        return Ok(dto);
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

        return Ok($"Updated at : {DateTime.Now.ToShortDateString()}");
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