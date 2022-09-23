using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly IBuildingService _buildingService;
    private readonly IMapper _mapper;

    public BuildingController(IBuildingService buildingService, IMapper mapper)
    {
        _buildingService = buildingService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBuildingList()
    {
        return Ok("Building");
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