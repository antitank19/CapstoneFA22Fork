using AutoMapper;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentTypeController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public PaymentTypeController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    public PaymentTypeController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/PaymentTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentType>>> GetPaymentType()
    {
        return await _context.PaymentType.ToListAsync();
    }

    // GET: api/PaymentTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentType>> GetPaymentType(int id)
    {
        var paymentType = await _context.PaymentType.FindAsync(id);

        if (paymentType == null) return NotFound();

        return paymentType;
    }

    // PUT: api/PaymentTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPaymentType(int id, PaymentType paymentType)
    {
        if (id != paymentType.PaymentTypeId) return BadRequest();

        _context.Entry(paymentType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentTypeExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/PaymentTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PaymentType>> PostPaymentType(PaymentType paymentType)
    {
        _context.PaymentType.Add(paymentType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
    }

    // DELETE: api/PaymentTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaymentType(int id)
    {
        var paymentType = await _context.PaymentType.FindAsync(id);
        if (paymentType == null) return NotFound();

        _context.PaymentType.Remove(paymentType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaymentTypeExists(int id)
    {
        return _context.PaymentType.Any(e => e.PaymentTypeId == id);
    }
}