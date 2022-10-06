using AutoMapper;
using Domain.EntitiesDTO.Account;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
    [HttpGet]
    public async Task<ActionResult<AccountDto>> GetAccounts()
    {
        var result = await _serviceWrapper.Accounts.GetAccountList();
        if (!result.Any())
            return NotFound("No account available");

        var response = _mapper.Map<IEnumerable<AccountDto>>(result);
        return Ok(response);
    }

    // PUT: api/Accounts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAccount(int id, [FromBody] Account account)
    {
        if (id != account.AccountId)
            return BadRequest();

        var result = await _serviceWrapper.Accounts.UpdateAccount(account);
        if (result == null)
            return NotFound("Updating account failed");

        return Ok($"Updated at : {DateTime.Now.ToShortDateString()}");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> ToggleAccountStatus(int id, [FromBody] Account account)
    {
        if (id != account.AccountId)
            return BadRequest();

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