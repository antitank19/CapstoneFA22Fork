using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
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
    public async Task<IActionResult> GetRoleList()
    {
        return Ok("Role");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole(int id)
    {
        return Ok("Delete");
    }

    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] RoleGetDto roleDto)
    {
        return Ok("Add");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] RoleGetDto roleDto)
    {
        return Ok("Update");
    }
}