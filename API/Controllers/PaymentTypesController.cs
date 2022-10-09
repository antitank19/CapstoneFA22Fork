using AutoMapper;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentTypesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public PaymentTypesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }


    // GET: api/PaymentTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentType>>> GetPaymentType()
    {
    }

    // GET: api/PaymentTypes/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentType>> GetPaymentType(int id)
    {
    }

    // PUT: api/PaymentTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutPaymentType(int id, PaymentType paymentType)
    {
        if (id != paymentType.PaymentTypeId) return BadRequest();


        return NoContent();
    }

    // POST: api/PaymentTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PaymentType>> PostPaymentType(PaymentType paymentType)
    {
        return CreatedAtAction("GetPaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
    }

    // DELETE: api/PaymentTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePaymentType(int id)
    {
    }
}