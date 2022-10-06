﻿using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillsController : ControllerBase
{
    private readonly ApplicationContext _context;

    public BillsController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/Bills
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
    {
        return await _context.Bills.ToListAsync();
    }

    // GET: api/Bills/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bill>> GetBill(int id)
    {
        var bill = await _context.Bills.FindAsync(id);

        if (bill == null) return NotFound();

        return bill;
    }

    // PUT: api/Bills/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBill(int id, Bill bill)
    {
        if (id != bill.BillId) return BadRequest();

        _context.Entry(bill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BillExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Bills
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Bill>> PostBill(Bill bill)
    {
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBill", new { id = bill.BillId }, bill);
    }

    // DELETE: api/Bills/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBill(int id)
    {
        var bill = await _context.Bills.FindAsync(id);
        if (bill == null) return NotFound();

        _context.Bills.Remove(bill);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BillExists(int id)
    {
        return _context.Bills.Any(e => e.BillId == id);
    }
}