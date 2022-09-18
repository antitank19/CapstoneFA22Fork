using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;
    
    public RoomController(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoomList()
    {
        return Ok("Room");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRoom([FromBody] RoomDto roomDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateRoom([FromBody] RoomDto roomDto)
    {
        return Ok("Update");
    }
    
}
