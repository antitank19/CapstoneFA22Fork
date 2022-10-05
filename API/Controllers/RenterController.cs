using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RenterController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public RenterController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpPost]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetUserList()
    {
        return Ok("User");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id)
    {
        return Ok("DeleteExpenseHistory");
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] RenterDto renterDto)
    {
        return Ok("AddExpenseHistory");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] RenterDto renterDto)
    {
        return Ok("UpdateExpenseHistory");
    }
}