using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlatsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/Flats
    public FlatsController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<Flat>>> GetFlats(ODataQueryOptions<FlatGetDto>? options)
    {
        var list = _serviceWrapper.Flats.GetFlatList();
        if (!list.Any())
            return NotFound();

        return Ok(await list.AsQueryable().GetQueryAsync(_mapper, options));
    }

    // GET: api/Flats/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Flat>> GetFlat(int id, ODataQueryOptions<FlatGetDto>? options)
    {
        var list = _serviceWrapper.Flats.GetFlatList()
            .Where(x => x.FlatId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Request type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/Flats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFlat(int id, Flat flat)
    {
        if (id != flat.FlatId) return BadRequest();

        var updateFlat = new Flat
        {
            FlatId = id,
            Description = flat.Description,
            Name = flat.Name,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Pending),
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };
        var result = await _serviceWrapper.Flats.UpdateFlat(updateFlat);
        if (result == null)
            return NotFound("Flat not found");

        return Ok("Flat updated");
    }

    // POST: api/Flats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Flat>> PostFlat(FlatCreateDto flat)
    {
        var newFlat = new Flat
        {
            Description = flat.Description,
            Name = flat.Name,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Pending),
            FlatTypeId = flat.FlatTypeId,
            BuildingId = flat.BuildingId
        };
        var result = await _serviceWrapper.Flats.AddFlat(newFlat);
        if (result == null)
            return NotFound("Flat not found");
        return CreatedAtAction("GetFlat", new { id = flat.FlatId }, flat);
    }

    // DELETE: api/Flats/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFlat(int id)
    {
        var result = await _serviceWrapper.Flats.DeleteFlat(id);
        if (!result)
            return NotFound("Flat not found");
        return Ok("Flat deleted");
    }
}