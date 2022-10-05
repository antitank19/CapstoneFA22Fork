using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public TransactionController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactionList()
    {
        return Ok("Transaction");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        return Ok("Delete");
    }

    [HttpPost]
    public async Task<IActionResult> AddTransaction([FromBody] BillGetDto transactionDto)
    {
        return Ok("Add");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTransaction([FromBody] BillGetDto transactionDto)
    {
        return Ok("Update");
    }
}