using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public UniversityController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUniversityList()
    {
        return Ok("University");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        return Ok("Delete");
    }

    [HttpPost]
    public async Task<IActionResult> AddBuilding([FromBody] UniversityGetDto universityDto)
    {
        return Ok("Add");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUniversity([FromBody] UniversityGetDto universityDto)
    {
        return Ok("Update");
    }
}