using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AddressController : ControllerBase
{
    private readonly ICityService _cityService;
    private readonly IDistrictService _districtService;
    private readonly IWardService _wardService;
    private readonly IMapper _mapper;


    public AddressController(ICityService cityService, IDistrictService districtService, IWardService wardService, IMapper mapper)
    {
        _cityService = cityService;
        _districtService = districtService;
        _wardService = wardService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAddressList()
    {
        return Ok("Add");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAddress([FromBody] AddressDto addressDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAddress([FromBody] AddressDto addressDto)
    {
        return Ok("Update");
    }
    
}
