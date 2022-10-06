using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceHistoriesController : ControllerBase
{
    private readonly ApplicationContext _context;

    public InvoiceHistoriesController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/InvoiceHistories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceHistory>>> GetInvoiceHistories()
    {
        return await _context.InvoiceHistories.ToListAsync();
    }

    // GET: api/InvoiceHistories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InvoiceHistory>> GetInvoiceHistory(int id)
    {
        var invoiceHistory = await _context.InvoiceHistories.FindAsync(id);

        if (invoiceHistory == null) return NotFound();

        return invoiceHistory;
    }

    // PUT: api/InvoiceHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInvoiceHistory(int id, InvoiceHistory invoiceHistory)
    {
        if (id != invoiceHistory.InvoiceHistoryId) return BadRequest();

        _context.Entry(invoiceHistory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InvoiceHistoryExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/InvoiceHistories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<InvoiceHistory>> PostInvoiceHistory(InvoiceHistory invoiceHistory)
    {
        _context.InvoiceHistories.Add(invoiceHistory);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInvoiceHistory", new { id = invoiceHistory.InvoiceHistoryId }, invoiceHistory);
    }

    // DELETE: api/InvoiceHistories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoiceHistory(int id)
    {
        var invoiceHistory = await _context.InvoiceHistories.FindAsync(id);
        if (invoiceHistory == null) return NotFound();

        _context.InvoiceHistories.Remove(invoiceHistory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InvoiceHistoryExists(int id)
    {
        return _context.InvoiceHistories.Any(e => e.InvoiceHistoryId == id);
    }
}