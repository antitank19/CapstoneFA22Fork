using Application.IService;
using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PaymentTypeController : ControllerBase
{
    private readonly IPaymentTypeService _paymentTypeService;
    private readonly IMapper _mapper;


    public PaymentTypeController(IPaymentTypeService paymentTypeService, IMapper mapper)
    {
        _paymentTypeService = paymentTypeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentTypeList()
    {
        return Ok("List");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeletePaymentType(int id)
    {
        return Ok("Delete");
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPaymentType([FromBody] PaymentTypeDto paymentDto)
    {
        return Ok("Add");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePaymentType([FromBody] PaymentTypeDto paymentDto)
    {
        return Ok("Update");
    }

    
}
