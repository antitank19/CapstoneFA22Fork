using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RentEntityController : ControllerBase
{
    private readonly IRentEntityService _rentEntityService;
    private readonly IMapper _mapper;

    public RentEntityController(IRentEntityService rentEntityService, IMapper mapper)
    {
        _rentEntityService = rentEntityService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRentEntities()
    {
        return Ok("RentEntities");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteRentEntities(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRentEntity([FromBody] RentEntityDto rentEntityDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateRentEntity([FromBody] RentEntityDto rentEntityDto)
    {
        return Ok("Update");
    }
    
}
