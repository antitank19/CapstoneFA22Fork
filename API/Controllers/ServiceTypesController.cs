using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceTypesController : ControllerBase
{
    private readonly ApplicationContext _context;

    public ServiceTypesController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/ServiceTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypes()
    {
    }

    // GET: api/ServiceTypes/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceType>> GetServiceType(int id)
    {
    }

    // PUT: api/ServiceTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutServiceType(int id, ServiceType serviceType)
    {
        if (id != serviceType.ServiceTypeId) return BadRequest();
    }

    // POST: api/ServiceTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ServiceType>> PostServiceType(ServiceType serviceType)
    {
        return CreatedAtAction("GetServiceType", new { id = serviceType.ServiceTypeId }, serviceType);
    }

    // DELETE: api/ServiceTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteServiceType(int id)
    {
    }
}