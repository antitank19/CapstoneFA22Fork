using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MajorsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public MajorsController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Majors
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<Major>> GetMajors()
    {
        var result = await _serviceWrapper.Majors.GetMajorList().ToListAsync();
        if (!result.Any())
            return NotFound("No major available");

        return Ok(_mapper.Map<IEnumerable<MajorGetDto>>(result));
    }

// GET: api/Majors/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Major>> GetMajor(int id)
    {
        var result = await GetMajorById(id);
        if (result == null)
            return NotFound("No major found");

        return Ok(result.Name.ToJson());
    }

    [HttpPost]
    public async Task<IActionResult> PostMajor([FromBody] MajorCreateDto major)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var addNewMajor = new Major
        {
            Name = major.Name
        };

        var result = await _serviceWrapper.Majors.AddMajor(addNewMajor);
        if (result == null)
            return BadRequest("Major already exists");

        return CreatedAtAction("GetMajor", new { id = result.MajorId }, result.Name);
    }

    // PUT: api/Majors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMajor(int id, MajorUpdateDto major)
    {
        if (id != major.MajorId)
            return BadRequest();

        var updateMajor = new Major
        {
            Name = major.Name
        };

        var result = await _serviceWrapper.Majors.UpdateMajor(updateMajor);
        if (result == null)
            return NotFound("Updating major failed");

        return Ok($"Major updated at : {DateTime.Now.ToShortDateString()}");
    }

    // DELETE: api/Majors/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMajor(int id)
    {
        var result = await _serviceWrapper.Majors.DeleteMajor(id);
        if (!result)
            return NotFound("Deleting major failed");

        return Ok($"Major deleted at : {DateTime.Now.ToShortDateString()}");
    }

    private async Task<Major?> GetMajorById(int id)
    {
        var result = await _serviceWrapper.Majors.GetMajorById(id);
        return result ?? null;
    }
}