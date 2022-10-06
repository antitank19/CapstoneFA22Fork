using AutoMapper;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public PaymentController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    public PaymentController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/Payments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
    {
        return await _context.Payments.ToListAsync();
    }

    // GET: api/Payments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Payment>> GetPayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null) return NotFound();

        return payment;
    }

    // PUT: api/Payments/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPayment(int id, Payment payment)
    {
        if (id != payment.PaymentId) return BadRequest();

        _context.Entry(payment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Payments
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Payment>> PostPayment(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPayment", new { id = payment.PaymentId }, payment);
    }

    // DELETE: api/Payments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return NotFound();

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaymentExists(int id)
    {
        return _context.Payments.Any(e => e.PaymentId == id);
    }
}