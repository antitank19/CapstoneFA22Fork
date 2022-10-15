using Domain.ControllerEntities;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

public class AuthController : ControllerBase
{
    private readonly IServiceWrapper _serviceWrapper;

    public AuthController(IServiceWrapper serviceWrapper)
    {
        _serviceWrapper = serviceWrapper;
    }

    [HttpPost("v1/login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        var login = new Account()
        {
            Username = loginModel.Username,
            Password = loginModel.Password
        };
        
        var account = await _serviceWrapper.Accounts
            .AccountLogin(login);
        
        if (account == null) 
            return Unauthorized("Username or password is wrong");
        
        var jwtToken = _serviceWrapper.Tokens.CreateTokenForAccount(account);
        return Ok(new { Token = jwtToken });
    }
}