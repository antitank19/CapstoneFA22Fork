using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApartmentGetDto>>> GetApartments(
        ODataQueryOptions<ApartmentGetDto>? options)
    {
        var list = await _serviceWrapper.Apartments.GetApartmentList().ToListAsync();
        if (!list.Any())
            return NotFound("No apartment available");

        var dtos = await list.AsQueryable().GetQueryAsync(_mapper, options);
        return Ok(dtos);
    }

    // GET: api/Apartments/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Apartment>> GetApartment(int id, ODataQueryOptions<AccountGetDto>? options)
    {
        var list = (await _serviceWrapper.Apartments.GetApartmentList().ToListAsync())
            .Where(e => e.ApartmentId == id).AsQueryable();
        if (list.IsNullOrEmpty()) 
            return NotFound("Apartment not found");
        var dto = (await list.AsQueryable().GetQueryAsync(_mapper, options)).ToArray()[0];
        return Ok(dto);
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
            ApartmentId = id,
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
    public async Task<ActionResult<Apartment>> AddApartment(ApartmentCreateDto apartment)
    {
        var newApartment = new Apartment
        {
            Name = apartment.Name,
            AreaId = apartment.AreaId
        };

        var result = await _serviceWrapper.Apartments.AddApartment(newApartment);
        if (result == null)
            return NotFound("Add apartment failed");

        return CreatedAtAction("GetApartment", new { id = newApartment.ApartmentId }, apartment);
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