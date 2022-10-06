//<<<<<<< Updated upstream
using AutoMapper;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
//=======
using API.Models;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using Domain.EntitiesDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper services;

    public AccountController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        services = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/Accounts
    [HttpGet]
    public async Task<ActionResult<AccountGetDto>> GetAccounts()
    {
        var result = await services.Accounts.GetAccountList();
        if (!result.Any())
            return NotFound("No account available");

        var response = _mapper.Map<IEnumerable<AccountGetDto>>(result);
        return Ok(response);
    }

    // PUT: api/Accounts/5t
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountUpdateDto accountDto)
    {
        if (id != accountDto.AccountId)
            return BadRequest();
        var account=_mapper.Map<Account>(accountDto);

        var result = await services.Accounts.UpdateAccount(account);
        if (result == null)
            return NotFound("Updating account failed");

        return Ok($"Updated at : {DateTime.Now.ToShortDateString()}");
    }
    [HttpPost]
    public async Task<ActionResult<Apartment>> PostAccount(AccountCreateDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        services.Accounts.AddAccount(account);

        return CreatedAtAction("GetAccount", new { id = accountDto.AccountId }, accountDto);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> ToggleAccountStatus(int id, [FromBody] Account account)
    {
        if (id != account.AccountId)
            return BadRequest();

        var result = await services.Accounts.ToggleAccountStatus(id);
        if (!result)
            return BadRequest("Updating account status failed");

        //<<<<<<< Updated upstream
        return Ok($"Status updated at : {DateTime.Now.ToShortDateString()}");
    }
    // POST: api/Accounts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        Account account = await services.Accounts.Login(loginModel.Username, loginModel.Password);
        if (account == null)
        {
            return Unauthorized("Failed to login");
        }
        string jwtToken = services.Tokens.CreateTokenForEmployee(account);
        return Ok(jwtToken);
    }

    // DELETE: api/Accounts/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var result = await services.Accounts.DeleteAccount(id);

        if (!result)
            return BadRequest("Account failed to delete");

        return Ok($"Account deleted at : {DateTime.Now.ToShortDateString()}");
    }
}