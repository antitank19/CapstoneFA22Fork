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
public class ServicesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ServicesController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/ServiceEntities
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceEntity>>> GetServiceEntities(
        ODataQueryOptions<ServiceGetDto>? options)
    {
        var list = _serviceWrapper.ServicesEntity.GetServiceEntityList();
        if (!list.Any())
            return NotFound("No service available");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/ServiceEntitys/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceEntity>> GetServiceEntity(int id, ODataQueryOptions<ServiceGetDto>? options)
    {
        var list = _serviceWrapper.ServicesEntity.GetServiceEntityList()
            .Where(e => e.ServiceTypeId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Service entities not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/ServiceEntitys/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutServiceEntity(int id, ServiceCreateDto service)
    {
        if (id != service.ServiceId)
            return BadRequest("Service id mismatch");

        var serviceTypeCheck = await _serviceWrapper.ServiceTypes.GetServiceTypeById(service.ServiceTypeId);
        if (serviceTypeCheck == null)
            return BadRequest("Service type not found");

        var updateService = new ServiceEntity
        {
            ServiceId = id,
            Name = service.Name,
            Description = service.Description,
            Status = service.Status,
            ServiceTypeId = service.ServiceTypeId
        };
        var result = await _serviceWrapper.ServicesEntity.UpdateServiceEntity(updateService);
        if (result == null)
            return NotFound("Service not found");

        return Ok("Service updated successfully");
    }

    // POST: api/ServiceEntitiess
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ServiceEntity>> PostServiceEntity(ServiceCreateDto service)
    {
        var newService = new ServiceEntity
        {
            Name = service.Name,
            Description = service.Description,
            Status = service.Status,
            ServiceTypeId = service.ServiceTypeId
        };

        var result = await _serviceWrapper.ServicesEntity.AddServiceEntity(newService);
        if (result == null)
            return NotFound("Service not found");

        return CreatedAtAction("GetServiceEntity", new { id = service.ServiceId }, service);
    }

    // DELETE: api/ServiceEntitys/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteServiceEntity(int id)
    {
        var result = await _serviceWrapper.ServicesEntity.DeleteServiceEntity(id);
        if (!result)
            return NotFound("Service not found");

        return Ok("Service deleted");
    }
}