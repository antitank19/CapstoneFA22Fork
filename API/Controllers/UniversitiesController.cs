using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public UniversitiesController(IMapper mapper, IServiceWrapper serviceWrapper, ApplicationContext context)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }


    // GET: api/Universities
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<University>>> GetUniversity(ODataQueryOptions<RequestType>? options)
    {
        var list = await _serviceWrapper.Universities.GetUniversityList().ToListAsync();
        if (!list.Any())
            return NotFound("No university available");

        return Ok(await list.AsQueryable().GetQueryAsync(_mapper, options));
    }

    // GET: api/Universities/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<University>> GetUniversity(int id, ODataQueryOptions<RequestType>? options)
    {
        var list = (await _serviceWrapper.Universities.GetUniversityList().ToListAsync())
            .Where(x => x.UniversityId == id).AsQueryable();
        if (list.IsNullOrEmpty())
            return NotFound("Request type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).FirstOrDefaultAsync());
    }

    // PUT: api/Universities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutUniversity(int id, UniversityUpdateDto university)
    {
        if (id != university.UniversityId) return BadRequest();
        var updateUniversity = new University()
        {
            UniversityId = id,
            UniversityName = university.UniversityName,
            Description = university.Description,
            Image = university.Image,
            Address = university.Address,
            Status = university.Status,
        };
        var result = await _serviceWrapper.Universities.UpdateUniversity(updateUniversity);
        if (result == null)
            return NotFound("University not found");
        return Ok("University updated successfully");
    }

    // POST: api/Universities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<University>> PostUniversity(UniversityCreateDto university)
    {
        var addNewUniversity = new University()
        {
            UniversityName = university.UniversityName,
            Description = university.Description,
            Image = university.Image,
            Address = university.Address,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Success) ?? Enum.GetName(typeof(StatusEnum), StatusEnum.Pending)
        };
        var result = await _serviceWrapper.Universities.AddUniversity(addNewUniversity);
        if (result == null)
            return NotFound("University failed to add");
        return CreatedAtAction("GetUniversity", university);
    }

    // DELETE: api/Universities/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        var result = await _serviceWrapper.Universities.DeleteUniversity(id);
        if (result)
            return NotFound("University not found");
        
        return Ok("University deleted");
    }
}