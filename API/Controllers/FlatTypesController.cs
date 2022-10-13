using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlatTypesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/FlatTypes
    public FlatTypesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<FlatTypeGetDto>>> GetFlatTypes(ODataQueryOptions<FlatTypeGetDto>? options)
    {
        var list = _serviceWrapper.FlatTypes.GetFlatTypeList();
        if (!list.Any())
            return NotFound();

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/FlatTypes/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<FlatTypeGetDto>> GetFlatType(int id, ODataQueryOptions<FlatTypeGetDto>? options)
    {
        var list = _serviceWrapper.FlatTypes.GetFlatTypeList()
            .Where(x => x.FlatTypeId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Request type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/FlatTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFlatType(int id, FlatTypeUpdateDto flatType)
    {
        if (id != flatType.FlatTypeId) return BadRequest();
        var updateFlatType = new FlatType
        {
            FlatTypeId = id,
            Capacity = flatType.Capacity,
            Status = flatType.Status
        };
        var result = await _serviceWrapper.FlatTypes.UpdateFlatType(updateFlatType);
        if (result == null)
            return NotFound("Flat type not found");
        return Ok("Flat type updated");
    }

    // POST: api/FlatTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<FlatType>> PostFlatType(FlatTypeCreateDto flatType)
    {
        var newFlatType = new FlatType
        {
            Capacity = flatType.Capacity,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Pending)
        };
        var result = await _serviceWrapper.FlatTypes.AddFlatType(newFlatType);
        if (result == null)
            return NotFound("Flat type not found");
        return CreatedAtAction("GetFlatType", new { id = flatType.FlatTypeId }, flatType);
    }

    // DELETE: api/FlatTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFlatType(int id)
    {
        var result = await _serviceWrapper.FlatTypes.DeleteFlatType(id);
        if (!result)
            return NotFound("FlatType not found");

        return Ok("FlatType deleted");
    }
}