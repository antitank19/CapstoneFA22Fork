using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public RolesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetRoleList()
    {
        var result = await _serviceWrapper.Roles.GetRoleList();
        if (!result.Any())
            return NotFound("No role available");

        var response = _mapper.Map<IEnumerable<Role>>(result);

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetRole(int id)
    {
        var result = await _serviceWrapper.Roles.GetRoleById(id);
        if (result == null)
            return NotFound("No role available");

        return Ok(result);
    }

    /*
    [HttpDelete]
    public async Task<IActionResult> DeleteRole(int id)
    {
        
    }

    
    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] RoleGetDto role)
    {
        
    }
    */

    [HttpPut]
    public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleUpdateDto role)
    {
        if (id != role.RoleId)
            return BadRequest("Id mismatch");

        var updateRole = new Role
        {
            RoleName = role.RoleName
        };

        var result = await _serviceWrapper.Roles.UpdateRole(updateRole);
        if (result == null)
            return NotFound("Updating role failed");

        return Ok("Role updated successfully");
    }
}