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
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService, IMapper mapper)
    {
        _transactionService = transactionService;
        _mapper = mapper;
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
    public async Task<IActionResult> AddTransaction([FromBody] TransactionDto transactionDto)
    {
        return Ok("Add");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTransaction([FromBody] TransactionDto transactionDto)
    {
        return Ok("Update");
    }
}