﻿using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApartmentsController : ControllerBase
{
    private readonly ApplicationContext _context;

    public ApartmentsController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/Apartments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments()
    {
        return await _context.Apartments.ToListAsync();
    }

    // GET: api/Apartments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Apartment>> GetApartment(int id)
    {
        var apartment = await _context.Apartments.FindAsync(id);

        if (apartment == null) return NotFound();

        return apartment;
    }

    // PUT: api/Apartments/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutApartment(int id, Apartment apartment)
    {
        if (id != apartment.ApartmentId) return BadRequest();

        _context.Entry(apartment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ApartmentExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Apartments
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Apartment>> PostApartment(Apartment apartment)
    {
        _context.Apartments.Add(apartment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetApartment", new { id = apartment.ApartmentId }, apartment);
    }

    // DELETE: api/Apartments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApartment(int id)
    {
        var apartment = await _context.Apartments.FindAsync(id);
        if (apartment == null) return NotFound();

        _context.Apartments.Remove(apartment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApartmentExists(int id)
    {
        return _context.Apartments.Any(e => e.ApartmentId == id);
    }
}