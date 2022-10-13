using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public PaymentsController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Payments
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayments(ODataQueryOptions<PaymentGetDto>? options)
    {
        var list = _serviceWrapper.Payments.GetPaymentList();
        if (!list.Any())
            return NotFound("No payment available");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/Payments/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Payment>> GetPayment(int id, ODataQueryOptions<PaymentGetDto>? options)
    {
        var list = _serviceWrapper.Payments.GetPaymentList()
            .Where(e => e.PaymentId == id);
        if (list.IsNullOrEmpty()) return NotFound("Payment not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/Payments/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutPayment(int id, PaymentUpdateDto payment)
    {
        if (id != payment.PaymentId) return BadRequest("Id mismatch");

        var paymentTypeCheck = await _serviceWrapper.PaymentTypes.GetPaymentTypeById(payment.PaymentTypeId);
        if (paymentTypeCheck == null)
            return NotFound("Payment type not found");

        var updatePayment = new Payment
        {
            Detail = payment.Detail,
            Amount = payment.Amount,
            Status = payment.Status,
            PaymentTime = payment.PaymentTime,
            PaymentPeriod = payment.PaymentPeriod,
            CreatedTime = payment.CreatedTime,
            PaymentTypeId = payment.PaymentTypeId
        };

        var result = await _serviceWrapper.Payments.UpdatePayment(updatePayment);
        if (result == null)
            return NotFound("Payment failed to update");

        return Ok(result);
        //return Ok("Payment updated");
    }

    // POST: api/Payments
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Payment>> PostPayment(PaymentCreateDto payment)
    {
        var newPayment = new Payment
        {
            PaymentPeriod = DateTime.Now.AddMonths(1).TimeOfDay,
            PaymentTypeId = payment.PaymentTypeId,
            CreatedTime = payment.CreatedTime,
            PaymentTime = payment.PaymentTime,
            Detail = payment.Detail,
            Amount = payment.Amount,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Pending)
        };

        var result = await _serviceWrapper.Payments.AddPayment(newPayment);
        if (result == null)
            return NotFound("Payment not added");

        return CreatedAtAction("Getpayment", new { id = payment.PaymentId }, payment);
    }

    // DELETE: api/Payments/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var result = await _serviceWrapper.Payments.DeletePayment(id);

        if (!result)
            return NotFound("Payment not found");

        return Ok("Delete payment successfully");
    }
}