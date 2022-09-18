using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly IMapper _mapper;

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

    [HttpDelete] public async Task<IActionResult> DeleteTransaction(int id)
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
