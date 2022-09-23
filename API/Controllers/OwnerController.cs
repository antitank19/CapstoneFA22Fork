using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService, IMapper mapper)
    {
        _ownerService = ownerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetOwnerList()
    {
        return Ok("Owner");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOwner(int id)
    {
        return Ok("DeleteBuilding");
    }

    [HttpPost]
    public async Task<IActionResult> AddOwner([FromBody] OwnerDto ownerDto)
    {
        return Ok("Add");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBuilding([FromBody] OwnerDto ownerDto)
    {
        return Ok("Update");
    }
}