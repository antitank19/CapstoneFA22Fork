using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RentEntityController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRentEntityService _rentEntityService;

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