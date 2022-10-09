using AutoMapper;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RequestType>>> GetRequestTypes()
    {
    }

    // GET: api/RequestTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RequestType>> GetRequestType(int id)
    {
        return requestType;
    }

    // PUT: api/RequestTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRequestType(int id, RequestType requestType)
    {
        if (id != requestType.RequestTypeId) return BadRequest();
    }

    // POST: api/RequestTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<RequestType>> PostRequestType(RequestType requestType)
    {
        return CreatedAtAction("GetRequestType", new { id = requestType.RequestTypeId }, requestType);
    }

    // DELETE: api/RequestTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequestType(int id)
    {
    }
}