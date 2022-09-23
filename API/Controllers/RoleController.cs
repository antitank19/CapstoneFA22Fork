using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly RoleService _roleService;


    public RoleController(RoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
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
    public async Task<IActionResult> AddRole([FromBody] RoleDto roleDto)
    {
        return Ok("Add");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] RoleDto roleDto)
    {
        return Ok("Update");
    }
}