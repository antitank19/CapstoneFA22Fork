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

    [HttpPost("management/v1/login")]
    public async Task<ActionResult> LoginManagement(LoginModel loginModel)
    {
        var account = await _serviceWrapper.Accounts
            .AccountLogin(loginModel.Username, loginModel.Password);
        
        if (account == null) 
            return Unauthorized("Username or password is wrong");
        
        var jwtToken = _serviceWrapper.Tokens.CreateTokenForAccount(account);
        return Ok(new { Token = jwtToken });
    }
    
    [HttpPost("user/v1/login")]
    public async Task<ActionResult> LoginRenter(LoginModel loginModel)
    {
        var renter = await _serviceWrapper.Renters
            .RenterLogin(loginModel.Username, loginModel.Password);
        
        if (renter == null) 
            return Unauthorized("Username or password is wrong");
        
        var jwtToken = _serviceWrapper.Tokens.CreateTokenForRenter(renter);
        return Ok(new { Token = jwtToken });
    }
    
}