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
public class RequestTypesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public RequestTypesController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/RequestTypes
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IQueryable<RequestTypeGetDto>>> GetRequestTypes(ODataQueryOptions<RequestTypeGetDto>? options)
    {
        var list = _serviceWrapper.RequestTypes.GetRequestTypeList();
        if (!list.Any())
            return NotFound();

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/RequestTypes/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<RequestTypeGetDto>> GetRequestType(int id, ODataQueryOptions<RequestTypeGetDto>? options)
    {
        var list = _serviceWrapper.RequestTypes.GetRequestTypeList()
            .Where(x => x.RequestTypeId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Request type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/RequestTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutRequestType(int id, RequestTypeCreateDto requestType)
    {
        if (id != requestType.RequestTypeId) return BadRequest();
        var updateRequestType = new RequestType
        {
            Description = requestType.Description,
            Name = requestType.Name,
            Status = true
        };
        var result = await _serviceWrapper.RequestTypes.UpdateRequestType(updateRequestType);
        if (result == null)
            return NotFound("Request type not found");

        return Ok("Request type updated successfully");
    }

    // POST: api/RequestTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<RequestType>> PostRequestType(RequestTypeCreateDto requestType)
    {
        var newRequestType = new RequestType
        {
            Description = requestType.Description,
            Name = requestType.Name,
            Status = true
        };
        var result = await _serviceWrapper.RequestTypes.AddRequestType(newRequestType);
        if (result == null)
            return NotFound("Request type not found");
        return CreatedAtAction("GetRequestType", new { id = requestType.RequestTypeId }, requestType);
    }

    // DELETE: api/RequestTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRequestType(int id)
    {
        var result = await _serviceWrapper.RequestTypes.DeleteRequestType(id);
        if (!result)
            return NotFound("Request type not found");

        return Ok("Request type deleted");
    }
}