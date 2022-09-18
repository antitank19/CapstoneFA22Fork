using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserList()
    {
        return Ok("User");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
    {
        return Ok("Update");
    }
    
}
