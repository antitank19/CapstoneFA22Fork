using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ContractController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetContractList()
    {
        return Ok("Get");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContract(int id)
    {
        return Ok("DeleteExpenseHistory");
    }

    [HttpPost]
    public async Task<IActionResult> AddContract([FromBody] ContractGetDto contractDto)
    {
        return Ok("AddExpenseHistory");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContract([FromBody] ContractGetDto contractDto)
    {
        return Ok("UpdateExpenseHistory");
    }
}