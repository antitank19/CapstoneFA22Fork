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
public class BuildingsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public BuildingsController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Buildings
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IQueryable<BuildingGetDto>>> GetBuildings(ODataQueryOptions<BuildingGetDto>? options)
    {
        var list = _serviceWrapper.Buildings.GetBuildingList();
        if (!list.Any())
            return NotFound("No builings available");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/Buildings/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BuildingGetDto>> GetBuilding(int id, ODataQueryOptions<BuildingGetDto>? options)
    {
        var list = _serviceWrapper.Buildings.GetBuildingList()
            .Where(e => e.BuildingId == id);
        if (list.IsNullOrEmpty()) return NotFound("Building not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/Buildings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBuilding(int id, BuildingUpdateDto building)
    {
        if (id != building.BuildingId)
            return BadRequest();

        var updateBuilding = new Building
        {
            BuildingId = id,
            BuildingName = building.BuildingName,
            Description = building.Description,
            CoordinateX = building.CoordinateX,
            CoordinateY = building.CoordinateY,
            ImageUrl = building.ImageUrl,
            TotalFloor = building.TotalFloor,
            TotalRooms = building.TotalRooms
        };

        var result = await _serviceWrapper.Buildings.UpdateBuilding(updateBuilding);

        if (result == null)
            return NotFound();

        return Ok(new { message = "Update building successfully" });
    }

    // POST: api/Buildings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Building>> PostBuilding(BuildingCreateDto building)
    {
        var newBuilding = new Building
        {
            BuildingName = building.BuildingName,
            ImageUrl = building.ImageUrl,
            Description = building.Description,
            CoordinateX = building.CoordinateX,
            CoordinateY = building.CoordinateY,
            TotalFloor = building.TotalFloor,
            TotalRooms = building.TotalRooms,
            ApartmentId = building.ApartmentId
        };

        var result = await _serviceWrapper.Buildings.AddBuilding(newBuilding);
        if (result == null)
            return NotFound(new { message = "Create new building failed" });

        return CreatedAtAction("GetBuilding", new { id = building.BuildingId }, building);
    }

    // DELETE: api/Buildings/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        var result = await _serviceWrapper.Buildings.DeleteBuilding(id);

        if (!result)
            return NotFound("Building not found");

        return Ok("Delete building successfully");
    }
}