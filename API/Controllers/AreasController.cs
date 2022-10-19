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
public class AreasController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public AreasController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Areas
    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> GetAreas()
    {
        var list = _serviceWrapper.Areas.GetAreaList();
        if (!list.Any())
            return NotFound("No area available");

        //return Ok(await list.GetQueryAsync(_mapper, options));
        return Ok(_mapper.Map<AreaGetDto>(list));
    }

    // GET: api/Areas/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Area>> GetArea(int id)
    {
        var entity = await _serviceWrapper.Areas.GetAreaById(id);
        if (entity == null)
            return NotFound("Area not found");
        var dto = _mapper.Map<AreaGetDto>(entity);
        return Ok(dto);
    }

    // PUT: api/Areas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutArea(int id, AreaGetDto area)
    {
        if (id != area.AreaId)
            return BadRequest("Area id mismatch");

        var updateArea = new Area
        {
            AreaId = id,
            Name = area.Name,
            Address = area.Address
        };

        var result = await _serviceWrapper.Areas.UpdateArea(updateArea);
        if (result == null)
            return NotFound("Area not found");

        return Ok("Area updated successfully");
    }

    // POST: api/Areas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Area>> PostArea(AreaCreateDto area)
    {
        var newArea = new Area
        {
            Name = area.Name,
            Address = area.Address
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
            return NotFound("Area not found");

        return Ok("Area deleted successfully");
    }
}