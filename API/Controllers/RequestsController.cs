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
public class RequestsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;


    // GET: api/Requests
    public RequestsController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<ActionResult<IQueryable<RequestGetDto>>> GetRequests(
        ODataQueryOptions<RequestTypeGetDto>? options)
    {
        var list = _serviceWrapper.Requests.GetRequestList();
        if (!list.Any())
            return NotFound();

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/Requests/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<RequestGetDto>> GetRequest(int id, ODataQueryOptions<RequestTypeGetDto>? options)
    {
        var list = _serviceWrapper.Requests.GetRequestList()
            .Where(x => x.RequestTypeId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Request type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/Requests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutRequest(int id, RequestCreateDto request)
    {
        if (id != request.RequestId)
            return BadRequest("Request id is not valid");

        var requestTypeCheck = await RequestTypeCheck(request.RequestTypeId);
        if (requestTypeCheck == null)
            return NotFound("Request type not found");

        var updateRequest = new Request
        {
            RequestId = id,
            RequestTypeId = request.RequestTypeId,
            Description = request.Description,
            CreateDate = request.CreateDate,
            SolveDate = request.SolveDate
        };
        var result = await _serviceWrapper.Requests.UpdateRequest(updateRequest);
        if (result == null)
            return NotFound("Request not found");
        return Ok("Request updated");
    }

    // POST: api/Requests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Request>> PostRequest(RequestCreateDto request)
    {
        var requestTypeCheck = await RequestTypeCheck(request.RequestTypeId);
        if (requestTypeCheck == null)
            return NotFound("Request type not found");

        var newRequest = new Request
        {
            Description = request.Description,
            CreateDate = request.CreateDate,
            SolveDate = request.SolveDate,
            RequestTypeId = request.RequestTypeId
        };
        var result = await _serviceWrapper.Requests.AddRequest(newRequest);
        if (result == null) return BadRequest();
        return CreatedAtAction("GetRequest", new { id = request.RequestId }, request);
    }

    // DELETE: api/Requests/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
        var result = await _serviceWrapper.Requests.DeleteRequest(id);
        if (!result)
            return NotFound("Request not found");
        return Ok("Request deleted");
    }

    private async Task<RequestType?> RequestTypeCheck(int id)
    {
        return await _serviceWrapper.RequestTypes.GetRequestTypeById(id) ?? null;
    }
}