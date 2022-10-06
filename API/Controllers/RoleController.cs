using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public RoleController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<ActionResult/*<IEnumerable<Role>>*/> GetRoleList()
    {
        IEnumerable<Role> list =(await _serviceWrapper.Roles.GetRoleList()).AsQueryable();
        return Ok("Ok");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole(int id)
    {
        return Ok("DeleteExpenseHistory");
    }

    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] RoleGetDto roleDto)
    {
        return Ok("AddExpenseHistory");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] RoleGetDto roleDto)
    {
        return Ok("UpdateExpenseHistory");
    }
}