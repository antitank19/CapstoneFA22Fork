using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<PaymentType>>> GetPaymentType(
        ODataQueryOptions<PaymentTypeGetDto>? options)
    {
        var list = await _serviceWrapper.PaymentTypes.GetPaymentTypeList().ToListAsync();
        if (!list.Any())
            return NotFound();

        return Ok(await list.AsQueryable().GetQueryAsync(_mapper, options));
    }

    // GET: api/PaymentTypes/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<PaymentType>> GetPaymentType(int id, ODataQueryOptions<PaymentTypeGetDto>? options)
    {
        var list = (await _serviceWrapper.PaymentTypes.GetPaymentTypeList().ToListAsync())
            .Where(x => x.PaymentTypeId == id).AsQueryable();
        if (list.IsNullOrEmpty())
            return NotFound("Payment type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).FirstOrDefaultAsync());
    }

    // PUT: api/PaymentTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutPaymentType(int id, PaymentTypeUpdateDto paymentType)
    {
        if (id != paymentType.PaymentTypeId) return BadRequest();
        var updatePaymentType = new PaymentType
        {
            PaymentTypeId = id,
            Name = paymentType.Name,
            Status = paymentType.Status
        };
        var result = await _serviceWrapper.PaymentTypes.UpdatePaymentType(updatePaymentType);
        if (result == null) return NotFound("Payment Type Not Found");
        return Ok("Payment Type Updated Successfully");
    }

    // POST: api/PaymentTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PaymentType>> PostPaymentType(PaymentTypeCreateDto paymentType)
    {
        var newPaymentType = new PaymentType
        {
            Name = paymentType.Name,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Success)
        };
        var result = await _serviceWrapper.PaymentTypes.AddPaymentType(newPaymentType);
        if (result == null) return BadRequest();
        return CreatedAtAction("GetPaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
    }

    // DELETE: api/PaymentTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePaymentType(int id)
    {
        var result = await _serviceWrapper.Payments.DeletePayment(id);
        if (!result)
            return NotFound("Payment not found");
        return Ok("Payment deleted");
    }
}