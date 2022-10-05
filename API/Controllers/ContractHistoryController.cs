using AutoMapper;
using Domain.EntitiesDTO.ContractHistory;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContractHistoryController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ContractHistoryController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetContractHistoryList()
    {
        return Ok("Get");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContractHistory(int id)
    {
        return Ok("DeleteExpenseHistory");
    }

    [HttpPost]
    public async Task<IActionResult> AddContractHistory([FromBody] ContractHistoryGetDto contractHistoryDto)
    {
        return Ok("AddExpenseHistory");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContractHistory([FromBody] ContractHistoryGetDto contractHistoryDto)
    {
        return Ok("UpdateExpenseHistory");
    }
}