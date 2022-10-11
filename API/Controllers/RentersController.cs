using Microsoft.EntityFrameworkCore;
using API.Models;
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
public class RentersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public RentersController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Renters
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<Renter>> GetRenters(ODataQueryOptions<RenterGetDto>? options)
    {
        var list = _serviceWrapper.Renters.GetRenterList();
        if (!list.Any())
            return NotFound("No renter available");

        return Ok(await list.GetQueryAsync(_mapper, options));

        //var response = _mapper.Map<IEnumerable<Renter>>(result);
        //return Ok(response);
    }

    // GET: api/Renters/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Renter>> GetRenter(int id, ODataQueryOptions<RenterGetDto>? options)
    {
        var list = _serviceWrapper.Requests.GetRequestList()
            .Where(x => x.RequestTypeId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Request type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
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

        var result = await _serviceWrapper.Renters.UpdateRenter(updateRenter);
        if (result == null)
            return NotFound("Update failed");

        return Ok("Update successfully");
    }

    // POST: api/Renters
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Renter>> PostRenter(RenterCreateDto renter)
    {
        var newRenter = new Renter()
        {
            Username = renter.Username,
            Email = renter.Email,
            Password = renter.Password,
            Phone = renter.Phone,
            FullName = renter.FullName,
            BirthDate = renter.BirthDate,
            Status = true,
            Image = renter.Image,
            Address = renter.Address,
            Gender = renter.Gender,
            UniversityId = renter.UniversityId,
            MajorId = renter.MajorId
        };
        var result = await _serviceWrapper.Renters.AddRenter(newRenter);
        if (result == null)
            return NotFound("Create failed");
        return CreatedAtAction("GetRenter", renter);
    }

    // POST: api/Accounts/Login
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        var renter = await _serviceWrapper.Renters.Login(loginModel.Username, loginModel.Password);
        var jwtToken = _serviceWrapper.Tokens.CreateTokenForRenter(renter);
        return Ok(new { Token = jwtToken });
    }

    // DELETE: api/Renters/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRenter(int id)
    {
        var result = await _serviceWrapper.Renters.DeleteRenter(id);
        if (result)
            return NotFound("Renter not found");

        return Ok("Renter deleted");
    }
}