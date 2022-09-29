using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public BuildingController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBuildingList()
    {
        throw new Exception("Building");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        return Ok("DeleteBuilding");
    }

    [HttpPost]
    public async Task<IActionResult> AddBuilding([FromBody] BuildingDto buildingDto)
    {
        return Ok("AddBuilding");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBuilding([FromBody] BuildingDto buildingDto)
    {
        return Ok("UpdateBuilding");
    }
}