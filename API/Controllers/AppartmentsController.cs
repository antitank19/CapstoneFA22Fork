using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApartmentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ApartmentsController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/Apartments
    [HttpGet]
    public async Task<ActionResult> GetApartments()
    {
        var result = await _serviceWrapper.Apartments.GetApartmentList();
        if (!result.Any())
            return NotFound("No apartment available");

        var response = _mapper.Map<IEnumerable<Apartment>>(result);
        return Ok(response);
    }

    // GET: api/Apartments/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Apartment>> GetApartment(int id)
    {
        var result = await _serviceWrapper.Apartments.GetApartmentById(id);
        if (result == null)
            return NotFound("Apartment not found");

        return Ok(result);
    }

    // PUT: api/Apartments/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutApartment(int id, ApartmentUpdateDto apartment)
    {
        if (id != apartment.ApartmentId)
            return BadRequest();
        var updateApartment = new Apartment
        {
            Name = apartment.Name,
            AreaId = apartment.AreaId
        };
        var result = await _serviceWrapper.Apartments.UpdateApartment(updateApartment);
        if (result == null)
            return NotFound("Update apartment failed");

        return Ok("Update apartment successfully");
    }

    // POST: api/Apartments
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Apartment>> AddApartment(ApartmentUpdateDto apartment)
    {
        var newApartment = new Apartment
        {
            Name = apartment.Name,
            AreaId = apartment.AreaId
        };

        var result = await _serviceWrapper.Apartments.AddApartment(newApartment);
        if (result == null)
            return NotFound("Add apartment failed");
        return Ok("Add apartment successfully");
    }

    // DELETE: api/Apartments/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteApartment(int id)
    {
        var result = await _serviceWrapper.Apartments.DeleteApartment(id);
        if (!result)
            return NotFound("Delete apartment failed");

        return Ok("Delete apartment successfully");
    }
}