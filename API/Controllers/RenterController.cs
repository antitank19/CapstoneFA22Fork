using API.Models;
using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RenterController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper services;

    public RenterController(IMapper mapper, IServiceWrapper serviceWrapper, ApplicationContext context)
    {
        _mapper = mapper;
        services = serviceWrapper;
        _context = context;
    }

    // GET: api/Renters
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Renter>>> GetRenters()
    {
        return await _context.Renters.ToListAsync();
    }

    // GET: api/Renters/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Renter>> GetRenter(int id)
    {
        var renter = await _context.Renters.FindAsync(id);

        if (renter == null) return NotFound();

        return renter;
    }

    // PUT: api/Renters/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRenter(int id, Renter renter)
    {
        if (id != renter.RenterId) return BadRequest();

        _context.Entry(renter).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RenterExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Renters
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Renter>> PostRenter(RenterCreateDto renterDto)
    {
        var renter = _mapper.Map<Renter>(renterDto);
        services.Renters.AddRenter(renter);

        return CreatedAtAction("GetRenter", new { id = renterDto.RenterId }, renterDto);
    }
    // POST: api/Accounts/Login
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        Renter renter = await services.Renters.Login(loginModel.Username, loginModel.Password);
        if (renter == null)
        {
            return Unauthorized("Failed to login");
        }
        string jwtToken = services.Tokens.CreateTokenForRenter(renter);
        return Ok(jwtToken);
    }

    // DELETE: api/Renters/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRenter(int id)
    {
        var renter = await _context.Renters.FindAsync(id);
        if (renter == null) return NotFound();

        _context.Renters.Remove(renter);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RenterExists(int id)
    {
        return _context.Renters.Any(e => e.RenterId == id);
    }
}