using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceTypesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/ServiceTypes
    public ServiceTypesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypes(
        ODataQueryOptions<ServiceTypeGetDto>? options)
    {
        var list = _serviceWrapper.ServiceTypes.GetServiceTypeList();
        if (!list.Any())
            return NotFound();

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/ServiceTypes/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<ServiceType>> GetServiceType(int id, ODataQueryOptions<ServiceTypeGetDto>? options)
    {
        var list = _serviceWrapper.ServiceTypes.GetServiceTypeList()
            .Where(x => x.ServiceTypeId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Service type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/ServiceTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutServiceType(int id, ServiceTypeCreateDto serviceType)
    {
        if (id != serviceType.ServiceTypeId) 
            return BadRequest("Service type id mismatch");

        var updateServiceType = new ServiceType
        {
            ServiceTypeId = id,
            Name = serviceType.Name,
            Status = serviceType.Status
        };
        var result = await _serviceWrapper.ServiceTypes.UpdateServiceType(updateServiceType);
        if (result == null)
            return NotFound("Service type not found");

        return Ok("Service type updated");
    }

    // POST: api/ServiceTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ServiceType>> PostServiceType(ServiceTypeCreateDto serviceType)
    {
        var addNewServiceType = new ServiceType
        {
            Name = serviceType.Name,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Success)
        };

        var result = await _serviceWrapper.ServiceTypes.AddServiceType(addNewServiceType);
        if (result == null)
            return BadRequest("Service type failed to add");

        return CreatedAtAction("GetServiceType", new { id = serviceType.ServiceTypeId }, serviceType);
    }

    // DELETE: api/ServiceTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteServiceType(int id)
    {
        var result = await _serviceWrapper.ServiceTypes.DeleteServiceType(id);
        if (!result)
            return NotFound("Service type not found");

        return Ok("Service type deleted");
    }
}