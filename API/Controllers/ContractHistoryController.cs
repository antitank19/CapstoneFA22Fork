using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContractHistoryController : ControllerBase
{
    private readonly IContractHistoryService _contractService;
    private readonly IMapper _mapper;

    public ContractHistoryController(IContractHistoryService contractService, IMapper mapper)
    {
        _contractService = contractService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetContractHistoryList()
    {
        return Ok("Get");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteContractHistory(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddContractHistory([FromBody] ContractHistoryDto contractHistoryDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateContractHistory([FromBody] ContractHistoryDto contractHistoryDto)
    {
        return Ok("Update");
    }
    
}