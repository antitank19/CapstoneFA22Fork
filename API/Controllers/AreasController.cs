using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesDTO.Area;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AreasController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    
    public AreasController(ApplicationContext context, IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Areas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
    {
        return await _context.Areas.ToListAsync();
    }

    // GET: api/Areas/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Area>> GetArea(int id)
    {
        var area = await _context.Areas.FindAsync(id);

        if (area == null) return NotFound();

        return area;
    }

    // PUT: api/Areas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutArea(int id, AreaGetDto area)
    {
        if (id != area.AreaId) 
            return BadRequest();

        var updateArea = new Area()
        {
            AreaId = id,
            Name = area.Name,
            Address = area.Address,
        };
      
        var result = await _serviceWrapper.Areas.UpdateArea(updateArea);
        if (result == null) 
            return NotFound();
        
        return Ok("Area updated successfully");
    }

    // POST: api/Areas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Area>> PostArea(AreaCreateDto area)
    {
        var newArea = new Area()
        {
            Name = area.Name,
            Address = area.Address,
        };
        
        var result = await _serviceWrapper.Areas.AddArea(newArea);
        if (result == null) 
            return NotFound();

        return CreatedAtAction("GetArea", new { id = newArea.AreaId }, area);
    }

    // DELETE: api/Areas/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteArea(int id)
    {
        var result = await _serviceWrapper.Areas.DeleteArea(id);
        if (!result) 
            return NotFound();

        return Ok("Area deleted successfully");
    }
}