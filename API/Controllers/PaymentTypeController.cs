using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentTypeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public PaymentTypeController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentTypeList()
    {
        return Ok("List");
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePaymentType(int id)
    {
        return Ok("DeleteExpenseHistory");
    }

    [HttpPost]
    public async Task<IActionResult> AddPaymentType([FromBody] PaymentTypeGetDto paymentDto)
    {
        return Ok("AddExpenseHistory");
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePaymentType([FromBody] PaymentTypeGetDto paymentDto)
    {
        return Ok("UpdateExpenseHistory");
    }
}