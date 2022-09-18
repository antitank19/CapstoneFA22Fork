using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UniversityController : ControllerBase
{
    private readonly IUniversityService _universityService;
    private readonly IMapper _mapper;

    public UniversityController(IUniversityService universityService, IMapper mapper)
    {
        _universityService = universityService;
        _mapper = mapper;
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
    public async Task<IActionResult> AddBuilding([FromBody] UniversityDto universityDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUniversity([FromBody] UniversityDto universityDto)
    {
        return Ok("Update");
    }
    
}
