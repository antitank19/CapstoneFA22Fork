using API.Models;
using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper services;

    public RentersController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        services = serviceWrapper;
    }

    // GET: api/Renters
    [HttpGet]
    public async Task<ActionResult<RenterGetDto>> GetRenters()
    {
        var result = await services.Renters.GetRenterList();
        if (!result.Any())
            return NotFound("No renter available");

        var response = _mapper.Map<IEnumerable<Renter>>(result);
        return Ok(response);
    }

    // GET: api/Renters/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Renter>> GetRenter(int id)
    {
        var result = await services.Renters.GetRenterById(id);
        if (result == null)
            return NotFound("No renter found");

        return Ok(result);
    }

    // PUT: api/Renters/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutRenter(int id, Renter renter)
    {
        if (id != renter.RenterId)
            return BadRequest();

        var updateRenter = new Renter
        {
            Username = renter.Username,
            Email = renter.Email,
            Password = renter.Password,
            Phone = renter.Phone,
            FullName = renter.FullName,
            BirthDate = renter.BirthDate,
            Gender = renter.Gender,
            Image = renter.Image,
            Address = renter.Address,
            University = new University
            {
                UniversityName = renter.University.UniversityName
            },
            Major = new Major
            {
                Name = renter.Major.Name
            }
        };

        var result = await services.Renters.UpdateRenter(updateRenter);
        if (result == null)
            return NotFound("Update failed");

        return Ok("Update successfully");
    }

    // POST: api/Renters
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Renter>> PostRenter(RenterCreateDto renterDto)
    {
        var renter = _mapper.Map<Renter>(renterDto);
        await services.Renters.AddRenter(renter);

        return CreatedAtAction("GetRenter", renterDto);
    }

    // POST: api/Accounts/Login
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        var renter = await services.Renters.Login(loginModel.Username, loginModel.Password);
        var jwtToken = services.Tokens.CreateTokenForRenter(renter);
        return Ok(jwtToken);
    }

    // DELETE: api/Renters/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRenter(int id)
    {
        var result = await services.Renters.DeleteRenter(id);
        if (result)
            return NotFound("Renter not found");

        return Ok("Renter deleted");
    }
}