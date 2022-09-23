using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;
    private readonly IMapper _mapper;


    public ContractController(IContractService contractService, IMapper mapper)
    {
        _contractService = contractService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetContractList()
    {
        return Ok("Get");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContract(int id)
    {
        return Ok("Delete");
    }

    [HttpPost]
    public async Task<IActionResult> AddContract([FromBody] ContractDto contractDto)
    {
        return Ok("Add");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContract([FromBody] ContractDto contractDto)
    {
        return Ok("Update");
    }
}