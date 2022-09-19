using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;


    public PaymentController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentList()
    {
        return Ok("List");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeletePayment(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPayment([FromBody] PaymentDto paymentDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePayment([FromBody] PaymentDto paymentDto)
    {
        return Ok("Update");
    }
    
}
