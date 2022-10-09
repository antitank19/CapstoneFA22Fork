using AutoMapper;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
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

    // GET: api/ServiceEntitys
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceEntity>>> GetServiceEntitys()
    {
    }

    // GET: api/ServiceEntitys/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceEntity>> GetServiceEntity(int id)
    {
        return service;
    }

    // PUT: api/ServiceEntitys/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutServiceEntity(int id, ServiceEntity service)
    {
        if (id != service.ServiceId) return BadRequest();
    }

    // POST: api/ServiceEntitys
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ServiceEntity>> PostServiceEntity(ServiceEntity service)
    {
        return CreatedAtAction("GetServiceEntity", new { id = service.ServiceId }, service);
    }

    // DELETE: api/ServiceEntitys/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteServiceEntity(int id)
    {
    }
}