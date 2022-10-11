using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;
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

    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult> GetRoleList(ODataQueryOptions<RequestType>? options)
    {
        var list = await _serviceWrapper.Roles.GetRoleList().ToListAsync();
        if (!list.Any())
            return NotFound("No role available");

        //var response = _mapper.Map<IEnumerable<Role>>(result);
        return Ok(await list.AsQueryable().GetQueryAsync(_mapper, options));
    }

    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult> GetRole(int id, ODataQueryOptions<RequestType>? options)
    {
        /*
        var result = await _serviceWrapper.Roles.GetRoleById(id);
        if (result == null)
            return NotFound("No role available");

        return Ok(result);*/
        var list = (await _serviceWrapper.Roles.GetRoleList().ToListAsync())
            .Where(x => x.RoleId == id).AsQueryable();
        if (list.IsNullOrEmpty())
            return NotFound("Request type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).FirstOrDefaultAsync());
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