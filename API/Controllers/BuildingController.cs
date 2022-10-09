using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public BuildingController(IMapper mapper, IServiceWrapper serviceWrapper, ApplicationContext context)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _context = context;
    }

    // GET: api/Buildings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
    {
        return await _context.Buildings.ToListAsync();
    }

    // GET: api/Buildings/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Building>> GetBuilding(int id)
    {
        var result = await _serviceWrapper.Buildings.GetBuildingById(id);
        if (result == null)
            return NotFound("Building not found");

        return Ok(result);
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

        return Ok( new { message = "Update building successfully" });
    }

    // POST: api/Buildings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Building>> PostBuilding(BuildingCreateDto building)
    {
        var newBuilding = new Building()
        {
            BuildingName = building.BuildingName,
            ImageUrl = building.ImageUrl,
            Description = building.Description,
            CoordinateX = building.CoordinateX,
            CoordinateY = building.CoordinateY,
            TotalFloor = building.TotalFloor,
            TotalRooms = building.TotalRooms,
            ApartmentId = building.AppartmentId,
        };
        
        var result = await _serviceWrapper.Buildings.AddBuilding(newBuilding);
        if (result == null)
            return NotFound( new { message = "Create new building failed" });
        
        return CreatedAtAction("GetBuilding", new { id = building.BuildingName }, building);
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