using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RoomTypeController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;
    private readonly IMapper _mapper;

    public RoomTypeController(IRoomTypeService roomTypeService, IMapper mapper)
    {
        _roomTypeService = roomTypeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoomType()
    {
        return Ok("RoomType");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteRoomType(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRoomType([FromBody] RoomTypeDto roomTypeDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateRoomType([FromBody] RoomTypeDto roomTypeDto)
    {
        return Ok("Update");
    }

    
}
